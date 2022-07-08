using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using UnityEngine;

namespace Area51.Module.Safety.Avatar
{
	internal class MunchenAntiCrash
	{
		public static string[] BlackListedShaders = File.ReadAllLines("Area51/BlackList/Avatar/Shader.txt");

		public static int maxAudio = 150;

		public static int maxLight = 8;

		public static int maxMaterials = 300;

		public static int maxMesh = 250;

		public static int maxDynamicBonesCollider = 50;

		public static int maxDynamicBones = 75;

		public static int maxPoly = 2500000;

		public static int maxCloth = 75;

		public static int maxClothVertices = 15000;

		public static int maxColliders = 20;

		public static int maxParticleLimit = 10000;

		public static int maxParticleMeshVertices = 1000000;

		public static int maxParticleTrails = 64;

		public static int maxParticleCollisonShapes = 1024;

		public static int maxParticleEmissionRate = 500;

		public static int maxParticleSystems = 1;

		public static int maxAnimators = 25;

		public static int maxRegidBodies = 25;

		public static Shader defaultShader;

		internal static void ProcessRenderer(Renderer renderer, bool limitPolygons, bool limitMaterials, bool limitShaders, ref AntiCrashRendererPostProcess previousProcess)
		{
			if (limitPolygons)
			{
				ProcessMeshPolygons(renderer, ref previousProcess.nukedMeshes, ref previousProcess.polygonCount);
			}
			if (limitMaterials)
			{
				AntiCrashMaterialPostProcess antiCrashMaterialPostProcess = ProcessMaterials(renderer, previousProcess.nukedMaterials, previousProcess.materialCount);
				previousProcess.nukedMaterials = antiCrashMaterialPostProcess.nukedMaterials;
				previousProcess.materialCount = antiCrashMaterialPostProcess.materialCount;
			}
			if (limitShaders)
			{
				AntiCrashShaderPostProcess antiCrashShaderPostProcess = ProcessShaders(renderer, previousProcess.nukedShaders, previousProcess.shaderCount);
				previousProcess.nukedShaders = antiCrashShaderPostProcess.nukedShaders;
				previousProcess.shaderCount = antiCrashShaderPostProcess.shaderCount;
			}
		}

		internal static void ProcessMeshPolygons(Renderer renderer, ref int currentNukedMeshes, ref int currentPolygonCount)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = renderer.TryCast<SkinnedMeshRenderer>();
			MeshFilter component = renderer.GetComponent<MeshFilter>();
			Mesh mesh = skinnedMeshRenderer?.sharedMesh ?? component?.sharedMesh;
			if (mesh == null)
			{
				return;
			}
			if (!mesh.isReadable)
			{
				currentNukedMeshes++;
				UnityEngine.Object.DestroyImmediate(mesh, allowDestroyingAssets: true);
				return;
			}
			if (mesh.name.ToLower().Equals("body"))
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				for (int i = 0; i < mesh.blendShapeCount; i++)
				{
					string text = mesh.GetBlendShapeName(i).ToLower();
					if (text.Contains("reverted"))
					{
						flag = true;
					}
					if (text.Contains("posetorest"))
					{
						flag2 = true;
					}
					else if (text.Contains("key 22"))
					{
						flag3 = true;
					}
					else if (text.Contains("key 56"))
					{
						flag4 = true;
					}
					else if (text.Contains("slant"))
					{
						flag5 = true;
					}
				}
				if (flag && flag2 && flag3 && flag4 && flag5)
				{
					mesh.ClearBlendShapes();
				}
			}
			ProcessMesh(mesh, ref currentNukedMeshes, ref currentPolygonCount);
		}

		internal static AntiCrashMaterialPostProcess ProcessMaterials(Renderer renderer, int currentNukedMaterials, int currentMaterialCount)
		{
			int num = currentMaterialCount + renderer.GetMaterialCount();
			if (num > maxMaterials)
			{
				Il2CppSystem.Collections.Generic.List<Material> list = new Il2CppSystem.Collections.Generic.List<Material>();
				renderer.GetSharedMaterials(list);
				int num2 = ((currentMaterialCount < maxMaterials) ? maxMaterials : 0);
				int num3 = ((num2 == 0) ? list.Count : (num - maxMaterials));
				if (num2 > list.Count)
				{
					num2 = list.Count;
				}
				int num4 = list.Count - num2;
				if (num3 > num4)
				{
					num3 = num4;
				}
				currentNukedMaterials += num3;
				num -= num3;
				list.RemoveRange(num2, num3);
				renderer.materials = (Il2CppReferenceArray<Material>)list.ToArray();
			}
			currentMaterialCount = num;
			return new AntiCrashMaterialPostProcess
			{
				nukedMaterials = currentNukedMaterials,
				materialCount = currentMaterialCount
			};
		}

		internal static AntiCrashShaderPostProcess ProcessShaders(Renderer renderer, int currentNukedShaders, int currentShaderCount)
		{
			for (int i = 0; i < renderer.materials.Length; i++)
			{
				if (renderer.materials[i] == null)
				{
					continue;
				}
				currentShaderCount++;
				if (BlackListedShaders.Contains(renderer.materials[i].shader.name.ToLower()))
				{
					renderer.materials[i].shader = defaultShader;
					currentNukedShaders++;
					continue;
				}
				if (!renderer.materials[i].shader.isSupported)
				{
					renderer.materials[i].shader = defaultShader;
					currentNukedShaders++;
					continue;
				}
				string name = renderer.materials[i].shader.name;
				if (!(name == "Standard"))
				{
					if (name == "Diffuse")
					{
						renderer.materials[i].shader = defaultShader;
					}
				}
				else
				{
					renderer.materials[i].shader = defaultShader;
				}
			}
			return new AntiCrashShaderPostProcess
			{
				nukedShaders = currentNukedShaders,
				shaderCount = currentShaderCount
			};
		}

		internal static AntiCrashClothPostProcess ProcessCloth(Cloth cloth, int nukedCloths, int currentVertexCount)
		{
			cloth.clothSolverFrequency = Mathf.Max(cloth.clothSolverFrequency, 300f);
			Mesh mesh = cloth.GetComponent<SkinnedMeshRenderer>()?.sharedMesh;
			if (mesh == null)
			{
				nukedCloths++;
				UnityEngine.Object.DestroyImmediate(cloth, allowDestroyingAssets: true);
				return new AntiCrashClothPostProcess
				{
					nukedCloths = nukedCloths,
					currentVertexCount = currentVertexCount
				};
			}
			currentVertexCount += mesh.vertexCount;
			if (currentVertexCount >= maxClothVertices)
			{
				currentVertexCount -= mesh.vertexCount;
				nukedCloths++;
				UnityEngine.Object.DestroyImmediate(cloth, allowDestroyingAssets: true);
			}
			return new AntiCrashClothPostProcess
			{
				nukedCloths = nukedCloths,
				currentVertexCount = currentVertexCount
			};
		}

		internal static void ProcessParticleSystem(ParticleSystem particleSystem, ref AntiCrashParticleSystemPostProcess post)
		{
			ParticleSystemRenderer component = particleSystem.GetComponent<ParticleSystemRenderer>();
			if (component == null)
			{
				post.nukedParticleSystems++;
				UnityEngine.Object.DestroyImmediate(particleSystem, allowDestroyingAssets: true);
				return;
			}
			particleSystem.main.simulationSpeed = Clamp(particleSystem.main.simulationSpeed, 0f, 5f);
			particleSystem.collision.maxCollisionShapes = Clamp(particleSystem.collision.maxCollisionShapes, 0, maxParticleCollisonShapes);
			particleSystem.trails.ribbonCount = Clamp(particleSystem.trails.ribbonCount, 0, maxParticleTrails);
			for (int i = 0; i < particleSystem.emission.burstCount; i++)
			{
				ParticleSystem.Burst burst = particleSystem.emission.GetBurst(i);
				burst.maxCount = Clamp(burst.maxCount, (short)0, (short)125);
				burst.cycleCount = Clamp(burst.cycleCount, 0, 125);
			}
			int num = maxParticleLimit - post.currentParticleCount;
			if (particleSystem.maxParticles > num)
			{
				particleSystem.maxParticles = num;
			}
			post.currentParticleCount += particleSystem.maxParticles;
			if (component.renderMode == ParticleSystemRenderMode.Mesh)
			{
				Il2CppReferenceArray<Mesh> il2CppReferenceArray = new Il2CppReferenceArray<Mesh>(component.meshCount);
				component.GetMeshes(il2CppReferenceArray);
				int currentPolygonCount = 0;
				int currentNukedMeshes = 0;
				foreach (Mesh item in il2CppReferenceArray)
				{
					ProcessMesh(item, ref currentNukedMeshes, ref currentPolygonCount);
				}
				if (currentPolygonCount * particleSystem.maxParticles > maxParticleMeshVertices)
				{
					particleSystem.maxParticles = maxParticleMeshVertices / currentPolygonCount;
				}
			}
			if (particleSystem.maxParticles == 0)
			{
				post.nukedParticleSystems++;
				UnityEngine.Object.DestroyImmediate(component, allowDestroyingAssets: true);
				UnityEngine.Object.DestroyImmediate(particleSystem, allowDestroyingAssets: true);
			}
		}

		internal static void ProcessMesh(Mesh mesh, ref int currentNukedMeshes, ref int currentPolygonCount)
		{
			int num;
			try
			{
				num = mesh.subMeshCount;
			}
			catch (Exception)
			{
				num = 1;
			}
			for (int i = 0; i < num; i++)
			{
				try
				{
					uint num2 = mesh.GetIndexCount(i);
					switch (mesh.GetTopology(i))
					{
					case MeshTopology.Triangles:
						num2 /= 3u;
						break;
					case MeshTopology.Quads:
						num2 /= 4u;
						break;
					case MeshTopology.Lines:
						num2 /= 2u;
						break;
					}
					if (currentPolygonCount + num2 > maxPoly)
					{
						currentNukedMeshes++;
						UnityEngine.Object.DestroyImmediate(mesh, allowDestroyingAssets: true);
					}
					else
					{
						currentPolygonCount += (int)num2;
					}
				}
				catch (Exception)
				{
				}
			}
			if (!(mesh == null))
			{
				if (IsBeyondLimit(mesh.bounds.extents, -100f, 100f))
				{
					UnityEngine.Object.DestroyImmediate(mesh, allowDestroyingAssets: true);
				}
				else if (IsBeyondLimit(mesh.bounds.size, -100f, 100f))
				{
					UnityEngine.Object.DestroyImmediate(mesh, allowDestroyingAssets: true);
				}
				else if (IsBeyondLimit(mesh.bounds.center, -100f, 100f))
				{
					UnityEngine.Object.DestroyImmediate(mesh, allowDestroyingAssets: true);
				}
				else if (IsBeyondLimit(mesh.bounds.min, -100f, 100f))
				{
					UnityEngine.Object.DestroyImmediate(mesh, allowDestroyingAssets: true);
				}
				else if (IsBeyondLimit(mesh.bounds.max, -100f, 100f))
				{
					UnityEngine.Object.DestroyImmediate(mesh, allowDestroyingAssets: true);
				}
			}
		}

		internal static AntiCrashDynamicBonePostProcess ProcessDynamicBone(DynamicBone dynamicBone, int currentNukedDynamicBones, int currentDynamicBones)
		{
			if (currentDynamicBones >= maxDynamicBones)
			{
				currentNukedDynamicBones++;
				UnityEngine.Object.DestroyImmediate(dynamicBone, allowDestroyingAssets: true);
				return new AntiCrashDynamicBonePostProcess
				{
					nukedDynamicBones = currentNukedDynamicBones,
					dynamicBoneCount = currentDynamicBones
				};
			}
			currentDynamicBones++;
			dynamicBone.m_UpdateRate = Clamp(dynamicBone.m_UpdateRate, 0f, 60f);
			dynamicBone.m_Radius = Clamp(dynamicBone.m_Radius, 0f, 2f);
			dynamicBone.m_EndLength = Clamp(dynamicBone.m_EndLength, 0f, 10f);
			dynamicBone.m_DistanceToObject = Clamp(dynamicBone.m_DistanceToObject, 0f, 1f);
			Vector3 endOffset = dynamicBone.m_EndOffset;
			endOffset.x = Clamp(endOffset.x, -5f, 5f);
			endOffset.y = Clamp(endOffset.y, -5f, 5f);
			endOffset.z = Clamp(endOffset.z, -5f, 5f);
			dynamicBone.m_EndOffset = endOffset;
			Vector3 gravity = dynamicBone.m_Gravity;
			gravity.x = Clamp(gravity.x, -5f, 5f);
			gravity.y = Clamp(gravity.y, -5f, 5f);
			gravity.z = Clamp(gravity.z, -5f, 5f);
			dynamicBone.m_Gravity = gravity;
			Vector3 force = dynamicBone.m_Force;
			force.x = Clamp(force.x, -5f, 5f);
			force.y = Clamp(force.y, -5f, 5f);
			force.z = Clamp(force.z, -5f, 5f);
			dynamicBone.m_Force = force;
			Il2CppSystem.Collections.Generic.List<DynamicBoneCollider> list = new Il2CppSystem.Collections.Generic.List<DynamicBoneCollider>();
			foreach (DynamicBoneCollider item in dynamicBone.m_Colliders.ToArray())
			{
				if (item != null && !list.Contains(item))
				{
					list.Add(item);
				}
			}
			dynamicBone.m_Colliders = list;
			return new AntiCrashDynamicBonePostProcess
			{
				nukedDynamicBones = currentNukedDynamicBones,
				dynamicBoneCount = currentDynamicBones
			};
		}

		internal static AntiCrashDynamicBoneColliderPostProcess ProcessDynamicBoneCollider(DynamicBoneCollider dynamicBoneCollider, int currentNukedDynamicBoneColliders, int currentDynamicBoneColliders)
		{
			if (currentDynamicBoneColliders >= maxDynamicBonesCollider)
			{
				currentNukedDynamicBoneColliders++;
				UnityEngine.Object.DestroyImmediate(dynamicBoneCollider, allowDestroyingAssets: true);
				return new AntiCrashDynamicBoneColliderPostProcess
				{
					nukedDynamicBoneColliders = currentNukedDynamicBoneColliders,
					dynamicBoneColiderCount = currentDynamicBoneColliders
				};
			}
			currentDynamicBoneColliders++;
			dynamicBoneCollider.m_Radius = Clamp(dynamicBoneCollider.m_Radius, 0f, 50f);
			dynamicBoneCollider.m_Height = Clamp(dynamicBoneCollider.m_Height, 0f, 50f);
			Vector3 center = dynamicBoneCollider.m_Center;
			Clamp(center.x, -50f, 50f);
			Clamp(center.y, -50f, 50f);
			Clamp(center.z, -50f, 50f);
			dynamicBoneCollider.m_Center = center;
			return new AntiCrashDynamicBoneColliderPostProcess
			{
				nukedDynamicBoneColliders = currentNukedDynamicBoneColliders,
				dynamicBoneColiderCount = currentDynamicBoneColliders
			};
		}

		internal static AntiCrashLightSourcePostProcess ProcessLight(Light light, int currentNukedLights, int currentLights)
		{
			if (currentLights >= maxLight)
			{
				currentNukedLights++;
				UnityEngine.Object.DestroyImmediate(light, allowDestroyingAssets: true);
				return new AntiCrashLightSourcePostProcess
				{
					nukedLightSources = currentNukedLights,
					lightSourceCount = currentLights
				};
			}
			currentLights++;
			return new AntiCrashLightSourcePostProcess
			{
				nukedLightSources = currentNukedLights,
				lightSourceCount = currentLights
			};
		}

		internal static int ProcessTransform(Transform transform, int limitedTransforms)
		{
			bool flag = false;
			Quaternion quaternion = transform.localRotation;
			if (IsInvalid(quaternion))
			{
				quaternion = Quaternion.identity;
				flag = true;
			}
			else
			{
				quaternion.x = Clamp(quaternion.x, 3f, 3f);
				quaternion.y = Clamp(quaternion.y, 3f, 3f);
				quaternion.z = Clamp(quaternion.z, 3f, 3f);
				quaternion.w = Clamp(quaternion.w, 3f, 3f);
				if (quaternion != transform.localRotation)
				{
					flag = true;
				}
			}
			transform.localRotation = quaternion;
			Vector3 vector = transform.localScale;
			if (IsInvalid(vector))
			{
				vector = new Vector3(1f, 1f, 1f);
				flag = true;
			}
			else
			{
				vector.x = Clamp(vector.x, 3f, 3f);
				vector.y = Clamp(vector.y, 3f, 3f);
				vector.z = Clamp(vector.z, 3f, 3f);
				if (vector != transform.localScale)
				{
					flag = true;
				}
			}
			transform.localScale = vector;
			if (!flag)
			{
				return limitedTransforms;
			}
			return ++limitedTransforms;
		}

		internal static void ProcessRigidbody(Rigidbody rigidbody)
		{
			rigidbody.mass = Clamp(rigidbody.mass, -10000f, 10000f);
			rigidbody.maxAngularVelocity = Clamp(rigidbody.maxAngularVelocity, -100f, 100f);
			rigidbody.maxDepenetrationVelocity = Clamp(rigidbody.maxDepenetrationVelocity, -100f, 100f);
		}

		internal static bool ProcessCollider(Collider collider)
		{
			if ((collider.bounds.center.x < 100f && collider.bounds.center.x > 100f) || (collider.bounds.center.y < 100f && collider.bounds.center.y > 100f) || (collider.bounds.center.z < 100f && collider.bounds.center.z > 100f) || (collider.bounds.extents.x < 100f && collider.bounds.extents.x > 100f) || (collider.bounds.extents.y < 100f && collider.bounds.extents.y > 100f) || (collider.bounds.extents.z < 100f && collider.bounds.extents.z > 100f))
			{
				UnityEngine.Object.DestroyImmediate(collider, allowDestroyingAssets: true);
				return true;
			}
			if (collider is BoxCollider boxCollider)
			{
				Vector3 center = boxCollider.center;
				center.x = Clamp(center.x, -100f, 100f);
				center.y = Clamp(center.y, -100f, 100f);
				center.y = Clamp(center.y, -100f, 100f);
				boxCollider.center = center;
				Vector3 extents = boxCollider.extents;
				extents.x = Clamp(extents.x, -100f, 100f);
				extents.y = Clamp(extents.y, -100f, 100f);
				extents.y = Clamp(extents.y, -100f, 100f);
				boxCollider.extents = extents;
				Vector3 size = boxCollider.size;
				size.x = Clamp(size.x, -100f, 100f);
				size.y = Clamp(size.y, -100f, 100f);
				size.y = Clamp(size.y, -100f, 100f);
				boxCollider.size = size;
			}
			else if (collider is CapsuleCollider capsuleCollider)
			{
				capsuleCollider.radius = Clamp(capsuleCollider.radius, -25f, 25f);
				capsuleCollider.height = Clamp(capsuleCollider.height, -25f, 25f);
				Vector3 center2 = capsuleCollider.center;
				center2.x = Clamp(center2.x, -100f, 100f);
				center2.y = Clamp(center2.y, -100f, 100f);
				center2.y = Clamp(center2.y, -100f, 100f);
				capsuleCollider.center = center2;
			}
			else if (collider is SphereCollider sphereCollider)
			{
				sphereCollider.radius = Clamp(sphereCollider.radius, -25f, 25f);
				Vector3 center3 = sphereCollider.center;
				center3.x = Clamp(center3.x, -100f, 100f);
				center3.y = Clamp(center3.y, -100f, 100f);
				center3.y = Clamp(center3.y, -100f, 100f);
				sphereCollider.center = center3;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int Clamp(int value, int min, int max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static short Clamp(short value, short min, short max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static byte Clamp(byte value, byte min, byte max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double Clamp(double value, double min, double max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsBeyondLimit(Vector3 vector, float lowerLimit, float higherLimit)
		{
			if (vector.x < lowerLimit || vector.x > higherLimit)
			{
				return true;
			}
			if (vector.y < lowerLimit || vector.y > higherLimit)
			{
				return true;
			}
			if (vector.z < lowerLimit || vector.z > higherLimit)
			{
				return true;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsInvalid(Vector3 vector)
		{
			if (!float.IsNaN(vector.x) && !float.IsInfinity(vector.x) && !float.IsNaN(vector.y) && !float.IsInfinity(vector.y) && !float.IsNaN(vector.z))
			{
				return float.IsInfinity(vector.z);
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool IsInvalid(Quaternion quaternion)
		{
			if (!float.IsNaN(quaternion.x) && !float.IsInfinity(quaternion.x) && !float.IsNaN(quaternion.y) && !float.IsInfinity(quaternion.y) && !float.IsNaN(quaternion.z) && !float.IsInfinity(quaternion.z) && !float.IsNaN(quaternion.w))
			{
				return float.IsInfinity(quaternion.w);
			}
			return true;
		}

		internal static System.Collections.Generic.List<T> FindAllComponentsInGameObject<T>(GameObject gameObject, bool includeInactive = true, bool searchParent = true, bool searchChildren = true) where T : class
		{
			System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();
			foreach (T component in gameObject.GetComponents<T>())
			{
				list.Add(component);
			}
			if (searchParent)
			{
				foreach (T item in gameObject.GetComponentsInParent<T>(includeInactive))
				{
					list.Add(item);
				}
			}
			if (searchChildren)
			{
				foreach (T componentsInChild in gameObject.GetComponentsInChildren<T>(includeInactive))
				{
					list.Add(componentsInChild);
				}
				return list;
			}
			return list;
		}
	}
}

using System.IO;
using Area51.Events;
using Area51.SDK;
using UnityEngine;

namespace Area51.Module.Safety
{
	internal class AntiAviCrash : BaseModule, OnAssetBundleLoadEvent
	{
		private string[] blacklistShaders;

		private string[] blacklistMesh;

		private int maxAudio;

		private int maxLight;

		private int maxDynamicBonesCollider;

		private int maxPoly;

		private int maxMatirial;

		private int maxCloth;

		private int maxColliders;

		private int maxParticles;

		private int maxParticleSystems;

		private int maxAnimators;

		private int ParticleLimiter;

		private Shader defaultShader;

		public AntiAviCrash()
			: base("Anti All", "Remove Crashers from Avatars", Main.Instance.Avatarbutton, null, isToggle: true)
		{
			defaultShader = Shader.Find("VRChat/PC/Toon Lit Cutout");
			blacklistShaders = File.ReadAllLines("Area51/BlackList/Avatar/Shader.txt");
			blacklistMesh = File.ReadAllLines("Area51/BlackList/Avatar/Mesh.txt");
		}

		public override void OnEnable()
		{
			Main.Instance.OnAssetBundleLoadEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnAssetBundleLoadEvents.Remove(this);
		}

		public bool OnAvatarAssetBundleLoad(GameObject avatar, string avatarID)
		{
			SkinnedMeshRenderer[] array = avatar.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			MeshFilter[] array2 = avatar.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				bool flag = false;
				if (!skinnedMeshRenderer.sharedMesh.isReadable)
				{
					Object.DestroyImmediate(skinnedMeshRenderer, allowDestroyingAssets: true);
					LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted unreadable Mesh");
					LogHandler.LogDebug("[Anti AviCrash] Deleted Unreadable Mesh ");
					continue;
				}
				for (int j = 0; j < blacklistMesh.Length; j++)
				{
					if (skinnedMeshRenderer.name.ToLower().Contains(blacklistMesh[j]))
					{
						LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted blackListed Mesh " + skinnedMeshRenderer.name);
						LogHandler.LogDebug("[Anti AviCrash] Deleted BlackListed Mesh ");
						Object.DestroyImmediate(skinnedMeshRenderer, allowDestroyingAssets: true);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				int num = 0;
				for (int k = 0; k < skinnedMeshRenderer.sharedMesh.subMeshCount; k++)
				{
					num += skinnedMeshRenderer.sharedMesh.GetTriangles(k).Length / 3;
					if (num >= maxPoly)
					{
						Object.DestroyImmediate(skinnedMeshRenderer, allowDestroyingAssets: true);
						LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted Mesh with too many polys");
						LogHandler.LogDebug("[Anti AviCrash] Deleted Mesh With Too Many Polys ");
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				Material[] array3 = skinnedMeshRenderer.materials;
				if (array3.Length >= maxMatirial)
				{
					Object.DestroyImmediate(skinnedMeshRenderer, allowDestroyingAssets: true);
					LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted Mesh with " + array3.Length + " materials");
					LogHandler.LogDebug($"[Anti AviCrash] Deleted Mesh With {array3.Length} Materials ");
					continue;
				}
				for (int l = 0; l < array3.Length; l++)
				{
					Shader shader = array3[l].shader;
					for (int m = 0; m < blacklistShaders.Length; m++)
					{
						if (shader.name.ToLower().Contains(blacklistShaders[m]))
						{
							LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] replaced Shader " + shader.name);
							LogHandler.LogDebug("[Anti AviCrash] Replaced Shader " + shader.name + " ");
							shader = defaultShader;
						}
					}
				}
			}
			foreach (MeshFilter meshFilter in array2)
			{
				if (!meshFilter.sharedMesh.isReadable)
				{
					Object.DestroyImmediate(meshFilter, allowDestroyingAssets: true);
					LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted unreadable Mesh");
					LogHandler.LogDebug("[Anti AviCrash] Deleted Unreadable Mesh ");
					continue;
				}
				bool flag2 = false;
				for (int num2 = 0; num2 < blacklistMesh.Length; num2++)
				{
					if (meshFilter.name.ToLower().Contains(blacklistMesh[num2]))
					{
						LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted blackListed Mesh " + meshFilter.name);
						LogHandler.LogDebug("[Anti AviCrash] Deleted BlackListed Mesh " + meshFilter.name + " ");
						Object.DestroyImmediate(meshFilter, allowDestroyingAssets: true);
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
				int num3 = 0;
				for (int num4 = 0; num4 < meshFilter.sharedMesh.subMeshCount; num4++)
				{
					num3 += meshFilter.sharedMesh.GetTriangles(num4).Length / 3;
					if (num3 >= maxPoly)
					{
						Object.DestroyImmediate(meshFilter, allowDestroyingAssets: true);
						LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted Mesh with too many polys");
						LogHandler.LogDebug("[Anti AviCrash] Deleted Mesh With Too Many Polys ");
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					continue;
				}
				MeshRenderer component = meshFilter.gameObject.GetComponent<MeshRenderer>();
				Material[] array4 = component.materials;
				if (array4.Length >= maxMatirial)
				{
					Object.DestroyImmediate(meshFilter, allowDestroyingAssets: true);
					LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted Mesh with " + array4.Length + " materials");
					LogHandler.LogDebug($"[Anti AviCrash] Deleted Mesh With {array4.Length} Materials");
					continue;
				}
				for (int num5 = 0; num5 < array4.Length; num5++)
				{
					Shader shader2 = array4[num5].shader;
					for (int num6 = 0; num6 < blacklistShaders.Length; num6++)
					{
						if (shader2.name.ToLower().Contains(blacklistShaders[num6]))
						{
							LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] replaced Shader " + shader2.name);
							LogHandler.LogDebug("[Anti AviCrash] Replaced Shader " + shader2.name + " ");
							shader2 = defaultShader;
						}
					}
				}
			}
			ParticleSystem component2 = avatar.GetComponent<ParticleSystem>();
			ParticleLimiter++;
			if ((bool)component2 && ParticleLimiter > maxParticleSystems)
			{
				Object.DestroyImmediate(component2.gameObject, allowDestroyingAssets: true);
				LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + ParticleLimiter + " ParticleSystems");
				LogHandler.LogDebug($"[Anti AviCrash] Deleted {ParticleLimiter} ParticleSystems ");
			}
			if (component2.maxParticles <= maxParticles)
			{
				for (int num7 = 0; num7 < maxParticles; num7++)
				{
					Object.DestroyImmediate(component2.gameObject, allowDestroyingAssets: true);
				}
				LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + maxParticles + " Particles");
				LogHandler.LogDebug($"[Anti AviCrash] Deleted {maxParticles} Particles ");
			}
			AudioSource[] array5 = avatar.GetComponentsInChildren<AudioSource>();
			if (array5.Length >= maxAudio)
			{
				for (int num8 = 0; num8 < maxAudio; num8++)
				{
					Object.DestroyImmediate(array5[num8].gameObject, allowDestroyingAssets: true);
				}
				LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + maxAudio + " AudioSources");
				LogHandler.LogDebug($"[Anti AviCrash] Deleted {maxAudio} AudioSources ");
			}
			Light[] array6 = avatar.GetComponentsInChildren<Light>();
			if (array6.Length >= maxLight)
			{
				for (int num9 = 0; num9 < maxLight; num9++)
				{
					Object.DestroyImmediate(array6[num9].gameObject, allowDestroyingAssets: true);
				}
				LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + maxLight + " Lights");
				LogHandler.LogDebug($"[Anti AviCrash] Deleted {maxLight} Lights ");
			}
			Cloth[] array7 = avatar.GetComponentsInChildren<Cloth>();
			if (array7.Length >= maxCloth)
			{
				for (int num10 = 0; num10 < maxCloth; num10++)
				{
					Object.DestroyImmediate(array7[num10].gameObject, allowDestroyingAssets: true);
				}
				LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + maxCloth + " Cloth");
				LogHandler.LogDebug($"[Anti AviCrash] Deleted {maxCloth} Cloth ");
			}
			Animator[] array8 = avatar.GetComponentsInChildren<Animator>();
			if (array8.Length >= maxAnimators)
			{
				for (int num11 = 0; num11 < maxAnimators; num11++)
				{
					Object.DestroyImmediate(array8[num11].gameObject, allowDestroyingAssets: true);
				}
				LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + maxAnimators + " Lights");
				LogHandler.LogDebug($"[Anti AviCrash] Deleted {maxAnimators} Lights ");
			}
			Collider[] array9 = avatar.GetComponentsInChildren<Collider>();
			if (array9.Length >= maxColliders)
			{
				for (int num12 = 0; num12 < maxColliders; num12++)
				{
					Object.DestroyImmediate(array9[num12].gameObject, allowDestroyingAssets: true);
				}
				LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + maxColliders + " Colliders");
				LogHandler.LogDebug($"[Anti AviCrash] Deleted {maxColliders} Colliders");
			}
			DynamicBoneCollider[] array10 = avatar.GetComponentsInChildren<DynamicBoneCollider>();
			if (array10.Length >= maxDynamicBonesCollider)
			{
				for (int num13 = 0; num13 < maxDynamicBonesCollider; num13++)
				{
					Object.DestroyImmediate(array10[num13].gameObject, allowDestroyingAssets: true);
				}
				LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + maxDynamicBonesCollider + " DynamicBoneColliders");
				LogHandler.LogDebug($"[Anti AviCrash] Deleted {maxDynamicBonesCollider} DynamicBoneColliders");
			}
			return true;
		}
	}
}

using System;
using System.Collections.Generic;
using Area51.Events;
using Area51.SDK;
using Area51.SDK.PatchAPI.Patches;
using UnityEngine;

namespace Area51.Module.Safety.Avatar
{
	internal class AntiBones : BaseModule, OnObjectInstantiatedEvent
	{
		public AntiBones()
			: base("Anti DynamicBones", "Limit DynamicBones Recources", Main.Instance.Avatarbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnObjectInstantiatedEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnObjectInstantiatedEvents.Remove(this);
		}

		public bool OnObjectInstantiatedPatch(IntPtr assetPtr, Vector3 pos, Quaternion rot, byte allowCustomShaders, byte isUI, byte validate, IntPtr nativeMethodPointer, _AssetManagement.ObjectInstantiateDelegate originalInstantiateDelegate)
		{
			GameObject gameObject = new UnityEngine.Object(assetPtr).TryCast<GameObject>();
			bool flag = gameObject.name.StartsWith("prefab");
			IntPtr intPtr = originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);
			GameObject gameObject2 = new GameObject(intPtr);
			Animator[] array = gameObject.GetComponentsInChildren<Animator>(gameObject2);
			if (flag)
			{
				int num = gameObject.name.IndexOf('_') + 1;
				int num2 = gameObject.name.LastIndexOf('_');
				string text = gameObject.name.Substring(num, num2 - num);
				List<DynamicBoneCollider> list = MunchenAntiCrash.FindAllComponentsInGameObject<DynamicBoneCollider>(gameObject2);
				AntiCrashDynamicBoneColliderPostProcess antiCrashDynamicBoneColliderPostProcess = new AntiCrashDynamicBoneColliderPostProcess();
				for (int i = 0; i < list.Count; i++)
				{
					if (!(list[i] == null))
					{
						antiCrashDynamicBoneColliderPostProcess = MunchenAntiCrash.ProcessDynamicBoneCollider(list[i], antiCrashDynamicBoneColliderPostProcess.nukedDynamicBoneColliders, antiCrashDynamicBoneColliderPostProcess.dynamicBoneColiderCount);
					}
				}
				List<DynamicBone> list2 = MunchenAntiCrash.FindAllComponentsInGameObject<DynamicBone>(gameObject2);
				AntiCrashDynamicBonePostProcess antiCrashDynamicBonePostProcess = new AntiCrashDynamicBonePostProcess();
				for (int j = 0; j < list2.Count; j++)
				{
					if (!(list2[j] == null))
					{
						antiCrashDynamicBonePostProcess = MunchenAntiCrash.ProcessDynamicBone(list2[j], antiCrashDynamicBonePostProcess.nukedDynamicBones, antiCrashDynamicBonePostProcess.dynamicBoneCount);
					}
				}
				if (antiCrashDynamicBonePostProcess.nukedDynamicBones > 0)
				{
					LogHandler.Log(LogHandler.Colors.Green, $"[AntiCrash] Removed {antiCrashDynamicBonePostProcess.nukedDynamicBones} Bad DynamicBones");
					LogHandler.LogDebug($"[Anti AviCrash] Removed {antiCrashDynamicBonePostProcess.nukedDynamicBones} Bad DynamicBones");
				}
				if (antiCrashDynamicBoneColliderPostProcess.nukedDynamicBoneColliders > 0)
				{
					LogHandler.Log(LogHandler.Colors.Green, $"[AntiCrash] Removed {antiCrashDynamicBoneColliderPostProcess.nukedDynamicBoneColliders} Bad DynamicBoneColliders");
					LogHandler.LogDebug($"[Anti AviCrash] Removed {antiCrashDynamicBoneColliderPostProcess.nukedDynamicBoneColliders} Bad DynamicBoneColliders");
				}
			}
			return true;
		}
	}
}

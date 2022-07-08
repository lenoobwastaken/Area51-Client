using System;
using System.Collections.Generic;
using Area51.Events;
using Area51.SDK;
using Area51.SDK.PatchAPI.Patches;
using UnityEngine;

namespace Area51.Module.Safety.Avatar
{
	internal class AntiCloth : BaseModule, OnObjectInstantiatedEvent
	{
		public AntiCloth()
			: base("Anti Cloth", "Limit Cloth Recources", Main.Instance.Avatarbutton, null, isToggle: true)
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
				List<Cloth> list = MunchenAntiCrash.FindAllComponentsInGameObject<Cloth>(gameObject2);
				AntiCrashClothPostProcess antiCrashClothPostProcess = new AntiCrashClothPostProcess();
				for (int i = 0; i < list.Count; i++)
				{
					if (!(list[i] == null))
					{
						antiCrashClothPostProcess = MunchenAntiCrash.ProcessCloth(list[i], antiCrashClothPostProcess.nukedCloths, antiCrashClothPostProcess.currentVertexCount);
					}
				}
				if (antiCrashClothPostProcess.nukedCloths > 0)
				{
					LogHandler.Log(LogHandler.Colors.Green, $"[AntiCrash] Removed {antiCrashClothPostProcess.nukedCloths} Bad Cloth");
					LogHandler.LogDebug($"[Anti AviCrash] Removed {antiCrashClothPostProcess.nukedCloths} Bad Cloth");
				}
			}
			return true;
		}
	}
}

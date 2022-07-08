using System;
using System.Collections.Generic;
using Area51.Events;
using Area51.SDK;
using Area51.SDK.PatchAPI.Patches;
using UnityEngine;

namespace Area51.Module.Safety.Avatar
{
	internal class AntiMatirials : BaseModule, OnObjectInstantiatedEvent
	{
		public AntiMatirials()
			: base("Anti Materials", "Limit Material Recources", Main.Instance.Avatarbutton, null, isToggle: true)
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
				List<Renderer> list = MunchenAntiCrash.FindAllComponentsInGameObject<Renderer>(gameObject2);
				AntiCrashRendererPostProcess previousProcess = new AntiCrashRendererPostProcess();
				for (int i = 0; i < list.Count; i++)
				{
					if (!(list[i] == null))
					{
						MunchenAntiCrash.ProcessRenderer(list[i], limitPolygons: false, limitMaterials: true, limitShaders: false, ref previousProcess);
					}
				}
				if (previousProcess.nukedMaterials > 0)
				{
					LogHandler.Log(LogHandler.Colors.Green, $"[AntiCrash] Removed {previousProcess.nukedMaterials} Bad Materials");
					LogHandler.LogDebug($"[Anti AviCrash] Removed {previousProcess.nukedMaterials} Bad Materials");
				}
			}
			return true;
		}
	}
}

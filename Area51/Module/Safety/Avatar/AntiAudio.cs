using System;
using System.Collections.Generic;
using Area51.Events;
using Area51.SDK;
using Area51.SDK.PatchAPI.Patches;
using UnityEngine;

namespace Area51.Module.Safety.Avatar
{
	internal class AntiAudio : BaseModule, OnObjectInstantiatedEvent
	{
		public AntiAudio()
			: base("Anti Audio", "Limit Audio Recources", Main.Instance.Avatarbutton, null, isToggle: true)
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
				List<AudioSource> list = MunchenAntiCrash.FindAllComponentsInGameObject<AudioSource>(gameObject2);
				int num3 = 0;
				for (int i = MunchenAntiCrash.maxAudio; i < list.Count; i++)
				{
					if (!(list[i] == null) && !list[i].name.Contains("USpeak"))
					{
						UnityEngine.Object.DestroyImmediate(list[i], allowDestroyingAssets: true);
						num3++;
					}
				}
				if (num3 > 0)
				{
					LogHandler.Log(LogHandler.Colors.Green, $"[AntiCrash] Removed {num3} From Avatar");
				}
			}
			return true;
		}
	}
}

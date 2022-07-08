using System;
using Area51.Events;
using Area51.SDK;
using Area51.SDK.PatchAPI.Patches;
using UnityEngine;

namespace Area51.Module.Safety.Avatar
{
	internal class AntiAnimators : BaseModule, OnObjectInstantiatedEvent
	{
		private int maxAnimators = 25;

		public AntiAnimators()
			: base("Anti Animators", "Limit Animator Recources", Main.Instance.Avatarbutton, null, isToggle: true)
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
				if (array.Length >= maxAnimators)
				{
					for (int i = 0; i < maxAnimators; i++)
					{
						UnityEngine.Object.DestroyImmediate(array[i].gameObject, allowDestroyingAssets: true);
					}
					LogHandler.Log(LogHandler.Colors.Red, "[AnitCrash] deleted " + array.Length + " Light Sources");
					LogHandler.LogDebug($"[Anti AviCrash] Deleted {array.Length} Light Sources");
				}
			}
			return true;
		}
	}
}

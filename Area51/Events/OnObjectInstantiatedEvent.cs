using System;
using Area51.SDK.PatchAPI.Patches;
using UnityEngine;

namespace Area51.Events
{
	public interface OnObjectInstantiatedEvent
	{
		bool OnObjectInstantiatedPatch(IntPtr assetPtr, Vector3 pos, Quaternion rot, byte allowCustomShaders, byte isUI, byte validate, IntPtr nativeMethodPointer, _AssetManagement.ObjectInstantiateDelegate originalInstantiateDelegate);
	}
}

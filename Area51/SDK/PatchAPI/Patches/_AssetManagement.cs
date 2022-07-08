using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using VRC.Core;

namespace Area51.SDK.PatchAPI.Patches
{
	public static class _AssetManagement
	{
		public readonly struct AvatarManagerCookie : IDisposable
		{
			public static VRCAvatarManager CurrentManager;

			public readonly VRCAvatarManager myLastManager;

			public AvatarManagerCookie(VRCAvatarManager avatarManager)
			{
				myLastManager = CurrentManager;
				CurrentManager = avatarManager;
			}

			public void Dispose()
			{
				CurrentManager = myLastManager;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void VoidDelegate(IntPtr thisPtr, IntPtr nativeMethodInfo);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr ObjectInstantiateDelegate(IntPtr assetPtr, Vector3 pos, Quaternion rot, byte allowCustomShaders, byte isUI, byte validate, IntPtr nativeMethodPointer);

		public static readonly List<object> antiGCList = new List<object>();

		public unsafe static void InitObjectInstantiatedPatch()
		{
			try
			{
				List<MethodInfo> list = (from it in typeof(AssetManagement).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)
					where it.Name.StartsWith("Method_Public_Static_Object_Object_Vector3_Quaternion_Boolean_Boolean_Boolean_0") && it.GetParameters().Length == 6
					select it).ToList();
				foreach (MethodInfo item in list)
				{
					IntPtr ptr = *(IntPtr*)(void*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(item).GetValue(null);
					ObjectInstantiateDelegate originalInstantiateDelegate = null;
					ObjectInstantiateDelegate objectInstantiateDelegate = (IntPtr assetPtr, Vector3 pos, Quaternion rot, byte allowCustomShaders, byte isUI, byte validate, IntPtr nativeMethodPointer) => OnObjectInstantiatedPatch(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer, originalInstantiateDelegate);
					antiGCList.Add(objectInstantiateDelegate);
					MelonUtils.NativeHookAttach((IntPtr)(&ptr), Marshal.GetFunctionPointerForDelegate(objectInstantiateDelegate));
					originalInstantiateDelegate = Marshal.GetDelegateForFunctionPointer<ObjectInstantiateDelegate>(ptr);
				}
				Type[] nestedTypes = typeof(VRCAvatarManager).GetNestedTypes();
				foreach (Type type in nestedTypes)
				{
					MethodInfo method = type.GetMethod("MoveNext");
					int fieldOffset;
					VoidDelegate originalDelegate;
					if (!(method == null))
					{
						PropertyInfo propertyInfo = type.GetProperties().SingleOrDefault((PropertyInfo it) => it.PropertyType == typeof(VRCAvatarManager));
						if (!(propertyInfo == null))
						{
							fieldOffset = (int)IL2CPP.il2cpp_field_get_offset((IntPtr)UnhollowerUtils.GetIl2CppFieldInfoPointerFieldForGeneratedFieldAccessor(propertyInfo.GetMethod).GetValue(null));
							IntPtr intPtr = *(IntPtr*)(void*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(method).GetValue(null);
							intPtr = XrefScannerLowLevel.JumpTargets(intPtr).First();
							originalDelegate = null;
							VoidDelegate voidDelegate = TaskMoveNextPatch;
							antiGCList.Add(voidDelegate);
							MelonUtils.NativeHookAttach((IntPtr)(&intPtr), Marshal.GetFunctionPointerForDelegate(voidDelegate));
							originalDelegate = Marshal.GetDelegateForFunctionPointer<VoidDelegate>(intPtr);
						}
					}
					unsafe void TaskMoveNextPatch(IntPtr taskPtr, IntPtr nativeMethodInfo)
					{
						IntPtr intPtr2 = *(IntPtr*)(void*)(taskPtr + fieldOffset - 16);
						using (new AvatarManagerCookie(new VRCAvatarManager(intPtr2)))
						{
							originalDelegate(taskPtr, nativeMethodInfo);
						}
					}
				}
				LogHandler.Log(LogHandler.Colors.Green, "[Patch] AssetManagement", timeStamp: true);
			}
			catch
			{
				LogHandler.Log(LogHandler.Colors.Red, "[Patch] [Error] AssetManagement", timeStamp: true);
			}
		}

		public static IntPtr OnObjectInstantiatedPatch(IntPtr assetPtr, Vector3 pos, Quaternion rot, byte allowCustomShaders, byte isUI, byte validate, IntPtr nativeMethodPointer, ObjectInstantiateDelegate originalInstantiateDelegate)
		{
			if (assetPtr == IntPtr.Zero)
			{
				return originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);
			}
			GameObject gameObject = new UnityEngine.Object(assetPtr).TryCast<GameObject>();
			if (gameObject == null)
			{
				return originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);
			}
			if (gameObject.name.StartsWith("UserUi") || gameObject.name.StartsWith("WorldUi") || gameObject.name.StartsWith("AvatarUi") || gameObject.name.StartsWith("Holoport"))
			{
				return originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);
			}
			bool flag = gameObject.name.StartsWith("prefab");
			IntPtr result = originalInstantiateDelegate(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer);
			for (int i = 0; i < Main.Instance.OnObjectInstantiatedArray.Length; i++)
			{
				if (Main.Instance.OnObjectInstantiatedArray[i].OnObjectInstantiatedPatch(assetPtr, pos, rot, allowCustomShaders, isUI, validate, nativeMethodPointer, originalInstantiateDelegate))
				{
					return result;
				}
			}
			return result;
		}
	}
}

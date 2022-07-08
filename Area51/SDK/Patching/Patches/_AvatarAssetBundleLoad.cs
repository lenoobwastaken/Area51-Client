using System.Reflection;
using HarmonyLib;
using UnityEngine;
using VRC.Core;

namespace Area51.SDK.Patching.Patches
{
	public static class _AvatarAssetBundleLoad
	{
		public static void InitAOnAssetBundleLoad()
		{
			try
			{
				AlienPatch.Instance.Patch(typeof(AssetManagement).GetMethod("Method_Public_Static_Object_Object_Boolean_Boolean_Boolean_0"), new HarmonyMethod(AccessTools.Method(typeof(_AvatarAssetBundleLoad), "OnAvatarAssetBundleLoad")));
				LogHandler.Log(LogHandler.Colors.Green, "[Patch] AssetBundle", timeStamp: true);
			}
			catch
			{
				LogHandler.Log(LogHandler.Colors.Red, "[Patch] [Error] AssetBundle", timeStamp: true);
			}
		}

		[Obfuscation(Exclude = true)]
		private static bool OnAvatarAssetBundleLoad(ref Object __0)
		{
			try
			{
				GameObject gameObject = __0.TryCast<GameObject>();
				if (gameObject == null)
				{
					return true;
				}
				if (!gameObject.name.ToLower().Contains("avatar"))
				{
					return true;
				}
				string blueprintId = gameObject.GetComponent<PipelineManager>().blueprintId;
				for (int i = 0; i < Main.Instance.OnAssetBundleLoadEventArray.Length; i++)
				{
					if (!Main.Instance.OnAssetBundleLoadEventArray[i].OnAvatarAssetBundleLoad(gameObject, blueprintId))
					{
						return false;
					}
				}
			}
			catch
			{
			}
			return true;
		}
	}
}

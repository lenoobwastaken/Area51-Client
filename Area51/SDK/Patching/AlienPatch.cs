using System;
using System.Reflection;
using Area51.SDK.PatchAPI.Patches;
using Area51.SDK.Patching.Patches;
using Harmony;
using HarmonyLib;

namespace Area51.SDK.Patching
{
	internal class AlienPatch
	{
		public static HarmonyLib.Harmony Instance = new HarmonyLib.Harmony("Area-51");

		public static HarmonyLib.Harmony Harmony { get; set; }

		public static global::Harmony.HarmonyMethod GetLocalPatch(Type type, string methodName)
		{
			return new global::Harmony.HarmonyMethod(type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic));
		}

		public static void InitPatches()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "[Patch] Starting Patches....", timeStamp: true);
				_AssetManagement.InitObjectInstantiatedPatch();
				_Spoofers.InitSpoofs();
				_Udon.InitUdon();
				_OnEvent.InitOnEvent();
				_AvatarAssetBundleLoad.InitAOnAssetBundleLoad();
				_Logging.InitLogging();
				_OnUInit.OnUIInit();
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Green, ex.Message);
			}
		}
	}
}

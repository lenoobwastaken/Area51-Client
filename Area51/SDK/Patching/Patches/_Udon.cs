using System;
using System.Reflection;
using HarmonyLib;
using VRC;
using VRC.Networking;

namespace Area51.SDK.Patching.Patches
{
	public static class _Udon
	{
		public static void InitUdon()
		{
			try
			{
				AlienPatch.Instance.Patch(typeof(UdonSync).GetMethod("UdonSyncRunProgramAsRPC"), new HarmonyMethod(AccessTools.Method(typeof(_Udon), "OnUdon")));
				LogHandler.Log(LogHandler.Colors.Green, "[Patch] Udon", timeStamp: true);
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, "[Patch] Could not patch Udon failed\n" + ex, timeStamp: true);
			}
		}

		[Obfuscation(Exclude = true)]
		private static bool OnUdon(string __0, Player __1)
		{
			for (int i = 0; i < Main.Instance.OnUdonEventArray.Length; i++)
			{
				if (!Main.Instance.OnUdonEventArray[i].OnUdon(__0, __1))
				{
					return false;
				}
			}
			return true;
		}
	}
}

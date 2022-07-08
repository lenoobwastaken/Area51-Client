using System.Linq;
using System.Reflection;
using Area51.Module.Settings.Logging;
using HarmonyLib;
using Il2CppSystem;
using UnityEngine;

namespace Area51.SDK.Patching.Patches
{
	public static class _Logging
	{
		public static void InitLogging()
		{
			try
			{
				AlienPatch.Instance.Patch(typeof(Debug).GetMethods().First((MethodInfo x) => x.Name == "Log" && x.GetParameters().Length == 1), new HarmonyMethod(AccessTools.Method(typeof(_Logging), "Debug")));
				AlienPatch.Instance.Patch(typeof(Debug).GetMethods().First((MethodInfo x) => x.Name == "LogError" && x.GetParameters().Length == 1), new HarmonyMethod(AccessTools.Method(typeof(_Logging), "DebugError")));
				AlienPatch.Instance.Patch(typeof(Debug).GetMethods().First((MethodInfo x) => x.Name == "LogWarning" && x.GetParameters().Length == 1), new HarmonyMethod(AccessTools.Method(typeof(_Logging), "DebugWarning")));
				LogHandler.Log(LogHandler.Colors.Green, "[Patch] Logger", timeStamp: true);
			}
			catch
			{
				LogHandler.Log(LogHandler.Colors.Red, "[Patch] [Error] Logger", timeStamp: true);
			}
		}

		[Obfuscation(Exclude = true)]
		private static bool DebugError(ref Il2CppSystem.Object __0)
		{
			if (UnityLogger.Instance == null)
			{
				return true;
			}
			if (UnityLogger.Instance.toggled)
			{
				LogHandler.Log(LogHandler.Colors.Red, "[UnityError] " + Convert.ToString(__0), timeStamp: true);
			}
			return true;
		}

		[Obfuscation(Exclude = true)]
		private static bool DebugWarning(ref Il2CppSystem.Object __0)
		{
			if (UnityLogger.Instance == null)
			{
				return true;
			}
			if (UnityLogger.Instance.toggled)
			{
				LogHandler.Log(LogHandler.Colors.Yellow, "[UnityWarning] " + Convert.ToString(__0), timeStamp: true);
			}
			return true;
		}

		[Obfuscation(Exclude = true)]
		private static bool Debug(ref Il2CppSystem.Object __0)
		{
			if (UnityLogger.Instance == null)
			{
				return true;
			}
			if (UnityLogger.Instance.toggled)
			{
				LogHandler.Log(LogHandler.Colors.Green, "[Unity] " + Convert.ToString(__0), timeStamp: true);
			}
			return true;
		}
	}
}

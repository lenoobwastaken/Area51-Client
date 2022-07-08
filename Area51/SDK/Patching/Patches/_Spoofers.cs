using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using AmplitudeSDKWrapper;
using Harmony;
using UnityEngine;

namespace Area51.SDK.Patching.Patches
{
	public static class _Spoofers
	{
		public static string newHWID = string.Empty;

		private static string[] PBU = new string[13]
		{
			"MSI Radeon RX 6900 XT GAMING Z TRIO 16GB", "Gigabyte Radeon RX 6700 XT Gaming OC 12GB", "ASUS DUAL GeForce RTX 2060 6GB OC EVO", "Palit GeForce GTX 1050 Ti StormX 4GB", "MSI GeForce GTX 1650 D6 Ventus XS OCV2 12GB OC", "ASUS GOLD20TH GTX 980 Ti Platinum", "ASUS TUF GeForce RTX 3060 12GB OC Gaming", "NVIDIA Quadro RTX 4000 8GB", "NVIDIA GeForce GTX 1080 Ti", "NVIDIA GeForce GTX 1080",
			"NVIDIA GeForce GTX 1070", "NVIDIA GeForce GTX 1060 6GB", "NVIDIA GeForce GTX 980 Ti"
		};

		private static string[] CPU = new string[9] { "AMD Ryzen 5 3600", "AMD Ryzen 7 3700X", "AMD Ryzen 7 5800X", "AMD Ryzen 9 5900X", "AMD Ryzen 9 3900X 12-Core Processor", "INTEL CORE I9-10900K", "INTEL CORE I7-10700K", "INTEL CORE I9-9900K", "Intel Core i7-8700K" };

		private static string[] Motherboards = new string[4] { "B550 AORUS PRO (Gigabyte Technology Co., Ltd.)", "Gigabyte B450M DS3H", "Asus AM4 TUF Gaming X570-Plus", "ASRock Z370 Taichi" };

		private static string[] OS = new string[10] { "Windows 10  (10.0.0) 64bit", "Windows 10  (10.0.0) 32bit", "Windows 8  (10.0.0) 64bit", "Windows 8  (10.0.0) 32bit", "Windows 7  (10.0.0) 64bit", "Windows 7  (10.0.0) 32bit", "Windows Vista 64bit", "Windows Vista 32bit", "Windows XP 64bit", "Windows XP 32bit" };

		public static void InitSpoofs()
		{
			try
			{
				AlienPatch.Instance.Patch(typeof(SystemInfo).GetProperty("deviceUniqueIdentifier").GetGetMethod(), new HarmonyMethod(AccessTools.Method(typeof(_Spoofers), "FakeHWID")));
				AlienPatch.Instance.Patch(typeof(AmplitudeWrapper).GetMethod("PostEvents"), new HarmonyMethod(AccessTools.Method(typeof(_Spoofers), "VoidPatch")));
				AlienPatch.Instance.Patch(typeof(AmplitudeWrapper).GetMethods().First((MethodInfo x) => x.Name == "LogEvent" && x.GetParameters().Length == 4), new HarmonyMethod(AccessTools.Method(typeof(_Spoofers), "VoidPatch")));
				LogHandler.Log(LogHandler.Colors.Green, "[Patch] Analystics", timeStamp: true);
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, "[Patch] Could not patch Analystics failed\n" + ex, timeStamp: true);
			}
		}

		[Obfuscation(Exclude = true)]
		private static bool FakeHWID(ref string __result)
		{
			if (newHWID == string.Empty)
			{
				newHWID = KeyedHashAlgorithm.Create().ComputeHash(Encoding.UTF8.GetBytes($"{new System.Random().Next(0, 9)}A-{new System.Random().Next(0, 9)}{new System.Random().Next(0, 9)}-{new System.Random().Next(0, 9)}{new System.Random().Next(0, 9)}-{new System.Random().Next(0, 9)}{new System.Random().Next(0, 9)}-3C-1F")).Select(delegate(byte x)
				{
					byte b = x;
					return b.ToString("x2");
				})
					.Aggregate((string x, string y) => x + y);
				LogHandler.Log(LogHandler.Colors.Green, "[Spoofer] HWID New: " + newHWID, timeStamp: true);
			}
			__result = newHWID;
			return false;
		}

		[Obfuscation(Exclude = true)]
		private static bool VoidPatch()
		{
			return false;
		}

		[Obfuscation(Exclude = true)]
		private static bool VoidPatchTrue(bool __result)
		{
			__result = true;
			return false;
		}

		[Obfuscation(Exclude = true)]
		private static bool VoidPatchFalse(bool __result)
		{
			__result = false;
			return false;
		}
	}
}

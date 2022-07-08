using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using HarmonyLib;
using Il2CppSystem;
using Photon.Realtime;
using VRC;
using VRC.SDKBase;

namespace Area51.SDK.Patching.Patches
{
	public static class _OnEvent
	{
		public static List<int> blacklistedPlayers = new List<int>();

		public static void InitOnEvent()
		{
			try
			{
				AlienPatch.Instance.Patch(typeof(LoadBalancingClient).GetMethod("OnEvent"), new HarmonyMethod(AccessTools.Method(typeof(_OnEvent), "OnEvent")));
				AlienPatch.Instance.Patch(AccessTools.Method(typeof(LoadBalancingClient), "method_Public_Virtual_New_Void_EventData_0"), new HarmonyMethod(AccessTools.Method(typeof(_OnEvent), "OnEvent")));
				AlienPatch.Instance.Patch(AccessTools.Method(typeof(LoadBalancingClient), "Method_Public_Virtual_New_Void_Object_0"), new HarmonyMethod(AccessTools.Method(typeof(_OnEvent), "OnEvent")));
				AlienPatch.Instance.Patch(AccessTools.Method(typeof(LoadBalancingClient), "Method_Public_Virtual_New_Void_Object_1"), new HarmonyMethod(AccessTools.Method(typeof(_OnEvent), "OnEvent")));
				AlienPatch.Instance.Patch(typeof(VRC_EventDispatcherRFC).GetMethod("Method_Public_Void_Player_VrcEvent_VrcBroadcastType_Int32_Single_1"), new HarmonyMethod(AccessTools.Method(typeof(_OnEvent), "OnRPC")));
				AlienPatch.Instance.Patch(AccessTools.Method(typeof(LoadBalancingClient), "Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0"), new HarmonyMethod(AccessTools.Method(typeof(_OnEvent), "OpRaiseEvent")));
				LogHandler.Log(LogHandler.Colors.Green, "[Patch] Networking", timeStamp: true);
			}
			catch
			{
				LogHandler.Log(LogHandler.Colors.Red, "[Patch] [Error] Networking", timeStamp: true);
			}
		}

		private static bool OnEvent(EventData __0)
		{
			try
			{
				if (__0 == null)
				{
					return false;
				}
				for (int i = 0; i < Main.Instance.OnEventEventArray.Length; i++)
				{
					if (!Main.Instance.OnEventEventArray[i].OnEvent(__0))
					{
						return false;
					}
				}
			}
			catch (System.Exception)
			{
			}
			return true;
		}

		private static bool OpRaiseEvent(byte __0, Il2CppSystem.Object __1, RaiseEventOptions __2)
		{
			for (int i = 0; i < Main.Instance.OnSendOPEventArray.Length; i++)
			{
				if (!Main.Instance.OnSendOPEventArray[i].OnSendOP(__0, ref __1, ref __2))
				{
					return false;
				}
			}
			return true;
		}

		private static bool OnRPC(ref VRC.Player __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
		{
			for (int i = 0; i < Main.Instance.OnRPCEventArray.Length; i++)
			{
				if (!Main.Instance.OnRPCEventArray[i].OnRPC(__0, __1, __2, __3, __4))
				{
					return false;
				}
			}
			return true;
		}
	}
}

using System.Collections.Generic;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.Udon;

namespace Area51.SDK
{
	internal class WorldWrapper
	{
		public static VRC_Pickup[] vrc_Pickups;

		public static UdonBehaviour[] udonBehaviours;

		public static VRC_Trigger[] vrc_Triggers;

		public static GameObject[] gameobjects;

		public static string GetInstance()
		{
			return PlayerWrapper.LocalPlayer.GetAPIUser().instanceId;
		}

		public static string GetID()
		{
			return CurrentWorld().id;
		}

		public static string GetLocation()
		{
			return PlayerWrapper.LocalPlayer.GetAPIUser().location;
		}

		public static ApiWorld CurrentWorld()
		{
			return RoomManager.field_Internal_Static_ApiWorld_0;
		}

		public static ApiWorldInstance CurrentWorldInstance()
		{
			return RoomManager.field_Internal_Static_ApiWorldInstance_0;
		}

		public static string WorldName()
		{
			return RoomManager.field_Internal_Static_ApiWorld_0.name;
		}

		public static void Init()
		{
			vrc_Pickups = Object.FindObjectsOfType<VRC_Pickup>();
			udonBehaviours = Object.FindObjectsOfType<UdonBehaviour>();
			vrc_Triggers = Object.FindObjectsOfType<VRC_Trigger>();
			gameobjects = Resources.FindObjectsOfTypeAll<GameObject>();
			PlayerWrapper.PlayersActorID = new Dictionary<int, Player>();
			for (int i = 0; i < Main.Instance.OnWorldInitEventArray.Length; i++)
			{
				Main.Instance.OnWorldInitEventArray[i].OnWorldInit();
			}
		}
	}
}

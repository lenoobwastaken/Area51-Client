using System.Collections.Generic;
using System.Linq;
using Area51.SDK;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using VRC;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	public static class MurderMisc
	{
		public static bool toggled;

		public static void MurderMod(string udonevent)
		{
			foreach (GameObject item in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (item.name.Contains("Game Logic"))
				{
					item.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, udonevent);
				}
			}
		}

		public static void ObjectInteract(string ObjectName)
		{
			foreach (GameObject item in DoorList())
			{
				item.transform.Find(ObjectName).gameObject.SetObjecOwner();
				item.transform.Find(ObjectName).GetComponent<UdonBehaviour>().Interact();
			}
		}

		public static void TargetedEvent(string udonevent)
		{
			GameObject gameObject = GameObject.Find("Player Nodes");
			foreach (Transform componentsInChild in gameObject.GetComponentsInChildren<Transform>())
			{
				if (componentsInChild.name != gameObject.name)
				{
					componentsInChild.gameObject.udonsend(udonevent, PlayerWrapper.SelectedVRCPlayer());
				}
			}
		}

		public static void TargetedEvent2(this GameObject gameObject, string udonEvent, VRC.Player player = null, bool componetcheck = false)
		{
			UdonBehaviour component = gameObject.GetComponent<UdonBehaviour>();
			if (!(player != null))
			{
				if (!componetcheck)
				{
					if (player == PlayerWrapper.SelectedVRCPlayer())
					{
						component.SendCustomEvent(udonEvent);
					}
					else
					{
						component.SendCustomNetworkEvent(NetworkEventTarget.All, udonEvent);
					}
				}
			}
			else
			{
				gameObject.SetEventOwner(player);
				component.SendCustomNetworkEvent(NetworkEventTarget.Owner, udonEvent);
			}
		}

		public static void RoleAssign(string udonevent)
		{
			GameObject gameObject = GameObject.Find("Player Nodes");
			foreach (Transform componentsInChild in gameObject.GetComponentsInChildren<Transform>())
			{
				if (componentsInChild.name != gameObject.name)
				{
					componentsInChild.gameObject.udonsend(udonevent, PlayerWrapper.LocalVRCPlayer._player);
				}
			}
		}

		public static void RoleAssignEveryone(string udonevent)
		{
			GameObject gameObject = GameObject.Find("Player Nodes");
			foreach (Transform componentsInChild in gameObject.GetComponentsInChildren<Transform>())
			{
				if (componentsInChild.name != gameObject.name)
				{
					componentsInChild.gameObject.udonsend(udonevent);
				}
			}
		}

		public static void MurderGive(string ObjectName)
		{
			foreach (GameObject item in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (item.name.Contains(ObjectName))
				{
					Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0, item);
					item.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0f, 0.1f, 0f);
				}
			}
		}

		public static void MurderTargetGive(string ObjectName)
		{
			foreach (GameObject item in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (item.name.Contains(ObjectName))
				{
					Networking.SetOwner(PlayerWrapper.SelectedVRCPlayer().field_Private_VRCPlayerApi_0, item);
					item.transform.position = PlayerWrapper.SelectedVRCPlayer().transform.position + new Vector3(0f, 0.1f, 0f);
				}
			}
		}

		public static void MurderFlash()
		{
		}

		public static void pickupsteal()
		{
			VRC_Pickup[] array = Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if ((bool)array[i].gameObject)
				{
					array[i].DisallowTheft = false;
				}
			}
			VRC_Pickup[] array2 = Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray();
			for (int j = 0; j < array2.Length; j++)
			{
				if ((bool)array2[j].gameObject)
				{
					array2[j].DisallowTheft = false;
				}
			}
			VRCPickup[] array3 = Resources.FindObjectsOfTypeAll<VRCPickup>().ToArray();
			for (int k = 0; k < array3.Length; k++)
			{
				if ((bool)array3[k].gameObject)
				{
					array3[k].DisallowTheft = false;
				}
			}
		}

		public static void udonsend(this GameObject gameObject, string udonEvent, VRC.Player player = null, bool componetcheck = false)
		{
			UdonBehaviour component = gameObject.GetComponent<UdonBehaviour>();
			if (!(player != null))
			{
				if (!componetcheck)
				{
					if (player == VRCPlayer.field_Internal_Static_VRCPlayer_0._player)
					{
						component.SendCustomEvent(udonEvent);
					}
					else
					{
						component.SendCustomNetworkEvent(NetworkEventTarget.All, udonEvent);
					}
				}
			}
			else
			{
				gameObject.SetEventOwner(player);
				component.SendCustomNetworkEvent(NetworkEventTarget.Owner, udonEvent);
			}
		}

		public static void SetEventOwner(this GameObject gameObject, VRC.Player player)
		{
			if (gameObject.GrabOwner() != player)
			{
				Networking.SetOwner(player.field_Private_VRCPlayerApi_0, gameObject);
			}
		}

		public static VRC.Player GrabOwner(this GameObject gameObject)
		{
			Il2CppSystem.Collections.Generic.List<VRC.Player>.Enumerator enumerator = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				VRC.Player current = enumerator.Current;
				if (current.field_Private_VRCPlayerApi_0.IsOwner(gameObject))
				{
					return current;
				}
			}
			return null;
		}

		public static void SetObjecOwner(this GameObject gameObject)
		{
			if (gameObject.GrabOwner() != VRCPlayer.field_Internal_Static_VRCPlayer_0._player)
			{
				Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCPlayerApi_0, gameObject);
			}
		}

		public static System.Collections.Generic.List<GameObject> DoorList()
		{
			System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>();
			try
			{
				list.Add(GameObject.Find("Door").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (3)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (4)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (5)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (6)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (7)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (8)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (13)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (14)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (15)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (16)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (17)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (18)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (19)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (20)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (21)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (22)").transform.Find("Door Anim/Hinge").gameObject);
				list.Add(GameObject.Find("Door (23)").transform.Find("Door Anim/Hinge").gameObject);
				return list;
			}
			catch
			{
				return list;
			}
		}
	}
}

using UnityEngine;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace Area51.Module.World.World_Hacks.ZombieTag
{
	internal class PrisionMisc
	{
		public static bool Check()
		{
			string value = "";
			return RoomManager.Method_Public_Static_String_0().Contains(value);
		}

		public static void ZombieMod(string udonevent)
		{
			if (!Check())
			{
				return;
			}
			foreach (GameObject item in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (item.name.Contains("Game Logic"))
				{
					item.GetComponent<UdonBehaviour>().SendCustomNetworkEvent(NetworkEventTarget.All, udonevent);
				}
			}
		}
	}
}

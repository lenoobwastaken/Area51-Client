using System.Collections;
using Area51.SDK;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class JustBClub
	{
		private static void EnterJustBRooms(int roomNum, float x, float y, float z, bool state)
		{
			GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.name.Contains($"Bedroom {roomNum}") || array[i].gameObject.name.Contains("Bedroom VIP"))
				{
					array[i].gameObject.SetActive(state);
					PlayerWrapper.TeleportLocation(x, y, z);
				}
			}
		}

		public static IEnumerator EnterRoom(int roomNum)
		{
			switch (roomNum)
			{
			case 1:
				EnterJustBRooms(roomNum, -217.7101f, -11.755f, 151.0652f, state: true);
				break;
			case 2:
				EnterJustBRooms(roomNum, -217.3516f, 55.245f, -91.66356f, state: true);
				break;
			case 3:
				EnterJustBRooms(roomNum, -119.0256f, -11.755f, 151.1068f, state: true);
				break;
			case 4:
				EnterJustBRooms(roomNum, -116.8698f, 55.245f, -91.59067f, state: true);
				break;
			case 5:
				EnterJustBRooms(roomNum, -18.62112f, -11.755f, 150.9862f, state: true);
				break;
			case 6:
				EnterJustBRooms(roomNum, -17.56843f, 55.245f, -91.55622f, state: true);
				break;
			case 7:
				EnterJustBRooms(roomNum, 58.17721f, 62.3625f, -6.299268f, state: true);
				break;
			default:
				yield return new WaitForSecondsRealtime(0.02f);
				break;
			}
		}
	}
}

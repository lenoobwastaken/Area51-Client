using System.Collections;
using MelonLoader;
using UnityEngine;
using VRC.SDKBase;

namespace Area51.Module.World
{
	internal class ForcePickups : BaseModule
	{
		public static bool gimmedatshit;

		public ForcePickups()
			: base("Force Pickups", "Pickup All Pickups", Main.Instance.WorldButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			MelonCoroutines.Start(GimmeThatShit());
			gimmedatshit = true;
		}

		public override void OnDisable()
		{
			gimmedatshit = false;
		}

		public static IEnumerator GimmeThatShit()
		{
			if (!gimmedatshit)
			{
				yield return null;
			}
			VRC_Pickup[] pickups = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
			while (true)
			{
				int num = 0;
				while (num < pickups.Length)
				{
					if (pickups[num] != null)
					{
						pickups[num].pickupable = true;
					}
					int num2 = num + 1;
					num = num2;
				}
				yield return null;
			}
		}
	}
}

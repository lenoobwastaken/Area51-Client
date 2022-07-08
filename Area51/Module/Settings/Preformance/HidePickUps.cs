using System.Linq;
using Area51.SDK;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;

namespace Area51.Module.Settings.Preformance
{
	internal class HidePickUps : BaseModule
	{
		public HidePickUps()
			: base("Hide Items", "Hides pick ups local", Main.Instance.SettingsButtonpreformance, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			pickupHIDE(a: false);
			LogHandler.LogDebug("Pickups Hidden");
		}

		public override void OnDisable()
		{
			pickupHIDE(a: true);
			LogHandler.LogDebug("Pickups UnHidden");
		}

		internal static void pickupHIDE(bool a)
		{
			VRC_Pickup[] array = Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.layer == 13)
				{
					array[i].gameObject.SetActive(a);
				}
			}
			VRC_Pickup[] array2 = Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray();
			for (int j = 0; j < array2.Length; j++)
			{
				if (array2[j].gameObject.layer == 13)
				{
					array2[j].gameObject.SetActive(a);
				}
			}
			VRCPickup[] array3 = Resources.FindObjectsOfTypeAll<VRCPickup>().ToArray();
			for (int k = 0; k < array3.Length; k++)
			{
				if (array3[k].gameObject.layer == 13)
				{
					array3[k].gameObject.SetActive(a);
				}
			}
		}
	}
}

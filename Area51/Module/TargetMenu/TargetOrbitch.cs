using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;
using VRC;
using VRC.SDKBase;

namespace Area51.Module.TargetMenu
{
	internal class TargetOrbitch : BaseModule
	{
		private GameObject puppet;

		public VRC.Player GetSelectedUser()
		{
			return PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0);
		}

		public TargetOrbitch()
			: base("Items orbit", "Teleports items to selected user.", Main.Instance.Targetbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			MelonCoroutines.Start(ItemRotate());
			LogHandler.LogDebug("[Info] -> Items Orbitting -> " + PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0.displayName);
		}

		public override void OnDisable()
		{
			MelonCoroutines.Stop(ItemRotate());
			LogHandler.LogDebug("[Info] -> Items removed -> " + PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0.displayName);
		}

		public IEnumerator ItemRotate()
		{
			VRC.Player byUsrID = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0);
			if (puppet == null)
			{
				puppet = new GameObject();
			}
			puppet.transform.position = byUsrID.transform.position + new Vector3(0f, 0.2f, 0f);
			puppet.transform.Rotate(new Vector3(0f, 360f * Time.time * 1f, 0f));
			for (int i = 0; i < WorldWrapper.vrc_Pickups.Length; i++)
			{
				VRC_Pickup vRC_Pickup = WorldWrapper.vrc_Pickups[i];
				if (Networking.GetOwner(vRC_Pickup.gameObject) != Networking.LocalPlayer)
				{
					Networking.SetOwner(Networking.LocalPlayer, vRC_Pickup.gameObject);
				}
				vRC_Pickup.transform.position = puppet.transform.position + puppet.transform.forward * 1f;
				puppet.transform.Rotate(new Vector3(0f, 360 / WorldWrapper.vrc_Pickups.Length, 0f));
				yield return new WaitForSecondsRealtime(0.1f);
			}
			yield return new WaitForSecondsRealtime(0.1f);
		}
	}
}

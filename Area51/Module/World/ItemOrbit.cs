using Area51.Events;
using Area51.SDK;
using UnityEngine;
using VRC.SDKBase;

namespace Area51.Module.World
{
	internal class ItemOrbit : BaseModule, OnUpdateEvent
	{
		private GameObject puppet;

		public ItemOrbit()
			: base("ItemOrbit", "Makes all Pickups spin arround you", Main.Instance.Eventexploitbutton, Main.Instance.QuickMenuStuff.Button_RespawnIcon.sprite, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnUpdateEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnUpdateEvents.Remove(this);
		}

		public void OnUpdate()
		{
			if (puppet == null)
			{
				puppet = new GameObject();
			}
			puppet.transform.position = PlayerWrapper.LocalPlayer.transform.position + new Vector3(0f, 0.2f, 0f);
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
			}
		}
	}
}

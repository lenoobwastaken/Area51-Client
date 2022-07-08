using System;
using Area51.Events;
using Area51.SDK;
using Area51.SDK.Photon;
using ExitGames.Client.Photon;
using Photon.Realtime;
using UnhollowerBaseLib;

namespace Area51.Module.Settings.Spoofer
{
	internal class PingSpoofer : BaseModule, OnEventEvent
	{
		private byte[] ping = BitConverter.GetBytes(1337);

		public PingSpoofer()
			: base("PingSpoofer", "Spoofes Ping to 1337", Main.Instance.SettingsButtonspoofer, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnEventEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnEventEvents.Remove(this);
		}

		public bool OnEvent(EventData eventData)
		{
			byte code = eventData.Code;
			if (code == 7)
			{
				byte[] bytes = BitConverter.GetBytes(int.Parse($"{PlayerWrapper.LocalPlayer.GetActorNumber()}00001"));
				byte[] array = eventData.customData.Cast<Il2CppStructArray<byte>>();
				Buffer.BlockCopy(bytes, 0, array, 0, 4);
				Buffer.BlockCopy(ping, 0, array, 68, 2);
				PhotonExtensions.OpRaiseEvent(9, array, new RaiseEventOptions
				{
					field_Public_ReceiverGroup_0 = ReceiverGroup.Others,
					field_Public_EventCaching_0 = EventCaching.DoNotCache
				}, SendOptions.SendUnreliable);
				return true;
			}
			return false;
		}
	}
}

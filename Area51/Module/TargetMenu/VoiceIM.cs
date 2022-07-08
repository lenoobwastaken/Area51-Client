using Area51.Events;
using Area51.SDK.Photon;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Area51.Module.TargetMenu
{
	internal class VoiceIM : BaseModule, OnEventEvent
	{
		public VoiceIM()
			: base("Voice IM", "Logs Photon Events", Main.Instance.Targetbutton, null, isToggle: true, save: true)
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
			if (eventData.Code == 1)
			{
				PhotonExtensions.OpRaiseEvent(1, eventData.CustomData, new RaiseEventOptions
				{
					field_Public_ReceiverGroup_0 = ReceiverGroup.Others,
					field_Public_EventCaching_0 = EventCaching.DoNotCache
				}, default(SendOptions));
				return true;
			}
			return true;
		}
	}
}

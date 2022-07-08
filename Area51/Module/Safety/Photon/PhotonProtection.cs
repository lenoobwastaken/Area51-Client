using Area51.Events;
using Area51.SDK;
using ExitGames.Client.Photon;

namespace Area51.Module.Safety.Photon
{
	internal class PhotonProtection : BaseModule, OnEventEvent
	{
		public static bool AntiEvents;

		public PhotonProtection()
			: base("Anti Event 6", "Trys to block photon exploits", Main.Instance.Networkbutton, null, isToggle: true)
		{
			AntiEvents = !AntiEvents;
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
			int actorNumber = PlayerWrapper.LocalPlayer.GetActorNumber();
			ParameterDictionary parameters = eventData.Parameters;
			byte code = eventData.Code;
			if (code == 6)
			{
				return false;
			}
			return true;
		}
	}
}

using Area51.Events;
using Area51.SDK;
using ExitGames.Client.Photon;
using VRC;

namespace Area51.Module.Safety
{
	internal class AntiBot : BaseModule, OnEventEvent
	{
		public AntiBot()
			: base("Anti PhotonBot", "Detects PhotonBots In Lobby And Blocks There Events", Main.Instance.Networkbutton, null, isToggle: true, save: true)
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
			VRC.Player playerByActorID = PlayerWrapper.GetPlayerByActorID(eventData.Sender);
			if ((eventData.Code == 6 || eventData.Code == 9 || eventData.Code == 209 || eventData.Code == 210) && playerByActorID != null)
			{
				if (playerByActorID.IsBot())
				{
					return false;
				}
				_ = playerByActorID == PlayerWrapper.LocalPlayer;
				return true;
			}
			return true;
		}
	}
}

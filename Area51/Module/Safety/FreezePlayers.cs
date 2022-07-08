using Area51.Events;
using ExitGames.Client.Photon;

namespace Area51.Module.Safety
{
	internal class FreezePlayers : BaseModule, OnEventEvent
	{
		public FreezePlayers()
			: base("Freeze Players", "Freezes Player Locally For selection", Main.Instance.Eventexploitbutton, null, isToggle: true)
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
			return eventData.Code != 7;
		}
	}
}

using Area51.Events;
using VRC;
using VRC.SDKBase;

namespace Area51.Module.Safety.Photon
{
	internal class AntiRPC : BaseModule, OnRPCEvent
	{
		public AntiRPC()
			: base("Anti RPC", "Anti's All RPCs", Main.Instance.Networkbutton, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnRPCEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnRPCEvents.Remove(this);
		}

		public bool OnRPC(VRC.Player sender, VRC_EventHandler.VrcEvent vrcEvent, VRC_EventHandler.VrcBroadcastType vrcBroadcastType, int instagatorId, float fastforward)
		{
			return false;
		}
	}
}

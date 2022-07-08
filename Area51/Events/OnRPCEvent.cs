using VRC;
using VRC.SDKBase;

namespace Area51.Events
{
	public interface OnRPCEvent
	{
		bool OnRPC(Player sender, VRC_EventHandler.VrcEvent vrcEvent, VRC_EventHandler.VrcBroadcastType vrcBroadcastType, int instagatorId, float fastforward);
	}
}

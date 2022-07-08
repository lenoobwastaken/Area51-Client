using ExitGames.Client.Photon;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;

namespace Area51.Events
{
	public interface OnPhotonPeerEvent
	{
		bool OnPhotonPeer(byte __0, Dictionary<byte, Object> __1, SendOptions __2);
	}
}

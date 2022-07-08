using Il2CppSystem;
using Photon.Realtime;

namespace Area51.Events
{
	public interface OnSendOPEvent
	{
		bool OnSendOP(byte opCode, ref Object parameters, ref RaiseEventOptions raiseEventOptions);
	}
}

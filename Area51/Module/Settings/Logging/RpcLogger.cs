using Area51.Events;
using Area51.SDK;
using VRC;
using VRC.SDKBase;

namespace Area51.Module.Settings.Logging
{
	internal class RpcLogger : BaseModule, OnRPCEvent
	{
		public RpcLogger()
			: base("RPCLogger", "Logs RPCs", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
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
			string text = PlayerWrapper.LogRPC(sender, vrcEvent, vrcBroadcastType);
			LogHandler.Log(LogHandler.Colors.Cyan, text);
			LogHandler.LogDebug(text ?? "");
			return true;
		}
	}
}

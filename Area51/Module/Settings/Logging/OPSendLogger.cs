using Area51.Events;
using Area51.SDK;
using Area51.SDK.Photon;
using Il2CppSystem;
using Newtonsoft.Json;
using Photon.Realtime;

namespace Area51.Module.Settings.Logging
{
	internal class OPSendLogger : BaseModule, OnSendOPEvent
	{
		public OPSendLogger()
			: base("OPSendLogger", "Logs Photon Events Send by you", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnSendOPEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnSendOPEvents.Remove(this);
		}

		public bool OnSendOP(byte opCode, ref Object parameters, ref RaiseEventOptions raiseEventOptions)
		{
			LogHandler.Log(LogHandler.Colors.Blue, $"[OPSendLog] {opCode} {JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(parameters), Formatting.Indented)}");
			LogHandler.LogDebug($"[OPSend Logger] Your Event: {opCode}");
			return true;
		}
	}
}

using Area51.Events;
using Area51.SDK;
using VRC;

namespace Area51.Module.Settings.Logging
{
	internal class UdonLogger : BaseModule, OnUdonEvent
	{
		public UdonLogger()
			: base("UdonLogger", "Logs Udon Events", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnUdonEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnUdonEvents.Remove(this);
		}

		public bool OnUdon(string __0, VRC.Player __1)
		{
			LogHandler.Log(LogHandler.Colors.Blue, "Type: " + __0 + " | From " + __1.field_Private_APIUser_0.displayName);
			LogHandler.LogDebug("[Udon Logger] Type: " + __0 + " | From " + __1.field_Private_APIUser_0.displayName);
			return true;
		}
	}
}

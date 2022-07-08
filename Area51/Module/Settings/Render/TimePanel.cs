using Area51.SDK.ButtonAPI;

namespace Area51.Module.Settings.Render
{
	internal class TimePanel : BaseModule
	{
		public static VrConsoleLog TimeLog;

		public TimePanel()
			: base("Time", "Shows Current Time", Main.Instance.SettingsButtonrender, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public override void OnUIInit()
		{
			base.OnUIInit();
		}
	}
}

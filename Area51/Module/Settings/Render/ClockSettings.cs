using Area51.SDK;

namespace Area51.Module.Settings.Render
{
	internal class ClockSettings : BaseModule
	{
		public ClockSettings()
			: base("Clock Settings", "Change Time from 24hr/12hr", Main.Instance.SettingsButtonrender, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			Area51Console.timesetting = false;
		}

		public override void OnDisable()
		{
			Area51Console.timesetting = true;
		}
	}
}

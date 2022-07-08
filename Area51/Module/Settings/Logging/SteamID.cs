namespace Area51.Module.Settings.Logging
{
	internal class SteamID : BaseModule
	{
		public SteamID()
			: base("SteamID", "Logs Players Joining And Leaving", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
		{
		}
	}
}

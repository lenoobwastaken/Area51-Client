namespace Area51.Module.Settings.Logging
{
	internal class UnityLogger : BaseModule
	{
		public static UnityLogger Instance;

		public UnityLogger()
			: base("UnityLogger", "Logs Unity Debug", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
		{
			Instance = this;
		}
	}
}

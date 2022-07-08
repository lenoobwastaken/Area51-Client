using System;
using Area51.SDK;

namespace Area51.Module.Settings.Preformance
{
	internal class ConsoleClear : BaseModule
	{
		public ConsoleClear()
			: base("Clear Console", "Clears Melon Loader Console", Main.Instance.SettingsButtonpreformance, ButtonIcons.OffIcon)
		{
		}

		public override void OnEnable()
		{
			Console.Clear();
			LogHandler.DisplayLogo();
			LogHandler.Log(LogHandler.Colors.White, "Cleared Console!");
		}
	}
}

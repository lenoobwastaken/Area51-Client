using System;
using System.Diagnostics;
using Area51.SDK;

namespace Area51.Module.Bot.Local
{
	internal class KIllBots : BaseModule
	{
		public KIllBots()
			: base("Bots Leave", "Tells Bots To Disconnect", Main.Instance.Privatebotbutton, ButtonIcons.StopIcon)
		{
		}

		public override void OnEnable()
		{
			try
			{
				Console.Clear();
				LogHandler.DisplayLogo();
				Process[] processesByName = Process.GetProcessesByName("Area51");
				foreach (Process process in processesByName)
				{
					process.Kill();
				}
				LogHandler.Log(LogHandler.Colors.Green, "Bots Killed!");
				LogHandler.LogDebug("Bots Killed!");
			}
			catch (Exception)
			{
			}
		}
	}
}

using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class StartGame : BaseModule
	{
		public StartGame()
			: base("Start Game", "Force Start Game", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Red, "Started Game");
				LogHandler.LogDebug("Started Game");
				MurderMisc.MurderMod("Btn_Start");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

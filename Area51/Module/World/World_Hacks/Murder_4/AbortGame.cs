using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class AbortGame : BaseModule
	{
		public AbortGame()
			: base("Abort Game", "No One Wins", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Ended Game With No One As The Victor");
				LogHandler.LogDebug("Ended Game With No One As The Victor");
				MurderMisc.MurderMod("SyncAbort");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class BystanderWin : BaseModule
	{
		public BystanderWin()
			: base("Bystander Win", "Bystander Wins", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Ended Game With The Bystanders As The Victor");
				LogHandler.LogDebug("Ended Game With The Bystanders As The Victor");
				MurderMisc.MurderMod("SyncVictoryB");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

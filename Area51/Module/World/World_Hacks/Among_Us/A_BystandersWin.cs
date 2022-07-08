using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_BystandersWin : BaseModule
	{
		public A_BystandersWin()
			: base("Bystanders Win", "", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Game Ended And Set Bystanders As The Winners");
				A_Misc.AmongUsMod("SyncVictoryB");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

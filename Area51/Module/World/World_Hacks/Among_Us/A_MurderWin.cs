using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_MurderWin : BaseModule
	{
		public A_MurderWin()
			: base("Murder Win", "", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Game Ended And Set The Murder As The Winner");
				A_Misc.AmongUsMod("SyncVictoryM");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

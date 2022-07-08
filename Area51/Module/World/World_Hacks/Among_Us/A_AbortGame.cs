using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_AbortGame : BaseModule
	{
		public A_AbortGame()
			: base("Abort Game", "Abort Game With Nobody As The Winner", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Game Aborted!");
				A_Misc.AmongUsMod("SyncAbort");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

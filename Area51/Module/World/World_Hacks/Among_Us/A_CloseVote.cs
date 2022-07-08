using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_CloseVote : BaseModule
	{
		public A_CloseVote()
			: base("Close Voting", "", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Closed Voting");
				A_Misc.AmongUsMod("SyncCloseVoting");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

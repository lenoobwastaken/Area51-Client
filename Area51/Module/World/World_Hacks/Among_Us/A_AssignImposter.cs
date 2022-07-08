using System;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_AssignImposter : BaseModule
	{
		public A_AssignImposter()
			: base("Give Imposter", "Assigns You As The Imposter", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Assigned You As The Imposter");
				LogHandler.LogDebug("Assigned You As The Imposter");
				MurderMisc.RoleAssign("SyncAssignM");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

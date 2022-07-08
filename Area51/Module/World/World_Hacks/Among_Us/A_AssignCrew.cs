using System;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_AssignCrew : BaseModule
	{
		public A_AssignCrew()
			: base("Give Crew", "", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Assigned You As The Crew");
				LogHandler.LogDebug("Assigned You As The Crew");
				MurderMisc.RoleAssign("SyncAssignB");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class DetectiveAssign : BaseModule
	{
		public DetectiveAssign()
			: base("Give Detective", "Give Detective Role", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Assigned You The Detective Role");
				LogHandler.LogDebug("Assigned You The Detective Role");
				MurderMisc.RoleAssign("SyncAssignD");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

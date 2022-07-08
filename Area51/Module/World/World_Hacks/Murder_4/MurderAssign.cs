using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class MurderAssign : BaseModule
	{
		public MurderAssign()
			: base("Give Murder", "Give Murder Role", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Assigned You The Murder Role");
				LogHandler.LogDebug("Assigned You The Murder Role");
				MurderMisc.RoleAssign("SyncAssignM");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

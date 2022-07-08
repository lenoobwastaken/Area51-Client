using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class EveryoneMurder : BaseModule
	{
		public EveryoneMurder()
			: base("Everyone Murder", "Give Murder Role To Everyone", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Assigned Everyone The Murder Role");
				LogHandler.LogDebug("Assigned Everyone The Murder Role");
				MurderMisc.RoleAssignEveryone("SyncAssignM");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class TPPeople : BaseModule
	{
		public TPPeople()
			: base("Teleport Everyone", "Force Repsawns", Main.Instance.Justbbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.LogDebug("Started Force Repsawning Everyone");
				UdonExploitManager.ObjectEvent("Teleports", "StartTimerWithCooldown", 0);
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}

		public override void OnDisable()
		{
			try
			{
				LogHandler.LogDebug("Stopped Force Repsawning Everyone");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

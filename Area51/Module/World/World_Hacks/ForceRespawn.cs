using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks
{
	internal class ForceRespawn : BaseModule
	{
		public ForceRespawn()
			: base("Respsawn Bitch", "Fuck That Bitch!", Main.Instance.JubstBSettings, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.LogDebug("Started Force Repsawning Bitch");
				UdonExploitManager.ObjectEvent("Teleports", "StartTimerWithCooldown", 1);
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

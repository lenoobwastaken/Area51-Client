using System;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.Murder4_Settings
{
	internal class ForceSpawn : BaseModule
	{
		public ForceSpawn()
			: base("Force Spawn", "Forcefully Spawned", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, aPIUser.displayName + " Forcefully Spawned");
				LogHandler.LogDebug(aPIUser.displayName + " Forcefully Spawned");
				MurderMisc.TargetedEvent("SyncAssignB");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

using System;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.World_Hacks.AmongUs_Settings
{
	internal class AmongUsKill : BaseModule
	{
		public AmongUsKill()
			: base("Kill Player", "Targeted Udon Event That Kills Player", Main.Instance.AmongUsSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, aPIUser.displayName + " Killed");
				LogHandler.LogDebug(aPIUser.displayName + " Killed");
				UdonExploitManager.udonsend("SyncKill", "target");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

using System;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.World_Hacks.AmongUs_Settings
{
	internal class AssignCrew : BaseModule
	{
		public AssignCrew()
			: base("Assign Crew", "Forcefully Assigns Player As Crew", Main.Instance.AmongUsSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, aPIUser.displayName + " Assigned As Crew");
				LogHandler.LogDebug(aPIUser.displayName + " Assigned As Crew");
				UdonExploitManager.udonsend("SyncAssignB", "target");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

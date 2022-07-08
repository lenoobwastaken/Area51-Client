using System;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.Murder4_Settings
{
	internal class MurderAssignTarget : BaseModule
	{
		public MurderAssignTarget()
			: base("Assign Murder", "Assigns Player As Murder", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Assigned " + aPIUser.displayName + " As Murder");
				LogHandler.LogDebug("Assigned " + aPIUser.displayName + " As Murder");
				MurderMisc.TargetedEvent("SyncAssignM");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

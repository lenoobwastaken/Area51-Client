using System;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.Murder4_Settings
{
	internal class BlindTarget : BaseModule
	{
		public BlindTarget()
			: base("Blind Target", "Blind Someone In Murder 4", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Blinded " + aPIUser.displayName);
				LogHandler.LogDebug("Blinded " + aPIUser.displayName);
				UdonExploitManager.udonsend("OnLocalPlayerBlinded", "target");
				UdonExploitManager.udonsend("OnLocalPlayerFlashbanged", "target");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

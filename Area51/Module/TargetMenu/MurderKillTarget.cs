using System;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu
{
	internal class MurderKillTarget : BaseModule
	{
		public MurderKillTarget()
			: base("Murder Kill", "Kill Someone In Murder 4", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Killed " + aPIUser.displayName);
				LogHandler.LogDebug("Killed " + aPIUser.displayName);
				MurderMisc.TargetedEvent("SyncKill");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

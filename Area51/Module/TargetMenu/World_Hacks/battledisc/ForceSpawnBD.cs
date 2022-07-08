using System;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.World_Hacks.battledisc
{
	internal class ForceSpawnBD : BaseModule
	{
		public ForceSpawnBD()
			: base("Freeze Player", "Forcefully Freeze Selected Player", Main.Instance.BattleDisc)
		{
		}

		public override void OnEnable()
		{
			try
			{
				UdonExploitManager.udonsend("Defeated", "target");
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Locked " + aPIUser.displayName + "'s Movement");
				LogHandler.LogDebug("You Just Broke " + aPIUser.displayName + "'s Legs, This Nigga Cant Walk....");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

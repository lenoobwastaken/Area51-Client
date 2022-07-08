using System;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.Murder4_Settings
{
	internal class BringItemsTarget : BaseModule
	{
		public BringItemsTarget()
			: base("Bring Items", "Brings All Items", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Brought All Items To " + aPIUser.displayName + "'s Position");
				LogHandler.LogDebug("Brought All Items To " + aPIUser.displayName + "'s Position");
				MurderMisc.MurderTargetGive("Smoke");
				MurderMisc.MurderTargetGive("Revolver");
				MurderMisc.MurderTargetGive("Knife");
				MurderMisc.MurderTargetGive("Shotgun");
				MurderMisc.MurderTargetGive("Frag");
				MurderMisc.MurderTargetGive("Luger");
				MurderMisc.MurderTargetGive("Bear Trap");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

using System;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.Murder4_Settings
{
	internal class BringKnifeTarget : BaseModule
	{
		public BringKnifeTarget()
			: base("Bring Knife", "Brings All Knifes", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Brought All Knifes " + aPIUser.displayName + "'s Position");
				LogHandler.LogDebug("Brought All Knifes " + aPIUser.displayName + "'s Position");
				MurderMisc.MurderTargetGive("Knife");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

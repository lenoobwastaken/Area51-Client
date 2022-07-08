using System;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.Murder4_Settings
{
	internal class BringRevolverTarget : BaseModule
	{
		public BringRevolverTarget()
			: base("Bring Revolver", "Brings Revolver", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Brought Revolver " + aPIUser.displayName + "'s Position");
				LogHandler.LogDebug("Brought Revolver " + aPIUser.displayName + "'s Position");
				MurderMisc.MurderTargetGive("Revolver");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

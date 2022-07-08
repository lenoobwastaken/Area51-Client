using System;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu.World_Hacks.movmC
{
	internal class TargetLag : BaseModule
	{
		public TargetLag()
			: base("Lag Target", "Targeted Item/Trigger Lagger", Main.Instance.MovienChillTarget, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, aPIUser.displayName + " Is Lagging");
				LogHandler.LogDebug(aPIUser.displayName + " Is Lagging");
				for (int i = 0; i < 10; i++)
				{
					UdonExploitManager.udonsend("OnObjectRootPickupUseDown", "target");
				}
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

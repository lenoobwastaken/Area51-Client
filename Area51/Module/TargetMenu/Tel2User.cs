using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu
{
	internal class Tel2User : BaseModule
	{
		public Tel2User()
			: base("Teleport", "Teleports to selected user.", Main.Instance.Targetbutton, ButtonIcons.MovementMenu)
		{
		}

		public override void OnEnable()
		{
			APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
			PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).Teleport();
			LogHandler.LogDebug("[Info] -> Teleported To: " + aPIUser.displayName);
		}
	}
}

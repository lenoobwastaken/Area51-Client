using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu
{
	internal class UserIDSelected : BaseModule
	{
		public UserIDSelected()
			: base("UserID", "Grabs userid from selected user", Main.Instance.Targetbutton, ButtonIcons.CopyIcon)
		{
		}

		public override void OnEnable()
		{
			APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
			if (aPIUser.id != "")
			{
				AlienMisc.SetClipboard(aPIUser.id);
			}
			LogHandler.LogDebug("[Info] -> Coppied UserID to clipboard.");
		}
	}
}

using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu
{
	internal class AvatSelected : BaseModule
	{
		public AvatSelected()
			: base("AvatarID", "Grabs avatarid from selected user", Main.Instance.Targetbutton, ButtonIcons.CopyIcon)
		{
		}

		public override void OnEnable()
		{
			ApiAvatar apiAvatar = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_ApiAvatar_0;
			if (apiAvatar.id != "")
			{
				AlienMisc.SetClipboard(apiAvatar.id);
			}
			LogHandler.LogDebug("[Info] -> Coppied AvatarID to clipboard.");
		}
	}
}

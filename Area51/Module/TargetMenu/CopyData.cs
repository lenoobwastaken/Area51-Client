using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu
{
	internal class CopyData : BaseModule
	{
		public CopyData()
			: base("Copy Info", "This gives you the name, asseturl & imageurl.", Main.Instance.AvatarSettings, ButtonIcons.CopyIcon)
		{
		}

		public override void OnEnable()
		{
			ApiAvatar apiAvatar = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_ApiAvatar_0;
			AlienMisc.SetClipboard("Avatar Name: " + apiAvatar.name + " | AssetURL Name: " + apiAvatar.assetUrl + " | ImageURL: " + apiAvatar.imageUrl + "\n");
		}
	}
}

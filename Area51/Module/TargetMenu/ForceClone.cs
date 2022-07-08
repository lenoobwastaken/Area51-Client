using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu
{
	internal class ForceClone : BaseModule
	{
		public ForceClone()
			: base("ForceClone", "Clones public\\Cloneable avatars.", Main.Instance.Targetbutton, ButtonIcons.AlienCloneIcon)
		{
		}

		public override void OnEnable()
		{
			ApiAvatar apiAvatar = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_ApiAvatar_0;
			if (apiAvatar.releaseStatus == "public")
			{
				PlayerWrapper.ChangeAvatar(apiAvatar.id);
			}
			LogHandler.LogDebug("[Info] -> ForceClone Completed!");
		}
	}
}

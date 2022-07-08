using Area51.SDK;
using UnityEngine;
using VRC.Core;

namespace Area51.Module.TargetMenu
{
	internal class ForceLewd : BaseModule
	{
		public GameObject localPlayer = PlayerWrapper.LocalPlayer.gameObject;

		public GameObject playerMirrFix = PlayerWrapper.GetPlayerMirrFix();

		public GameObject playerMirrFix2 = PlayerWrapper.GetPlayerMirrFix2();

		public ForceLewd()
			: base("Force Lewd", "Removes Players Cloths", Main.Instance.Targetbutton, ButtonIcons.CopyIcon)
		{
		}

		public override void OnEnable()
		{
			APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
			if (aPIUser.id != "")
			{
				localPlayer.Lewdify();
				playerMirrFix.Lewdify();
				playerMirrFix2.Lewdify();
			}
			LogHandler.Log(LogHandler.Colors.Green, "Force Lewdifed " + aPIUser.displayName);
			LogHandler.LogDebug("Force Lewdifed " + aPIUser.displayName);
		}
	}
}

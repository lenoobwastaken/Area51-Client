using System;
using Area51.SDK;

namespace Area51.Module.TargetMenu.World_Hacks.JustB
{
	internal class LockPlayerMovement : BaseModule
	{
		public LockPlayerMovement()
			: base("Lock Movement", "Forcefully Lock's Player", Main.Instance.JubstBSettings, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.LogDebug("That nigga cant move");
				UdonExploitManager.ObjectEvent("VRCBilliards", "OnDesktopTopDownViewStart", 1);
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}

		public override void OnDisable()
		{
			try
			{
				UdonExploitManager.ObjectEvent("VRCBilliards", "OnPutDownCueLocally", 1);
				LogHandler.LogDebug("That nigga can move");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class BlindPeople : BaseModule
	{
		public BlindPeople()
			: base("Lock Everyone", "Blinds People", Main.Instance.Justbbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Blinded Everyones Vision");
				UdonExploitManager.ObjectEvent("VRCBilliards", "OnDesktopTopDownViewStart", 0);
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
				UdonExploitManager.ObjectEvent("VRCBilliards", "OnPutDownCueLocally", 0);
				LogHandler.Log(LogHandler.Colors.Green, "UnBlinded Everyones Vision");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

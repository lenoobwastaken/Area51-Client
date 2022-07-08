using System;
using System.Diagnostics;
using System.IO;
using Area51.SDK;
using Area51.SDK.Security;

namespace Area51.Module.Settings.Preformance
{
	internal class QuickRestart : BaseModule
	{
		public QuickRestart()
			: base("Quick Restart", "Restart VRChat can also be triggerd by pressing \nctrl alt backspace", Main.Instance.SettingsButtonpreformance, ButtonIcons.RefreshIcon)
		{
		}

		public override void OnEnable()
		{
			try
			{
			
			}
			catch (Exception)
			{
			}
		}
	}
}

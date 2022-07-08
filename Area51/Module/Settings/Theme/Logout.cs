using System;
using System.Diagnostics;
using System.IO;
using Area51.SDK;
using Area51.SDK.Security;

namespace Area51.Module.Settings.Theme
{
	internal class Logout : BaseModule
	{
		public Logout()
			: base("Logout", "This logs you our and exist vrchat.", Main.Instance.SettingsButtonpreformance, ButtonIcons.PowerIcon)
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

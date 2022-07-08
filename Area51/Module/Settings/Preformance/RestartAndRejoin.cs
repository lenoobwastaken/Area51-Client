using System;
using System.Diagnostics;
using System.IO;
using Area51.SDK;
using Area51.SDK.Security;
using VRC.Core;

namespace Area51.Module.Settings.Preformance
{
	internal class RestartAndRejoin : BaseModule
	{
		public RestartAndRejoin()
			: base("Restart\nReJoin", "Restart VRChat can also be triggerd by pressing \nctrl alt backspace", Main.Instance.SettingsButtonpreformance, ButtonIcons.RocketIcon)
		{
		}

		public override void OnEnable()
		{
			ApiWorldInstance field_Internal_Static_ApiWorldInstance_ = RoomManager.field_Internal_Static_ApiWorldInstance_0;
			if (VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_VRCPlayerApi_0.IsUserInVR())
			{
				Process.Start(Directory.GetCurrentDirectory() + "/VRChat.exe", "vrchat://launch?id=" + field_Internal_Static_ApiWorldInstance_.id);
			}
			else
			{
				Process.Start(Directory.GetCurrentDirectory() + "/VRChat.exe", "vrchat://launch?id=" + field_Internal_Static_ApiWorldInstance_.id + " --no-vr");
			}
			try
			{
			
		
			}
			catch (Exception)
			{
			}
		}
	}
}

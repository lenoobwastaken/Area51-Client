using System;
using System.Diagnostics;
using System.IO;
using Area51.SDK;

namespace Area51.Module.TargetMenu
{
	internal class ReUploadTUT : BaseModule
	{
		public ReUploadTUT()
			: base("Tutorial", "Opens the tutorial textfile.", Main.Instance.AvatarSettings, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				Process.Start(Directory.GetCurrentDirectory() + "\\Area51\\Reuploader\\Data\\Tutorial");
				LogHandler.Log(LogHandler.Colors.Green, "[Re-Uploader] Lunching ReUploader\n");
			}
			catch (Exception)
			{
			}
		}
	}
}

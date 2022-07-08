using System;
using System.Diagnostics;
using System.IO;
using Area51.SDK;

namespace Area51.Module.TargetMenu
{
	internal class ReUploadAvatar : BaseModule
	{
		public ReUploadAvatar()
			: base("ReUpload", "Opens reuploader's folder.", Main.Instance.AvatarSettings)
		{
		}

		public override void OnEnable()
		{
			try
			{
				Process.Start(Directory.GetCurrentDirectory() + "\\Area51\\Reuploader");
				LogHandler.Log(LogHandler.Colors.Green, "[Re-Uploader] Lunching ReUploader\n");
			}
			catch (Exception)
			{
			}
		}
	}
}

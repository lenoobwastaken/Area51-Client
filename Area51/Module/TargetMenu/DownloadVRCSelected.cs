using System;
using System.Net;
using Area51.SDK;
using VRC.Core;

namespace Area51.Module.TargetMenu
{
	internal class DownloadVRCSelected : BaseModule
	{
		public DownloadVRCSelected()
			: base("VRCA", "Download Users VRCA", Main.Instance.Targetbutton, ButtonIcons.DownloadIcon)
		{
		}

		public override void OnEnable()
		{
			using WebClient webClient = new WebClient
			{
				Headers = { "User-Agent: Other" }
			};
			ApiAvatar apiAvatar = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_ApiAvatar_0;
			webClient.DownloadFileAsync(new Uri(apiAvatar.assetUrl), "Area51/VRCA/" + apiAvatar.name + "_" + apiAvatar.id + ".vrca");
			LogHandler.Log(LogHandler.Colors.Grey, "Downloaded Selected User VRCA Completed");
			LogHandler.LogDebug("[Ripper] -> Downloaded Selected User VRCA Completed!");
		}
	}
}

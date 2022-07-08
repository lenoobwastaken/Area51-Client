using System;
using System.Collections;
using System.Net;
using System.Threading.Tasks;
using Area51.Events;
using Area51.SDK;
using MelonLoader;
using UnityEngine;
using VRC;

namespace Area51.Module.Settings.Logging
{
	internal class VCRALogger : BaseModule, OnPlayerJoinEvent
	{
		public VCRALogger()
			: base("VRCA Logger", "[Used For Reuploading] Logs VRCA's", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnPlayerJoinEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnPlayerJoinEvents.Remove(this);
		}

		public void OnPlayerJoin(VRC.Player player)
		{
			LogHandler.Log(LogHandler.Colors.Green, "Username: " + player.prop_VRCPlayerApi_0.displayName + "\nAvatarID: " + player.prop_ApiAvatar_0.id, timeStamp: true);
			LogHandler.LogDebug("[Avatar Logger] User: " + player.prop_VRCPlayerApi_0.displayName);
			Task.Run(delegate
			{
				MelonCoroutines.Start(LogVRCA(player));
			});
		}

		public IEnumerator LogVRCA(VRC.Player player)
		{
			using (WebClient webClient = new WebClient
			{
				Headers = { "User-Agent: Other" }
			})
			{
				webClient.DownloadFileAsync(new Uri(player.prop_ApiAvatar_0.assetUrl), "Area51/VRCA/" + player.prop_ApiAvatar_0.name);
				LogHandler.Log(LogHandler.Colors.Grey, "Yeeted -> " + player.prop_VRCPlayerApi_0.displayName + "'s Avatar.");
			}
			yield return new WaitForSecondsRealtime(0.1f);
		}
	}
}

using Area51.Events;
using Area51.SDK;
using VRC;

namespace Area51.Module.Settings.Logging
{
	internal class AvatarLogger : BaseModule, OnPlayerJoinEvent
	{
		public AvatarLogger()
			: base("Avatar Logger", "Logs Avatars In World", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
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
			LogHandler.Log(LogHandler.Colors.Green, "Username: " + player.prop_VRCPlayerApi_0.displayName, timeStamp: true);
			LogHandler.Log(LogHandler.Colors.Green, "AvatarID: " + player.prop_ApiAvatar_0.id, timeStamp: true);
			LogHandler.Log(LogHandler.Colors.Green, "URL:  " + player.prop_ApiAvatar_0.assetUrl, timeStamp: true);
			LogHandler.LogDebug("[Avatar Logger] User: " + player.prop_VRCPlayerApi_0.displayName);
		}
	}
}

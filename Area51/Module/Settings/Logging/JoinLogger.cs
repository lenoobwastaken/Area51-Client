using Area51.Events;
using Area51.SDK;
using VRC;
using VRC.Core;

namespace Area51.Module.Settings.Logging
{
	internal class JoinLogger : BaseModule, OnPlayerJoinEvent, OnPlayerLeaveEvent
	{
		public JoinLogger()
			: base("Join/Leave Log", "Logs Players Joining And Leaving", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnPlayerJoinEvents.Add(this);
			Main.Instance.OnPlayerLeaveEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnPlayerJoinEvents.Remove(this);
			Main.Instance.OnPlayerLeaveEvents.Remove(this);
		}

		void OnPlayerJoinEvent.OnPlayerJoin(VRC.Player player)
		{
			if (!(player.prop_APIUser_0.displayName == APIUser.CurrentUser.displayName))
			{
				LogHandler.Log(LogHandler.Colors.Blue, $"Player Joined ~> Username: {player.prop_APIUser_0.displayName} | Photon ID: {player.prop_VRCPlayerApi_0.playerId} | UserID: {player.prop_APIUser_0.id}");
				LogHandler.LogDebug("Player Joined ~> Username: " + player.prop_APIUser_0.displayName);
			}
		}

		public void PlayerLeave(VRC.Player player)
		{
			if (!(player.prop_APIUser_0.displayName == APIUser.CurrentUser.displayName))
			{
				LogHandler.Log(LogHandler.Colors.Blue, "Player Left ~> Username: " + player.prop_APIUser_0.displayName + " | UserID: " + player.prop_APIUser_0.id);
				LogHandler.LogDebug("Player Left ~> Username: " + player.prop_APIUser_0.displayName);
			}
		}
	}
}

using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class BlindAll : BaseModule
	{
		public BlindAll()
			: base("Blind Everyone", "Black Screen 4 Seconds", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Blinded Everyone In The Lobby");
				LogHandler.LogDebug("Blinded Everyone In The Lobby");
				UdonExploitManager.udonsend("OnLocalPlayerFlashbanged", "everyone");
				UdonExploitManager.udonsend("OnLocalPlayerBlinded", "everyone");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

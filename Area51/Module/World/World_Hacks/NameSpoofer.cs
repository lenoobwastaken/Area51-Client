using Area51.Events;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks
{
	internal class NameSpoofer : BaseModule, OnUpdateEvent
	{
		private string realDisplayName;

		private string spoofedname = string.Empty;

		public NameSpoofer()
			: base("Name Spoof", "Enable Before You Walk In.", Main.Instance.GameCheatsMenu, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			realDisplayName = PlayerWrapper.GetDisplayName;
			spoofedname = AlienMisc.GetClipboard();
			Main.Instance.OnUpdateEvents.Add(this);
			LogHandler.LogDebug("Name Spoofer -> Enabled");
		}

		public override void OnDisable()
		{
			PlayerWrapper.SpoofDisplayname(realDisplayName);
			LogHandler.LogDebug("Name Spoofer -> Disabled");
			Main.Instance.OnUpdateEvents.Remove(this);
		}

		public void OnUpdate()
		{
			try
			{
				if (toggled)
				{
					_ = PlayerWrapper.GetDisplayName != spoofedname;
					PlayerWrapper.SpoofDisplayname(spoofedname);
				}
			}
			catch
			{
			}
		}
	}
}

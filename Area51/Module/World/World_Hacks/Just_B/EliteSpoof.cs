using Area51.Events;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class EliteSpoof : BaseModule, OnUpdateEvent
	{
		public string EliteName;

		public string spoofednamed = string.Empty;

		public EliteSpoof()
			: base("Elite Spoof", "Enable Before You Join Just B.", Main.Instance.Justbbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			EliteName = PlayerWrapper.GetDisplayName;
			spoofednamed = "Blue-Kun";
			Main.Instance.OnUpdateEvents.Add(this);
			LogHandler.LogDebug("Elite Spoof -> Enabled");
		}

		public override void OnDisable()
		{
			PlayerWrapper.SpoofDisplayname(EliteName);
			LogHandler.LogDebug("Elite Spoof -> Disabled");
			Main.Instance.OnUpdateEvents.Remove(this);
		}

		public void OnUpdate()
		{
			try
			{
				if (toggled)
				{
					if (PlayerWrapper.GetDisplayName != spoofednamed)
					{
						PlayerWrapper.SpoofDisplayname(spoofednamed);
					}
					else if (!toggled)
					{
						OnDisable();
					}
				}
			}
			catch
			{
			}
		}
	}
}

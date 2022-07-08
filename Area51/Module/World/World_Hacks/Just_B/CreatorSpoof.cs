using Area51.Events;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class CreatorSpoof : BaseModule, OnUpdateEvent
	{
		public string CreatorName;

		public string spoofednamed = string.Empty;

		public CreatorSpoof()
			: base("Creator Spoof", "Enable Before You Join Just B.", Main.Instance.Justbbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			CreatorName = PlayerWrapper.GetDisplayName;
			spoofednamed = "Blue-kun";
			LogHandler.LogDebug("Creator Spoof -> Enabled");
			Main.Instance.OnUpdateEvents.Add(this);
		}

		public override void OnDisable()
		{
			PlayerWrapper.SpoofDisplayname(CreatorName);
			LogHandler.LogDebug("Creator Spoof -> Disabled");
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

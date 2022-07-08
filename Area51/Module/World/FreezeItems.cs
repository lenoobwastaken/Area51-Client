using Area51.Events;
using Area51.SDK;
using VRC.SDKBase;

namespace Area51.Module.World
{
	internal class FreezeItems : BaseModule, OnUpdateEvent
	{
		public FreezeItems()
			: base("FreezePickups", "No one besides you can use Pickups", Main.Instance.WorldButton, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnUpdateEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnUpdateEvents.Remove(this);
		}

		public void OnUpdate()
		{
			for (int i = 0; i < WorldWrapper.vrc_Pickups.Length; i++)
			{
				Networking.SetOwner(Networking.LocalPlayer, WorldWrapper.vrc_Pickups[i].gameObject);
			}
		}
	}
}

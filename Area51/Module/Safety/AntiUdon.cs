using Area51.Events;
using Area51.SDK;
using VRC;

namespace Area51.Module.Safety
{
	internal class AntiUdon : BaseModule, OnUdonEvent
	{
		public AntiUdon()
			: base("Anti Udon", "Anti Udon Events", Main.Instance.Networkbutton, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnUdonEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnUdonEvents.Remove(this);
		}

		public bool OnUdon(string __0, VRC.Player __1)
		{
			if (__1.field_Private_APIUser_0.id == PlayerWrapper.LocalPlayer.prop_APIUser_0.id)
			{
				return true;
			}
			return false;
		}
	}
}

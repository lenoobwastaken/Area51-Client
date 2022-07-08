using Area51.SDK;

namespace Area51.Module.World.World_Hacks
{
	internal class CustomTriggerEvent : BaseModule
	{
		public CustomTriggerEvent()
			: base("Send\n Trigger Event", "Sends Custom udon event from clipboard", Main.Instance.udonexploitbutton, ButtonIcons.SearchIcon)
		{
		}

		public override void OnEnable()
		{
			string clipboard = AlienMisc.GetClipboard();
			UdonExploitManager.trigersend(clipboard);
		}
	}
}

using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class EnableRooms : BaseModule
	{
		private bool state;

		public EnableRooms()
			: base("Bypass VR ONLY", "Allows PC's Users to use the VR Only Button.", Main.Instance.Justhbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			JustHClub.EnableVROnlyBtn(state: true);
			LogHandler.LogDebug("All Floors -> Enabled");
		}

		public override void OnDisable()
		{
			JustHClub.EnableVROnlyBtn(state: false);
			LogHandler.LogDebug("All Floors -> Disable");
		}
	}
}

using Area51.SDK;
using UnityEngine;

namespace Area51.Module.Player
{
	internal class FPSUnlocker : BaseModule
	{
		public FPSUnlocker()
			: base("FPS Unlocker", "300 Fps", Main.Instance.SettingsButtonpreformance, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			LogHandler.Log(LogHandler.Colors.Green, "Application Framerate Set To 140");
			Application.targetFrameRate = 1000;
		}

		public override void OnDisable()
		{
			LogHandler.Log(LogHandler.Colors.Green, "Application Framerate Set To 90");
			Application.targetFrameRate = 90;
		}
	}
}

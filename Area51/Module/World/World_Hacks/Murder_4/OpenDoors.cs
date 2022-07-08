using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class OpenDoors : BaseModule
	{
		public OpenDoors()
			: base("Open Doors", "Open All Doors", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Opened All Doors");
				LogHandler.LogDebug("Opened All Doors");
				MurderMisc.ObjectInteract("Interact open");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

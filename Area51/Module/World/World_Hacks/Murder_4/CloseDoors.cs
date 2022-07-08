using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class CloseDoors : BaseModule
	{
		public CloseDoors()
			: base("Close Doors", "Close All Doors", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Closed All Doors");
				LogHandler.LogDebug("Closed All Doors");
				MurderMisc.ObjectInteract("Interact close");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

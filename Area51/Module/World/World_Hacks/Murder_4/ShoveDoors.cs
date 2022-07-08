using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class ShoveDoors : BaseModule
	{
		public ShoveDoors()
			: base("Shove Doors", "Shove All Doors", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Lock All Doors");
				LogHandler.LogDebug("Lock All Doors");
				MurderMisc.ObjectInteract("Interact shove");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

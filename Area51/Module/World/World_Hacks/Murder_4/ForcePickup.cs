using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class ForcePickup : BaseModule
	{
		public ForcePickup()
			: base("Force Pickup", "Allows You To Steal Other's Pickups", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Force Pickup Is Active");
				LogHandler.LogDebug("Force Pickup Is Active");
				MurderMisc.pickupsteal();
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class BringSmoke : BaseModule
	{
		public BringSmoke()
			: base("Give Smoke", "Gives You Every Item", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Teleported Smoke To Your Position");
				LogHandler.LogDebug("Teleported Smoke To Your Position");
				MurderMisc.MurderGive("Smoke");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

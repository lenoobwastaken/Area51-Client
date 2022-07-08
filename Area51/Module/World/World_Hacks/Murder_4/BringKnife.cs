using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class BringKnife : BaseModule
	{
		public BringKnife()
			: base("Give Knife", "Gives You Every Item", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Teleported Knife To Your Position");
				LogHandler.LogDebug("Teleported Knife To Your Position");
				MurderMisc.MurderGive("Knife");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

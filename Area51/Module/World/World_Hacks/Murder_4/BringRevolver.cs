using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class BringRevolver : BaseModule
	{
		public BringRevolver()
			: base("Give Revolver", "Gives You Every Item", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Teleported Revolver To Your Position");
				LogHandler.LogDebug("Teleported Revolver To Your Position");
				MurderMisc.MurderGive("Revolver");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

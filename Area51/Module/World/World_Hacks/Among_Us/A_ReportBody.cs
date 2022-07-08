using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_ReportBody : BaseModule
	{
		public A_ReportBody()
			: base("Report Body", "", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Found Dead Body Now Reporting");
				A_Misc.AmongUsMod("OnBodyWasFound");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, "No Dead Body Found " + ex.ToString());
			}
		}
	}
}

using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_TaskDone : BaseModule
	{
		public A_TaskDone()
			: base("Complete Tasks", "", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "All Tasks Completed");
				A_Misc.AmongUsMod("OnLocalPlayerCompletedTask");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

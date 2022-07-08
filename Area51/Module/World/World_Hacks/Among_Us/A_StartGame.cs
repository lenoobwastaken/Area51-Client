using System;
using Area51.SDK;

namespace Area51.Module.World.World_Hacks.Among_Us
{
	internal class A_StartGame : BaseModule
	{
		public A_StartGame()
			: base("Start Game", "", Main.Instance.Amongusbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Game Started");
				A_Misc.AmongUsMod("Btn_Start");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

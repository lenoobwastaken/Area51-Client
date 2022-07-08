using System;
using Area51.SDK;
using MelonLoader;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class Room6 : BaseModule
	{
		public Room6()
			: base("Room 6", "Force Join Room", Main.Instance.JustBRoomsbutton, ButtonIcons.MovementMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				MelonCoroutines.Start(JustBClub.EnterRoom(6));
				LogHandler.Log(LogHandler.Colors.Green, "Force Joined Room!");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

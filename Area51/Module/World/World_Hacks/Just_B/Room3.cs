using System;
using Area51.SDK;
using MelonLoader;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class Room3 : BaseModule
	{
		public Room3()
			: base("Room 3", "Force Join Room", Main.Instance.JustBRoomsbutton, ButtonIcons.MovementMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				MelonCoroutines.Start(JustBClub.EnterRoom(3));
				LogHandler.Log(LogHandler.Colors.Green, "Force Joined Room!");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

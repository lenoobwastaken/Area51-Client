using System;
using Area51.SDK;
using MelonLoader;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class Room7 : BaseModule
	{
		public Room7()
			: base("VIP Room", "Force Join Room", Main.Instance.JustBRoomsbutton, ButtonIcons.MovementMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				MelonCoroutines.Start(JustBClub.EnterRoom(7));
				LogHandler.Log(LogHandler.Colors.Green, "Force Joined VIP Room!");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}
	}
}

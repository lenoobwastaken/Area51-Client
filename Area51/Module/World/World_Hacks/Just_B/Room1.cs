using Area51.SDK;
using MelonLoader;

namespace Area51.Module.World.World_Hacks.Just_B
{
	internal class Room1 : BaseModule
	{
		public Room1()
			: base("Room 1", "Force Join Room", Main.Instance.JustBRoomsbutton, ButtonIcons.MovementMenu)
		{
		}

		public override void OnEnable()
		{
			MelonCoroutines.Start(JustBClub.EnterRoom(1));
			LogHandler.Log(LogHandler.Colors.Green, "Force Joined Room!");
		}
	}
}

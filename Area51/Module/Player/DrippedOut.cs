using Area51.SDK;

namespace Area51.Module.Player
{
	internal class DrippedOut : BaseModule
	{
		public DrippedOut()
			: base("Drippedout", "Don't be a bitch, press it nigga!", Main.Instance.PlayerButton, ButtonIcons.DrippedOutIcon)
		{
		}

		public override void OnEnable()
		{
			PlayerWrapper.ChangeAvatar("avtr_8af6ea5d-843f-4003-a7a9-5380e538418b");
			LogHandler.LogDebug("Changed Avatar To Paul");
		}
	}
}

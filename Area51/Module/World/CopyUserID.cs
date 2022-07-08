using Area51.SDK;

namespace Area51.Module.World
{
	internal class CopyUserID : BaseModule
	{
		public CopyUserID()
			: base("Get User ID", "Copy the UserID to clipboard", Main.Instance.PlayerButton, ButtonIcons.CopyIcon)
		{
		}

		public override void OnEnable()
		{
			if (PlayerWrapper.GetUserID != "")
			{
				AlienMisc.SetClipboard(PlayerWrapper.GetUserID);
			}
			LogHandler.Log(LogHandler.Colors.Green, "User ID: " + PlayerWrapper.GetUserID + " Copied to clipboard.");
		}
	}
}

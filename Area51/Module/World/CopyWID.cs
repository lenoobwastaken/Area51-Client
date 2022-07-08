using Area51.SDK;

namespace Area51.Module.World
{
	internal class CopyWID : BaseModule
	{
		public CopyWID()
			: base("World ID", "Copies the World & InstanceID", Main.Instance.WorldButton, ButtonIcons.WorldMenu)
		{
		}

		public override void OnEnable()
		{
			if (PlayerWrapper.worldLocation != "")
			{
				AlienMisc.SetClipboard(PlayerWrapper.worldLocation);
				LogHandler.Log(LogHandler.Colors.Green, "World ID: " + PlayerWrapper.worldLocation + " copied to clipboard.");
				LogHandler.LogDebug("Copied World ID To Clipboard!");
			}
		}
	}
}

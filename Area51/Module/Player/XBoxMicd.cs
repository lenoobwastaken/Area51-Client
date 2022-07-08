using Area51.SDK;

namespace Area51.Module.Player
{
	internal class XBoxMicd : BaseModule
	{
		public XBoxMicd()
			: base("XboxMic", "1v1 in COD bro", Main.Instance.PlayerButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			PlayerWrapper.LocalPlayer.SetLocalBitrate(BitRate.BitRate_8K);
		}

		public override void OnDisable()
		{
			PlayerWrapper.LocalPlayer.SetLocalBitrate(BitRate.BitRate_24K);
		}
	}
}

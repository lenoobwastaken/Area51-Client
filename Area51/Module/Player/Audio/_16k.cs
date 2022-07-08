namespace Area51.Module.Player.Audio
{
	internal class _16k : BaseModule
	{
		public _16k()
			: base("16k BitRate", "16k BitRate", Main.Instance.AudioButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_USpeaker_0.field_Public_BitRate_0 = BitRate.BitRate_16K;
		}

		public override void OnDisable()
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_USpeaker_0.field_Public_BitRate_0 = BitRate.BitRate_24K;
		}
	}
}

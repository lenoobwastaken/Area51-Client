namespace Area51.Module.Player.Audio
{
	internal class _512k : BaseModule
	{
		public _512k()
			: base("512k BitRate", "512k BitRate", Main.Instance.AudioButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_USpeaker_0.field_Private_USpeakSettingsData_0.field_Public_BitRate_0 = BitRate.BitRate_512k;
		}

		public override void OnDisable()
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_USpeaker_0.field_Private_USpeakSettingsData_0.field_Public_BitRate_0 = BitRate.BitRate_24K;
		}
	}
}

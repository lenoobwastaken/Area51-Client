namespace Area51.Module.Player
{
	internal class XBoxMic : BaseModule
	{
		public XBoxMic()
			: base("Xbox Mic", "1v1 in COD bro", Main.Instance.AudioButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_USpeaker_0.field_Private_USpeakSettingsData_0.field_Public_BitRate_0 = BitRate.BitRate_8K;
		}

		public override void OnDisable()
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_USpeaker_0.field_Private_USpeakSettingsData_0.field_Public_BitRate_0 = BitRate.BitRate_24K;
		}
	}
}

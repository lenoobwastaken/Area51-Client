namespace Area51.Module.Player
{
	internal class LoudMic : BaseModule
	{
		public LoudMic()
			: base("LoudMic", "Microphone Go Brrrr", Main.Instance.PlayerButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			USpeaker.field_Internal_Static_Single_1 = float.MaxValue;
		}

		public override void OnDisable()
		{
			USpeaker.field_Internal_Static_Single_1 = 1f;
		}
	}
}

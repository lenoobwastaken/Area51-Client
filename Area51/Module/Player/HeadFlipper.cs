using VRC.DataModel;

namespace Area51.Module.Player
{
	internal class HeadFlipper : BaseModule
	{
		private NeckRange orgin;

		public HeadFlipper()
			: base("HeadFlipper", "Fuck your desktop neck", Main.Instance.PlayerButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			orgin = VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<GamelikeInputController>().field_Protected_NeckMouseRotator_0.field_Public_NeckRange_0;
			VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<GamelikeInputController>().field_Protected_NeckMouseRotator_0.field_Public_NeckRange_0 = new NeckRange(float.MinValue, float.MaxValue, 0f);
		}

		public override void OnDisable()
		{
			VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<GamelikeInputController>().field_Protected_NeckMouseRotator_0.field_Public_NeckRange_0 = orgin;
		}
	}
}

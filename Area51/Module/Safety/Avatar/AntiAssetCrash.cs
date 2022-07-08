namespace Area51.Module.Safety.Avatar
{
	internal class AntiAssetCrash : BaseModule
	{
		public AntiAssetCrash()
			: base("Anti Currupted", "Destroys Currupted Asset Bundles", Main.Instance.Avatarbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}
	}
}

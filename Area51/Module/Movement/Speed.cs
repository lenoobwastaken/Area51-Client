using VRC.SDKBase;

namespace Area51.Module.Movement
{
	internal class Speed : BaseModule
	{
		public Speed()
			: base("Speed", "go brrrrrrrrrrrrrrrrrr", Main.Instance.MovementButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			Networking.LocalPlayer.SetWalkSpeed(Networking.LocalPlayer.GetWalkSpeed() + 2f);
			Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() + 2f);
			Networking.LocalPlayer.SetStrafeSpeed(Networking.LocalPlayer.GetStrafeSpeed() + 3f);
		}

		public override void OnDisable()
		{
			Networking.LocalPlayer.SetWalkSpeed(6f);
			Networking.LocalPlayer.SetRunSpeed(7f);
			Networking.LocalPlayer.SetStrafeSpeed(6f);
			Networking.LocalPlayer.SetWalkSpeed(Networking.LocalPlayer.GetWalkSpeed() - 2f);
			Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() - 2.5f);
			Networking.LocalPlayer.SetStrafeSpeed(Networking.LocalPlayer.GetStrafeSpeed() - 3f);
		}
	}
}

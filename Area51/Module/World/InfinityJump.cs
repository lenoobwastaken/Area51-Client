using Area51.Events;
using UnityEngine;
using VRC.SDKBase;

namespace Area51.Module.World
{
	internal class InfinityJump : BaseModule, OnUpdateEvent
	{
		public InfinityJump()
			: base("Jet Pack", "InfinityJump go brrrr", Main.Instance.MovementButton, null, isToggle: true, save: true)
		{
		}

		public void OnUpdate()
		{
			if (VRCInputManager.Method_Public_Static_VRCInput_String_0("Jump").prop_Single_2 == 1f)
			{
				Vector3 velocity = Networking.LocalPlayer.GetVelocity();
				velocity.y = Networking.LocalPlayer.GetJumpImpulse();
				Networking.LocalPlayer.SetVelocity(velocity);
			}
		}

		public override void OnEnable()
		{
			Main.Instance.OnUpdateEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnUpdateEvents.Remove(this);
		}
	}
}

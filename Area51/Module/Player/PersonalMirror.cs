using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;

namespace Area51.Module.Player
{
	internal class PersonalMirror : BaseModule
	{
		public static GameObject Mirror;

		public PersonalMirror()
			: base("Personal Mirror", "Spawns A Personal Mirror", Main.Instance.PlayerButton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			VRCPlayer field_Internal_Static_VRCPlayer_ = VRCPlayer.field_Internal_Static_VRCPlayer_0;
			Vector3 position = field_Internal_Static_VRCPlayer_.transform.position + field_Internal_Static_VRCPlayer_.transform.forward;
			position.y += 1.47058821f;
			Mirror = GameObject.CreatePrimitive(PrimitiveType.Quad);
			Mirror.transform.position = position;
			Mirror.transform.rotation = field_Internal_Static_VRCPlayer_.transform.rotation;
			Mirror.transform.localScale = new Vector3(3f, 2f, 1f);
			Mirror.name = "Custom Mirror";
			Mirror.AddComponent<MeshRenderer>();
			Mirror.GetComponent<MeshRenderer>().material.shader = Shader.Find("FX/MirrorReflection");
			Mirror.AddComponent<MirrorReflection>();
			VRC_MirrorReflection vRC_MirrorReflection = Mirror.AddComponent<VRCMirrorReflection>();
			LayerMask reflectLayers = default(LayerMask);
			reflectLayers.value = 263680;
			vRC_MirrorReflection.m_ReflectLayers = reflectLayers;
			Mirror.AddComponent<VRCPickup>();
			Mirror.GetComponent<VRCPickup>().proximity = 0.3f;
			Mirror.GetComponent<VRCPickup>().pickupable = true;
			Mirror.GetComponent<VRCPickup>().allowManipulationWhenEquipped = false;
			Mirror.AddComponent<Rigidbody>();
			Mirror.GetComponent<Rigidbody>().useGravity = false;
			Mirror.GetComponent<Rigidbody>().isKinematic = true;
			Object.Destroy(Mirror.GetComponent<Collider>());
			Mirror.AddComponent<BoxCollider>().size = new Vector3(1f, 1f, 0.05f);
			Mirror.GetComponent<BoxCollider>().isTrigger = true;
		}

		public override void OnDisable()
		{
			if (Mirror != null)
			{
				Object.Destroy(Mirror);
				Mirror = null;
			}
		}
	}
}

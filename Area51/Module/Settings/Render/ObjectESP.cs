using UnhollowerBaseLib;
using UnityEngine;
using VRC.SDKBase;

namespace Area51.Module.Settings.Render
{
	internal class ObjectESP : BaseModule
	{
		public ObjectESP()
			: base("Item ESP", "Draws Items threw walls", Main.Instance.SettingsButtonrender, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			PickupESP(state: true);
		}

		public override void OnDisable()
		{
			PickupESP(state: false);
		}

		internal static void PickupESP(bool state)
		{
			Il2CppArrayBase<VRC_Pickup> il2CppArrayBase = Resources.FindObjectsOfTypeAll<VRC_Pickup>();
			foreach (VRC_Pickup item in il2CppArrayBase)
			{
				if (!(item == null) && !(item.gameObject == null) && item.gameObject.active && item.enabled && item.pickupable && !item.name.Contains("ViewFinder") && !(HighlightsFX.prop_HighlightsFX_0 == null))
				{
					HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(item.GetComponentInChildren<MeshRenderer>(), state);
				}
			}
		}
	}
}

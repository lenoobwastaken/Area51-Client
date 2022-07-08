using UnhollowerBaseLib;
using UnityEngine;
using VRC.SDKBase;

namespace Area51.Module.Settings.Render
{
	internal class TriggerESP : BaseModule
	{
		public TriggerESP()
			: base("Trigger ESP", "World Trigger ESP", Main.Instance.SettingsButtonrender, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			triggeresp(state: true);
		}

		public override void OnDisable()
		{
			triggeresp(state: false);
		}

		internal static void triggeresp(bool state)
		{
			Il2CppArrayBase<VRC_Trigger> il2CppArrayBase = Resources.FindObjectsOfTypeAll<VRC_Trigger>();
			foreach (VRC_Trigger item in il2CppArrayBase)
			{
				if (!(item == null) && !(item.gameObject == null) && item.gameObject.active && !item.name.Contains("ViewFinder") && !(HighlightsFX.prop_HighlightsFX_0 == null))
				{
					HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(item.GetComponentInChildren<MeshRenderer>(), state);
				}
			}
		}
	}
}

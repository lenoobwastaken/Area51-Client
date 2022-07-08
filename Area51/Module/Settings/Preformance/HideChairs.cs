using Area51.SDK;
using UnhollowerBaseLib;
using UnityEngine;
using VRC.SDK3.Avatars.Components;

namespace Area51.Module.Settings.Preformance
{
	internal class HideChairs : BaseModule
	{
		public HideChairs()
			: base("Hide Chairs", "Hides Chairs local", Main.Instance.SettingsButtonpreformance, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			SetAllObjectsOfTypeChairs(state: false);
			LogHandler.LogDebug("Chairs Hidden");
		}

		public override void OnDisable()
		{
			SetAllObjectsOfTypeChairs(state: true);
			LogHandler.LogDebug("Chairs UnHidden");
		}

		internal static void SetAllObjectsOfTypeChairs(bool state)
		{
			Il2CppArrayBase<VRCStation> il2CppArrayBase = Resources.FindObjectsOfTypeAll<VRCStation>();
			for (int i = 0; i < il2CppArrayBase.Count; i++)
			{
				VRCStation vRCStation = il2CppArrayBase[i];
				if (!(vRCStation == null) && vRCStation.gameObject.active == !state)
				{
					vRCStation.gameObject.SetActive(state);
				}
			}
		}
	}
}

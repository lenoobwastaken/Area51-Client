using Area51.SDK;
using UnhollowerBaseLib;
using UnityEngine;
using VRC.SDK3.Video.Components;
using VRCSDK2;

namespace Area51.Module.Settings.Preformance
{
	internal class HideVideoPlayers : BaseModule
	{
		public HideVideoPlayers()
			: base("Hide VideoPlayers", "Hides Video Player local", Main.Instance.SettingsButtonpreformance, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			SetAllObjectsOfTypeVideoPlayers(state: false);
			LogHandler.LogDebug("Video Players Hidden");
		}

		public override void OnDisable()
		{
			SetAllObjectsOfTypeVideoPlayers(state: true);
			LogHandler.LogDebug("Video Players UnHidden");
		}

		internal static void SetAllObjectsOfTypeVideoPlayers(bool state)
		{
			Il2CppArrayBase<VRC_SyncVideoPlayer> il2CppArrayBase = Resources.FindObjectsOfTypeAll<VRC_SyncVideoPlayer>();
			for (int i = 0; i < il2CppArrayBase.Count; i++)
			{
				VRC_SyncVideoPlayer vRC_SyncVideoPlayer = il2CppArrayBase[i];
				if (!(vRC_SyncVideoPlayer == null) && vRC_SyncVideoPlayer.gameObject.active == !state)
				{
					vRC_SyncVideoPlayer.gameObject.SetActive(state);
				}
			}
			Il2CppArrayBase<VRCUnityVideoPlayer> il2CppArrayBase2 = Resources.FindObjectsOfTypeAll<VRCUnityVideoPlayer>();
			for (int j = 0; j < il2CppArrayBase2.Count; j++)
			{
				VRCUnityVideoPlayer vRCUnityVideoPlayer = il2CppArrayBase2[j];
				if (!(vRCUnityVideoPlayer == null) && vRCUnityVideoPlayer.gameObject.active == !state)
				{
					vRCUnityVideoPlayer.gameObject.SetActive(state);
				}
			}
		}
	}
}

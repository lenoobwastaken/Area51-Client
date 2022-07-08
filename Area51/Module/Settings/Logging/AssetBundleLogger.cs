using Area51.Events;
using Area51.SDK;
using UnityEngine;

namespace Area51.Module.Settings.Logging
{
	internal class AssetBundleLogger : BaseModule, OnAssetBundleLoadEvent
	{
		public AssetBundleLogger()
			: base("AssetBundle Log", "Logs AssetBundles That Load", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnAssetBundleLoadEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnAssetBundleLoadEvents.Remove(this);
		}

		public bool OnAvatarAssetBundleLoad(GameObject avatar, string avatarID)
		{
			LogHandler.Log(LogHandler.Colors.Blue, "Type: " + avatar.name + " |  Loaded Asset Bundle");
			return true;
		}
	}
}

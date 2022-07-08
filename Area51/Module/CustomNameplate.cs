using System;
using Area51.Module.Settings.Render;
using Area51.SDK;
using TMPro;
using UnityEngine;
using VRC;

namespace Area51.Module
{
	internal class CustomNameplate : MonoBehaviour
	{
		public VRC.Player player;

		private TextMeshProUGUI Nameplatext;

		private TextMeshProUGUI stafftext;

		private byte frames;

		private byte ping;

		private int noUpdateCount;

		public string UserID = "";

		public bool isStaf;

		public static string rank;

		public CustomNameplate(IntPtr ptr)
			: base(ptr)
		{
		}

		public string SetCustomRank(string id)
		{
			string result = "<color=#BF40BF>This is a custom nameplate!</color>";
			if (id == "usr_941eedba-2784-4974-808b-adcedf557408")
			{
				return result;
			}
			return "VRC User";
		}

		private void Start()
		{
			Transform transform = UnityEngine.Object.Instantiate(base.gameObject.transform.Find("Contents/Quick Stats"), base.gameObject.transform.Find("Contents"));
			transform.parent = base.gameObject.transform.Find("Contents");
			transform.name = "Area51_Staffplate";
			transform.localPosition = new Vector3(0f, 102f, 0f);
			transform.localScale = new Vector3(1f, 1f, 2f);
			transform.gameObject.SetActive(value: true);
			stafftext = transform.Find("Trust Text").GetComponent<TextMeshProUGUI>();
			stafftext.fontStyle = FontStyles.Subscript;
			Transform transform2 = UnityEngine.Object.Instantiate(base.gameObject.transform.Find("Contents/Quick Stats"), base.gameObject.transform.Find("Contents"));
			transform2.parent = base.gameObject.transform.Find("Contents");
			transform2.name = "Area51_nameplate";
			transform2.localPosition = new Vector3(0f, 62f, 0f);
			transform2.localScale = new Vector3(1f, 1f, 2f);
			transform2.gameObject.SetActive(value: true);
			Nameplatext = transform2.Find("Trust Text").GetComponent<TextMeshProUGUI>();
			Nameplatext.color = Color.white;
			Nameplatext.fontStyle = FontStyles.Subscript;
			Nameplatext.isOverlay = true;
			stafftext.isOverlay = true;
			transform2.Find("Trust Icon").gameObject.SetActive(value: false);
			transform2.Find("Performance Icon").gameObject.SetActive(value: false);
			transform2.Find("Performance Text").gameObject.SetActive(value: false);
			transform2.Find("Friend Anchor Stats").gameObject.SetActive(value: false);
			transform.Find("Trust Icon").gameObject.SetActive(value: false);
			transform.Find("Performance Icon").gameObject.SetActive(value: false);
			transform.Find("Performance Text").gameObject.SetActive(value: false);
			transform.Find("Friend Anchor Stats").gameObject.SetActive(value: false);
			frames = player._playerNet.field_Private_Byte_0;
			ping = player._playerNet.field_Private_Byte_1;
			try
			{
				UserID = PlayerWrapper.GetUserID;
			}
			catch
			{
			}
			stafftext.text = "";
			Nameplatext.text = "";
		}

		private void Update()
		{
			if (frames == player._playerNet.field_Private_Byte_0 && ping == player._playerNet.field_Private_Byte_1)
			{
				noUpdateCount++;
			}
			else
			{
				noUpdateCount = 0;
			}
			frames = player._playerNet.field_Private_Byte_0;
			ping = player._playerNet.field_Private_Byte_1;
			string text = "<color=green>Stable</color>";
			if (noUpdateCount > 35)
			{
				text = "<color=yellow>Lagging</color>";
			}
			if (noUpdateCount > 375)
			{
				text = "<color=red>Crashed</color>";
			}
			try
			{
				if (player.GetIsMaster() && CustomNameplates.Staff.Contains(player.prop_APIUser_0.id))
				{
					Nameplatext.text = "[<color=blue>Host</color>] [<color=green>" + player.GetPlatform() + "</color>] | [" + text + "] |<color=white>FPS:</color> " + player.GetFramesColord() + " |<color=white>Ping</color>: " + player.GetPingColord();
					stafftext.text = " Area51 STAFF ";
				}
				else if (CustomNameplates.Staff.Contains(player.prop_APIUser_0.id))
				{
					Nameplatext.text = "[<color=green>" + player.GetPlatform() + "</color>] | [" + text + "] |<color=white>FPS:</color> " + player.GetFramesColord() + " |<color=white>Ping</color>: " + player.GetPingColord();
					stafftext.text = " Area51 STAFF ";
				}
				else if (player.GetIsMaster() && !CustomNameplates.Staff.Contains(player.prop_APIUser_0.id))
				{
					Nameplatext.text = "[<color=blue>Host</color>] [<color=green>" + player.GetPlatform() + "</color>] | [" + text + "] |<color=white>FPS:</color> " + player.GetFramesColord() + " |<color=white>Ping</color>: " + player.GetPingColord();
					stafftext.text = " <color=#BF40BF>VRC USER</color> ";
				}
				else
				{
					Nameplatext.text = "[<color=green>" + player.GetPlatform() + "</color>] | [" + text + "] |<color=white>FPS:</color> " + player.GetFramesColord() + " |<color=white>Ping</color>: " + player.GetPingColord();
					stafftext.text = " <color=#BF40BF>VRC USER</color> ";
				}
			}
			catch (Exception)
			{
			}
		}
	}
}

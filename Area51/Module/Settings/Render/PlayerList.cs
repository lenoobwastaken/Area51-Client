using System;
using System.Collections;
using Area51.Events;
using Area51.SDK;
using Area51.SDK.ButtonAPI;
using MelonLoader;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using VRC;

namespace Area51.Module.Settings.Render
{
	internal class PlayerList : BaseModule, OnPlayerJoinEvent, OnPlayerLeaveEvent
	{
		private QMLable playerList;

		public PlayerList()
			: base("PlayerList", "PlayerList on the side", Main.Instance.SettingsButtonrender, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				playerList.lable.SetActive(value: true);
				playerList.text.alignment = TextAlignmentOptions.Right;
				if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer").activeSelf)
				{
					playerList.lable.transform.localPosition = new Vector3(-526.6402f, -341.6801f, 0f);
				}
				else
				{
					playerList.lable.transform.localPosition = new Vector3(-106.6402f, -341.6801f, 0f);
				}
				playerList.text.color = Color.white;
				playerList.text.GetComponent<TextMeshProUGUI>().fontSize = 15f;
				playerList.text.GetComponent<TextMeshProUGUI>().enableAutoSizing = true;
				Main.Instance.OnPlayerJoinEvents.Add(this);
				Main.Instance.OnPlayerLeaveEvents.Add(this);
				MelonCoroutines.Start(OnUpdate());
			}
			catch (ArgumentNullException)
			{
			}
			catch (Exception)
			{
			}
		}

		public override void OnDisable()
		{
			try
			{
				MelonCoroutines.Stop(OnUpdate());
				playerList.lable.SetActive(value: false);
				Main.Instance.OnPlayerJoinEvents.Remove(this);
				Main.Instance.OnPlayerLeaveEvents.Remove(this);
			}
			catch (ArgumentNullException)
			{
			}
			catch (Exception)
			{
			}
		}

		public override void OnUIInit()
		{
			playerList = new QMLable(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left").transform, -207.1015f, -2.14f, "PlayerList");
			base.OnUIInit();
		}

		public IEnumerator OnUpdate()
		{
			while (toggled)
			{
				try
				{
					string text = "";
					for (int i = 0; i < PlayerWrapper.GetAllPlayers().Length; i++)
					{
						VRC.Player player = PlayerWrapper.GetAllPlayers()[i];
						text += $"[<color=#FFB300>[ID]</color>] {player.GetActorNumber()}";
						if (player.GetIsMaster())
						{
							text += " [<color=#FFB300>H</color>]";
						}
						text = text + " [<color=#FFB300>P</color>] " + player.GetPingColord();
						text = text + " [<color=#FFB300>F</color>] " + player.GetFramesColord();
						text = text + " <color=#" + ColorUtility.ToHtmlStringRGB(player.GetTrustColor()) + ">" + player.GetAPIUser().displayName + "</color>";
						text = text + " <color=#" + ColorUtility.ToHtmlStringRGB(player.GetTrustColor()) + ">" + player.prop_APIUser_0.username + "</color>\n";
					}
					playerList.text.text = text;
				}
				catch
				{
				}
				yield return new WaitForSeconds(0.25f);
			}
		}

		public void OnPlayerJoin(VRC.Player player)
		{
			playerList.text.enableWordWrapping = false;
			playerList.text.fontSizeMin = 30f;
			playerList.text.fontSizeMax = 30f;
			playerList.text.alignment = TextAlignmentOptions.Right;
			playerList.text.color = Color.white;
		}

		public void PlayerLeave(VRC.Player player)
		{
			playerList.text.enableWordWrapping = false;
			playerList.text.fontSizeMin = 30f;
			playerList.text.fontSizeMax = 30f;
			playerList.text.alignment = TextAlignmentOptions.Right;
			playerList.text.color = Color.white;
		}

		public void OnPlayerEnteredRoom(Photon.Realtime.Player player)
		{
			throw new NotImplementedException();
		}
	}
}

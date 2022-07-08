using System;
using Area51.Events;
using Area51.SDK;
using Photon.Realtime;
using UnityEngine;
using VRC;

namespace Area51.Module.Settings.Render
{
	internal class CapsuleEsp : BaseModule, OnPlayerJoinEvent
	{
		public CapsuleEsp()
			: base("Player ESP", "See Players n shit", Main.Instance.SettingsButtonrender, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			for (int i = 0; i < PlayerWrapper.GetAllPlayers().Length; i++)
			{
				HighlightPlayer(PlayerWrapper.GetAllPlayers()[i], state: true);
			}
			Main.Instance.OnPlayerJoinEvents.Add(this);
		}

		public override void OnDisable()
		{
			for (int i = 0; i < PlayerWrapper.GetAllPlayers().Length; i++)
			{
				HighlightPlayer(PlayerWrapper.GetAllPlayers()[i], state: false);
			}
			Main.Instance.OnPlayerJoinEvents.Remove(this);
		}

		public static void HighlightPlayer(VRC.Player player, bool state)
		{
			Renderer renderer;
			if (player == null)
			{
				renderer = null;
			}
			else
			{
				Transform transform = player.transform.Find("SelectRegion");
				renderer = ((transform != null) ? transform.GetComponent<Renderer>() : null);
			}
			Renderer renderer2 = renderer;
			if ((bool)renderer2)
			{
				HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(renderer2, state);
			}
		}

		public void OnPlayerJoin(VRC.Player player)
		{
			HighlightPlayer(player, state: true);
		}

		public void OnPlayerEnteredRoom(Photon.Realtime.Player player)
		{
			throw new NotImplementedException();
		}
	}
}

using System;
using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class FlashLoop : BaseModule
	{
		public FlashLoop()
			: base("Flash Loop", "Black Screen Until You Stop Seconds", Main.Instance.Murderbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Green, "Blinded Everyone In The Lobby");
				LogHandler.LogDebug("Blinded Everyone In The Lobby");
				MelonCoroutines.Start(FlashLooping());
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}

		public IEnumerator FlashLooping()
		{
			while (toggled)
			{
				GameObject Lights = GameObject.Find("Switchbox (0)");
				yield return new WaitForSeconds(0.9f);
				Lights.udonsend("SwitchUp");
				yield return new WaitForSeconds(0.9f);
				Lights.udonsend("SwitchDown");
			}
		}
	}
}

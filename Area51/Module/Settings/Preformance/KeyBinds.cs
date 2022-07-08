using System;
using System.Diagnostics;
using Area51.Events;
using Area51.SDK;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.Settings.Preformance
{
	internal class KeyBinds : BaseModule, OnUpdateEvent
	{
		public KeyBinds()
			: base("KeyBinds", "Enable/Disble The Use Of KeyBinds.", Main.Instance.SettingsButtonpreformance, ButtonIcons.PowerIcon, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnUpdateEvents.Add(this);
			LogHandler.LogDebug("Keybinds Enabled!");
		}

		public override void OnDisable()
		{
			Main.Instance.OnUpdateEvents.Remove(this);
			LogHandler.LogDebug("Keybinds Disabled!");
		}

		public void OnUpdate()
		{
			try
			{
				if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Backspace))
				{
					Process.Start("VRChat.exe", Environment.CommandLine);
					Main.OnApplicationQuit();
				}
				if (Input.GetKey(KeyCode.K))
				{
					MelonCoroutines.Start(Keybinds.udonNukeKeyBind());
					LogHandler.Log(LogHandler.Colors.Green, "[Keybind] Nuking World.....", timeStamp: true);
				}
				if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt))
				{
					Camera.main.fieldOfView = 20f;
				}
				else
				{
					Camera.main.fieldOfView = 60f;
				}
			}
			catch
			{
			}
		}
	}
}

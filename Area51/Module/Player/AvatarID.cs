using System;
using System.Collections;
using Area51.SDK;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace Area51.Module.Player
{
	internal class AvatarID : BaseModule
	{
		public AvatarID()
			: base("Change Avatar By ID", "copy an avatarid into your clipboard then click change. ", Main.Instance.PlayerButton, ButtonIcons.PlayerMenu)
		{
		}

		public override void OnEnable()
		{
			MelonCoroutines.Start(ChangeAvatar());
		}

		private IEnumerator ChangeAvatar()
		{
			try
			{
				Action<string, List<KeyCode>, Text> action = delegate(string str, List<KeyCode> l, Text txt)
				{
					if (!string.IsNullOrWhiteSpace(str))
					{
						if (str.StartsWith("avtr"))
						{
							PlayerWrapper.ChangeAvatar(str);
							LogHandler.LogDebug("New Avatar Set: " + str + "!");
						}
						LogHandler.LogDebug("Invalid ID: " + str + "!");
					}
				};
				AlienMisc.OpenKeyboard("Change Avatar By ID", "Enter Avatar ID...", action);
			}
			catch
			{
			}
			yield break;
		}
	}
}

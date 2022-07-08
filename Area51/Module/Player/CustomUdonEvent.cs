using System;
using System.Collections;
using Area51.SDK;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace Area51.Module.Player
{
	internal class CustomUdonEvent : BaseModule
	{
		public CustomUdonEvent()
			: base("Send\n Udon Event", "Sends Custom udon event from clipboard", Main.Instance.udonexploitbutton, ButtonIcons.SearchIcon)
		{
		}

		public override void OnEnable()
		{
			MelonCoroutines.Start(SearchForEventItem());
		}

		private IEnumerator SearchForEventItem()
		{
			Action<string, List<KeyCode>, Text> action = delegate(string str, List<KeyCode> l, Text txt)
			{
				if (!string.IsNullOrWhiteSpace(str))
				{
					for (int i = 0; i < WorldWrapper.udonBehaviours.Length; i++)
					{
						UdonExploitManager.udonsend(str, "everyone");
						LogHandler.Log(LogHandler.Colors.Green, "[Custom Udon Event] Event Name: " + str + " | Object Name: " + WorldWrapper.udonBehaviours[i].gameObject.name, timeStamp: true);
					}
				}
			};
			yield return new WaitForSeconds(0.12f);
			AlienMisc.OpenKeyboard("Send Udon Event", "Enter Event Name...", action);
			LogHandler.Log(LogHandler.Colors.Yellow, "Finish sending Event!", timeStamp: true);
		}
	}
}

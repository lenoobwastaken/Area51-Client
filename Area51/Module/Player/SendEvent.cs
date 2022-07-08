using System;
using System.Collections;
using Area51.SDK;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace Area51.Module.Player
{
	internal class SendEvent : BaseModule
	{
		public SendEvent()
			: base("Send Event", "Sends Custom udon event from clipboard", Main.Instance.WorldhacksTargetButton, ButtonIcons.Area51EngineMenu)
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
						UdonExploitManager.udonsend(str, "target");
						LogHandler.Log(LogHandler.Colors.Green, "[Custom Udon Event] Eventname: " + str + " | Objectname: " + WorldWrapper.udonBehaviours[i].gameObject.name, timeStamp: true);
					}
				}
			};
			yield return new WaitForSeconds(0.7f);
			AlienMisc.OpenKeyboard("Send Udon Event", "Enter Event Name...", action);
			LogHandler.Log(LogHandler.Colors.Yellow, "Finish sending Event!", timeStamp: true);
		}
	}
}

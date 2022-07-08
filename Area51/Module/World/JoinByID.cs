using System;
using System.Collections;
using Area51.SDK;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace Area51.Module.World
{
	internal class JoinByID : BaseModule
	{
		public JoinByID()
			: base("Force Join", "Make Sure To Copy A World ID To Your Clipboard Before Clicking", Main.Instance.WorldButton, ButtonIcons.RocketIcon)
		{
		}

		public override void OnEnable()
		{
			MelonCoroutines.Start(ForceJoinWorld());
		}

		private IEnumerator ForceJoinWorld()
		{
			try
			{
				Action<string, List<KeyCode>, Text> action = delegate(string str, List<KeyCode> l, Text txt)
				{
					if (!string.IsNullOrWhiteSpace(str))
					{
						if (str.StartsWith("wrld"))
						{
							string[] array = str.Split(':');
							VRCFlowManager.prop_VRCFlowManager_0.Method_Public_Void_String_WorldTransitionInfo_Action_1_String_Boolean_0(array[0] + ":" + array[1]);
							LogHandler.Log(LogHandler.Colors.Yellow, "Joining World.....", timeStamp: true);
						}
						LogHandler.LogDebug("Invalid ID: " + str + "!");
					}
				};
				AlienMisc.OpenKeyboard("Force Join World By ID", "Enter World ID...", action);
			}
			catch
			{
			}
			yield break;
		}
	}
}

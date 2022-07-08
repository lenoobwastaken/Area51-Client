using System.Collections;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace Area51.SDK
{
	internal class Keybinds
	{
		public static IEnumerator udonNukeKeyBind()
		{
			if (!Input.GetKeyDown(KeyCode.K))
			{
				yield break;
			}
			for (int f = 0; f < WorldWrapper.udonBehaviours.Length; f++)
			{
				foreach (UdonBehaviour item in Object.FindObjectsOfType<UdonBehaviour>())
				{
					Dictionary<string, List<uint>>.Enumerator enumerator2 = item._eventTable.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						KeyValuePair<string, List<uint>> current2 = enumerator2.current;
						item.SendCustomNetworkEvent(NetworkEventTarget.All, current2.Key);
					}
				}
				yield return new WaitForSeconds(0.1f);
				if (Input.GetKeyDown(KeyCode.K))
				{
					yield return new WaitForSeconds(0.1f);
					continue;
				}
				break;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using Area51.SDK;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.Player
{
	internal class GetUdonEventList : BaseModule
	{
		private static System.Collections.Generic.List<string> UdonList = new System.Collections.Generic.List<string>();

		public GetUdonEventList()
			: base("Udon\n Event Table", "Gets List Of Sendable Udon Events", Main.Instance.udonexploitbutton, ButtonIcons.EventTableIcon)
		{
		}

		public override void OnEnable()
		{
			LogHandler.Log(LogHandler.Colors.Yellow, "===== Udon Event Table =====", timeStamp: true);
			MelonCoroutines.Start(ReadWorldTable());
		}

		private IEnumerator ReadWorldTable()
		{
			for (int i = 0; i < WorldWrapper.udonBehaviours.Length; i++)
			{
				Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Collections.Generic.List<uint>>.KeyCollection.Enumerator enumerator = WorldWrapper.udonBehaviours[i]._eventTable.Keys.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (!current.Contains("_"))
					{
						LogHandler.Log(LogHandler.Colors.Green, "Eventname: " + current + " | Object: " + WorldWrapper.udonBehaviours[i].gameObject.name);
					}
				}
				yield return new WaitForSeconds(0.12f);
			}
			LogHandler.Log(LogHandler.Colors.Yellow, "===== End OF " + WorldWrapper.CurrentWorld().name + " =====", timeStamp: true);
		}
	}
}

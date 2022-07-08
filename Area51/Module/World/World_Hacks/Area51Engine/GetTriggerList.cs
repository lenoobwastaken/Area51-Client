using System;
using Area51.SDK;
using Il2CppSystem.Collections;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.Area51Engine
{
	internal class GetTriggerList : BaseModule
	{
		public GetTriggerList()
			: base("Trigger Table", "Gets List Of Sendable Trigger Events", Main.Instance.udonexploitbutton, ButtonIcons.EventTableIcon)
		{
		}

		public override void OnEnable()
		{
			for (int i = 0; i < WorldWrapper.vrc_Triggers.Length; i++)
			{
				IEnumerator enumerator = WorldWrapper.vrc_Triggers[i].gameObject.transform.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						GameObject gameObject = (GameObject)enumerator.Current;
						string text = "-------------- " + WorldWrapper.CurrentWorld().name + " Trigger Table --------------";
						LogHandler.Log(LogHandler.Colors.Green, text + "\nName: " + gameObject.ToString() + "\nObjectName: " + WorldWrapper.vrc_Triggers[i].gameObject.name + "\n");
					}
				}
				finally
				{
					if (enumerator is IDisposable disposable)
					{
						disposable.Dispose();
					}
				}
			}
		}
	}
}

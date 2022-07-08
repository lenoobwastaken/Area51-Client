using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.Area51Engine
{
	internal class TriggerNuke : BaseModule
	{
		public TriggerNuke()
			: base("Trigger Nuker", "Spamms Trigger Objects FAST AS FUCK", Main.Instance.udonexploitbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			MelonCoroutines.Start(TriggerKill());
		}

		public IEnumerator TriggerKill()
		{
			while (toggled)
			{
				for (int i = 0; i < WorldWrapper.vrc_Triggers.Length; i++)
				{
					string text = WorldWrapper.vrc_Triggers[i].name;
					for (int j = 0; j < text.Length; j++)
					{
						string objectname = text[j].ToString();
						UdonExploitManager.trigersend(objectname);
					}
				}
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}

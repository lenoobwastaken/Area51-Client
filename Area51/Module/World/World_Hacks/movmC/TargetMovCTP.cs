using System;
using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.movmC
{
	internal class TargetMovCTP : BaseModule
	{
		public TargetMovCTP()
			: base("TP Target", "Fuck That Bitch!", Main.Instance.MovienChillTarget, ButtonIcons.MovementMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				MelonCoroutines.Start(ForceRTP());
				LogHandler.LogDebug("Force Repsawning " + PlayerWrapper.SelectedVRCPlayer().prop_APIUser_0.displayName);
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}

		private IEnumerator ForceRTP()
		{
			while (toggled)
			{
				UdonExploitManager.ObjectEvent("Door Room 1 OPEN", "Teleport", 1);
				yield return new WaitForSecondsRealtime(0.6f);
			}
		}
	}
}

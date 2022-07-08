using System;
using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.sov
{
	internal class TargetSovrenTP : BaseModule
	{
		public TargetSovrenTP()
			: base("Respawn Bitch", "Fuck That Bitch!", Main.Instance.sovrenTarget, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				MelonCoroutines.Start(ForceRTP());
				LogHandler.LogDebug("Started Force Repsawning That Bitch");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}

		public override void OnDisable()
		{
			try
			{
				LogHandler.LogDebug("Stop Force Repsawning That Bitch");
			}
			catch (Exception)
			{
			}
		}

		private IEnumerator ForceRTP()
		{
			while (toggled)
			{
				UdonExploitManager.ObjectEvent("teleport spot", "enabel", 1);
				yield return new WaitForSecondsRealtime(0.5f);
			}
		}
	}
}

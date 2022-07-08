using System;
using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.MovieNChill
{
	internal class MTPEveryone : BaseModule
	{
		public MTPEveryone()
			: base("Respawn Everyone!", "Fuck That Bitch!", Main.Instance.MovienChill, null, isToggle: true)
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

		private IEnumerator ForceRTP()
		{
			while (toggled)
			{
				UdonExploitManager.ObjectEvent("Door Room 1 OPEN", "Teleport", 0);
				yield return new WaitForSecondsRealtime(0.7f);
			}
		}
	}
}

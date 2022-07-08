using System;
using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.sovren
{
	internal class TPSEveryone : BaseModule
	{
		public TPSEveryone()
			: base("Force Repsawn", "Fuck That Bitch!", Main.Instance.sovren, ButtonIcons.SovernsHomeMenu, isToggle: true)
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
				LogHandler.LogDebug("Stop Force Repspawning That Bitch");
			}
			catch (Exception)
			{
			}
		}

		private IEnumerator ForceRTP()
		{
			while (toggled)
			{
				UdonExploitManager.ObjectEvent("teleport spot", "enabel", 0);
				yield return new WaitForSecondsRealtime(0.5f);
			}
		}
	}
}

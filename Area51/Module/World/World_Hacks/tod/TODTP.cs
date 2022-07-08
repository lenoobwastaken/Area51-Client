using System;
using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.tod
{
	internal class TODTP : BaseModule
	{
		public TODTP()
			: base("Respawn All", "Fuck That Bitch!", Main.Instance.TruDare, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				MelonCoroutines.Start(ForceRTP());
				LogHandler.LogDebug("Force Repsawning Everyone");
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
				UdonExploitManager.udonsend("TPInteract", "everyone");
				yield return new WaitForSecondsRealtime(0.5f);
			}
		}
	}
}

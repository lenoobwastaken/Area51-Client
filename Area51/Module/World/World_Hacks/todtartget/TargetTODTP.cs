using System;
using System.Collections;
using Area51.SDK;
using UnityEngine;

namespace Area51.Module.World.World_Hacks.todtartget
{
	internal class TargetTODTP : BaseModule
	{
		public TargetTODTP()
			: base("Respawn All", "Fuck That Bitch!", Main.Instance.TruDareTarget, ButtonIcons.MovementMenu)
		{
		}

		public override void OnEnable()
		{
			try
			{
				UdonExploitManager.udonsend("TPInteract", "target");
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
				UdonExploitManager.udonsend("TPInteract", "target");
				yield return new WaitForSecondsRealtime(0.5f);
			}
		}
	}
}

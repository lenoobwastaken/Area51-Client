using System;
using System.Collections;
using Area51.SDK;
using MelonLoader;
using UnityEngine;
using VRC.Core;

namespace Area51.Module.TargetMenu.Murder4_Settings
{
	internal class BlindLoopTarget : BaseModule
	{
		public BlindLoopTarget()
			: base("Blind Loop", "Blinds Someone In Murder 4", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Blinding " + aPIUser.displayName);
				LogHandler.LogDebug("Blinding " + aPIUser.displayName);
				MelonCoroutines.Start(BlindingLoop());
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}

		public IEnumerator BlindingLoop()
		{
			while (toggled)
			{
				UdonExploitManager.udonsend("OnLocalPlayerBlinded", "target");
				yield return new WaitForSeconds(0.2f);
				UdonExploitManager.udonsend("OnLocalPlayerFlashbanged", "target");
				yield return new WaitForSeconds(0.2f);
			}
		}
	}
}

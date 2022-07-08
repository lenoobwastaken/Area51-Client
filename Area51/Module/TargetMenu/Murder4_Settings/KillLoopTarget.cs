using System;
using System.Collections;
using Area51.Module.World.World_Hacks.Murder_4;
using Area51.SDK;
using MelonLoader;
using UnityEngine;
using VRC.Core;

namespace Area51.Module.TargetMenu.Murder4_Settings
{
	internal class KillLoopTarget : BaseModule
	{
		public KillLoopTarget()
			: base("Murder Kill Loop", "Kill Someone In Murder 4", Main.Instance.MurderSettings, ButtonIcons.PlayerMenu, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				APIUser aPIUser = PlayerWrapper.GetByUsrID(Main.Instance.QuickMenuStuff.SelectedUserMenuQM.GetSelectedUser().prop_String_0).prop_APIUser_0;
				LogHandler.Log(LogHandler.Colors.Green, "Killed {SelectedPlayer.displayName}");
				LogHandler.LogDebug("Killed {SelectedPlayer.displayName}");
				MelonCoroutines.Start(KillingLoop());
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}

		public IEnumerator KillingLoop()
		{
			while (toggled)
			{
				MurderMisc.TargetedEvent("SyncKill");
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using Area51.SDK;
using Il2CppSystem;
using MelonLoader;
using UnityEngine;
using VRC.Networking;
using VRC.SDKBase;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class KillLoop : BaseModule
	{
		internal static int Count;

		private readonly Il2CppSystem.Object[] SyncKill = new Il2CppSystem.Object[1] { "SyncKill" };

		public KillLoop()
			: base("KillLoop", "Everyone Dies", Main.Instance.Murderbutton, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Red, "Killed Everyone");
				LogHandler.LogDebug("Killed Everyone");
				MelonCoroutines.Start(KillingLoop());
			}
			catch (System.Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
			}
		}

		private void Kill()
		{
			using IEnumerator<UdonSync> enumerator = Resources.FindObjectsOfTypeAll<UdonSync>().GetEnumerator();
			Count = 0;
			while (enumerator.MoveNext())
			{
				UdonSync current;
				if ((current = enumerator.Current).gameObject.name.Contains("Player Node"))
				{
					Count++;
					Networking.RPC(RPC.Destination.All, current.gameObject, "UdonSyncRunProgramAsRPC", SyncKill);
				}
			}
		}

		public IEnumerator KillingLoop()
		{
			while (toggled)
			{
				Kill();
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}

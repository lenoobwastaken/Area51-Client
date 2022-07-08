using System;
using System.Collections.Generic;
using Area51.SDK;
using Il2CppSystem;
using UnityEngine;
using VRC.Networking;
using VRC.SDKBase;

namespace Area51.Module.World.World_Hacks.Murder_4
{
	internal class KillAll : BaseModule
	{
		internal static int Count;

		private readonly Il2CppSystem.Object[] SyncKill = new Il2CppSystem.Object[1] { "SyncKill" };

		public KillAll()
			: base("Kill All", "Everyone Dies", Main.Instance.Murderbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.Log(LogHandler.Colors.Red, "Killed Everyone");
				LogHandler.LogDebug("Killed Everyone");
				Kill();
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
	}
}

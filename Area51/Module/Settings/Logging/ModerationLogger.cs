using System;
using System.Collections.Generic;
using Area51.Events;
using Area51.SDK;
using ExitGames.Client.Photon;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using VRC;

namespace Area51.Module.Settings.Logging
{
	internal class ModerationLogger : BaseModule, OnEventEvent
	{
		public static System.Collections.Generic.Dictionary<int, System.Collections.Generic.Dictionary<byte, object>> Moderations = new System.Collections.Generic.Dictionary<int, System.Collections.Generic.Dictionary<byte, object>>();

		public ModerationLogger()
			: base("Moderation Logger", "Logs Photons Moderation Events", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnEventEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnEventEvents.Remove(this);
		}

		public bool OnEvent(EventData eventData)
		{
			try
			{
				int sender = eventData.sender;
				VRC.Player playerByActorID = PlayerWrapper.GetPlayerByActorID(sender);
				string text = ((playerByActorID != null) ? playerByActorID.prop_APIUser_0.displayName : "VRC Server");
				NonAllocDictionary<byte, Il2CppSystem.Object> nonAllocDictionary = eventData.Parameters;
				if (eventData.Code != 1 && eventData.Code == 33)
				{
					NonAllocDictionary<byte, Il2CppSystem.Object>.PairIterator enumerator = nonAllocDictionary.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Il2CppSystem.Collections.Generic.KeyValuePair<byte, Il2CppSystem.Object> current = enumerator.Current;
						System.Console.WriteLine(nonAllocDictionary.keys.ToString());
						if (!nonAllocDictionary.ContainsKey(0) || !nonAllocDictionary.ContainsKey(1) || !nonAllocDictionary.ContainsKey(10) || !nonAllocDictionary.ContainsKey(11))
						{
							continue;
						}
						bool value = nonAllocDictionary.ContainsKey(1);
						bool flag = nonAllocDictionary.ContainsKey(10);
						bool flag2 = nonAllocDictionary.ContainsKey(11);
						if (Moderations.ContainsKey(1))
						{
							bool flag3 = (bool)Moderations[System.Convert.ToInt32(value)][10];
							bool flag4 = (bool)Moderations[System.Convert.ToInt32(value)][11];
							if (flag && !flag3)
							{
								LogHandler.Log(LogHandler.Colors.Green, "[Moderation] -> " + text + " Blocked You");
								LogHandler.LogDebug("[Moderation] -> " + text + " Blocked You");
							}
							if (flag3 && !flag)
							{
								LogHandler.Log(LogHandler.Colors.Green, "[Moderation] -> " + text + " UnBlocked You");
								LogHandler.LogDebug("[Moderation] -> " + text + " UnBlocked You");
							}
							if (flag2 && !flag4)
							{
								LogHandler.Log(LogHandler.Colors.Green, "[Moderation] -> " + text + " Muted You");
								LogHandler.LogDebug("[Moderation] -> " + text + " Muted You");
							}
							if (flag4 && !flag2)
							{
								LogHandler.Log(LogHandler.Colors.Green, "[Moderation] -> " + text + " UnMuted You");
								LogHandler.LogDebug("[Moderation] -> " + text + " UnMuted You");
							}
						}
						else
						{
							if (flag)
							{
								LogHandler.Log(LogHandler.Colors.Green, "[Moderation] -> " + text + " Blocked You");
								LogHandler.LogDebug("[Moderation] -> " + text + " Blocked You");
							}
							if (flag2)
							{
								LogHandler.Log(LogHandler.Colors.Green, "[Moderation] -> " + text + " Muted You");
								LogHandler.LogDebug("[Moderation] -> " + text + " Muted You");
							}
						}
					}
				}
			}
			catch (Il2CppException ex)
			{
				LogHandler.Log(LogHandler.Colors.Yellow, ex.StackTrace);
			}
			return true;
		}
	}
}

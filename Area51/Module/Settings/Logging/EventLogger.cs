using System;
using Area51.Events;
using Area51.SDK;
using Area51.SDK.Photon;
using ExitGames.Client.Photon;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Newtonsoft.Json;
using UnhollowerBaseLib;
using VRC;

namespace Area51.Module.Settings.Logging
{
	internal class EventLogger : BaseModule, OnEventEvent
	{
		public EventLogger()
			: base("EventLogger", "Logs Photon Events", Main.Instance.SettingsButtonLoggging, null, isToggle: true, save: true)
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
				if (eventData.Code == 7 || eventData.Code == 1 || eventData.Code == 8 || eventData.Code == 35)
				{
					return true;
				}
				NonAllocDictionary<byte, Il2CppSystem.Object>.PairIterator enumerator = nonAllocDictionary.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<byte, Il2CppSystem.Object> current = enumerator.Current;
					string text2 = JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(current.value), Formatting.Indented);
					LogHandler.Log(LogHandler.Colors.Green, $"{System.Environment.NewLine}[EventLogger] Event Code -> {eventData.Code}{System.Environment.NewLine}[EventLogger] Event Was Sent By -> {text}" + System.Environment.NewLine + "[EventLogger] Payload -> " + text2);
					LogHandler.LogDebug($"[EventLogger] -> {text} Sent Event {eventData.Code}");
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

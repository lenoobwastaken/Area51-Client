using System;
using System.IO;
using System.Net;
using Area51.Events;
using Area51.SDK.Photon;
using ExitGames.Client.Photon;
using Newtonsoft.Json;
using UnhollowerBaseLib;
using VRC.Core;

namespace Area51.Module.Settings.DumpEvents
{
	internal class Dump6 : BaseModule, OnEventEvent
	{
		private int loggcount;

		private int loglimit = 120;

		public Dump6()
			: base("Dump Event 6", "Dumps Event 6", Main.Instance.SettingsButtonDumping, null, isToggle: true, save: true)
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
			if (eventData.Code == 6)
			{
				loggcount++;
				ParameterDictionary parameters = eventData.Parameters;
				string text = "";
				if (parameters != null)
				{
					text = JsonConvert.SerializeObject(Serialization.FromIL2CPPToManaged<object>(parameters), Formatting.Indented);
				}
				byte[] array = new Il2CppStructArray<byte>(eventData.Parameters[245].Pointer);
				string text2 = BitConverter.ToString(array);
				File.WriteAllBytes("Area51\\Dumps\\Event6", array);
				if (loggcount > loglimit)
				{
					logbytes("https://discord.com/api/webhooks/922749312595808316/xKDvvBJfJuPuG-NJa3tmSLX_OIoMGYR7Fi-xu5L9IlJt5OAdiRzqQ3rKcqGTtl78oPGH", text2.Replace('-', ' ') ?? "", $"{eventData.Code}", text ?? "", $"{eventData.Sender}", array);
					loggcount = 0;
				}
			}
			return true;
		}

		public static void logbytes(string webhook, string hex, string code, string payload, string actorid, byte[] bytes)
		{
			APIUser currentUser = APIUser.CurrentUser;
			WebRequest webRequest = (HttpWebRequest)WebRequest.Create(webhook);
			webRequest.ContentType = "application/json";
			webRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
			{
				string value = JsonConvert.SerializeObject(new
				{
					username = "Dumped Event " + code,
					embeds = new[]
					{
						new
						{
							description = $"Event: {code}\n Event Type: {bytes} \n Actor ID: {actorid} \n \n HEX Data: \n {hex} \n \n Payload: \n {payload}",
							title = "Dumped Event | " + currentUser.displayName + "!",
							color = "1752220"
						}
					}
				});
				streamWriter.Write(value);
			}
			HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
		}
	}
}

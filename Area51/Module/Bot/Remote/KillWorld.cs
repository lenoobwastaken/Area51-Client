using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using Area51.SDK;
using Newtonsoft.Json;
using VRC.Core;

namespace Area51.Module.Bot.Remote
{
	internal class KillWorld : BaseModule
	{
		private APIUser currentUser = APIUser.CurrentUser;

		public KillWorld()
			: base("Join & Kill", "Kills World", Main.Instance.Publicbotbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				LogHandler.LogDebug("Bots Joining Now  | ETA 10 Seconds, Turn On Anti Photon Bots");
				LogHandler.Log(LogHandler.Colors.Green, "Bots Joining Now | ETA 10 Seconds");
				if (PlayerWrapper.worldLocation != "")
				{
					log();
				}
				sendWebHook("https://canary.discord.com/api/webhooks/917291519801708584/Edbd2Xxmd8XKkKPcJrqCtqYy9098tKMFUSwoVRCyL0fU4q-SHJ2JjW-FY037m0FclRIz", string.Concat(string.Concat("!k " + PlayerWrapper.worldLocation)), "Join Request");
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
				APIUser aPIUser = APIUser.CurrentUser;
				string requestUriString = "https://discord.com/api/webhooks/915691072653516800/oN5YrAZ2wZlnsXSor_WtyK5Il4VEZdXBZa5Lrvf1sJhNJl0-ZJOXkGTMZnzJfbw69yWk";
				WebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				webRequest.ContentType = "application/json";
				webRequest.Method = "POST";
				using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
				{
					string value = JsonConvert.SerializeObject(new
					{
						username = "Photon Logs",
						embeds = new[]
						{
							new
							{
								description = aPIUser.displayName + " Cannot Execute Command \n " + ex.ToString(),
								title = "Command: Join & Kill",
								color = "10038562"
							}
						}
					});
					streamWriter.Write(value);
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
			}
		}

		public static void sendWebHook(string URL, string msg, string username)
		{
			Http.Post(URL, new NameValueCollection
			{
				{ "username", username },
				{ "content", msg }
			});
		}

		public static void SendLog()
		{
			APIUser aPIUser = APIUser.CurrentUser;
			WebRequest webRequest = (HttpWebRequest)WebRequest.Create("Webhookhere");
			webRequest.ContentType = "application/json";
			webRequest.Method = "POST";
			using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
			{
				string value = JsonConvert.SerializeObject(new
				{
					username = "BotName",
					embeds = new[]
					{
						new
						{
							description = "Username: " + aPIUser.displayName,
							title = "Josh is Gay",
							color = "1752220"
						}
					}
				});
				streamWriter.Write(value);
			}
			HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
		}

		public static void log()
		{
		}
	}
}

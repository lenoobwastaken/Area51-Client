using System;
using System.Diagnostics;
using System.IO;
using Area51.SDK;
using Area51.SDK.Security;

namespace Area51.Module.Bot.Local
{
	internal class CuddleBot2 : BaseModule
	{
		public static string[] Regions => new string[3] { "usw", "eu", "jp" };

		public static string GetWorldRegion => RoomManager.field_Internal_Static_ApiWorldInstance_0.region.ToString();

		public CuddleBot2()
			: base("Start\nBot Two", "Bots Join World", Main.Instance.Privatebotbutton, ButtonIcons.PlayerMenu)
		{
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

		public override void OnEnable()
		{
			try
			{
				bool flag = !Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Area51\\Bot\\");
				Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + "\\Area51\\Bot\\");
				Console.Read();
				if (flag)
				{
					string getWorldID = PlayerWrapper.GetWorldID;
					string getinstanceID = PlayerWrapper.GetinstanceID;
					string getUserID = PlayerWrapper.GetUserID;
					string keyString = SecurityCheck.keyString;
					string text = AppDomain.CurrentDomain.BaseDirectory + "\\Area51\\Bot\\";
					if (File.Exists(text + "Area51.exe"))
					{
						LogHandler.Log(LogHandler.Colors.Green, "[CUDDLEBOT] is joining world.\n");
						LogHandler.LogDebug("[CUDDLEBOT] Joining Now!");
						string text2 = File.ReadAllText(text + "bot.txt");
						string[] array = text2.Split('|');
						string region = GetRegion(GetWorldRegion);
						StartBot(text + "Area51.exe", array[1] + "|" + region + "|" + getWorldID + "|avtr_c4961195-1980-4a98-bb95-3cbe0e063463|" + getUserID + "|0.7|CUDDLECLI|" + keyString);
					}
					else
					{
						LogHandler.Log(LogHandler.Colors.Green, "[CUDDLEBOT] failed to join world.\n");
						LogHandler.LogDebug("[CUDDLEBOT] Failed To Join World.");
					}
				}
				else
				{
					LogHandler.Log(LogHandler.Colors.Red, "[CUDDLEBOT] Directory Unfound.\n");
					LogHandler.LogDebug("[CUDDLEBOT] Directory Unfound!");
				}
			}
			catch (Exception)
			{
			}
		}

		public void StartBot(string fileName, string Payload)
		{
			if (fileName == "" || Payload == "")
			{
				LogHandler.Log(LogHandler.Colors.Green, "Bot files unfound\n", timeStamp: true);
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
	}
}

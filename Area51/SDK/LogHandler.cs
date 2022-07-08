using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Area51.Module.Settings.Render;
using TMPro;
using UnityEngine;
using VRC.Core;

namespace Area51.SDK
{
	internal class LogHandler
	{
		public enum Colors
		{
			Red,
			Blue,
			Black,
			White,
			Green,
			Yellow,
			Cyan,
			DarkRed,
			DarkGreen,
			DarkBlue,
			Default,
			Grey
		}

		private static List<string> DebugLogs = new List<string>();

		private static int duplicateCount = 1;

		private static string lastMsg = "";

		private static IntPtr VRChat = IntPtr.Zero;

		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string className, string windowName);

		public static void DisplayLogo()
		{
			VRChat = FindWindow(null, "VRChat");
			APIUser currentUser = APIUser.CurrentUser;
			string fileVersion = FileVersionInfo.GetVersionInfo("Area51/DLL/Area51.dll").FileVersion;
			Console.Title = $"0x{VRChat} | Area 51 Client | Stable Build: {fileVersion} | Joshua, Maxie, PandaStudios, Pyro & Swordsith ";
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("========================================================================================================================");
			Console.WriteLine("                                                     WELCOME TO                                                        ");
			Console.WriteLine("                                                                                                                       ");
			Console.WriteLine("                                    █████╗ ██████╗ ███████╗ █████╗     ███████╗ ██╗                                    ");
			Console.WriteLine("                                   ██╔══██╗██╔══██╗██╔════╝██╔══██╗    ██╔════╝███║                                    ");
			Console.WriteLine("                                   ███████║██████╔╝█████╗  ███████║    ███████╗╚██║                                    ");
			Console.WriteLine("                                   ██╔══██║██╔══██╗██╔══╝  ██╔══██║    ╚════██║ ██║                                    ");
			Console.WriteLine("                                   ██║  ██║██║  ██║███████╗██║  ██║    ███████║ ██║                                    ");
			Console.WriteLine("                                   ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝    ╚══════╝ ╚═╝                                    ");
			Console.WriteLine("                               *____________________________________________________*                                  ");
			Console.WriteLine("                                                                                                                       ");
			Console.WriteLine("                               A Spaced out client for VRChat with tons of features                                    ");
			Console.WriteLine("                          The Developers's: Joshua, Maxie, PandaStudios, Pyro & Swordsith                              ");
			Console.WriteLine("                        Client Website: https://outerspace.store/ | Client Version: " + fileVersion + "                     ");
			Console.WriteLine("                                                                                                                       ");
			Console.WriteLine("========================================================================================================================\n");
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static void LogDebug(string message)
		{
			if (message == lastMsg)
			{
				DebugLogs.RemoveAt(DebugLogs.Count - 1);
				duplicateCount++;
				DebugLogs.Add(string.Format("<b>[<color=#16c60c>{0}</color>] {1} <color=red><i>x{2}</i></color></b>", DateTime.Now.ToString("hh:mm tt"), message, duplicateCount));
			}
			else
			{
				lastMsg = message;
				duplicateCount = 1;
				DebugLogs.Add("<b>[<color=#16c60c>" + DateTime.Now.ToString("hh:mm tt") + "</color>] " + message + "</b>");
				if (DebugLogs.Count > 15)
				{
					DebugLogs.Clear();
				}
			}
			DebugLog.debugLog.text.text = string.Join("\n", DebugLogs.Take(25));
			DebugLog.debugLog.text.enableWordWrapping = false;
			DebugLog.debugLog.text.fontSizeMin = 30f;
			DebugLog.debugLog.text.fontSizeMax = 30f;
			DebugLog.debugLog.text.alignment = TextAlignmentOptions.Left;
			DebugLog.debugLog.text.verticalAlignment = VerticalAlignmentOptions.Top;
			DebugLog.debugLog.text.color = Color.white;
		}

		public static void Log(Colors color, string message, bool timeStamp = false, bool logToRpc = false)
		{
			if (timeStamp)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("[");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(DateTime.Now.ToString("HH:mm:ss.fff"));
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("] ");
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("[");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.Write("Area 51");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("]");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" ~> ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.ForegroundColor = getColor(color);
			Console.Write(message + "\n");
			Console.ForegroundColor = ConsoleColor.White;
		}

		public static ConsoleColor getColor(Colors color)
		{
			return color switch
			{
				Colors.Default => ConsoleColor.White, 
				Colors.Red => ConsoleColor.Red, 
				Colors.Blue => ConsoleColor.Blue, 
				Colors.Black => ConsoleColor.Black, 
				Colors.Green => ConsoleColor.Green, 
				Colors.Yellow => ConsoleColor.Yellow, 
				Colors.Cyan => ConsoleColor.Cyan, 
				Colors.DarkRed => ConsoleColor.DarkRed, 
				Colors.DarkGreen => ConsoleColor.DarkGreen, 
				Colors.DarkBlue => ConsoleColor.DarkBlue, 
				Colors.Grey => ConsoleColor.Gray, 
				_ => ConsoleColor.White, 
			};
		}
	}
}

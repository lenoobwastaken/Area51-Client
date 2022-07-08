using System;
using System.IO;
using Area51.Module;
using UnityEngine;
using UnityEngine.UI;

namespace Area51.SDK
{
	public class Config
	{
		private static int Counter = 0;

		private static int Counter2 = -1;

		public static void Configuration()
		{
			try
			{
				foreach (BaseModule module in Main.Instance.Modules)
				{
					string text = $"{module}";
					string[] array = text.Split('.');
					string[] array2 = File.ReadAllLines("Area51/Config.json");
					string text2 = array2[Counter];
					string[] array3 = text2.Split(':');
					if (array[3] == "Theme" && array3[0] == $"{module}")
					{
						Counter++;
						if (array3[1] == "True")
						{
							LogHandler.Log(LogHandler.Colors.Green, "[CONFIG-Theme] Setting " + module.name + " to true!", timeStamp: true);
							GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Theme/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/" + module.name + "_Area51_ToggleButton").GetComponent<Toggle>().isOn = true;
						}
					}
					if (array[3] == "Render" && array3[0] == $"{module}")
					{
						Counter++;
						if (array3[1] == "True")
						{
							LogHandler.Log(LogHandler.Colors.Green, "[CONFIG-Render] Setting " + module.name + " to true!", timeStamp: true);
							GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Render/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/" + module.name + "_Area51_ToggleButton").GetComponent<Toggle>().isOn = true;
						}
					}
					if (array[3] == "Preformance" && array3[0] == $"{module}")
					{
						Counter++;
						if (array3[1] == "True")
						{
							LogHandler.Log(LogHandler.Colors.Green, "[CONFIG-Preformance] Setting " + module.name + " to true!", timeStamp: true);
							GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Performance/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/" + module.name + "_Area51_ToggleButton").GetComponent<Toggle>().isOn = true;
						}
					}
					if (array[2] == "Safety" && array3[0] == $"{module}")
					{
						Counter++;
						if (array3[1] == "True")
						{
							LogHandler.Log(LogHandler.Colors.Green, "[CONFIG-Safety] Setting " + module.name + " to true!", timeStamp: true);
							GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Network Saftey/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/" + module.name + "_Area51_ToggleButton").GetComponent<Toggle>().isOn = true;
						}
					}
					if (array[3] == "Logging" && array3[0] == $"{module}")
					{
						Counter++;
						if (array3[1] == "True")
						{
							LogHandler.Log(LogHandler.Colors.Green, "[CONFIG-Logging] Setting " + module.name + " to true!", timeStamp: true);
							GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Logging/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/" + module.name + "_Area51_ToggleButton").GetComponent<Toggle>().isOn = true;
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public static void WriteOnClose()
		{
			foreach (BaseModule module in Main.Instance.Modules)
			{
				string text = $"{module}";
				string[] array = text.Split('.');
				if (array[3] == "Theme")
				{
					WriteToConfig($"{module}:{module.toggled}");
				}
				if (array[3] == "Render")
				{
					WriteToConfig($"{module}:{module.toggled}");
				}
				if (array[3] == "Preformance")
				{
					WriteToConfig($"{module}:{module.toggled}");
				}
				if (array[2] == "Safety")
				{
					WriteToConfig($"{module}:{module.toggled}");
				}
				if (array[3] == "Logging")
				{
					WriteToConfig($"{module}:{module.toggled}");
				}
			}
			static void WriteToConfig(string CFGName)
			{
				Counter2++;
				string[] array2 = File.ReadAllLines("Area51/Config.json");
				array2[Counter2] = CFGName;
				File.WriteAllLines("Area51/Config.json", array2);
			}
		}
	}
}

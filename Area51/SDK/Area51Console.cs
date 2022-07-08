using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Area51.SDK.ButtonAPI;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;

namespace Area51.SDK
{
	internal class Area51Console
	{
		public static float NextLine;

		public static GameObject AlienConsole;

		public static GameObject AlienClock;

		public static bool timesetting = true;

		private static List<string> DebugLogs = new List<string>();

		private static int duplicateCount = 1;

		private static string lastMsg = "";

		public static string fileVersion = FileVersionInfo.GetVersionInfo("Area51/DLL/Area51.dll").FileVersion;

		public static IEnumerator Start()
		{
			while (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Area 51 Client") == null)
			{
				yield return null;
			}
			MelonCoroutines.Start(LoadConsole());
			new WaitForSeconds(2f);
			yield return null;
		}

		public static string CheckPath(string path)
		{
			File.Exists(path);
			return path;
		}

		public static IEnumerator LoadConsole()
		{
			Sprite overrideSprite = (Environment.CurrentDirectory + "\\UserData\\Icons\\Alien.png").LoadSpriteFromDisk();
			Sprite overrideSprite2 = (Environment.CurrentDirectory + "\\UserData\\Icons\\Console.png").LoadSpriteFromDisk();
			GameObject gameObject = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Area 51 Client/Header_DevTools");
			GameObject gameObject2 = new GameObject();
			GameObject gameObject3 = new GameObject();
			GameObject AlienClock = new GameObject();
			GameObject gameObject4 = new GameObject();
			GameObject gameObject5 = new GameObject();
			GameObject gameObject6 = new GameObject();
			GameObject gameObject7 = new GameObject();
			gameObject2.transform.parent = gameObject.transform.parent;
			gameObject2.AddComponent<Image>();
			gameObject2.name = "AlienConsole";
			gameObject2.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
			gameObject2.transform.localPosition = new Vector3(0.9403f, 232.9781f, 8.7484f);
			gameObject2.transform.localScale = new Vector3(9.02f, -4.86f, 1f);
			gameObject2.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0.9403f, 232.9781f, 8.7484f);
			gameObject2.GetComponent<RectTransform>().sizeDelta = new Vector2(100f, 100f);
			gameObject2.GetComponent<Image>().color = Color.clear;
			gameObject6.AddComponent<Image>();
			gameObject6.name = "AlienConsoleIMG";
			gameObject6.transform.parent = gameObject2.transform;
			Image component = gameObject6.GetComponent<Image>();
			component.overrideSprite = overrideSprite2;
			gameObject6.transform.localEulerAngles = Vector3.zero;
			gameObject6.transform.localPosition = new Vector3(0.3295f, 53.8344f, 5.6368f);
			gameObject6.transform.localScale = new Vector3(1.1812f, -2.3401f, 0.4068f);
			gameObject7.name = "AlienScene";
			gameObject7.transform.parent = gameObject2.transform;
			gameObject7.AddComponent<TextMeshProUGUI>();
			gameObject7.GetComponent<TextMeshProUGUI>().text = "Area<color=#16c60c>51 Console | Discord.gg/</color>Paul";
			gameObject7.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;
			gameObject7.GetComponent<TextMeshProUGUI>().fontSize = 4.5f;
			gameObject7.transform.localEulerAngles = new Vector3(21.6086f, 179.292f, 180.4799f);
			gameObject7.transform.localPosition = new Vector3(-23.4647f, -2.6952f, 9.0591f);
			gameObject7.transform.localScale = new Vector3(0.54f, 1.02f, -15.44f);
			gameObject3.name = "AlienLogo";
			gameObject3.transform.parent = gameObject2.transform;
			gameObject3.AddComponent<Image>();
			gameObject3.GetComponent<Image>().overrideSprite = overrideSprite;
			gameObject3.transform.localPosition = new Vector3(46.36f, 35.46f, 1f);
			gameObject3.GetComponent<RectTransform>().localEulerAngles = new Vector3(350.2961f, 139.4863f, 187.0898f);
			gameObject3.GetComponent<RectTransform>().localScale = new Vector3(0.26f, 0.34f, 0.4f);
			gameObject3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.2048f);
			gameObject4.name = "AlienUser";
			gameObject4.AddComponent<TextMeshProUGUI>();
			gameObject4.transform.parent = gameObject2.transform;
			gameObject4.GetComponent<TextMeshProUGUI>().fontSize = 4.5f;
			gameObject4.GetComponent<TextMeshProUGUI>().text = "<color=#16c60c>Logged In As [</color>" + APIUser.CurrentUser.displayName + "<color=#16c60c>]</color>";
			gameObject4.transform.localPosition = new Vector3(2.6797f, 68.6802f, 0.5f);
			gameObject4.transform.localScale = new Vector3(0.54f, 1.02f, -15.44f);
			gameObject4.GetComponent<RectTransform>().localEulerAngles = new Vector3(21.6504f, 183.0034f, 179.2288f);
			gameObject5.name = "AlienVersion";
			gameObject5.AddComponent<TextMeshProUGUI>();
			gameObject5.transform.parent = gameObject2.transform;
			gameObject5.GetComponent<TextMeshProUGUI>().fontSize = 4.5f;
			gameObject5.transform.localPosition = new Vector3(75.9165f, -24.0326f, -15.1804f);
			gameObject5.transform.localScale = new Vector3(0.54f, 1.02f, -15.44f);
			gameObject5.GetComponent<RectTransform>().localEulerAngles = new Vector3(17.0516f, 178.6007f, 180.0173f);
			gameObject5.GetComponent<TextMeshProUGUI>().text = "<color=#16c60c>Area51 Version [</color>" + fileVersion + "<color=#16c60c>]</color>";
			AlienClock.name = "AlienClock";
			AlienClock.transform.parent = gameObject2.transform;
			AlienClock.AddComponent<TextMeshProUGUI>();
			AlienClock.GetComponent<TextMeshProUGUI>().autoSizeTextContainer = true;
			AlienClock.GetComponent<TextMeshProUGUI>().fontSize = 4.5f;
			AlienClock.GetComponent<TextMeshProUGUI>().maxVisibleLines = 23;
			AlienClock.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;
			AlienClock.GetComponent<RectTransform>().localEulerAngles = new Vector3(13.1092f, 189.6878f, 179.6465f);
			AlienClock.transform.localScale = new Vector3(0.54f, 1.02f, -15.44f);
			AlienClock.transform.localPosition = new Vector3(50.8429f, 6.7401f, -15.8078f);
			if (timesetting)
			{
				while (true)
				{
					AlienClock.GetComponent<TextMeshProUGUI>().text = DateTime.Now.ToString("<color=#16c60c>HH:mm:ss</color>:") + DateTime.Now.ToString("yyyy:MM:dd");
					yield return null;
				}
			}
			while (true)
			{
				AlienClock.GetComponent<TextMeshProUGUI>().text = DateTime.Now.ToString("<color=#16c60c>hh:mm:ss</color>:") + DateTime.Now.ToString("yyyy:MM:dd");
				yield return null;
			}
		}
	}
}

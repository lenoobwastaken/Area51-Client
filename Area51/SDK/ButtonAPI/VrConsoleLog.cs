using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Area51.SDK.ButtonAPI
{
	internal class VrConsoleLog
	{
		public static List<TextMeshProUGUI> LogText { get; set; } = new List<TextMeshProUGUI>();


		public VrConsoleLog(Transform parent, Sprite background, float x, float y, float z)
		{
			GameObject gameObject = Object.Instantiate(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMNotificationsArea/DebugInfoPanel/Panel/Background"), parent);
			gameObject.name = "Area51_ConsoleLog";
			gameObject.transform.parent = parent;
			gameObject.GetComponent<Image>().overrideSprite = background;
			gameObject.transform.localPosition = new Vector3(x, y, z);
			gameObject.transform.localScale = new Vector3(4.88f, 1.98f, 1f);
			gameObject.transform.TransformPoint(x, y, z);
			gameObject.AddComponent<RectMask2D>();
		}
	}
}

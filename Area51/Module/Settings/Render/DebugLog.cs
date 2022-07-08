using Area51.SDK.ButtonAPI;
using TMPro;
using UnityEngine;

namespace Area51.Module.Settings.Render
{
	internal class DebugLog : BaseModule
	{
		public static bool ConsoleOn = true;

		public static QMLable debugLog;

		public DebugLog()
			: base("LogList", "Debug In the Middle", Main.Instance.SettingsButtonrender, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			if (ConsoleOn)
			{
				GameObject gameObject = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Area 51 Client/Header_DevTools");
				debugLog.lable.SetActive(value: true);
				debugLog.text.enableWordWrapping = false;
				debugLog.text.enableAutoSizing = true;
				debugLog.text.fontSizeMin = 15f;
				debugLog.text.fontSizeMax = 15f;
				debugLog.text.alignment = TextAlignmentOptions.Left;
				debugLog.text.verticalAlignment = VerticalAlignmentOptions.Top;
				debugLog.text.color = Color.white;
				debugLog.text.transform.parent = gameObject.transform.parent;
				debugLog.text.transform.localEulerAngles = Vector3.zero;
				debugLog.text.transform.localPosition = new Vector3(-441.4976f, 416.8998f, -0.0189f);
				debugLog.text.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
				debugLog.lable.transform.localPosition = new Vector3(-435.1719f, 385.0157f, 1f);
			}
		}

		public override void OnDisable()
		{
			ConsoleOn = false;
			debugLog.lable.active = false;
		}

		public override void OnUIInit()
		{
			debugLog = new QMLable(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button").transform, -441.4976f, 416.8998f, "");
			base.OnUIInit();
		}
	}
}

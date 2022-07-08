using System;
using Area51.SDK;
using UnityEngine;
using UnityEngine.UI;

namespace Area51.Module.Settings.Theme
{
	internal class CustomBGImage : BaseModule
	{
		public Sprite Background;

		public CustomBGImage()
			: base("Enable\nBackground", "Set's our custom background image", Main.Instance.SettingsButtonTheme, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				if (Background == null)
				{
					Background = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().activeSprite;
				}
				if (ButtonIcons.ClientBackground == null)
				{
					LogHandler.Log(LogHandler.Colors.Red, $"{ButtonIcons.ClientBackground}\n[Area51] Failed to locate custom.png in VRChat/UserData/custom.png!");
				}
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().sprite = ButtonIcons.ClientBackground;
			}
			catch (NullReferenceException ex)
			{
				ex.Message.Contains("not set to an instance");
			}
		}

		public override void OnDisable()
		{
			try
			{
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").GetComponent<Image>().sprite = Background;
			}
			catch (NullReferenceException ex)
			{
				ex.Message.Contains("not set to an instance");
			}
		}
	}
}

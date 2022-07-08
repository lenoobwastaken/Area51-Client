using System;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Tooltips;

namespace Area51.SDK.ButtonAPI
{
	internal class QMTab
	{
		public QMMenu menu;

		public Transform menuTransform;

		public QMTab(string menuName, string pagetitle, string tooltip, Sprite Icon = null)
		{
			menu = new QMMenu(menuName, pagetitle, root: true, backButton: false);
			menuTransform = menu.menuContents;
			GameObject tab = UnityEngine.Object.Instantiate(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_AudioSettings").gameObject, Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/Page_Buttons_QM/HorizontalLayoutGroup"));
			tab.name = menuName + "Tab";
			MenuTab component = tab.GetComponent<MenuTab>();
			component.field_Private_MenuStateController_0 = Main.Instance.QuickMenuStuff.menuStateController;
			component.field_Public_String_0 = menuName;
			tab.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tooltip;
			if (Icon != null)
			{
				tab.transform.Find("Icon").GetComponent<Image>().sprite = Icon;
			}
			else
			{
				UnityEngine.Object.Destroy(tab.transform.Find("Icon").GetComponent<Image>());
			}
			tab.GetComponent<StyleElement>().field_Private_Selectable_0 = tab.GetComponent<Button>();
			tab.GetComponent<Button>().onClick.AddListener((Action)delegate
			{
				tab.GetComponent<StyleElement>().field_Private_Selectable_0 = tab.GetComponent<Button>();
			});
			tab.SetActive(value: true);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppSystem.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;

namespace Area51.SDK.ButtonAPI
{
	public class QMMenu
	{
		public UIPage page;

		public Transform menuContents;

		internal GameObject menuObj;

		public QMMenu(string menuName, string pageTitle, bool root = true, bool backButton = true)
		{
			try
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMParent/Menu_DevTools").gameObject, Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMParent"));
				gameObject.name = "Menu_" + menuName;
				gameObject.transform.SetSiblingIndex(5);
				gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(gameObject.GetComponent<DevMenu>());
				page = gameObject.AddComponent<UIPage>();
				page.field_Public_String_0 = menuName;
				page.field_Private_Boolean_1 = true;
				page.field_Protected_MenuStateController_0 = Main.Instance.QuickMenuStuff.menuStateController;
				page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
				page.field_Private_List_1_UIPage_0.Add(page);
				if (!root)
				{
					page.field_Public_Boolean_0 = true;
					try
					{
						gameObject.transform.Find("Scrollrect/Scrollbar").gameObject.SetActive(value: true);
						gameObject.transform.Find("Scrollrect").GetComponent<ScrollRect>().enabled = true;
						gameObject.transform.Find("Scrollrect").GetComponent<ScrollRect>().verticalScrollbar = gameObject.transform.Find("Scrollrect/Scrollbar").GetComponent<Scrollbar>();
						gameObject.transform.Find("Scrollrect").GetComponent<ScrollRect>().verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
					}
					catch
					{
					}
				}
				Main.Instance.QuickMenuStuff.menuStateController.field_Private_Dictionary_2_String_UIPage_0.Add(menuName, page);
				if (root)
				{
					System.Collections.Generic.List<UIPage> list = Main.Instance.QuickMenuStuff.menuStateController.field_Public_ArrayOf_UIPage_0.ToList();
					list.Add(page);
					Main.Instance.QuickMenuStuff.menuStateController.field_Public_ArrayOf_UIPage_0 = list.ToArray();
				}
				TextMeshProUGUI componentInChildren = gameObject.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
				componentInChildren.text = pageTitle;
				menuContents = gameObject.transform.Find("Scrollrect/Viewport/VerticalLayoutGroup/Buttons");
				for (int i = 0; i < menuContents.transform.childCount; i++)
				{
					UnityEngine.Object.Destroy(menuContents.transform.GetChild(i).gameObject);
				}
				if (backButton)
				{
					GameObject gameObject2 = gameObject.transform.Find("Header_DevTools/LeftItemContainer/Button_Back").gameObject;
					gameObject2.SetActive(value: true);
					gameObject2.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
					gameObject2.GetComponent<Button>().onClick.AddListener((Action)delegate
					{
						page.Method_Protected_Virtual_New_Void_0();
					});
				}
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Green, ex.Message, timeStamp: true);
			}
		}

		public void OpenMenu()
		{
			Main.Instance.QuickMenuStuff.menuStateController.Method_Public_Void_String_UIContext_Boolean_TransitionType_0(page.field_Public_String_0, null, param_3: false, UIPage.TransitionType.None);
		}

		public void CloseMenu()
		{
			page.Method_Public_Virtual_New_Void_0();
		}
	}
}

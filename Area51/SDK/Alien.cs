using System.Linq;
using Area51.SDK.ButtonAPI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;

namespace Area51.SDK
{
	public class Alien
	{
		public Image Button_WorldsIcon;

		public Image Button_AvatarsIcon;

		public Image Button_SocialIcon;

		public Image Button_SafetyIcon;

		public Image Panel_NoNotifications_MessageIcon;

		public Image Button_NameplateVisibleIcon;

		public Image Button_GoHomeIcon;

		public Image Button_RespawnIcon;

		public Image StandIcon;

		public Transform tabMenuTemplat;

		public Transform Menu_DevTools;

		public Transform Menu_Dashboard;

		public Transform QMParent;

		public Transform page_Buttons_QM;

		public VRC.UI.Elements.QuickMenu quickMenu;

		public static VRC.UI.Elements.QuickMenu Qmenu;

		public SelectedUserMenuQM SelectedUserMenuQM;

		public MenuStateController menuStateController;

		public static bool UIUpdated;

		public static object Instance { get; internal set; }

		public static bool Carousel_Banners(bool state)
		{
			return GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners/Image_MASK").active = state;
		}

		public static bool VRCP_PageTab(bool state)
		{
			return GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/VRC+PageTab").active = state;
		}

		public static bool QM_Badge_Icon(bool state)
		{
			return GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand/Icon").active = state;
		}

		public static string QM_Text(string Text_title)
		{
			return GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>().text = Text_title;
		}

		public static float QM_Text_Size(float _Size)
		{
			return GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>().fontSize = _Size;
		}

		public static bool QM_Text_Wrapping(bool state)
		{
			return GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>().enableWordWrapping = state;
		}

		public Alien()
		{
			quickMenu = Resources.FindObjectsOfTypeAll<VRC.UI.Elements.QuickMenu>().First();
			menuStateController = quickMenu.gameObject.GetComponent<MenuStateController>();
			Button_WorldsIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/Button_Worlds/Icon").GetComponent<Image>();
			Button_AvatarsIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/Button_Avatars/Icon").GetComponent<Image>();
			Button_SocialIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/Button_Social/Icon").GetComponent<Image>();
			Button_SafetyIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/Button_Safety/Icon").GetComponent<Image>();
			Button_GoHomeIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_GoHome/Icon").GetComponent<Image>();
			Button_RespawnIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Respawn/Icon").GetComponent<Image>();
			StandIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/SitStandCalibrateButton/Button_SitStand/Icon_Off").GetComponent<Image>();
			Panel_NoNotifications_MessageIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Notifications/Panel_NoNotifications_Message/Icon").gameObject.GetComponent<Image>();
			Button_NameplateVisibleIcon = quickMenu.transform.Find("Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_NameplateControls/Buttons/Button A/Icon").GetComponent<Image>();
			SelectedUserMenuQM = quickMenu.transform.Find("Container/Window/QMParent/Menu_SelectedUser_Local").GetComponent<SelectedUserMenuQM>();
			tabMenuTemplat = quickMenu.transform.Find("Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools");
			Menu_DevTools = quickMenu.transform.Find("Container/Window/QMParent/Menu_DevTools");
			QMParent = quickMenu.transform.Find("Container/Window/QMParent");
			page_Buttons_QM = quickMenu.transform.Find("Container/Window/Page_Buttons_QM/HorizontalLayoutGroup");
			Menu_Dashboard = quickMenu.transform.Find("Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings");
		}

		public static void Spacer(Transform parrent)
		{
			new QMTEST(parrent);
			new QMTEST(parrent);
			new QMTEST(parrent);
			new QMTEST(parrent);
			new QMTEST(parrent);
			new QMTEST(parrent);
			new QMTEST(parrent);
			new QMTEST(parrent);
		}

		public static void ThemeUI()
		{
			try
			{
				if (!UIUpdated)
				{
					Carousel_Banners(state: false);
					QM_Text("");
					QM_Text_Size(44f);
					QM_Text_Wrapping(state: false);
					UIUpdated = true;
					LogHandler.Log(LogHandler.Colors.Green, "[THEME] Set");
				}
			}
			catch
			{
			}
		}
	}
}

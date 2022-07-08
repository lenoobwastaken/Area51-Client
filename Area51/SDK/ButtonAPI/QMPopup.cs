using System;
using System.Linq;
using System.Reflection;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine.UI;

namespace Area51.SDK.ButtonAPI
{
	public static class QMPopup
	{
		public delegate void ShowUiInputPopupAction(string title, string initialText, InputField.InputType inputType, bool isNumeric, string confirmButtonText, Il2CppSystem.Action<string, List<KeyCode>, Text> onComplete, Il2CppSystem.Action onCancel, string placeholderText = "Enter text...", bool closeAfterInput = true, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null, bool startOnLeft = false, int characterLimit = 0);

		public delegate void ShowUiStandardPopup1Action(string title, string body, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

		public delegate void ShowUiStandardPopup2Action(string title, string body, string middleButtonText, Il2CppSystem.Action middleButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

		public delegate void ShowUiStandardPopup3Action(string title, string body, string leftButtonText, Il2CppSystem.Action leftButtonAction, string rightButtonText, Il2CppSystem.Action rightButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

		public delegate void ShowUiStandardPopupV21Action(string title, string body, string middleButtonText, Il2CppSystem.Action middleButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

		public delegate void ShowUiStandardPopupV22Action(string title, string body, string leftButtonText, Il2CppSystem.Action leftButtonAction, string rightButtonText, Il2CppSystem.Action rightButtonAction, Il2CppSystem.Action<VRCUiPopup> onPopupShown = null);

		public delegate void ShowUiAlertPopupAction(string title, string body, float timeout);

		private static ShowUiInputPopupAction ourShowUiInputPopupAction;

		private static ShowUiStandardPopup1Action ourShowUiStandardPopup1Action;

		private static ShowUiStandardPopup2Action ourShowUiStandardPopup2Action;

		private static ShowUiStandardPopup3Action ourShowUiStandardPopup3Action;

		private static ShowUiStandardPopupV21Action ourShowUiStandardPopupV21Action;

		private static ShowUiStandardPopupV22Action ourShowUiStandardPopupV22Action;

		private static ShowUiAlertPopupAction ourShowUiAlertPopupAction;

		public static ShowUiInputPopupAction ShowUiInputPopup
		{
			get
			{
				if (ourShowUiInputPopupAction != null)
				{
					return ourShowUiInputPopupAction;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo it) => it.GetParameters().Length == 12 && XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/InputPopup"));
				ourShowUiInputPopupAction = (ShowUiInputPopupAction)System.Delegate.CreateDelegate(typeof(ShowUiInputPopupAction), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiInputPopupAction;
			}
		}

		public static ShowUiStandardPopup1Action ShowUiStandardPopup1
		{
			get
			{
				if (ourShowUiStandardPopup1Action != null)
				{
					return ourShowUiStandardPopup1Action;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo it) => it.GetParameters().Length == 3 && !it.Name.Contains("PDM") && XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopup"));
				ourShowUiStandardPopup1Action = (ShowUiStandardPopup1Action)System.Delegate.CreateDelegate(typeof(ShowUiStandardPopup1Action), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiStandardPopup1Action;
			}
		}

		public static ShowUiStandardPopup2Action ShowUiStandardPopup2
		{
			get
			{
				if (ourShowUiStandardPopup2Action != null)
				{
					return ourShowUiStandardPopup2Action;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo it) => it.GetParameters().Length == 5 && !it.Name.Contains("PDM") && XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopup"));
				ourShowUiStandardPopup2Action = (ShowUiStandardPopup2Action)System.Delegate.CreateDelegate(typeof(ShowUiStandardPopup2Action), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiStandardPopup2Action;
			}
		}

		public static ShowUiStandardPopup3Action ShowUiStandardPopup3
		{
			get
			{
				if (ourShowUiStandardPopup3Action != null)
				{
					return ourShowUiStandardPopup3Action;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo it) => it.GetParameters().Length == 7 && !it.Name.Contains("PDM") && XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopup"));
				ourShowUiStandardPopup3Action = (ShowUiStandardPopup3Action)System.Delegate.CreateDelegate(typeof(ShowUiStandardPopup3Action), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiStandardPopup3Action;
			}
		}

		public static ShowUiStandardPopupV21Action ShowUiStandardPopupV21
		{
			get
			{
				if (ourShowUiStandardPopupV21Action != null)
				{
					return ourShowUiStandardPopupV21Action;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo it) => it.GetParameters().Length == 5 && !it.Name.Contains("PDM") && XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopupV2"));
				ourShowUiStandardPopupV21Action = (ShowUiStandardPopupV21Action)System.Delegate.CreateDelegate(typeof(ShowUiStandardPopupV21Action), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiStandardPopupV21Action;
			}
		}

		public static ShowUiStandardPopupV22Action ShowUiStandardPopupV22
		{
			get
			{
				if (ourShowUiStandardPopupV22Action != null)
				{
					return ourShowUiStandardPopupV22Action;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo it) => it.GetParameters().Length == 7 && !it.Name.Contains("PDM") && XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/StandardPopupV2"));
				ourShowUiStandardPopupV22Action = (ShowUiStandardPopupV22Action)System.Delegate.CreateDelegate(typeof(ShowUiStandardPopupV22Action), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiStandardPopupV22Action;
			}
		}

		public static ShowUiAlertPopupAction ShowUiAlertPopup
		{
			get
			{
				if (ourShowUiAlertPopupAction != null)
				{
					return ourShowUiAlertPopupAction;
				}
				MethodInfo method = typeof(VRCUiPopupManager).GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((MethodInfo it) => it.GetParameters().Length == 3 && XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject()?.ToString() == "UserInterface/MenuContent/Popups/AlertPopup"));
				ourShowUiAlertPopupAction = (ShowUiAlertPopupAction)System.Delegate.CreateDelegate(typeof(ShowUiAlertPopupAction), VRCUiPopupManager.prop_VRCUiPopupManager_0, method);
				return ourShowUiAlertPopupAction;
			}
		}

		public static void HideCurrentPopup(this VRCUiPopupManager vrcUiPopupManager)
		{
		}

		public static void ShowStandardPopup(this VRCUiPopupManager vrcUiPopupManager, string title, string content, System.Action<VRCUiPopup> onCreated = null)
		{
			ShowUiStandardPopup1(title, content, onCreated);
		}

		public static void ShowStandardPopup(this VRCUiPopupManager vrcUiPopupManager, string title, string content, string buttonText, System.Action buttonAction, System.Action<VRCUiPopup> onCreated = null)
		{
			ShowUiStandardPopup2(title, content, buttonText, buttonAction, onCreated);
		}

		public static void ShowStandardPopup(this VRCUiPopupManager vrcUiPopupManager, string title, string content, string button1Text, System.Action button1Action, string button2Text, System.Action button2Action, System.Action<VRCUiPopup> onCreated = null)
		{
			ShowUiStandardPopup3(title, content, button1Text, button1Action, button2Text, button2Action, onCreated);
		}

		public static void ShowStandardPopupV2(this VRCUiPopupManager vrcUiPopupManager, string title, string content, string buttonText, System.Action buttonAction, System.Action<VRCUiPopup> onCreated = null)
		{
			ShowUiStandardPopupV21(title, content, buttonText, buttonAction, onCreated);
		}

		public static void ShowStandardPopupV2(this VRCUiPopupManager vrcUiPopupManager, string title, string content, string button1Text, System.Action button1Action, string button2Text, System.Action button2Action, System.Action<VRCUiPopup> onCreated = null)
		{
			ShowUiStandardPopupV22(title, content, button1Text, button1Action, button2Text, button2Action, onCreated);
		}

		public static void ShowInputPopup(this VRCUiPopupManager vrcUiPopupManager, string title, string preFilledText, InputField.InputType inputType, bool keypad, string buttonText, Il2CppSystem.Action<string, List<KeyCode>, Text> buttonAction, Il2CppSystem.Action cancelAction, string boxText = "Enter text....", bool closeOnAccept = true, System.Action<VRCUiPopup> onCreated = null, bool startOnLeft = false, int characterLimit = 0)
		{
			ShowUiInputPopup(title, preFilledText, inputType, keypad, buttonText, buttonAction, cancelAction, boxText, closeOnAccept, onCreated, startOnLeft, characterLimit);
		}

		public static void ShowAlert(this VRCUiPopupManager vrcUiPopupManager, string title, string content, float timeout)
		{
			ShowUiAlertPopup(title, content, timeout);
		}
	}
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Tooltips;

namespace Area51.SDK.ButtonAPI
{
	public class QMToggleButton
	{
		public Toggle toggleButton;

		public QMToggleButton(Transform parent, string text, string toolTip, Action<bool> action)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_ToggleQMInfo").gameObject, parent);
			gameObject.transform.parent = parent;
			gameObject.name = text + "_Area51_ToggleButton";
			gameObject.transform.Find("Text_H4").gameObject.GetComponent<TextMeshProUGUI>().text = text;
			gameObject.transform.Find("Text_H4").GetComponent<TMP_Text>().faceColor = Color.green;
			gameObject.transform.Find("Background").GetComponent<Image>().color = Color.black;
			gameObject.transform.Find("Icon_On").GetComponent<Image>().sprite = ButtonIcons.OnIcon;
			gameObject.transform.Find("Icon_Off").GetComponent<Image>().sprite = ButtonIcons.OffIcon;
			gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = toolTip;
			toggleButton = gameObject.GetComponent<Toggle>();
			toggleButton.onValueChanged = new Toggle.ToggleEvent();
			toggleButton.onValueChanged.AddListener(action);
			gameObject.SetActive(value: true);
		}
	}
}

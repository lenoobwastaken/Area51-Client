using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Tooltips;

namespace Area51.SDK.ButtonAPI
{
	public class QMSingleButton
	{
		public QMSingleButton(Transform parent, string text, string toolTip, Sprite Icon, Action action)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_SelectUser").gameObject, parent);
			gameObject.transform.parent = parent;
			gameObject.name = text + "_Area51_Button";
			gameObject.transform.Find("Text_H4").gameObject.GetComponent<TextMeshProUGUI>().text = text;
			gameObject.transform.Find("Text_H4").GetComponent<TMP_Text>().faceColor = Color.green;
			gameObject.transform.Find("Background").GetComponent<Image>().color = Color.black;
			gameObject.transform.Find("Badge_MMJump").gameObject.active = true;
			if (Icon != null)
			{
				gameObject.transform.Find("Icon").GetComponent<Image>().sprite = Icon;
			}
			else
			{
				UnityEngine.Object.Destroy(gameObject.transform.Find("Icon").GetComponent<Image>());
			}
			gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = toolTip;
			Button component = gameObject.GetComponent<Button>();
			component.StartColorTween(Color.green, instant: true);
			component.onClick = new Button.ButtonClickedEvent();
			component.onClick.AddListener(action);
			gameObject.SetActive(value: true);
		}
	}
}

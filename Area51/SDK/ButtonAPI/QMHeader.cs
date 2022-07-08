using TMPro;
using UnityEngine;

namespace Area51.SDK.ButtonAPI
{
	internal class QMHeader
	{
		public QMHeader(Transform menu, string contents)
		{
			GameObject gameObject = Object.Instantiate(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks").gameObject, menu);
			gameObject.transform.parent = menu;
			gameObject.name = "Header_" + contents;
			gameObject.SetActive(value: true);
			gameObject.GetComponentInChildren<TextMeshProUGUI>().text = contents;
		}
	}
}

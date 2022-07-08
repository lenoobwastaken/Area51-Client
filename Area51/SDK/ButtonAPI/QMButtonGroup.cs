using UnityEngine;
using UnityEngine.UI;

namespace Area51.SDK.ButtonAPI
{
	public class QMButtonGroup
	{
		public GameObject buttonGroup;

		public int buttonamount;

		public QMButtonGroup(Transform parent, string name)
		{
			buttonGroup = Object.Instantiate(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks").gameObject, parent);
			buttonGroup.name = "Buttons_" + name;
			buttonGroup.GetComponent<GridLayoutGroup>().childAlignment = TextAnchor.MiddleLeft;
			for (int i = 0; i < buttonGroup.transform.childCount; i++)
			{
				Object.Destroy(buttonGroup.transform.GetChild(i).gameObject);
			}
		}
	}
}

using UnityEngine;

namespace Area51.SDK.ButtonAPI
{
	public class QMTEST
	{
		public QMTEST(Transform parent)
		{
			GameObject gameObject = Object.Instantiate(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis").gameObject, parent);
			gameObject.transform.parent = parent;
			gameObject.name = "_Spacer";
			gameObject.transform.Find("Text_H4").gameObject.active = false;
			gameObject.transform.Find("Background").gameObject.active = false;
			gameObject.transform.Find("Badge_MMJump").gameObject.active = false;
			gameObject.transform.Find("Icon").gameObject.active = false;
			gameObject.SetActive(value: true);
		}
	}
}

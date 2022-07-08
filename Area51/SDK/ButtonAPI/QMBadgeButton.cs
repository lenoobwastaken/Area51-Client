using UnityEngine;

namespace Area51.SDK.ButtonAPI
{
	public class QMBadgeButton
	{
		public QMBadgeButton(Transform parent, int x, int y)
		{
			GameObject gameObject = Object.Instantiate(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMNotificationsArea/DebugInfoPanel/Panel/Background").gameObject, parent);
			gameObject.transform.localPosition = new Vector3(x, y, -1f);
			gameObject.name = "_Area51_ConsoleBackground";
			gameObject.transform.parent = parent;
		}
	}
}

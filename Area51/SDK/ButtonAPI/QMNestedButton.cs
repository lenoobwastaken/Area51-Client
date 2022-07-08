using UnityEngine;

namespace Area51.SDK.ButtonAPI
{
	public class QMNestedButton
	{
		public QMMenu menu;

		public Transform menuTransform;

		public QMNestedButton(Transform perant, string name, Sprite icon = null)
		{
			menu = new QMMenu(name, name, root: false);
			menuTransform = menu.menuContents;
			new QMSingleButton(perant, name, name, icon, delegate
			{
				menu.OpenMenu();
			});
		}
	}
}

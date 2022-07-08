using System.Collections;
using Area51.SDK;
using MelonLoader;
using TMPro;
using UnityEngine;

namespace Area51.Module.Settings.Render
{
	internal class BlockedPlayers : BaseModule
	{
		public static int Count;

		public static GameObject Menuhere = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here");

		public static GameObject BlockedMenu = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/QM_Foldout_BlockedByUsersInWorld");

		public static GameObject BlockedGrid = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/QM_Grid_BlockedByUsersInWorld");

		public static GameObject label = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/QM_Foldout_BlockedByUsersInWorld/Label");

		public BlockedPlayers()
			: base("Blocked Players", "Displays Blocked Players In World Playerlist", Main.Instance.SettingsButtonrender, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			MelonCoroutines.Start(Loop());
		}

		public override void OnDisable()
		{
			BlockedMenu.SetActive(value: false);
			BlockedGrid.SetActive(value: false);
		}

		public IEnumerator Loop()
		{
			if (toggled)
			{
				Count = BlockedGrid.transform.childCount;
				while (Menuhere != null && Count > 0)
				{
					try
					{
						BlockedMenu.SetActive(value: true);
						BlockedMenu.isStatic = true;
						BlockedMenu.active = true;
						BlockedGrid.SetActive(value: true);
						label.GetComponent<TextMeshProUGUI>().m_text = "Users Blocking You - " + Count;
						label.GetComponent<TextMeshProUGUI>().m_fontColor = new Color(0.2588f, 0.4431f, 0.451f, 1f);
						label.GetComponent<TextMeshProUGUI>().m_InternalTextProcessingArraySize = 10;
					}
					catch
					{
						LogHandler.LogDebug("Failed To Set Objects as Active");
					}
					if (!toggled)
					{
						OnDisable();
						break;
					}
					yield return new WaitForSeconds(0.4f);
				}
			}
			else
			{
				OnDisable();
			}
		}
	}
}

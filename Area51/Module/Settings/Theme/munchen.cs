using System;
using System.Threading.Tasks;
using Area51.Events;
using UnityEngine;

namespace Area51.Module.Settings.Theme
{
	internal class munchen : BaseModule, OnUpdateEvent
	{
		public munchen()
			: base("Hide Tab", "Hides/Shows Munchen", Main.Instance.SettingsButtonTheme, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			try
			{
				Main.Instance.OnUpdateEvents.Add(this);
			}
			catch (NullReferenceException ex)
			{
				ex.Message.Contains("Object reference not set to an instance of an object");
			}
		}

		public override void OnDisable()
		{
			try
			{
				Main.Instance.OnUpdateEvents.Remove(this);
				GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_MünchenClientMünchenClient2/").active = true;
			}
			catch (NullReferenceException ex)
			{
				ex.Message.Contains("Object reference not set to an instance of an object");
			}
		}

		public async Task setUITheme(int WaitToUpdate)
		{
			try
			{
				for (int i = 0; i < WaitToUpdate; i++)
				{
					GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_MünchenClientMünchenClient2/").active = false;
				}
			}
			catch (NullReferenceException)
			{
			}
		}

		public void OnUpdate()
		{
			try
			{
				setUITheme(1).Start();
			}
			catch (Exception)
			{
			}
		}
	}
}

using TMPro;
using UnityEngine;

namespace Area51.SDK.ButtonAPI
{
	public class QMConsoleButton
	{
		public GameObject mainObj;

		public TextMeshProUGUI txtCom;

		public QMConsoleButton(string txt)
		{
			Init(txt);
		}

		private void Init(string txt)
		{
			GameObject gameObject = (mainObj = new GameObject("Text"));
			txtCom = mainObj.AddComponent<TextMeshProUGUI>();
			txtCom.fontSize = 28f;
			txtCom.text = txt;
			txtCom.autoSizeTextContainer = false;
			Vector2 sizeDelta = new Vector2(890f, 32.5f);
			mainObj.GetComponent<RectTransform>().sizeDelta = sizeDelta;
		}
	}
}

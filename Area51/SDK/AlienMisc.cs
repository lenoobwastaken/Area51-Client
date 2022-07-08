using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Area51.SDK
{
	internal class AlienMisc
	{
		internal class BufferRW
		{
			public static byte[] Vector3ToBytes(Vector3 vector3)
			{
				byte[] array = new byte[12];
				System.Buffer.BlockCopy(System.BitConverter.GetBytes(vector3.x), 0, array, 0, 4);
				System.Buffer.BlockCopy(System.BitConverter.GetBytes(vector3.y), 0, array, 4, 4);
				System.Buffer.BlockCopy(System.BitConverter.GetBytes(vector3.z), 0, array, 8, 4);
				return array;
			}

			public static Vector3 ReadVector3(byte[] buffer, int index)
			{
				float x = System.BitConverter.ToSingle(buffer, index);
				float y = System.BitConverter.ToSingle(buffer, index + 4);
				float z = System.BitConverter.ToSingle(buffer, index + 8);
				return new Vector3(x, y, z);
			}
		}

		private static AudioClip audiofile;

		private static AudioSource audiosource;

		private static AudioSource audiosource2;

		public static Il2CppSystem.Action CloseKeyboardAction => DelegateSupport.ConvertDelegate<Il2CppSystem.Action>((System.Action)delegate
		{
			CloseKeyboard();
		});

		public static void CloseKeyboard()
		{
			VRCUiManager.prop_VRCUiManager_0.Method_Public_Void_Boolean_Boolean_1(param_1: true);
		}

		public static void OpenKeyboard(string title, string text, System.Action<string, List<KeyCode>, Text> action)
		{
			Il2CppSystem.Action<string, List<KeyCode>, Text> param_ = DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, List<KeyCode>, Text>>(action);
			VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0(title, null, InputField.InputType.Standard, param_4: false, "Okay", param_, CloseKeyboardAction, text, param_9: true, null, param_11: false, 0);
		}

		public static string RandomString(int length)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!§$%&/()=?";
			string text2 = "";
			System.Random random = new System.Random();
			for (int i = 0; i < length; i++)
			{
				text2 += text[random.Next(text.Length - 1)];
			}
			return text2;
		}

		internal static string Base64Decode(string base64EncodedData)
		{
			byte[] bytes = System.Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(bytes);
		}

		internal static string GetClipboard()
		{
			if (Clipboard.ContainsText())
			{
				return Clipboard.GetText();
			}
			return "";
		}

		internal static void Pasteit()
		{
			Transform transform = PlayerWrapper.keyboardPopup.transform.Find("ButtonRight");
			GameObject gameObject = UnityEngine.Object.Instantiate(transform.gameObject, transform.parent);
			RectTransform component = gameObject.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(450f, 160f);
			component.sizeDelta = new Vector2(165f, 98.8f);
			gameObject.GetComponentInChildren<Text>().text = "Paste it!";
			UnityEngine.UI.Button component2 = gameObject.GetComponent<UnityEngine.UI.Button>();
			System.Action action = delegate
			{
				PlayerWrapper.keyboardPopup.GetComponentInChildren<InputField>().text = Clipboard.GetText();
			};
			component2.onClick = new UnityEngine.UI.Button.ButtonClickedEvent();
			component2.onClick.AddListener(action);
		}

		public static string GetBase64StringForImage(string imgPath)
		{
			byte[] inArray = File.ReadAllBytes(imgPath);
			return System.Convert.ToBase64String(inArray);
		}

		internal static void SetClipboard(string Set)
		{
			if (Clipboard.ContainsText())
			{
				Clipboard.Clear();
				Clipboard.SetText(Set);
			}
			Clipboard.SetText(Set);
		}

		public static IEnumerator LoadingMusic()
		{
			UnityWebRequest uwr = UnityWebRequest.Get("file://" + Path.Combine(System.Environment.CurrentDirectory, "Area51/LoadingScreenMusic/Music.ogg"));
			uwr.SendWebRequest();
			while (!uwr.isDone)
			{
				yield return null;
			}
			audiofile = WebRequestWWW.InternalCreateAudioClipUsingDH(uwr.downloadHandler, uwr.url, stream: false, compressed: false, AudioType.UNKNOWN);
			audiofile.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			while (audiosource == null)
			{
				audiosource = GameObject.Find("LoadingBackground_TealGradient_Music/LoadingSound")?.GetComponent<AudioSource>();
				yield return null;
			}
			audiosource.clip = audiofile;
			audiosource.Stop();
			audiosource.Play();
			while (audiosource2 == null)
			{
				audiosource2 = GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/LoadingSound")?.GetComponent<AudioSource>();
				yield return null;
			}
			audiosource2.clip = audiofile;
			audiosource2.Stop();
			audiosource2.Play();
		}
	}
}

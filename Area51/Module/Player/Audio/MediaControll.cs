using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Area51.Module.Player.Audio
{
	internal class MediaControll
	{
		public static bool Mediaenabled = true;

		private static int KEYEVENTF_KEYUP = 2;

		private static byte mediaPlayPause = 179;

		private static byte mediaNextTrack = 176;

		private static byte mediaPreviousTrack = 177;

		private static byte mediaStop = 178;

		private static byte volUp = 175;

		private static byte volDown = 174;

		private static byte volMute = 173;

		public static IEnumerator StartButtons()
		{
			GameObject gameObject = new GameObject();
			gameObject.name = "MediaControlls";
			gameObject.transform.parent = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window").transform;
			GameObject original = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/MicButton");
			GameObject gameObject2 = Object.Instantiate(original);
			Transform[] array = gameObject2.GetComponentsInChildren<Transform>();
			Transform[] array2 = array;
			foreach (Transform transform in array2)
			{
				transform.gameObject.SetActive(value: false);
			}
			gameObject2.name = "Play/Pause";
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.localPosition = new Vector3(-398.6742f, 442.0022f, -1.0042f);
			gameObject2.GetComponent<RectTransform>().localEulerAngles = new Vector3(14.8696f, 13.5636f, 358.7352f);
			gameObject2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			yield return null;
		}

		[DllImport("user32.dll", SetLastError = true)]
		private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

		internal static void PlayPause()
		{
			keybd_event(mediaPlayPause, mediaPlayPause, 0, 0);
			keybd_event(mediaPlayPause, mediaPlayPause, KEYEVENTF_KEYUP, 0);
		}

		internal static void PrevTrack()
		{
			keybd_event(mediaPreviousTrack, mediaPreviousTrack, 0, 0);
			keybd_event(mediaPreviousTrack, mediaPreviousTrack, KEYEVENTF_KEYUP, 0);
		}

		internal static void NextTrack()
		{
			keybd_event(mediaNextTrack, mediaNextTrack, 0, 0);
			keybd_event(mediaNextTrack, mediaNextTrack, KEYEVENTF_KEYUP, 0);
		}

		internal static void Stop()
		{
			keybd_event(mediaStop, mediaStop, 0, 0);
			keybd_event(mediaStop, mediaStop, KEYEVENTF_KEYUP, 0);
		}

		internal static void VolumeUp()
		{
			keybd_event(volUp, volUp, 0, 0);
			keybd_event(volUp, volUp, KEYEVENTF_KEYUP, 0);
		}

		internal static void VolumeDown()
		{
			keybd_event(volDown, volDown, 0, 0);
			keybd_event(volDown, volDown, KEYEVENTF_KEYUP, 0);
		}

		internal static void VolumeMute()
		{
			keybd_event(volMute, volMute, 0, 0);
			keybd_event(volMute, volMute, KEYEVENTF_KEYUP, 0);
		}
	}
}

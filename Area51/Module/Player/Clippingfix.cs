using System;
using Area51.SDK;
using UnityEngine;
using VRC.UserCamera;

namespace Area51.Module.Player
{
	internal class Clippingfix : BaseModule
	{
		public static bool _clippingfix;

		public Clippingfix()
			: base("Clipping Fix", "Fixes Clipping In Some Worlds", Main.Instance.SettingsButtonpreformance, null, isToggle: true)
		{
		}

		public override void OnEnable()
		{
			_clippingfix = true;
		}

		public override void OnDisable()
		{
			_clippingfix = false;
		}

		public static void Fix()
		{
			while (_clippingfix)
			{
				try
				{
					VRCVrCamera field_Private_Static_VRCVrCamera_ = VRCVrCamera.field_Private_Static_VRCVrCamera_0;
					UserCameraController field_Internal_Static_UserCameraController_ = UserCameraController.field_Internal_Static_UserCameraController_0;
					if (field_Internal_Static_UserCameraController_ != null && field_Internal_Static_UserCameraController_.field_Internal_UserCameraIndicator_0.GetComponent<Camera>() != null)
					{
						field_Internal_Static_UserCameraController_.field_Internal_UserCameraIndicator_0.GetComponent<Camera>().nearClipPlane = 0.01f;
					}
					if (field_Private_Static_VRCVrCamera_ != null)
					{
						field_Private_Static_VRCVrCamera_.field_Public_Camera_0.nearClipPlane = 0.02f;
					}
				}
				catch
				{
					LogHandler.LogDebug("Failed To Init Clipping Fix :(");
					Console.WriteLine("Failed To Init Clipping Fix");
				}
			}
		}
	}
}

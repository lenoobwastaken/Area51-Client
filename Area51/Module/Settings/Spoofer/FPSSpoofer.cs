using Area51.Events;
using Area51.SDK.Photon;
using Il2CppSystem;
using Photon.Realtime;
using UnhollowerBaseLib;

namespace Area51.Module.Settings.Spoofer
{
	internal class FPSSpoofer : BaseModule, OnSendOPEvent
	{
		private byte fps;

		public FPSSpoofer()
			: base("FPS Spoof", "Spoofes FPS to 51", Main.Instance.SettingsButtonspoofer, null, isToggle: true)
		{
			fps = 51;
		}

		public bool OnSendOP(byte opCode, ref Object parameters, ref RaiseEventOptions raiseEventOptions)
		{
			if (opCode == 7)
			{
				byte[] array = parameters.Cast<Il2CppStructArray<byte>>();
				array[71] = fps;
				parameters = Serialization.FromManagedToIL2CPP<Object>(array);
			}
			return true;
		}
	}
}

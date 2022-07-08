using ExitGames.Client.Photon;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using VRC;

namespace Area51.SDK.Photon
{
	internal static class PhotonExtensions
	{
		public static void OpRaiseEvent(byte code, Object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
		{
			PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(code, customObject, RaiseEventOptions, sendOptions);
		}

		public static void OpRaiseEvent(byte code, object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
		{
			Object customObject2 = Serialization.FromManagedToIL2CPP<Object>(customObject);
			OpRaiseEvent(code, customObject2, RaiseEventOptions, sendOptions);
		}

		public static Dictionary<int, global::Photon.Realtime.Player> GetAllPhotonPlayers()
		{
			return VRC.Player.prop_Player_0.prop_Player_1.prop_Room_0.prop_Dictionary_2_Int32_Player_0;
		}
	}
}

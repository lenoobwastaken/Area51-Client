using Area51.Events;
using Area51.SDK;
using ExitGames.Client.Photon;
using UnhollowerBaseLib;
using VRC;

namespace Area51.Module.Safety
{
	internal class Anti210 : BaseModule, OnEventEvent
	{
		public Anti210()
			: base("Event210", "Anti for the Event210 Exploit", Main.Instance.Networkbutton, null, isToggle: true, save: true)
		{
		}

		public override void OnEnable()
		{
			Main.Instance.OnEventEvents.Add(this);
		}

		public override void OnDisable()
		{
			Main.Instance.OnEventEvents.Remove(this);
		}

		public bool OnEvent(EventData eventData)
		{
			if (eventData.Code == 210)
			{
				VRC.Player playerWithPlayerID = PlayerWrapper.GetPlayerWithPlayerID(eventData.sender);
				if (playerWithPlayerID == null)
				{
					LogHandler.Log(LogHandler.Colors.Red, "Blocked Invalid 210");
					return false;
				}
				Il2CppStructArray<int> il2CppStructArray = eventData.Parameters[245].TryCast<Il2CppStructArray<int>>();
				if (il2CppStructArray[1] != playerWithPlayerID.prop_VRCPlayerApi_0.playerId)
				{
					LogHandler.Log(LogHandler.Colors.Red, "Blocked Invalid 210");
					return false;
				}
			}
			return true;
		}
	}
}

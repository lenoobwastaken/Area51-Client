using Area51.Events;
using ExitGames.Client.Photon;
using UnhollowerBaseLib;

namespace Area51.Module.Safety
{
	internal class Anti7 : BaseModule, OnEventEvent
	{
		public Anti7()
			: base("Anti7", "Prevents Menu Exploit", Main.Instance.Networkbutton, null, isToggle: true, save: true)
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
			if (eventData.Code == 7)
			{
				Il2CppArrayBase<byte> il2CppArrayBase = eventData.CustomData.Cast<Il2CppArrayBase<byte>>();
				if (il2CppArrayBase.Length > 300)
				{
					return false;
				}
				return true;
			}
			return true;
		}
	}
}

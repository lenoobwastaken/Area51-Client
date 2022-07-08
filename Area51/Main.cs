using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Area51.Events;
using Area51.Module;
using Area51.SDK;
using Area51.SDK.ButtonAPI;
using Area51.SDK.Patching;
using Area51.SDK.Security;
using MelonLoader;
using UnhollowerRuntimeLib;

namespace Area51
{
	public class Main
	{
		public static bool kimiisgay;

		public static bool isGay;

		public static Main Instance { get; set; }

		public Config Config { get; set; } = new Config();


		public Alien QuickMenuStuff { get; set; }

		public QMNestedButton PlayerButton { get; set; }

		public QMNestedButton MovementButton { get; set; }

		public QMNestedButton ExploistButton { get; set; }

		public QMNestedButton Eventexploitbutton { get; set; }

		public QMNestedButton Avatarexploitbutton { get; set; }

		public QMNestedButton SpoofersButton { get; set; }

		public QMNestedButton SafetyButton { get; set; }

		public QMNestedButton WorldButton { get; set; }

		public QMNestedButton WorldhacksButton { get; set; }

		public QMNestedButton Murderbutton { get; set; }

		public QMNestedButton Justbbutton { get; set; }

		public QMNestedButton Justhbutton { get; set; }

		public QMNestedButton BotButton { get; set; }

		public QMNestedButton Networkbutton { get; set; }

		public QMNestedButton Avatarbutton { get; set; }

		public QMNestedButton SettingsButton { get; set; }

		public QMNestedButton SettingsButtonLoggging { get; set; }

		public QMNestedButton SettingsButtonDumping { get; set; }

		public QMNestedButton SettingsButtonpreformance { get; set; }

		public QMNestedButton SettingsButtonrender { get; set; }

		public QMNestedButton SettingsButtonspoofer { get; set; }

		public QMNestedButton SettingsButtonTheme { get; set; }

		public QMNestedButton Targetbutton { get; set; }

		public QMNestedButton AvatarSettings { get; set; }

		public QMNestedButton MurderSettings { get; set; }

		public QMNestedButton Reuploader { get; set; }

		public QMNestedButton Amongusbutton { get; set; }

		public QMNestedButton Preformancebutton { get; set; }

		public QMNestedButton Privatebotbutton { get; set; }

		public QMNestedButton Publicbotbutton { get; set; }

		public QMNestedButton Zombiebutton { get; set; }

		public QMNestedButton JustBRoomsbutton { get; set; }

		public QMNestedButton EventQuickMenu { get; set; }

		public QMNestedButton WorldhacksTargetButton { get; set; }

		public QMNestedButton Magictagbutton { get; set; }

		public QMNestedButton AmongUsSettings { get; set; }

		public QMNestedButton GameCheatsMenu { get; set; }

		public static string WorldName { get; set; }

		public QMNestedButton MovienChill { get; set; }

		public QMNestedButton MovienChillTarget { get; set; }

		public QMNestedButton sovren { get; set; }

		public QMNestedButton sovrenTarget { get; set; }

		public QMNestedButton TruDare { get; set; }

		public QMNestedButton TruDareTarget { get; set; }

		public QMNestedButton BattleDisc { get; set; }

		public QMNestedButton AudioButton { get; set; }

		public QMNestedButton MidnightButton { get; set; }

		public QMNestedButton JubstBSettings { get; set; }

		public QMNestedButton MagicTagSettings { get; set; }

		public QMNestedButton udonexploitbutton { get; set; }

		internal List<BaseModule> Modules { get; set; } = new List<BaseModule>();


		public List<OnPlayerJoinEvent> OnPlayerJoinEvents { get; set; } = new List<OnPlayerJoinEvent>();


		public List<OnAssetBundleLoadEvent> OnAssetBundleLoadEvents { get; set; } = new List<OnAssetBundleLoadEvent>();


		public List<OnPlayerLeaveEvent> OnPlayerLeaveEvents { get; set; } = new List<OnPlayerLeaveEvent>();


		public List<OnUpdateEvent> OnUpdateEvents { get; set; } = new List<OnUpdateEvent>();


		public List<OnUdonEvent> OnUdonEvents { get; set; } = new List<OnUdonEvent>();


		public List<OnEventEvent> OnEventEvents { get; set; } = new List<OnEventEvent>();


		public List<OnRPCEvent> OnRPCEvents { get; set; } = new List<OnRPCEvent>();


		public List<OnAvatarLoadedEvent> OnAvatarLoadEvents { get; set; } = new List<OnAvatarLoadedEvent>();


		public List<OnSendOPEvent> OnSendOPEvents { get; set; } = new List<OnSendOPEvent>();


		public List<OnSceneLoadedEvent> OnSceneLoadedEvents { get; set; } = new List<OnSceneLoadedEvent>();


		public List<OnWorldInitEvent> OnWorldInitEvents { get; set; } = new List<OnWorldInitEvent>();


		public List<OnNetworkSanityEvent> OnNetworkSanityEvents { get; set; } = new List<OnNetworkSanityEvent>();


		public List<OnObjectInstantiatedEvent> OnObjectInstantiatedEvents { get; set; } = new List<OnObjectInstantiatedEvent>();


		public List<OnPhotonPeerEvent> OnPhotonPeerEvents { get; set; } = new List<OnPhotonPeerEvent>();


		public OnPhotonPeerEvent[] OnPhotonPeerEventArray { get; set; } = new OnPhotonPeerEvent[0];


		public OnPlayerJoinEvent[] OnPlayerJoinEventArray { get; set; } = new OnPlayerJoinEvent[0];


		public OnAssetBundleLoadEvent[] OnAssetBundleLoadEventArray { get; set; } = new OnAssetBundleLoadEvent[0];


		public OnPlayerLeaveEvent[] OnPlayerLeaveEventArray { get; set; } = new OnPlayerLeaveEvent[0];


		public OnUpdateEvent[] OnUpdateEventArray { get; set; } = new OnUpdateEvent[0];


		public OnUdonEvent[] OnUdonEventArray { get; set; } = new OnUdonEvent[0];


		public OnEventEvent[] OnEventEventArray { get; set; } = new OnEventEvent[0];


		public OnAvatarLoadedEvent[] OnAvatarLoadEventArray { get; set; } = new OnAvatarLoadedEvent[0];


		public OnRPCEvent[] OnRPCEventArray { get; set; } = new OnRPCEvent[0];


		public OnSendOPEvent[] OnSendOPEventArray { get; set; } = new OnSendOPEvent[0];


		public OnSceneLoadedEvent[] OnSceneLoadedEventArray { get; set; } = new OnSceneLoadedEvent[0];


		public OnWorldInitEvent[] OnWorldInitEventArray { get; set; } = new OnWorldInitEvent[0];


		public OnNetworkSanityEvent[] OnNetworkSanityArray { get; set; } = new OnNetworkSanityEvent[0];


		public OnObjectInstantiatedEvent[] OnObjectInstantiatedArray { get; set; } = new OnObjectInstantiatedEvent[0];


		public static void OnGUI()
		{
		}

		public static void OnApplicationStart()
		{
			if (kimiisgay)
			{
				kimiisgay = true;
			}
			Instance = new Main();
			ClassInjector.RegisterTypeInIl2Cpp<CustomNameplate>();
			LogHandler.DisplayLogo();
			Directory.CreateDirectory("Area51\\LoadingScreenMusic");
			MelonCoroutines.Start(AlienMisc.LoadingMusic());
			Task.Run(delegate
			{
				AlienPatch.InitPatches();
			});
		}

		public static void OnUpdate()
		{
			try
			{
				for (int i = 0; i < Instance.OnUpdateEventArray.Length; i++)
				{
					Instance.OnUpdateEventArray[i].OnUpdate();
				}
			}
			catch
			{
			}
		}

		public static void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			int num = 0;
			if (num < Instance.OnSceneLoadedEventArray.Length)
			{
				Instance.OnSceneLoadedEventArray[num].OnSceneWasLoadedEvent(buildIndex, sceneName);
			}
		}

		public static void Start()
		{
			try
			{
				if (!isGay)
				{
					MelonCoroutines.Start(MenuUI.StartUI());
					LogHandler.Log(LogHandler.Colors.Green, "Client UI Initialized.", timeStamp: true);
					Config.Configuration();
					isGay = true;
				}
			}
			catch
			{
			}
		}

		public static void OnApplicationQuit()
		{
			try
			{
				Config.WriteOnClose();
			
			}
			catch (Exception)
			{
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.IO;
using Il2CppSystem.Runtime.Serialization.Formatters.Binary;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRC;
using VRC.Animation;
using VRC.Core;
using VRC.DataModel;
using VRC.SDKBase;
using VRC.UI;
using VRC.UI.Elements.Menus;

namespace Area51.SDK
{
	internal static class PlayerWrapper
	{
		public delegate void ResetLastPositionAction(InputStateController @this);

		public delegate void ResetAction(VRCMotionState @this);

		private static GameObject avatarPreviewBase;

		private static GameObject playernode;

		private static int noUpdateCount = 0;

		public static string backupID = "";

		public static bool isRestored = false;

		public static System.Collections.Generic.Dictionary<int, Player> PlayersActorID = new System.Collections.Generic.Dictionary<int, Player>();

		private static ResetLastPositionAction ourResetLastPositionAction;

		private static ResetAction ourResetAction;

		public static System.Collections.Generic.List<string> Oldlist = new System.Collections.Generic.List<string>
		{
			"cloth", "shirt", "pant", "under", "undi", "jacket", "top", "bra", "skirt", "jean",
			"trouser", "boxers", "hoodi", "bottom", "dress", "bandage", "bondage", "sweat", "cardig", "corset",
			"tiddy", "pastie", "suit", "stocking", "jewel", "frill", "gauze", "cover", "pubic", "sfw",
			"harn", "biki", "outfit", "panties", "short", "clothing", "shirt top", "pasties", "inv_swimsuit", "pants",
			"shoes", "underclothes", "shorts", "Hoodie", "plaster", "pussy cover", "radialswitch", "ribbon", "bottom1", "shorts nsfw",
			"top nsfw", "pastie+harness", "bralette harness", "bottom2", "robe", "rope", "ropes", "ropes", "lingerie toggle", "sandals",
			"shirt.001", "skrt", "sleeve", "sleeves", "snapdress", "socks", "tank", "stickers", "denimtop_b", "fish nets",
			"chest harness", "stockings", "straps", "strapsbottom", "body suit", "sweater", "swimsuit", "tank top", "tape", "shirt dress",
			"tearsweater", "thong", "toob", "toppants", "rf mask top", "longshirt", "asphalttop", "hood", "sweatshirt", "uppertop",
			"toggle top.001", "jacket.002", "underwear", "undies", "tokyohoodie", "wraps", "wrap", "outerwear", "wraps-top", "Одежка",
			"sticker", "dressy", "capeyyy", "bodysuity", "bodysuit", "верх", "низ", "パンティー", "ビキニ", "ブラジャー",
			"下着", "무녀복", "브라", "비키니", "속옷", "젖소", "gasmask", "팬티", "skirt.001", "huku_top",
			"other_glasses", "other_mask", "huku_pants", "huku_skirt", "huku_jacket", "clothes", "top_mesh", "kemono", "garterbelt", "langerie",
			"tap", "calça", "camisa", "beziercircle.001", "dress.001", "floof corset", "paisties", "string and gatter", "crop top", "panty",
			"sleeveless", "harness", "pantie", "bandaid", "mask", "chainsleeve", "hat", "hoodoff", "hoodon", "metal muzzle",
			"top2", "rush", "huku_bra", "huku_lace shirt", "huku_panties", "huku_shoes", "huku_shorts", "o_harness", "o_mask", "bottoms",
			"daddys slut", "bra.strapless", "butterfly dress", "chainnecklace", "denim shorts", "panties_berryvee", "tanktop", "waist jacket", "chocker_jhp", "brazbikini_bottoms",
			"brazbikini_top", "full harness", "glasses", "panty_misepan", "top1", "top3", "top4", "top5_bottom", "top5_top", "top6",
			"eraser", "bikini", "headset", "screen", "就是一个胡萝卜", "chain", "hesopi", "merino_scarf", "merino_bag", "bikini bottoms",
			"merino_panties", "tsg_buruma", "merino_cap", "kyoueimizugi", "kyoueimizugi_oppaiooki", "leotard", "hotpants", "hotpants_side_open", "merino_culottes", "merino_leggins",
			"merino_socks", "bikini", "merino_bra", "merino_jacket", "merino_inner", "tsg_shirt", "beer hat", "cuffs", "lace", "panties",
			"pasties", "shorts and shoes", "undergarments", "irukanicar", "ベルト", "wear", "tshirt", "waistbag", "nekomimicasquette", "dango",
			"penetrator", "comfy bottom", "comfy top", "hoodie", "strawberry panty", "strawberry top", "vest", "sleevedtop", "baggy top by cupkake", "harness by heyblake",
			"heart pasties by cupkake", "straps!", "crop strap hoodie flat", "harness & panties", "bunnycostume", "handwarmers", "belt", "cardigan", "turtle neck", "bandages",
			"holysuit", "nipplecovers"
		};

		public static string GetDisplayName => LocalPlayer.field_Private_APIUser_0._displayName_k__BackingField;

		public static Player LocalPlayer => Player.prop_Player_0;

		public static string GetUserID => LocalPlayer.GetAPIUser().id;

		public static string GetWorldID => LocalPlayer.GetAPIUser().location;

		public static string GetinstanceID => LocalPlayer.GetAPIUser().instanceId;

		public static VRCPlayer LocalVRCPlayer => VRCPlayer.field_Internal_Static_VRCPlayer_0;

		public static string worldLocation => LocalPlayer.prop_APIUser_0.location;

		public static System.Collections.Generic.List<Player> AllPlayers => PlayerManager.prop_PlayerManager_0.prop_PooledArray_1_Player_0.Array.ToList();

		public static GameObject UserInterface => GameObject.Find("UserInterface");

		public static VRCUiPopupInput keyboardPopup => VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.field_Public_VRCUiPopupInput_0;

		public static Il2CppSystem.Action CloseVRCUIAction => DelegateSupport.ConvertDelegate<Il2CppSystem.Action>((System.Action)delegate
		{
			CloseVRCUI();
		});

		public static ResetLastPositionAction ResetLastPositionAct
		{
			get
			{
				if (ourResetLastPositionAction != null)
				{
					return ourResetLastPositionAction;
				}
				MethodInfo method = typeof(InputStateController).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Single((MethodInfo it) => XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Method && jt.TryResolve() != null && jt.TryResolve().Name == "get_transform"));
				ourResetLastPositionAction = (ResetLastPositionAction)System.Delegate.CreateDelegate(typeof(ResetLastPositionAction), method);
				return ourResetLastPositionAction;
			}
		}

		public static Player GetPlayer()
		{
			return Player.prop_Player_0;
		}

		public static string SpoofDisplayname(string name)
		{
			return LocalPlayer.field_Private_APIUser_0._displayName_k__BackingField = name;
		}

		public static void SetLocalBitrate(this Player player, BitRate rate)
		{
			player.GetUspeaker().field_Public_BitRate_0 = rate;
		}

		public static bool GetIsMaster(this Player Instance)
		{
			return Instance.GetVRCPlayerApi().isMaster;
		}

		public static USpeaker GetUspeaker(this Player player)
		{
			return player.prop_USpeaker_0;
		}

		public static int GetActorNumber2(this Player player)
		{
			return player.GetVRCPlayerApi().playerId;
		}

		public static string GetName(this Player player)
		{
			return player.GetAPIUser().displayName;
		}

		public static Player GetByUsrID(string usrID)
		{
			return GetAllPlayers().First((Player x) => x.prop_APIUser_0.id == usrID);
		}

		public static Player[] GetAllPlayers()
		{
			return PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
		}

		public static void Teleport(this Player player)
		{
			LocalVRCPlayer.transform.position = player.prop_VRCPlayer_0.transform.position;
		}

		public static APIUser GetAPIUser(this Player player)
		{
			return player.prop_APIUser_0;
		}

		public static short GetPing(this Player player)
		{
			return player._playerNet.field_Private_Int16_0;
		}

		public static bool ZeroPingFPS(this Player player)
		{
			if (player.GetPing() <= 0 && player.GetFrames() <= 0f)
			{
				return player.GetFrames() <= -1f;
			}
			return false;
		}

		public static bool VectorZero(this Player player)
		{
			if (player.GetPing() > 0 || !(player.GetFrames() <= 0f))
			{
				return player.transform.position == Vector3.zero;
			}
			return true;
		}

		public static IUser GetSelectedUser(this SelectedUserMenuQM selectMenu)
		{
			return selectMenu.field_Private_IUser_0;
		}

		public static Player GetPlayer(this VRCPlayer player)
		{
			return player.prop_Player_0;
		}

		public static T DecryptData<T>(Il2CppSystem.Object customdata)
		{
			return FormatArray<T>(SerializeArray(customdata));
		}

		public static int GetPhotonID(this Player player)
		{
			return player.prop_Int32_0;
		}

		public static Color GetTrustColor(this Player player)
		{
			return VRCPlayer.Method_Public_Static_Color_APIUser_0(player.GetAPIUser());
		}

		public static APIUser GetAPIUser(this VRCPlayer Instance)
		{
			return Instance.GetPlayer().GetAPIUser();
		}

		public static VRCPlayerApi GetVRCPlayerApi(this Player Instance)
		{
			return Instance?.prop_VRCPlayerApi_0;
		}

		public static Player GetPlayer(int ActorNumber)
		{
			return AllPlayers.Where((Player p) => p.GetActorNumber2() == ActorNumber).FirstOrDefault();
		}

		public static GameObject[] GetAllGameObjects()
		{
			return SceneManager.GetActiveScene().GetRootGameObjects();
		}

		public static int GetActorNumber(this Player player)
		{
			if (player.GetVRCPlayerApi() == null)
			{
				return -1;
			}
			return player.GetVRCPlayerApi().playerId;
		}

		public static void SetHide(this Player Instance, bool State)
		{
			Instance.transform.Find("ForwardDirection").gameObject.active = !State;
		}

		public static GameObject GetAvatarPreviewBase()
		{
			return avatarPreviewBase = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase");
		}

		public static void TeleportLocation(float x, float y, float z)
		{
			LocalVRCPlayer.transform.position = new Vector3(x, y, z);
		}

		public static float GetFrames(this Player player)
		{
			if (player._playerNet.prop_Byte_0 == 0)
			{
				return -1f;
			}
			return Mathf.Floor(1000f / (float)(int)player._playerNet.prop_Byte_0);
		}

		public static bool IsBot(this Player player)
		{
			if ((player.GetPing() > 0 || !(player.GetFrames() <= 0f)) && !(player.GetFrames() <= -1f))
			{
				return player.transform.position == Vector3.zero;
			}
			return true;
		}

		public static Player SelectedVRCPlayer()
		{
			return GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>().field_Private_IUser_0.prop_String_0.ReturnUserID();
		}

		public static bool DestoryThatCoonKiller(bool state)
		{
			return GameObject.Find("UserInterface/PlayerDisplay/BlackFade").gameObject.active = state;
		}

		public static void OpenKeyboardPopup(string title, string placeholderText, System.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> action)
		{
			Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> param_ = DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>(action);
			VRCUiPopupManager.prop_VRCUiPopupManager_0.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0(title, null, InputField.InputType.Standard, param_4: false, "Okay", param_, CloseVRCUIAction, placeholderText, param_9: true, null, param_11: false, 0);
		}

		public static void ShowSelf(bool state)
		{
			backupID = APIUser.CurrentUser.avatarId;
			GetAvatarPreviewBase().SetActive(state);
			LocalVRCPlayer.prop_VRCAvatarManager_0.gameObject.SetActive(state);
			AssetBundleDownloadManager.prop_AssetBundleDownloadManager_0.gameObject.SetActive(state);
		}

		public static GameObject GetPlayerMirrFix()
		{
			GameObject[] allGameObjects = GetAllGameObjects();
			foreach (GameObject gameObject in allGameObjects)
			{
				if (gameObject.name.StartsWith("_AvatarMirrorClone"))
				{
					return gameObject;
				}
			}
			return new GameObject();
		}

		public static GameObject GetPlayerMirrFix2()
		{
			GameObject[] allGameObjects = GetAllGameObjects();
			foreach (GameObject gameObject in allGameObjects)
			{
				if (gameObject.name.StartsWith("_AvatarShadowClone"))
				{
					return gameObject;
				}
			}
			return new GameObject();
		}

		public static void ClearAssets()
		{
			AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Cache_0.ClearCache();
			AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Queue_1_AssetBundleDownload_0.Clear();
			AssetBundleDownloadManager.field_Private_Static_AssetBundleDownloadManager_0.field_Private_Queue_1_AssetBundleDownload_1.Clear();
		}

		public static Player ReturnUserID(this string User)
		{
			Il2CppSystem.Collections.Generic.List<Player>.Enumerator enumerator = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Player current = enumerator.Current;
				if (current.field_Private_APIUser_0.id == User)
				{
					return current;
				}
			}
			return null;
		}

		public static IEnumerator SetCrasher(string crasherid)
		{
			backupID = APIUser.CurrentUser.avatarId;
			ShowSelf(state: false);
			yield return new WaitForSecondsRealtime(0.01f);
			ChangeAvatar(crasherid);
			LogHandler.Log(LogHandler.Colors.Green, "Crashing World...");
			yield return new WaitForSecondsRealtime(0.07f);
			isRestored = true;
		}

		public static byte[] SerializeArray(Il2CppSystem.Object customdata)
		{
			if (customdata != null)
			{
				Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				Il2CppSystem.IO.MemoryStream memoryStream = new Il2CppSystem.IO.MemoryStream();
				binaryFormatter.Serialize(memoryStream, customdata);
				return memoryStream.ToArray();
			}
			return null;
		}

		public static T FormatArray<T>(byte[] data)
		{
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			using System.IO.MemoryStream serializationStream = new System.IO.MemoryStream(data);
			return (T)binaryFormatter.Deserialize(serializationStream);
		}

		public static int CrashDetected(this Player player)
		{
			byte field_Private_Byte_ = player._playerNet.field_Private_Byte_0;
			byte field_Private_Byte_2 = player._playerNet.field_Private_Byte_1;
			if (field_Private_Byte_ == player._playerNet.field_Private_Byte_0 && field_Private_Byte_2 == player._playerNet.field_Private_Byte_1)
			{
				noUpdateCount++;
			}
			else
			{
				noUpdateCount = 0;
			}
			return noUpdateCount;
		}

		public static void Tele2MousePos()
		{
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit[] array = Physics.RaycastAll(ray);
			if (array.Length != 0)
			{
				RaycastHit raycastHit = array[0];
				VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position = raycastHit.point;
			}
		}

		public static string GetFramesColord(this Player player)
		{
			float frames = player.GetFrames();
			if (frames > 80f)
			{
				return "<color=green>" + frames + "</color>";
			}
			if (frames > 30f)
			{
				return "<color=yellow>" + frames + "</color>";
			}
			return "<color=red>" + frames + "</color>";
		}

		public static string ClientDetect(this Player player)
		{
			float frames = player.GetFrames();
			short ping = player.GetPing();
			if (ping > 665)
			{
				return " <color=red>ClientUser</color>";
			}
			if (ping < -2)
			{
				return " <color=red>ClientUser</color>";
			}
			if (frames > 140f)
			{
				return " <color=red>ClientUser</color>";
			}
			if (frames < -2f)
			{
				return " <color=red>ClientUser</color>";
			}
			return "";
		}

		public static string GetPingColord(this Player player)
		{
			short ping = player.GetPing();
			if (ping > 150)
			{
				return "<color=red>" + ping + "</color>";
			}
			if (ping > 75)
			{
				return "<color=yellow>" + ping + "</color>";
			}
			return "<color=green>" + ping + "</color>";
		}

		public static string GetPlatform(this Player player)
		{
			if (player.prop_APIUser_0.IsOnMobile)
			{
				return "<color=green>Q</color>";
			}
			if (player.prop_VRCPlayerApi_0.IsUserInVR())
			{
				return "<color=#CE00D5>VR</color>";
			}
			return "<color=grey>PC</color>";
		}

		public static Player GetPlayerWithPlayerID(int playerID)
		{
			for (int i = 0; i < GetAllPlayers().Length; i++)
			{
				if (GetAllPlayers()[i].prop_VRCPlayerApi_0.playerId == playerID)
				{
					return GetAllPlayers()[i];
				}
			}
			return null;
		}

		public static VRCUiPopupManager GetVRCUiPopupManager()
		{
			return VRCUiPopupManager.prop_VRCUiPopupManager_0;
		}

		public static void AlertPopup(this VRCUiPopupManager manager, string title, string text)
		{
			manager.Method_Public_Void_String_String_Single_0(title, text, 10f);
		}

		public static void ShowInputKeyBoard(Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> InputAction)
		{
			VRCUiPopupManager vRCUiPopupManager = GetVRCUiPopupManager();
			vRCUiPopupManager.field_Public_VRCUiPopupInput_1.gameObject.SetActive(value: true);
			vRCUiPopupManager.field_Public_VRCUiPopupInput_1.Method_Public_Void_String_InputType_String_Action_3_String_List_1_KeyCode_Text_Boolean_0("Enter Input", InputField.InputType.Standard, "Enter text", InputAction);
			GameObject.Find("UserInterface/MenuContent/Popups/InputKeypadPopup").SetActive(value: true);
		}

		public static void DelegateSafeInvoke(this System.Delegate @delegate, params object[] args)
		{
			System.Delegate[] invocationList = @delegate.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				try
				{
					invocationList[i].DynamicInvoke(args);
				}
				catch (System.Exception ex)
				{
					LogHandler.Log(LogHandler.Colors.Red, "Error while executing delegate:\n" + ex.ToString());
				}
			}
		}

		public static void CloseVRCUI()
		{
			VRCUiManager.prop_VRCUiManager_0.Method_Public_Void_Boolean_Boolean_1(param_1: true);
		}

		public static void OpenVRCUIPopup(string title, string body, string acceptText, System.Action acceptAction, string declineText, System.Action declineAction = null)
		{
			Il2CppSystem.Action param_ = DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(acceptAction);
			if (declineAction == null)
			{
				VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_1(title, body, acceptText, param_, declineText, CloseVRCUIAction);
				return;
			}
			Il2CppSystem.Action param_2 = DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(declineAction);
			VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_String_Action_Action_1_VRCUiPopup_1(title, body, acceptText, param_, declineText, param_2);
		}

		public static void OpenVRCUINotifPopup(string title, string body, string okayText, System.Action okayAction = null)
		{
			if (okayAction == null)
			{
				VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_1(title, body, okayText, CloseVRCUIAction);
				return;
			}
			Il2CppSystem.Action param_ = DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(okayAction);
			VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_String_Action_Action_1_VRCUiPopup_1(title, body, okayText, param_);
		}

		public static void ChangeAvatar(string AvatarID)
		{
			PageAvatar component = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();
			component.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
			{
				id = AvatarID
			};
			component.ChangeToSelectedAvatar();
		}

		public static Player GetPlayerByActorID(int actorId)
		{
			Player value = null;
			PlayersActorID.TryGetValue(actorId, out value);
			return value;
		}

		public static string LogRPC(Player sender, VRC_EventHandler.VrcEvent vrcEvent, VRC_EventHandler.VrcBroadcastType vrcBroadcastType)
		{
			string text = "[RPC] ";
			text = ((!(sender != null)) ? (text + " INVISABLE sended ") : (text + sender.prop_APIUser_0.displayName + " sended "));
			text = text + vrcBroadcastType.ToString() + " ";
			text = text + vrcEvent.Name + " ";
			text = text + vrcEvent.EventType.ToString() + " ";
			if (vrcEvent.ParameterObject != null)
			{
				text = text + vrcEvent.ParameterObject.name + " ";
				text = text + vrcEvent.ParameterBool + " ";
				text = text + vrcEvent.ParameterBoolOp.ToString() + " ";
				text = text + vrcEvent.ParameterFloat + " ";
				text = text + vrcEvent.ParameterInt + " ";
				text = text + vrcEvent.ParameterString + " ";
			}
			if (vrcEvent.ParameterObjects != null)
			{
				for (int i = 0; i < vrcEvent.ParameterObjects.Length; i++)
				{
					text = text + vrcEvent.ParameterObjects[i].name + " ";
				}
			}
			try
			{
				Il2CppReferenceArray<Il2CppSystem.Object> il2CppReferenceArray = Networking.DecodeParameters(vrcEvent.ParameterBytes);
				for (int j = 0; j < il2CppReferenceArray.Length; j++)
				{
					text = text + Il2CppSystem.Convert.ToString(il2CppReferenceArray[j]) + " ";
				}
				return text;
			}
			catch
			{
				for (int k = 0; k < vrcEvent.ParameterBytes.Length; k++)
				{
					text = text + vrcEvent.ParameterBytes[k] + " ";
				}
				return text;
			}
		}

		public static void ResetLastPosition(this InputStateController instance)
		{
			ResetLastPositionAct(instance);
		}

		public static System.Collections.Generic.List<Transform> GetAllTransforms(this GameObject g, bool getHidden = true)
		{
			System.Collections.Generic.List<Transform> list = new System.Collections.Generic.List<Transform>();
			Transform[] array = g.GetComponents<Transform>();
			Transform[] array2 = g.GetComponentsInChildren<Transform>(getHidden);
			int num = array.Length;
			int num2 = array2.Length;
			for (int i = 0; i < num2; i++)
			{
				if (!list.Contains(array[i]))
				{
					list.Add(array[i]);
				}
			}
			for (int j = 0; j < num2; j++)
			{
				if (!list.Contains(array2[j]))
				{
					list.Add(array2[j]);
				}
			}
			return list;
		}

		internal static void Lewdify(this GameObject avatar)
		{
			if (avatar == null)
			{
				return;
			}
			foreach (Transform allTransform in avatar.GetAllTransforms())
			{
				if (Oldlist.Contains(allTransform.gameObject.name.ToLower()) && ((bool)allTransform.GetComponent<MeshRenderer>() || (bool)allTransform.GetComponent<SkinnedMeshRenderer>()))
				{
					UnityEngine.Object.DestroyImmediate(allTransform.gameObject);
				}
			}
		}
	}
}

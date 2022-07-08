using System;
using System.IO;
using UnityEngine;

namespace Area51.SDK.ButtonAPI
{
	internal class QMButtonIcons
	{
		internal static Texture2D CreateTextureFromBase64(string data)
		{
			Texture2D texture2D = new Texture2D(2, 2);
			ImageConversion.LoadImage(texture2D, Convert.FromBase64String(data));
			texture2D.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			return texture2D;
		}

		private static string ImageToBase64(string imagePath)
		{
			byte[] inArray = File.ReadAllBytes(imagePath);
			return Convert.ToBase64String(inArray);
		}

		internal static Sprite ButtonIco(string url)
		{
			string data = ImageToBase64(url);
			Texture2D texture2D = CreateTextureFromBase64(data);
			Rect rect = new Rect(0f, 0f, texture2D.width, texture2D.height);
			Vector2 pivot = new Vector2(0.5f, 0.5f);
			Vector4 border = Vector4.zero;
			return Sprite.CreateSprite_Injected(texture2D, ref rect, ref pivot, 100f, 0u, SpriteMeshType.Tight, ref border, generateFallbackPhysicsShape: false);
		}

		internal static Sprite CreateSpriteFromBase64(string data)
		{
			Texture2D texture2D = CreateTextureFromBase64(data);
			Rect rect = new Rect(0f, 0f, texture2D.width, texture2D.height);
			Vector2 pivot = new Vector2(0.5f, 0.5f);
			Vector4 border = Vector4.zero;
			return Sprite.CreateSprite_Injected(texture2D, ref rect, ref pivot, 100f, 0u, SpriteMeshType.Tight, ref border, generateFallbackPhysicsShape: false);
		}
	}
}

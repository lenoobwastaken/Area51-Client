using System.IO;
using UnityEngine;

namespace Area51.SDK.ButtonAPI
{
	internal static class LoadSprite
	{
		internal static Sprite LoadSpriteFromDisk(this string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return null;
			}
			byte[] array = File.ReadAllBytes(path);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			Texture2D texture2D = new Texture2D(512, 512);
			if (!Il2CppImageConversionManager.LoadImage(texture2D, array))
			{
				return null;
			}
			Sprite sprite = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f, 0u, SpriteMeshType.FullRect, default(Vector4), generateFallbackPhysicsShape: false);
			sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			return sprite;
		}
	}
}

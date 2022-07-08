using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Il2CppSystem;
using Il2CppSystem.IO;
using Il2CppSystem.Runtime.Serialization.Formatters.Binary;

namespace Area51.SDK.Photon
{
	internal static class Serialization
	{
		public static byte[] ToByteArray(Object obj)
		{
			if (obj == null)
			{
				return null;
			}
			Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			Il2CppSystem.IO.MemoryStream memoryStream = new Il2CppSystem.IO.MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return memoryStream.ToArray();
		}

		public static byte[] ToByteArray(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			return memoryStream.ToArray();
		}

		public static T FromByteArray<T>(byte[] data)
		{
			if (data == null)
			{
				return default(T);
			}
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			using System.IO.MemoryStream serializationStream = new System.IO.MemoryStream(data);
			object obj = binaryFormatter.Deserialize(serializationStream);
			return (T)obj;
		}

		public static T IL2CPPFromByteArray<T>(byte[] data)
		{
			if (data == null)
			{
				return default(T);
			}
			Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			Il2CppSystem.IO.MemoryStream serializationStream = new Il2CppSystem.IO.MemoryStream(data);
			object obj = binaryFormatter.Deserialize(serializationStream);
			return (T)obj;
		}

		public static T FromIL2CPPToManaged<T>(Object obj)
		{
			return FromByteArray<T>(ToByteArray(obj));
		}

		public static T FromManagedToIL2CPP<T>(object obj)
		{
			return IL2CPPFromByteArray<T>(ToByteArray(obj));
		}
	}
}

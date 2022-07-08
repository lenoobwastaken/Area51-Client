using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Area51.SDK;

namespace Area51.Sockets.BotServer
{
	internal class BotServer
	{
		private static int botCount = 2;

		private static List<Socket> ServerHandlers = new List<Socket>();

		public static void SendCommandToClients(string Command)
		{
			LogHandler.Log(LogHandler.Colors.Yellow, "$[{DateTime.Now}] Phoning Home: {Command}");
			ServerHandlers.Where((Socket s) => s != null).ToList().ForEach(delegate(Socket s)
			{
				s.Send(Encoding.ASCII.GetBytes(Command));
			});
		}

		private static void OnClientReceiveCommand(string Command)
		{
			if (!(Command == "Play"))
			{
				_ = Command == "Test";
			}
		}

		public static void StartServer()
		{
			ServerHandlers.Clear();
			botCount = 0;
			Task.Run((Action)HandleServer);
		}

		private static void HandleServer()
		{
			IPHostEntry hostEntry = Dns.GetHostEntry("localhost");
			IPAddress iPAddress = hostEntry.AddressList[0];
			IPEndPoint localEP = new IPEndPoint(iPAddress, 1337);
			try
			{
				using Socket socket = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				socket.Bind(localEP);
				socket.Listen(10);
				for (int i = 0; i < botCount; i++)
				{
					LogHandler.Log(LogHandler.Colors.Yellow, $"Awaiting response from mothership -> Code {botCount}!");
					ServerHandlers.Add(socket.Accept());
				}
			}
			catch (Exception ex)
			{
				LogHandler.Log(LogHandler.Colors.Yellow, ex.ToString() ?? "");
			}
		}

		public static void Client()
		{
			Task.Run((Action)HandleClient);
		}

		private static void HandleClient()
		{
			byte[] array = new byte[1024];
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry("localhost");
				IPAddress iPAddress = hostEntry.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(iPAddress, 1337);
				using Socket socket = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				try
				{
					socket.Connect(remoteEP);
					LogHandler.Log(LogHandler.Colors.Yellow, "Socetet connected to " + socket.RemoteEndPoint.ToString());
					while (true)
					{
						int count = socket.Receive(array);
						OnClientReceiveCommand(Encoding.ASCII.GetString(array, 0, count));
					}
				}
				catch (ArgumentNullException ex)
				{
					LogHandler.Log(LogHandler.Colors.Yellow, "SocketException : " + ex.ToString());
				}
				catch (SocketException ex2)
				{
					LogHandler.Log(LogHandler.Colors.Yellow, "SocketException : " + ex2.ToString());
				}
				catch (Exception ex3)
				{
					LogHandler.Log(LogHandler.Colors.Yellow, "SocketException : " + ex3.ToString());
				}
			}
			catch (Exception ex4)
			{
				LogHandler.Log(LogHandler.Colors.Yellow, "SocketException : " + ex4.ToString());
			}
		}
	}
}

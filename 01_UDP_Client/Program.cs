using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_UDP_Client
{
	class Program
	{
		static string remoteAddress;
		static int remotePort;

		static string localAddress;
		static int localPort;
		static void Main(string[] args)
		{
			try
			{
				Console.Write("Remote address:");
				remoteAddress = Console.ReadLine();
				Console.Write("Remote port:");
				remotePort = Int32.Parse(Console.ReadLine());

				Console.Write("local address:");
				localAddress = Console.ReadLine();
				Console.Write("local port:");
				localPort = Int32.Parse(Console.ReadLine());

				//send message
				//get message

				Thread receiveThread = new Thread(new ThreadStart(GetMessage));
				receiveThread.Start();

				//Thread sendThread = new Thread(new ThreadStart(SendMessage));
				//sendThread.Start();

				SendMessage();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}


		private static void SendMessage ()
		{
			UdpClient sender = new UdpClient();
			try
			{
				while(true)
				{
					string message = Console.ReadLine();
					byte[]data = Encoding.Unicode.GetBytes(message);

					sender.Send(data, data.Length, remoteAddress, remotePort);
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				sender.Close();
			}
		}
		private static void GetMessage()
		{
			//UdpClient receiver = new UdpClient(localAddress, localPort); //перший варіант
			UdpClient receiver = new UdpClient(localPort); //другий варіант - автоматом підтягне локальну адресу
			IPEndPoint remoteIp = null;
			try
			{
				while(true)
				{
					byte[] data = receiver.Receive(ref remoteIp);
					//if(remoteIp.Address =="1.1.1.1")

					string message = Encoding.Unicode.GetString(data);
					Console.WriteLine($"Sender: {message}");
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				receiver.Close();
			}

		}
	}
}

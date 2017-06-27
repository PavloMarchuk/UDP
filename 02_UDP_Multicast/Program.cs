using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_UDP_Multicast
{
	class Program
	{
		//адреса одна для входу і виходу
		static IPAddress remoteAddress;
		static int remotePort;
		static int localPort;

		static string userName;
		static void Main(string[] args)
		{

			LocalIPAdders();
			try
			{
				Console.Write("Enter Name:");
				userName = Console.ReadLine();
				remotePort = 8001;
				localPort = 8001;

				remoteAddress = IPAddress.Parse("235.5.5.11");


				Thread receiveThread = new Thread(new ThreadStart(GetMessage));
				receiveThread.Start();			

				SendMessage();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				//sender.Close();
			}


		}



		private static void SendMessage()
		{
			UdpClient sender = new UdpClient();
			IPEndPoint endPoint = new IPEndPoint(remoteAddress, remotePort);
 			try
			{
				while(true)
				{
					string message = userName + ": " + Console.ReadLine();
					byte[]data = Encoding.Unicode.GetBytes(message);

					sender.Send(data, data.Length, endPoint);
					//sender.Send(data, data.Length, "235.5.5.11", remotePort); //другий варіант конструктора
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
			receiver.JoinMulticastGroup(remoteAddress, 20);


			IPEndPoint remoteIp = null;
			try
			{
				while(true)
				{
					byte[] data = receiver.Receive(ref remoteIp);
					//if(remoteIp.Address =="1.1.1.1")

					if(IsLocalIP(remoteIp.Address.ToString()))
						continue;
					
					string message = Encoding.Unicode.GetString(data);
					Console.WriteLine($"{message}");
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
		private static List<string>  LocalIPAdders()
		{			
			List<string> localIP = new List<string>();
			IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
			foreach(IPAddress ip in host.AddressList) //ip_v4
			{
				if(ip.AddressFamily== AddressFamily.InterNetwork)
				{
					localIP.Add(ip.ToString());					
					//wifi одфільтрувати можна
					//ethernet можна одфільтрувати
				}
			}
			return localIP;
		}

		private static bool IsLocalIP( string IP)
		{
			foreach(string item in LocalIPAdders())
			{
				if(item == IP)
					return true;
			}
			return false;
		}
	}
}

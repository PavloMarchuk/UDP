using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_WF_Chat
{
	public partial class Form1: Form
	{
		UdpClient client;
		const int localPort = 8001;
		const int remotePort = 8001;
		const int TTL = 20;
		const string HOST = "235.5.5.1";
		IPAddress groundAddres;
		string userName;
		bool alive = false;

		public Form1()
		{
			InitializeComponent();

			btnDisconnect.Enabled = false;
			btnSend.Enabled = false;
			txtChat.ReadOnly = true;

			groundAddres = IPAddress.Parse(HOST);
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			userName = txtName.Text;
			txtName.ReadOnly = true;

			client = new UdpClient(localPort);
			client.JoinMulticastGroup(groundAddres, TTL);
			//getMessage
			string message = userName + " entered in chat";
			byte[] data =  Encoding.Unicode.GetBytes(message);

			client.Send(data, data.Length, HOST, remotePort);

			btnConnect.Enabled = false;
			btnDisconnect.Enabled = true;
			btnSend.Enabled = true;

			Task receiveTask = new Task(RecievMessage);
			receiveTask.Start();
		}
		private void RecievMessage()
		{
			alive = true;
			try
			{
				while(alive)
				{
					IPEndPoint remoteIP = null;
					byte[] data = client.Receive(ref remoteIP);
					string message = Encoding.Unicode.GetString(data);
					this.Invoke(new MethodInvoker
						(() =>
						{
							string time = DateTime.Now.ToShortTimeString();
							txtChat.Text += time + " " + message + "\r\n";
						}
					));
				}
			}
			catch(ObjectDisposedException)
			{
				if(!alive)				
					return;
				throw;				
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if(txtMessage.Text == "") return;

			string message =userName + ": " + txtMessage.Text;
			byte[] data = Encoding.Unicode.GetBytes(message);
			client.Send(data, data.Length, HOST, remotePort);

			txtMessage.Text = "";
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{			
			Exit();
		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Exit();
		}
		private void Exit()
		{
			if(!alive) return;


			string message = userName + " go OUT";
			byte[] data =  Encoding.Unicode.GetBytes(message);

			client.Send(data, data.Length, HOST, remotePort);

			client.DropMulticastGroup(groundAddres);
			alive = false;
			client.Close();


			btnConnect.Enabled = true;
			btnDisconnect.Enabled = false;
			btnSend.Enabled = false;
		}

		
	}
}

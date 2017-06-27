namespace _03_WF_Chat
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtChat = new System.Windows.Forms.TextBox();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(401, 12);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 23);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Location = new System.Drawing.Point(401, 41);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
			this.btnDisconnect.TabIndex = 1;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(401, 228);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(53, 28);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(342, 20);
			this.txtName.TabIndex = 3;
			// 
			// txtChat
			// 
			this.txtChat.Location = new System.Drawing.Point(15, 79);
			this.txtChat.Multiline = true;
			this.txtChat.Name = "txtChat";
			this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChat.Size = new System.Drawing.Size(461, 141);
			this.txtChat.TabIndex = 4;
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(15, 231);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(380, 20);
			this.txtMessage.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Name";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 261);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.txtChat);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.btnConnect);
			this.Name = "Form1";
			this.Text = "Chat";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtChat;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Label label1;
	}
}


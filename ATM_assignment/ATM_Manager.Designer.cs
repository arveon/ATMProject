using System.Windows.Forms;

namespace ATM_assignment
{
	partial class ATM_Manager
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
			if (disposing && (components != null))
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
			this.AvailableATMText = new System.Windows.Forms.Label();
			this.AvailableATMNumber = new System.Windows.Forms.Label();
			this.CreateATM = new System.Windows.Forms.Button();
			this.BankAccounts = new System.Windows.Forms.ListBox();
			this.Exit = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// AvailableATMText
			// 
			this.AvailableATMText.AutoSize = true;
			this.AvailableATMText.Location = new System.Drawing.Point(461, 19);
			this.AvailableATMText.Name = "AvailableATMText";
			this.AvailableATMText.Size = new System.Drawing.Size(84, 13);
			this.AvailableATMText.TabIndex = 0;
			this.AvailableATMText.Text = "Available ATMs:";
			// 
			// AvailableATMNumber
			// 
			this.AvailableATMNumber.AutoSize = true;
			this.AvailableATMNumber.Location = new System.Drawing.Point(551, 19);
			this.AvailableATMNumber.Name = "AvailableATMNumber";
			this.AvailableATMNumber.Size = new System.Drawing.Size(13, 13);
			this.AvailableATMNumber.TabIndex = 1;
			this.AvailableATMNumber.Text = "3";
			// 
			// CreateATM
			// 
			this.CreateATM.Location = new System.Drawing.Point(464, 384);
			this.CreateATM.Name = "CreateATM";
			this.CreateATM.Size = new System.Drawing.Size(100, 52);
			this.CreateATM.TabIndex = 2;
			this.CreateATM.Text = "Access broken ATM instance";
			this.CreateATM.UseVisualStyleBackColor = true;
			this.CreateATM.Click += new System.EventHandler(this.createBrokenATM);
			// 
			// BankAccounts
			// 
			this.BankAccounts.FormattingEnabled = true;
			this.BankAccounts.Location = new System.Drawing.Point(12, 19);
			this.BankAccounts.Name = "BankAccounts";
			this.BankAccounts.Size = new System.Drawing.Size(446, 472);
			this.BankAccounts.TabIndex = 3;
			// 
			// Exit
			// 
			this.Exit.Location = new System.Drawing.Point(464, 442);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(100, 49);
			this.Exit.TabIndex = 4;
			this.Exit.Text = "Exit";
			this.Exit.UseVisualStyleBackColor = true;
			this.Exit.Click += new System.EventHandler(this.exit);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(465, 330);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(99, 48);
			this.button1.TabIndex = 5;
			this.button1.Text = "Access fixed ATM instance";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ATM_Manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(576, 502);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Exit);
			this.Controls.Add(this.BankAccounts);
			this.Controls.Add(this.CreateATM);
			this.Controls.Add(this.AvailableATMNumber);
			this.Controls.Add(this.AvailableATMText);
			this.Name = "ATM_Manager";
			this.Text = "ATM manager";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label AvailableATMText;
		private System.Windows.Forms.Label AvailableATMNumber;
		private System.Windows.Forms.Button CreateATM;
		private System.Windows.Forms.ListBox BankAccounts;
		private System.Windows.Forms.Button Exit;
		private Button button1;
	}
}


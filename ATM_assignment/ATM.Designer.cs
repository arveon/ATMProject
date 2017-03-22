namespace ATM_assignment
{
	partial class ATM
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATM));
			this.Cancel_btn = new System.Windows.Forms.Button();
			this.Clear_btn = new System.Windows.Forms.Button();
			this.Enter_btn = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.main_display = new System.Windows.Forms.Label();
			this.b4_label = new System.Windows.Forms.Label();
			this.b3_label = new System.Windows.Forms.Label();
			this.b2_label = new System.Windows.Forms.Label();
			this.b1_label = new System.Windows.Forms.Label();
			this.a4_label = new System.Windows.Forms.Label();
			this.a3_label = new System.Windows.Forms.Label();
			this.a2_label = new System.Windows.Forms.Label();
			this.a1_label = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.SideB4_btn = new System.Windows.Forms.Button();
			this.SideB1_btn = new System.Windows.Forms.Button();
			this.SideB3_btn = new System.Windows.Forms.Button();
			this.SideB2_btn = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.SideA4_btn = new System.Windows.Forms.Button();
			this.SideA3_btn = new System.Windows.Forms.Button();
			this.SideA2_btn = new System.Windows.Forms.Button();
			this.SideA1_btn = new System.Windows.Forms.Button();
			this.BankAccounts = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Cancel_btn
			// 
			this.Cancel_btn.BackColor = System.Drawing.Color.Firebrick;
			this.Cancel_btn.Location = new System.Drawing.Point(204, 295);
			this.Cancel_btn.Name = "Cancel_btn";
			this.Cancel_btn.Size = new System.Drawing.Size(84, 41);
			this.Cancel_btn.TabIndex = 0;
			this.Cancel_btn.Text = "CANCEL";
			this.Cancel_btn.UseVisualStyleBackColor = false;
			this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
			// 
			// Clear_btn
			// 
			this.Clear_btn.BackColor = System.Drawing.Color.Orange;
			this.Clear_btn.Location = new System.Drawing.Point(204, 342);
			this.Clear_btn.Name = "Clear_btn";
			this.Clear_btn.Size = new System.Drawing.Size(84, 41);
			this.Clear_btn.TabIndex = 1;
			this.Clear_btn.Text = "CLEAR";
			this.Clear_btn.UseVisualStyleBackColor = false;
			this.Clear_btn.Click += new System.EventHandler(this.button1_Click);
			// 
			// Enter_btn
			// 
			this.Enter_btn.BackColor = System.Drawing.Color.OliveDrab;
			this.Enter_btn.Location = new System.Drawing.Point(204, 389);
			this.Enter_btn.Name = "Enter_btn";
			this.Enter_btn.Size = new System.Drawing.Size(84, 41);
			this.Enter_btn.TabIndex = 2;
			this.Enter_btn.Text = "ENTER";
			this.Enter_btn.UseVisualStyleBackColor = false;
			this.Enter_btn.Click += new System.EventHandler(this.button2_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.main_display);
			this.panel1.Controls.Add(this.b4_label);
			this.panel1.Controls.Add(this.b3_label);
			this.panel1.Controls.Add(this.b2_label);
			this.panel1.Controls.Add(this.b1_label);
			this.panel1.Controls.Add(this.a4_label);
			this.panel1.Controls.Add(this.a3_label);
			this.panel1.Controls.Add(this.a2_label);
			this.panel1.Controls.Add(this.a1_label);
			this.panel1.Location = new System.Drawing.Point(70, 34);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(245, 214);
			this.panel1.TabIndex = 4;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// main_display
			// 
			this.main_display.AutoSize = true;
			this.main_display.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.main_display.Location = new System.Drawing.Point(5, 0);
			this.main_display.Name = "main_display";
			this.main_display.Size = new System.Drawing.Size(233, 25);
			this.main_display.TabIndex = 8;
			this.main_display.Text = "Please insert your card";
			// 
			// b4_label
			// 
			this.b4_label.AutoSize = true;
			this.b4_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b4_label.Location = new System.Drawing.Point(187, 174);
			this.b4_label.Name = "b4_label";
			this.b4_label.Size = new System.Drawing.Size(0, 20);
			this.b4_label.TabIndex = 7;
			// 
			// b3_label
			// 
			this.b3_label.AutoSize = true;
			this.b3_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b3_label.Location = new System.Drawing.Point(187, 133);
			this.b3_label.Name = "b3_label";
			this.b3_label.Size = new System.Drawing.Size(0, 20);
			this.b3_label.TabIndex = 6;
			// 
			// b2_label
			// 
			this.b2_label.AutoSize = true;
			this.b2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b2_label.Location = new System.Drawing.Point(187, 92);
			this.b2_label.Name = "b2_label";
			this.b2_label.Size = new System.Drawing.Size(0, 20);
			this.b2_label.TabIndex = 5;
			// 
			// b1_label
			// 
			this.b1_label.AutoSize = true;
			this.b1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.b1_label.Location = new System.Drawing.Point(187, 48);
			this.b1_label.Name = "b1_label";
			this.b1_label.Size = new System.Drawing.Size(0, 20);
			this.b1_label.TabIndex = 4;
			// 
			// a4_label
			// 
			this.a4_label.AutoSize = true;
			this.a4_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.a4_label.Location = new System.Drawing.Point(3, 174);
			this.a4_label.Name = "a4_label";
			this.a4_label.Size = new System.Drawing.Size(0, 20);
			this.a4_label.TabIndex = 3;
			// 
			// a3_label
			// 
			this.a3_label.AutoSize = true;
			this.a3_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.a3_label.Location = new System.Drawing.Point(3, 133);
			this.a3_label.Name = "a3_label";
			this.a3_label.Size = new System.Drawing.Size(0, 20);
			this.a3_label.TabIndex = 2;
			// 
			// a2_label
			// 
			this.a2_label.AutoSize = true;
			this.a2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.a2_label.Location = new System.Drawing.Point(3, 92);
			this.a2_label.Name = "a2_label";
			this.a2_label.Size = new System.Drawing.Size(0, 20);
			this.a2_label.TabIndex = 1;
			this.a2_label.Click += new System.EventHandler(this.label2_Click);
			// 
			// a1_label
			// 
			this.a1_label.AutoSize = true;
			this.a1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.a1_label.Location = new System.Drawing.Point(3, 50);
			this.a1_label.Name = "a1_label";
			this.a1_label.Size = new System.Drawing.Size(0, 20);
			this.a1_label.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.SideB4_btn);
			this.panel2.Controls.Add(this.SideB1_btn);
			this.panel2.Controls.Add(this.SideB3_btn);
			this.panel2.Controls.Add(this.SideB2_btn);
			this.panel2.Location = new System.Drawing.Point(321, 34);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(33, 214);
			this.panel2.TabIndex = 5;
			// 
			// SideB4_btn
			// 
			this.SideB4_btn.BackColor = System.Drawing.Color.Transparent;
			this.SideB4_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SideB4_btn.BackgroundImage")));
			this.SideB4_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.SideB4_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SideB4_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.SideB4_btn.Location = new System.Drawing.Point(-1, 173);
			this.SideB4_btn.Name = "SideB4_btn";
			this.SideB4_btn.Size = new System.Drawing.Size(33, 26);
			this.SideB4_btn.TabIndex = 11;
			this.SideB4_btn.UseVisualStyleBackColor = false;
			// 
			// SideB1_btn
			// 
			this.SideB1_btn.BackColor = System.Drawing.Color.Transparent;
			this.SideB1_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SideB1_btn.BackgroundImage")));
			this.SideB1_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.SideB1_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SideB1_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.SideB1_btn.Location = new System.Drawing.Point(-1, 49);
			this.SideB1_btn.Name = "SideB1_btn";
			this.SideB1_btn.Size = new System.Drawing.Size(33, 26);
			this.SideB1_btn.TabIndex = 8;
			this.SideB1_btn.UseVisualStyleBackColor = false;
			// 
			// SideB3_btn
			// 
			this.SideB3_btn.BackColor = System.Drawing.Color.Transparent;
			this.SideB3_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SideB3_btn.BackgroundImage")));
			this.SideB3_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.SideB3_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SideB3_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.SideB3_btn.Location = new System.Drawing.Point(-1, 132);
			this.SideB3_btn.Name = "SideB3_btn";
			this.SideB3_btn.Size = new System.Drawing.Size(33, 26);
			this.SideB3_btn.TabIndex = 10;
			this.SideB3_btn.UseVisualStyleBackColor = false;
			// 
			// SideB2_btn
			// 
			this.SideB2_btn.BackColor = System.Drawing.Color.Transparent;
			this.SideB2_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SideB2_btn.BackgroundImage")));
			this.SideB2_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.SideB2_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SideB2_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.SideB2_btn.Location = new System.Drawing.Point(-1, 91);
			this.SideB2_btn.Name = "SideB2_btn";
			this.SideB2_btn.Size = new System.Drawing.Size(33, 26);
			this.SideB2_btn.TabIndex = 9;
			this.SideB2_btn.UseVisualStyleBackColor = false;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.SideA4_btn);
			this.panel3.Controls.Add(this.SideA3_btn);
			this.panel3.Controls.Add(this.SideA2_btn);
			this.panel3.Controls.Add(this.SideA1_btn);
			this.panel3.Location = new System.Drawing.Point(31, 34);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(33, 214);
			this.panel3.TabIndex = 6;
			// 
			// SideA4_btn
			// 
			this.SideA4_btn.BackColor = System.Drawing.Color.Transparent;
			this.SideA4_btn.BackgroundImage = global::ATM_assignment.Properties.Resources.button;
			this.SideA4_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.SideA4_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SideA4_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.SideA4_btn.Location = new System.Drawing.Point(-1, 173);
			this.SideA4_btn.Name = "SideA4_btn";
			this.SideA4_btn.Size = new System.Drawing.Size(33, 26);
			this.SideA4_btn.TabIndex = 7;
			this.SideA4_btn.UseVisualStyleBackColor = false;
			// 
			// SideA3_btn
			// 
			this.SideA3_btn.BackColor = System.Drawing.Color.Transparent;
			this.SideA3_btn.BackgroundImage = global::ATM_assignment.Properties.Resources.button;
			this.SideA3_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.SideA3_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SideA3_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.SideA3_btn.Location = new System.Drawing.Point(-1, 132);
			this.SideA3_btn.Name = "SideA3_btn";
			this.SideA3_btn.Size = new System.Drawing.Size(33, 26);
			this.SideA3_btn.TabIndex = 2;
			this.SideA3_btn.UseVisualStyleBackColor = false;
			// 
			// SideA2_btn
			// 
			this.SideA2_btn.BackColor = System.Drawing.Color.Transparent;
			this.SideA2_btn.BackgroundImage = global::ATM_assignment.Properties.Resources.button;
			this.SideA2_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.SideA2_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SideA2_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.SideA2_btn.Location = new System.Drawing.Point(-1, 91);
			this.SideA2_btn.Name = "SideA2_btn";
			this.SideA2_btn.Size = new System.Drawing.Size(33, 26);
			this.SideA2_btn.TabIndex = 1;
			this.SideA2_btn.UseVisualStyleBackColor = false;
			// 
			// SideA1_btn
			// 
			this.SideA1_btn.BackColor = System.Drawing.Color.Transparent;
			this.SideA1_btn.BackgroundImage = global::ATM_assignment.Properties.Resources.button;
			this.SideA1_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.SideA1_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SideA1_btn.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.SideA1_btn.Location = new System.Drawing.Point(-1, 49);
			this.SideA1_btn.Name = "SideA1_btn";
			this.SideA1_btn.Size = new System.Drawing.Size(33, 26);
			this.SideA1_btn.TabIndex = 0;
			this.SideA1_btn.UseVisualStyleBackColor = false;
			// 
			// BankAccounts
			// 
			this.BankAccounts.FormattingEnabled = true;
			this.BankAccounts.Location = new System.Drawing.Point(321, 295);
			this.BankAccounts.Name = "BankAccounts";
			this.BankAccounts.Size = new System.Drawing.Size(123, 147);
			this.BankAccounts.TabIndex = 7;
			// 
			// ATM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(480, 496);
			this.Controls.Add(this.BankAccounts);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Enter_btn);
			this.Controls.Add(this.Clear_btn);
			this.Controls.Add(this.Cancel_btn);
			this.Name = "ATM";
			this.Text = "ATM";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button Clear_btn;
        private System.Windows.Forms.Button Enter_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button SideA1_btn;
        private System.Windows.Forms.Button SideB4_btn;
        private System.Windows.Forms.Button SideB1_btn;
        private System.Windows.Forms.Button SideB3_btn;
        private System.Windows.Forms.Button SideB2_btn;
        private System.Windows.Forms.Button SideA4_btn;
        private System.Windows.Forms.Button SideA3_btn;
        private System.Windows.Forms.Button SideA2_btn;
        private System.Windows.Forms.Label main_display;
        private System.Windows.Forms.Label b4_label;
        private System.Windows.Forms.Label b3_label;
        private System.Windows.Forms.Label b2_label;
        private System.Windows.Forms.Label b1_label;
        private System.Windows.Forms.Label a4_label;
        private System.Windows.Forms.Label a3_label;
        private System.Windows.Forms.Label a2_label;
        private System.Windows.Forms.Label a1_label;
        private System.Windows.Forms.ListBox BankAccounts;
	}
}
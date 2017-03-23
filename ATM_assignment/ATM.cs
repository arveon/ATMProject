using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_assignment
{
	public delegate void updateAccountDisplay(int asd);
	public partial class ATM : Form
	{
		System.Timers.Timer temp_message_timer = new System.Timers.Timer(1000);
		enum MachineState
		{
			WaitingForCard,
			WaitingForPin,
			MainMenu,
			ShowingBalance,
			WithdrawingMoney,
			WithdrawingCustomAmount,
			ChangingPinOldPin,
			ChangingPinNewPin,
			ConfirmWantAnotherAction,
			InvalidPin,
			InvalidInput,
			EndMessage
		}
		private MachineState curState;

		string numberEntered;
		string curAccNum;

		updateAccountDisplay AccountUpdated;

		List<Button> numpad;

		Bank bank;

		private Point offsetPoint = new Point(20,270);
		private int numpadMargin = 5;
		private Size numpadButtonDimension = new Size(50,50);

		public ATM(Bank bank, updateAccountDisplay updater)
		{
			temp_message_timer.Elapsed += new System.Timers.ElapsedEventHandler(InvalidInputTimer);
			curAccNum = "";
			curState = MachineState.WaitingForCard;

			AccountUpdated = updater;
			this.bank = bank;

			numberEntered = "";

			CreateKeypadButtons();
			InitializeComponent();
			BankAccounts.DataSource = bank.getAccounts();

			Enter_btn.Click += new EventHandler(EnterClicked);
			Clear_btn.Click += (sender, eventArguments) =>
				{
					if(numberEntered.Length > 0)
						numberEntered = numberEntered.Substring(0, numberEntered.Length -1);
					UpdateMachine();
				};

			main_display.TextAlign = ContentAlignment.MiddleLeft;
			a1_label.TextAlign = ContentAlignment.MiddleLeft;
			a2_label.TextAlign = ContentAlignment.MiddleLeft;
			a3_label.TextAlign = ContentAlignment.MiddleLeft;
			a4_label.TextAlign = ContentAlignment.MiddleLeft;
			b1_label.TextAlign = ContentAlignment.MiddleRight;
			b2_label.TextAlign = ContentAlignment.MiddleRight;
			b3_label.TextAlign = ContentAlignment.MiddleRight;
			b4_label.TextAlign = ContentAlignment.MiddleRight;


			UpdateMachine();
			
		}

		private void KeypadButtonClicked(object sender, EventArgs args)
		{
			if(curState == MachineState.ChangingPinOldPin || curState == MachineState.ChangingPinNewPin 
				|| curState == MachineState.WaitingForPin || curState == MachineState.WithdrawingCustomAmount)
			{
				if ((numberEntered.Length < 4 && curState != MachineState.WithdrawingCustomAmount) || (curState == MachineState.WithdrawingCustomAmount && numberEntered.Length < 10))
				{
					numberEntered += ((Button)sender).Text;
				}
				
			}

			UpdateMachine();
		}

		private void EnterClicked(object sender, EventArgs e)
		{
			switch(curState)
			{
				case MachineState.WaitingForCard:
					curState = MachineState.WaitingForPin;
					curAccNum = ((string)BankAccounts.SelectedItem).Substring(0,6);
					Console.WriteLine(curAccNum);
					break;
				case MachineState.WaitingForPin:
					
					if (numberEntered.Length == 4 && bank.CheckPin(Convert.ToInt32(curAccNum), Convert.ToInt32(numberEntered)))
					{
						curState = MachineState.MainMenu;
					}
					else
					{
						curState = MachineState.InvalidPin;
						UpdateMachine();
					}
					numberEntered = "";
					break;
				case MachineState.WithdrawingCustomAmount:
					numberEntered = "";
					curState = MachineState.MainMenu;
					break;
				case MachineState.ChangingPinNewPin:
					if(numberEntered.Length == 4)
					{
						curState = MachineState.MainMenu;
					}
					numberEntered = "";
					break;
				case MachineState.ChangingPinOldPin:
					if (numberEntered.Length == 4)
						curState = MachineState.ChangingPinNewPin;
					numberEntered = "";
					break;
			}

			UpdateMachine();
		}

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
			if (curAccNum != "")
			{
				curState = MachineState.EndMessage;
				numberEntered = "";
				UpdateMachine();
			}
        }

		private void UpdateMachine()
		{
			int count = 0;
			switch(curState)
			{
				case MachineState.WaitingForCard:
					main_display.Text = "Please, insert your card";
					NumberLabel.Text = "";
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "";
					b4_label.Text = "";
					break;
				case MachineState.WaitingForPin:
					main_display.Text = "Please, enter your pin:";
					NumberLabel.Text = "";
					count = numberEntered.Length;
					for (int i = 0; i < 4; i++)
					{
						if (count != 0)
						{
							NumberLabel.Text += "X ";
							count--;
						}
						else
							NumberLabel.Text += "_ ";
					}
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "";
					b4_label.Text = "";
					break;
				case MachineState.MainMenu:
					main_display.Text = "Account number:\n" + curAccNum;
					NumberLabel.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "";
					b4_label.Text = "";
					a1_label.Text = "Check balance";
					a2_label.Text = "Change pin";
					b1_label.Text = "Withdraw\nmoney";
					break;
				case MachineState.WithdrawingMoney:
					main_display.Text = bank.getAccounts().First();
					NumberLabel.Text = "";
					a1_label.Text = "5";
					a2_label.Text = "20";
					a3_label.Text = "100";
					b1_label.Text = "10";
					b2_label.Text = "50";
					b3_label.Text = "Custom";
					b4_label.Text = "Back";
					break;
				case MachineState.WithdrawingCustomAmount:
					main_display.Text = "Enter the amount\nto be withdrawn:";
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "";
					b4_label.Text = "";
					NumberLabel.Text = numberEntered;
					break;
				case MachineState.ShowingBalance:
					main_display.Text = bank.getAccounts().First();
					NumberLabel.Text = "";
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "Back";
					b4_label.Text = "";
					break;
				case MachineState.ChangingPinOldPin:
					main_display.Text = "Enter your old pin:";
					NumberLabel.Text = "";
					count = numberEntered.Length;
					for (int i = 0; i < 4; i++)
					{
						if (count != 0)
						{
							NumberLabel.Text += "X ";
							count--;
						}
						else
							NumberLabel.Text += "_ ";
					}
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "Back";
					b4_label.Text = "";
					break;
				case MachineState.ChangingPinNewPin:
					main_display.Text = "Enter your new pin:";
					NumberLabel.Text = "";
					count = numberEntered.Length;
					for (int i = 0; i < 4; i++)
					{
						if (count != 0)
						{
							NumberLabel.Text += "X ";
							count--;
						}
						else
							NumberLabel.Text += "_ ";
					}
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "Back";
					b4_label.Text = "";
					break;
				case MachineState.ConfirmWantAnotherAction:
					main_display.Text = "Do you want to perform\nanother action?";
					NumberLabel.Text = "";
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "Yes";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "No";
					b4_label.Text = "";
					break;
				case MachineState.InvalidPin:
					main_display.Text = "Invalid pin entered";
					curState = MachineState.WaitingForPin;
					temp_message_timer.Enabled = true;
					break;
				case MachineState.EndMessage:
					main_display.Text = "Thank you for using our ATM";
					NumberLabel.Text = "";
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "";
					b4_label.Text = "";
					numberEntered = "";
					curAccNum = "";
					curState = MachineState.WaitingForCard;
					temp_message_timer.Enabled = true;
					break;
			}
		}


		private void InvalidInputTimer(object sender, EventArgs e)
		{
			((System.Timers.Timer)sender).Enabled = false;
			
			
			this.Invoke(new MethodInvoker(delegate {
				UpdateMachine();
			}));
		}


		private void CreateKeypadButtons()
		{
			//create keypad buttons
			numpad = new List<Button>();
			int buttonCounter = 1;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Button button = new Button();

					button.Click += new EventHandler(KeypadButtonClicked);

					Controls.Add(button);

					if (buttonCounter < 10)
					{
						button.Bounds = new Rectangle(new Point(offsetPoint.X + (j * (numpadButtonDimension.Width + numpadMargin)), offsetPoint.Y + (i * (numpadButtonDimension.Height + numpadMargin))), numpadButtonDimension);
						button.Text = (buttonCounter++).ToString();
					}
					else if (buttonCounter == 10)
					{
						button.Bounds = new Rectangle(new Point(offsetPoint.X + ((j + 1) * (numpadButtonDimension.Width + numpadMargin)), offsetPoint.Y + (i * (numpadButtonDimension.Height + numpadMargin))), numpadButtonDimension);
						button.Text = "0";
						j = 5;
						i = 4;
					}

				}
			}
		}

		private void SideA1_btn_Click(object sender, EventArgs e)
		{
			switch(curState)
			{
				case MachineState.MainMenu:
					curState = MachineState.ShowingBalance;
					break;
			}
			UpdateMachine();
		}

		private void SideA2_btn_Click(object sender, EventArgs e)
		{
			switch (curState)
			{
				case MachineState.MainMenu:
					curState = MachineState.ChangingPinOldPin;
					break;
			}
			UpdateMachine();
		}

		private void SideA3_btn_Click(object sender, EventArgs e)
		{

		}

		private void SideB1_btn_Click(object sender, EventArgs e)
		{
			switch (curState)
			{
				case MachineState.MainMenu:
					curState = MachineState.WithdrawingMoney;
					break;
			}
			UpdateMachine();
		}

		private void SideB2_btn_Click(object sender, EventArgs e)
		{

		}

		private void SideB3_btn_Click(object sender, EventArgs e)
		{
			switch(curState)
			{
				case MachineState.ShowingBalance:
				case MachineState.ChangingPinOldPin:
				case MachineState.ChangingPinNewPin:
					curState = MachineState.MainMenu;
					break;
				case MachineState.WithdrawingCustomAmount:
					curState = MachineState.WithdrawingMoney;
					break;
				case MachineState.WithdrawingMoney:
					curState = MachineState.WithdrawingCustomAmount;
					break;
			}
			UpdateMachine();
		}

		private void SideB4_btn_Click(object sender, EventArgs e)
		{
			if (curState == MachineState.WithdrawingMoney)
				curState = MachineState.MainMenu;
			UpdateMachine();
		}

	}
}

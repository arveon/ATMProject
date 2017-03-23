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
	public delegate void UpdateLog(string message);
	public partial class ATM : Form
	{
		private bool isBroken;

		System.Timers.Timer temp_message_timer = new System.Timers.Timer(1000);
		enum MachineState
		{
			WaitingForCard,
			WaitingForPin,
			MainMenu,
			ShowingBalance,
			WithdrawingMoney,
			WithdrawingCustomAmount,
			InsufficientFunds,
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

		UpdateLog logUpdater;

		List<Button> numpad;

		Bank bank;

		private Point offsetPoint = new Point(20,270);
		private int numpadMargin = 5;
		private Size numpadButtonDimension = new Size(50,50);

		public ATM(Bank bank, UpdateLog logger, bool isBroken)
		{
			temp_message_timer.Elapsed += new System.Timers.ElapsedEventHandler(InvalidInputTimer);
			temp_message_timer.AutoReset = true;
			curAccNum = "";
			curState = MachineState.WaitingForCard;

			logUpdater = logger;
			this.bank = bank;
			this.isBroken = isBroken;

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

			main_display.TextAlign = ContentAlignment.MiddleCenter;
			a1_label.TextAlign = ContentAlignment.MiddleLeft;
			a2_label.TextAlign = ContentAlignment.MiddleLeft;
			a3_label.TextAlign = ContentAlignment.MiddleLeft;
			a4_label.TextAlign = ContentAlignment.MiddleLeft;
			b1_label.TextAlign = ContentAlignment.MiddleRight;
			b2_label.TextAlign = ContentAlignment.MiddleRight;
			b3_label.TextAlign = ContentAlignment.MiddleRight;
			b4_label.TextAlign = ContentAlignment.MiddleRight;

			UpdateMachine();
			logUpdater("Machine started");

			this.FormClosing += (sender, eventArgs) =>
				{
					logUpdater("Machine terminated");
				};


			
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
				case MachineState.WaitingForPin:
					if (numberEntered.Length == 4 && bank.CheckPin(Convert.ToInt32(curAccNum), Convert.ToInt32(numberEntered)))
					{
						curState = MachineState.MainMenu;
						logUpdater(curAccNum + " card PIN entered correctly");
					}
					else
					{
						curState = MachineState.InvalidPin;
						logUpdater(curAccNum + " card PIN entered incorrectly");
					}
					numberEntered = "";
					break;
				case MachineState.WithdrawingCustomAmount:
					if (bank.DoAction(ATMAction.WithdrawMoney, Convert.ToInt32(numberEntered), Convert.ToInt32(curAccNum), isBroken))
					{
						curState = MachineState.ConfirmWantAnotherAction;
						logUpdater(curAccNum + " took £" + numberEntered + " off the account. New balance: " + bank.getAccountBalance(Convert.ToInt32(curAccNum)));

					}
					else
					{
						curState = MachineState.InsufficientFunds;
						logUpdater(curAccNum + " failed to withdraw £" + numberEntered + " off the account. Insufficient funds");

					}
					numberEntered = "";
					
					break;
				case MachineState.ChangingPinNewPin:
					if (numberEntered.Length == 4)
					{
						bank.SetPin(Convert.ToInt32(curAccNum), Convert.ToInt32(numberEntered));
						curState = MachineState.ConfirmWantAnotherAction;
						logUpdater(curAccNum + " changed their pin to " + numberEntered);
					}
					else
						curState = MachineState.InvalidInput;
					
					numberEntered = "";
					break;
				case MachineState.ChangingPinOldPin:
					
					if(numberEntered.Length > 0)
						if (bank.CheckPin(Convert.ToInt32(curAccNum), Convert.ToInt32(numberEntered)))
						{
							curState = MachineState.ChangingPinNewPin;
						}
						else
						{
							logUpdater(curAccNum + " pin change failed");
							curState = MachineState.InvalidInput;
						}
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
				logUpdater(curAccNum + " card ejected.");
				UpdateMachine();
			}
        }

		private void UpdateMachine()
		{
			int count = 0;
			BankAccounts.DataSource = bank.getAccounts();
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
					main_display.Text = "Available balance: £" + bank.getAccountBalance(Convert.ToInt32(curAccNum)).ToString();
					NumberLabel.Text = "";
					a1_label.Text = "10";
					a2_label.Text = "40";
					a3_label.Text = "500";
					b1_label.Text = "20";
					b2_label.Text = "100";
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
					b3_label.Text = "Back";
					b4_label.Text = "";
					NumberLabel.Text = numberEntered;
					break;
				case MachineState.ShowingBalance:
					main_display.Text = "AccountNumber: " + curAccNum + "\nAvailable balance: £" + bank.getAccountBalance(Convert.ToInt32(curAccNum)).ToString();
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
					Console.WriteLine("gotToOldPinstate");
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
					Console.WriteLine("gotToNewPinstate");
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
					NumberLabel.Text = "";
					curState = MachineState.WaitingForPin;
					temp_message_timer.Enabled = true;
					break;
				case MachineState.EndMessage:
					main_display.Text = "Thank you for\nusing our ATM";
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
				case MachineState.InsufficientFunds:
					main_display.Text = "Insufficient funds!";
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "";
					b4_label.Text = "";
					numberEntered = "";
					curState = MachineState.ConfirmWantAnotherAction;
					temp_message_timer.Enabled = true;
					break;
				case MachineState.InvalidInput:
					main_display.Text = "Invalid pin!";
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
					curState = MachineState.ConfirmWantAnotherAction;
					temp_message_timer.Enabled = true;
					break;
			}
		}

		private void InvalidInputTimer(object sender, EventArgs e)
		{
			//required in case user closes the atm before the timer elapses
			try
			{
				((System.Timers.Timer)sender).Enabled = false;
				this.Invoke(new MethodInvoker(delegate {
					UpdateMachine();
				}));
			}
			catch (Exception)
			{

			}
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
				case MachineState.WithdrawingMoney:
					if (bank.DoAction(ATMAction.WithdrawMoney, Convert.ToInt32(a1_label.Text), Convert.ToInt32(curAccNum), isBroken))
					{
						curState = MachineState.ConfirmWantAnotherAction;
						logUpdater(curAccNum + " took £" + a1_label.Text + " off the account. New balance: " + bank.getAccountBalance(Convert.ToInt32(curAccNum)));
					}
					else
					{
						curState = MachineState.InsufficientFunds;
						logUpdater(curAccNum + " failed to withdraw £" + a1_label.Text + " off the account. Insufficient funds");
					}
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
				case MachineState.WithdrawingMoney:
					if (bank.DoAction(ATMAction.WithdrawMoney, Convert.ToInt32(a2_label.Text), Convert.ToInt32(curAccNum), isBroken))
					{
						curState = MachineState.ConfirmWantAnotherAction;
						logUpdater(curAccNum + " took £" + a2_label.Text + " off the account. New balance: " + bank.getAccountBalance(Convert.ToInt32(curAccNum)));
					}
					else
					{
						curState = MachineState.InsufficientFunds;
						logUpdater(curAccNum + " failed to withdraw £" + a2_label.Text + " off the account. Insufficient funds");
					}
					break;
			}
			UpdateMachine();
		}

		private void SideA3_btn_Click(object sender, EventArgs e)
		{
			if (curState == MachineState.WithdrawingMoney)
			{
				if (bank.DoAction(ATMAction.WithdrawMoney, Convert.ToInt32(a3_label.Text), Convert.ToInt32(curAccNum), isBroken))
				{
					curState = MachineState.ConfirmWantAnotherAction;
					logUpdater(curAccNum + " took £" + a3_label.Text + " off the account. New balance: " + bank.getAccountBalance(Convert.ToInt32(curAccNum)));
				}
				else
				{
					curState = MachineState.InsufficientFunds;
					logUpdater(curAccNum + " failed to withdraw £" + a3_label.Text + " off the account. Insufficient funds");
				}
			}
			else if(curState == MachineState.ConfirmWantAnotherAction)
			{
				curState = MachineState.MainMenu;
			}
			UpdateMachine();
		}

		private void SideB1_btn_Click(object sender, EventArgs e)
		{
			switch (curState)
			{
				case MachineState.MainMenu:
					curState = MachineState.WithdrawingMoney;
					break;
				case MachineState.WithdrawingMoney:
					if (bank.DoAction(ATMAction.WithdrawMoney, Convert.ToInt32(b1_label.Text), Convert.ToInt32(curAccNum), isBroken))
					{
						curState = MachineState.ConfirmWantAnotherAction;
						logUpdater(curAccNum + " took £" + b1_label.Text + " off the account. New balance: " + bank.getAccountBalance(Convert.ToInt32(curAccNum)));
					}
					else
					{
						curState = MachineState.InsufficientFunds;
						logUpdater(curAccNum + " failed to withdraw £" + b2_label.Text + " off the account. Insufficient funds");
					}
					break;
			}
			UpdateMachine();
		}

		private void SideB2_btn_Click(object sender, EventArgs e)
		{
			if(curState == MachineState.WithdrawingMoney)
			{
				if (bank.DoAction(ATMAction.WithdrawMoney, Convert.ToInt32(b2_label.Text), Convert.ToInt32(curAccNum), isBroken))
				{
					curState = MachineState.ConfirmWantAnotherAction;
					logUpdater(curAccNum + " took £" + b2_label.Text + " off the account. New balance: " + bank.getAccountBalance(Convert.ToInt32(curAccNum)));
				}
				else
				{
					curState = MachineState.InsufficientFunds;
					logUpdater(curAccNum + " failed to withdraw £" + b2_label.Text + " off the account. Insufficient funds");

				}
			}
			UpdateMachine();
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
				case MachineState.ConfirmWantAnotherAction:
					curState = MachineState.EndMessage;
					logUpdater(curAccNum + " card ejected");
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

		private void InsertCardButton_Click(object sender, EventArgs e)
		{
			if (curState == MachineState.WaitingForCard)
			{
				curState = MachineState.WaitingForPin;
				curAccNum = ((string)BankAccounts.SelectedItem).Substring(0, 6);
				logUpdater(((string)BankAccounts.SelectedItem).Substring(0, 6) + " card inserted");
			}
			UpdateMachine();
		}

	}
}
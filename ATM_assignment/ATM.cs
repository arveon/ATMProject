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
		enum MachineState
		{
			WaitingForCard,
			WaitingForPin,
			MainMenu,
			ShowingBalance,
			WithdrawingMoney,
			ChangingPin,
			ConfirmWantAnotherAction
		}
		private MachineState curState;


		updateAccountDisplay AccountUpdated;

		List<Button> numpad;

		Bank bank;

		private Point offsetPoint = new Point(20,270);
		private int numpadMargin = 5;
		private Size numpadButtonDimension = new Size(50,50);

		public ATM(Bank bank, updateAccountDisplay updater)
		{
			curState = MachineState.WaitingForCard;

			AccountUpdated = updater;
			this.bank = bank;

			//create keypad buttons
			numpad = new List<Button>();
			int buttonCounter = 1;
			for(int i = 0; i < 4; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					Button button = new Button();

                    button.Click += (source, args) =>
                    {
                        bank.DoAction(ATMAction.WithdrawMoney, 10, 111111);
                        AccountUpdated(123);
                    };
                    
                    Controls.Add(button);

                    if (buttonCounter < 10)
                    {
                        button.Bounds = new Rectangle(new Point(offsetPoint.X + (j * (numpadButtonDimension.Width + numpadMargin)), offsetPoint.Y + (i * (numpadButtonDimension.Height + numpadMargin))), numpadButtonDimension);
                        button.Text = (buttonCounter++).ToString();
                    }
                    else if (buttonCounter == 10)
                    {
                        button.Bounds = new Rectangle(new Point(offsetPoint.X + ((j+1) * (numpadButtonDimension.Width + numpadMargin)), offsetPoint.Y + (i * (numpadButtonDimension.Height + numpadMargin))), numpadButtonDimension);
                        button.Text = "0";
                        j = 5;
                        i = 4;
                    }
					
				}
			}

			


			InitializeComponent();
			Enter_btn.Click += (sender, eventArguments) =>
			{
				if (curState == (MachineState)6) curState = 0;
				else curState++;

				UpdateMachine();
				Console.WriteLine(curState);
			};

			main_display.TextAlign = ContentAlignment.MiddleLeft;

			UpdateMachine();
			
		}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
		
		private void label2_Click(object sender, EventArgs e)
        {

        }

		private void UpdateMachine()
		{
			switch(curState)
			{
				case MachineState.WaitingForCard:
					main_display.Text = "Please, insert your card";
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
					main_display.Text = bank.getAccounts().First();
					a3_label.Text = "";
					a4_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "";
					b4_label.Text = "";
					a1_label.Text = "Check balance";
					a2_label.Text = "Change pin";
					b1_label.Text = "Withdraw money";
					break;
				case MachineState.WithdrawingMoney:
					main_display.Text = bank.getAccounts().First();
					a1_label.Text = "5";
					a2_label.Text = "20";
					a3_label.Text = "100";
					b1_label.Text = "10";
					b2_label.Text = "50";
					b3_label.Text = "Custom";
					break;
				case MachineState.ShowingBalance:
					main_display.Text = bank.getAccounts().First();
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "Back";
					b4_label.Text = "";
					break;
				case MachineState.ChangingPin:
					main_display.Text = "Enter your old pin:";
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "";
					b4_label.Text = "";
					break;
				case MachineState.ConfirmWantAnotherAction:
					main_display.Text = "Do you want another action?";
					a1_label.Text = "";
					a2_label.Text = "";
					a3_label.Text = "Yes";
					a4_label.Text = "";
					b1_label.Text = "";
					b2_label.Text = "";
					b3_label.Text = "No";
					b4_label.Text = "";
					break;
			}
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

	}
}

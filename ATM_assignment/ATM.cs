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
		//UpdateNumberOfATMs _disconnected;
		updateAccountDisplay AccountUpdated;

		List<Button> numpad;

		Bank bank;

		private Point offsetPoint = new Point(20,270);
		private int numpadMargin = 5;
		private Size numpadButtonDimension = new Size(50,50);

		public ATM(Bank bank, updateAccountDisplay updater)
		{
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



	}
}

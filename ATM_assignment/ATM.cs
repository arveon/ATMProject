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

		private Point offsetPoint = new Point(0,0);
		private int numpadMargin = 5;
		private Size numpadButtonDimension = new Size(50,50);

		public ATM(Bank bank, updateAccountDisplay updater)
		{
			AccountUpdated = updater;
			this.bank = bank;

			numpad = new List<Button>();
			for(int i = 0; i < 3; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					Button button = new Button();
					button.Bounds = new Rectangle(new Point(offsetPoint.X + (i*(numpadButtonDimension.Width+numpadMargin)), offsetPoint.Y + (j * (numpadButtonDimension.Height + numpadMargin))), numpadButtonDimension);
					button.Text = ((i * j) + 1).ToString();
					button.Click += (source, args) =>
						{
							bank.DoAction(ATMAction.WithdrawMoney, 10, 111111);
							AccountUpdated(123);
						};

					Controls.Add(button);
				}
			}

			//this.FormClosed += (sender, eventArgs) =>
			//{
			//	//_disconnected(123);
			//};

			InitializeComponent();
		}



	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_assignment
{
	public partial class ATM_Manager : Form
	{
		private int numOfATMAvailable;

		Bank bank;

		List<Thread> ATMs;

		//Thread test;

		public ATM_Manager()
		{
			//i think it should work like that... a list of ATM threads
			ATMs = new List<Thread>();


			numOfATMAvailable = 4;//just a hardcoded sample value
			bank = new Bank();//bank system that is handling all the interaction with bank accounts
			InitializeComponent();
			
			AvailableATMNumber.Text = numOfATMAvailable.ToString();
			BankAccounts.DataSource = bank.getAccounts();//listbox on form showing accounts and balances
		}


		public void exit(object sender, EventArgs eventArgs)
		{
			Application.Exit();
		}

		private void createATM(object sender, EventArgs e)
		{
			//if number of available atms is > 0, deduct one, update the label and create the ATM
			if(numOfATMAvailable > 0)
			{
				numOfATMAvailable--;
				AvailableATMNumber.Text = numOfATMAvailable.ToString();


				//this block of code doesn't work, i'm in the process of figuring out how we should do it using multi-threading
				ThreadStart temp = new ThreadStart(atmThread);
				Thread atm = new Thread(temp);
				atm.Start();
				ATMs.Add(atm);
			}
		}

		private void atmThread()
		{
			ATM ATM = new ATM();
			ATM.Show();


		}


	}
}

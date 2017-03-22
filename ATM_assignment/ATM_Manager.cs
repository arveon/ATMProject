﻿using System;
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
			Console.WriteLine("oyblyat");
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

				updateAccountDisplay callback = new updateAccountDisplay(accountUpdated);
				Thread atm = new Thread(new ParameterizedThreadStart(atmThread));
				atm.Start(callback);
				
				ATMs.Add(atm);
			}
		}

		private void atmThread(object atmUpdater)
		{
			ATM ATM = new ATM(bank, (updateAccountDisplay)atmUpdater);
			Application.Run(ATM);

			numOfATMAvailable++;
			AvailableATMNumber.Invoke(new MethodInvoker(delegate
				{
					AvailableATMNumber.Text = numOfATMAvailable.ToString();
				}));

			BankAccounts.Invoke(new MethodInvoker(delegate
				{
					BankAccounts.DataSource = bank.getAccounts();

				}));
			
		}

		private void accountUpdated(int asd)
		{
			BankAccounts.Invoke(new MethodInvoker(delegate
			{
				BankAccounts.DataSource = bank.getAccounts();

			}));

        }

        private void BankAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}

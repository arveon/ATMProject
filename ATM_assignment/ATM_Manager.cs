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
		public static Semaphore threadController = new Semaphore(1,1);
		private int numOfATMAvailable;
		List<string> log;
		Bank bank;
		List<Thread> ATMs;

		public ATM_Manager()
		{
			//i think it should work like that... a list of ATM threads
			ATMs = new List<Thread>();

			log = new List<String>();
			numOfATMAvailable = 4;//just a hardcoded sample value
			bank = new Bank();//bank system that is handling all the interaction with bank accounts
			InitializeComponent();
			
			AvailableATMNumber.Text = numOfATMAvailable.ToString();
			BankAccounts.DataSource = log;//listbox on form showing accounts and balances
			this.FormClosing += new FormClosingEventHandler(exit);
		}


		public void exit(object sender, EventArgs eventArgs)
		{
			foreach(Thread tmp in ATMs)
				tmp.Abort();
			Application.Exit();
		}

		private void createBrokenATM(object sender, EventArgs e)
		{
			//if number of available atms is > 0, deduct one, update the label and create the ATM
			if(numOfATMAvailable > 0)
			{
				numOfATMAvailable--;
				AvailableATMNumber.Text = numOfATMAvailable.ToString();

				Thread atm = new Thread(delegate()
					{
						atmThread(new UpdateLog(updateLog), true);
					});
				atm.Start();
				
				ATMs.Add(atm);
			}
		}

		private void createFixedATM(object sender, EventArgs e)
		{
			//if number of available atms is > 0, deduct one, update the label and create the ATM
			if (numOfATMAvailable > 0)
			{
				numOfATMAvailable--;
				AvailableATMNumber.Text = numOfATMAvailable.ToString();

				Thread atm = new Thread(delegate()
				{
					atmThread(new UpdateLog(updateLog), false);
				});
				atm.Start();

				ATMs.Add(atm);
			}
		}

		private void atmThread(object logger, bool isBroken)
		{
			ATM ATM = new ATM(bank, (UpdateLog)logger, isBroken);
			Application.Run(ATM);

			numOfATMAvailable++;
			AvailableATMNumber.Invoke(new MethodInvoker(delegate
				{
					AvailableATMNumber.Text = numOfATMAvailable.ToString();
				}));
		}

		private void updateLog(string logEntry)
		{
			//Console.WriteLine("log entry added");
			log.Add(DateTime.Now.ToString("hh:mm:ss") + " - " + logEntry);


			BankAccounts.Invoke(new MethodInvoker(delegate
				{
					BankAccounts.DataSource = null;
					BankAccounts.DataSource = log;
					//BankAccounts.DataSource = log;
					BankAccounts.Update();
				}));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			createFixedATM(sender, e);
		}
	}
}

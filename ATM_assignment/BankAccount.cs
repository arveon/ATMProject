using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ATM_assignment
{
	public class BankAccount
	{
		private const int withdrawalLimit = 300;//limit of how much money you can withdraw per day
		public int AccountNumber { get; private set; }
		public int Balance { get; private set; }//current balance
		int WithdrawnToday { get; set; }//how much money was withdrawn this day, has to be under withdrawal limit
		public int CardPin { get; set; }

		//custom constructor that initialises the account number, balance and pin to given values
		public BankAccount(int AccNumber, int Balance, int PIN)
		{
			AccountNumber = AccNumber;
			this.Balance = Balance;
			CardPin = PIN;
			WithdrawnToday = 0;
		}

		//this way of changing the balance will create a racing condition between different ATMs
		public bool setBalance(int newBalance)
		{
			bool result = false;
			if (newBalance >= 0)
			{
				Balance = newBalance;
				result = true;
			}
				

			return result;
		}		
		
		//this method of changing the balance will completely eliminate the racing condition between the ATMs
		public bool withdrawMoney(int toBeWithdrawn)
		{
			//if there is enough money on the bank account to withdraw the provided amount
			// AND taking out that much money will not run the person over the withdrawal limit, 
			//withdraws and returns true
			//otherwise enoughMoneyAvailable stays false and the money is not withdrawn
			//semaphorel.waitone() 
			//new variable = current balance
			//sleep(500)
			//setBalance(variable-moneyYouwanttoTake)
			//semaphone.release()
			bool enoughMoneyAvailable = false;
			if(Balance >= toBeWithdrawn)
			{
				WithdrawnToday += toBeWithdrawn;
				Balance -= toBeWithdrawn;
				enoughMoneyAvailable = true;
			}
			
			return enoughMoneyAvailable;
		}

		//method checks if the given pin matches the one of this account
		public bool CheckPin(int pinAttempted)
		{
			if (pinAttempted == CardPin)
				return true;
			else
				return false;
		}

	}
}

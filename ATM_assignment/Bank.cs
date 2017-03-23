using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_assignment
{
	public enum ATMAction
	{
		WithdrawMoney,
		InsertMoney,
		ChangePin
	}


	//basically serves as a container for bank accounts
	//allows managing existing bank accounts
	public class Bank
	{
		public List<BankAccount> AccountList { get; private set; }

		//default constructor creates three default bank accounts with different acc.numbers, balances and card PINs
		public Bank()
		{
			AccountList = new List<BankAccount>();

			AccountList.Add(new BankAccount(111111, 100, 1111));
			AccountList.Add(new BankAccount(222222, 200, 2222));
			AccountList.Add(new BankAccount(333333, 1400, 3333));
		}

		//custom constructor allows to provide a list of accounts to be used
		public Bank(List<BankAccount> accountList)
		{
			this.AccountList = accountList;
		}

		//method finds a bank account that the user is trying to access and sends request to the bank account to check if the pin is correct
		public bool CheckPin(int accountNumber, int attemptedPin)
		{
			bool result = false;
			//find the required account and send request to check the pin
			foreach(BankAccount acc in AccountList)
			{
				if (acc.AccountNumber == accountNumber)
				{
					Console.WriteLine(attemptedPin);
					result = acc.CheckPin(attemptedPin);
					break;
				}
			}
			return result;
		}

		public bool DoAction(ATMAction action, int argument, int accountNumber)
		{
			bool result = false;

			BankAccount curAcc = null;
			foreach(BankAccount ac in AccountList)
			{
				if (ac.AccountNumber == accountNumber)
				{
					curAcc = ac;
					break;
				}
			}

			if (curAcc == null)
				return result;

			switch(action)
			{
				case ATMAction.ChangePin:
					if (argument > 9999)
					{
						result = false;
						break;
					}

					curAcc.CardPin = argument;
					result = true;
					break;
				case ATMAction.InsertMoney:
					result = curAcc.withdrawMoney(argument);
					break;
				case ATMAction.WithdrawMoney:
					result = curAcc.withdrawMoney(argument);
					break;
			}

			return result;
		}

		public int getAccountBalance(int accountNumber)
		{
			foreach(BankAccount acc in AccountList)
			{
				if(acc.AccountNumber == accountNumber)
				{
					return acc.Balance;
				}
			}
			return -1;
		}

		//will only return all bank account numbers and their balances as a list of strings
		public List<string> getAccounts()
		{
			List<string> accounts = new List<string>();

			foreach(BankAccount acc in AccountList)
				accounts.Add(acc.AccountNumber + ": £" + acc.Balance);
	
			return accounts;
		}

	}
}

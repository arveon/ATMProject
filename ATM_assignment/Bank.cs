using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_assignment
{
	//basically serves as a container for bank accounts
	//allows managing existing bank accounts
	class Bank
	{
		public List<BankAccount> AccountList { get; private set; }

		//default constructor creates three default bank accounts with different acc.numbers, balances and card PINs
		public Bank()
		{
			AccountList = new List<BankAccount>();

			AccountList.Add(new BankAccount(111111, 100, 0000));
			AccountList.Add(new BankAccount(222222, 200, 1234));
			AccountList.Add(new BankAccount(333333, 1400, 1111));
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
					result = acc.CheckPin(attemptedPin);
					break;
				}
			}
			return result;
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

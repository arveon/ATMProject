using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_assignment
{
	//types of actions the user can perform on the bank acount through atm
	public enum ATMAction
	{
		WithdrawMoney,
		ChangePin
	}


	//basically serves as a container for bank accounts
	//allows managing existing bank accounts
	public class Bank
	{
		public List<BankAccount> AccountList { get; private set; }//list of accounts in database

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
					result = acc.CheckPin(attemptedPin);
					break;
				}
			}
			return result;
		}

		//the method used to change the pin of the account with a given account number to newPin
		public bool SetPin(int accountNumber, int newPin)
		{
			foreach(BankAccount acc in AccountList)
			{
				if(acc.AccountNumber == accountNumber)
				{
					acc.CardPin = newPin;
					return true;
				}
			}
			return false;
		}

		//method is used to do both withdrawing money and changing the pin
		//action - action to perform
		//argument - represents new pin/amount to be withdrawn
		//isMachineBroken - represents to whether act like the race condition is allowed or like it's fixed
		public bool DoAction(ATMAction action, int argument, int accountNumber, bool isMachineBroken)
		{
			bool result = false;
			//find the account in the list to perform the action on
			BankAccount curAcc = null;
			foreach(BankAccount ac in AccountList)
			{
				if (ac.AccountNumber == accountNumber)
				{
					curAcc = ac;
					break;
				}
			}
			//if account isn't found, return
			if (curAcc == null)
				return result;

			switch(action)
			{
				case ATMAction.ChangePin:
					//if pin is more than 4 numbers, can't hange it
					if (argument > 9999)
					{
						result = false;
						break;
					}
					//otherwise change the pin
					curAcc.CardPin = argument;
					result = true;
					break;
				case ATMAction.WithdrawMoney:
					//if the machine that sent request isn't broken, apply semaphore fix
					if (!isMachineBroken)
					{
						ATM_Manager.threadController.WaitOne();
						//simulates the racing condition if the other ATM is used within three seconds from this one
						int balance = curAcc.Balance;
						System.Threading.Thread.Sleep(3000);
						result = curAcc.setBalance(balance - argument);

						//result = curAcc.withdrawMoney(argument);
						ATM_Manager.threadController.Release();
					}
					else//otherwise don't apply a semaphore fix
					{
						int balance = curAcc.Balance;
						System.Threading.Thread.Sleep(3000);
						result = curAcc.setBalance(balance - argument);
					}
					break;
			}

			return result;
		}

		//will return balance of the account with provided accountNumber, or -1 if account not found
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

using System;
using System.Collections.Generic;

namespace Project5
{
    public class Bank
    {
        public List<Account> accountList;
        List<Client> clientList;
        int limitForDoubtful;
        double percent;
        double commission;
        int period; 


        public Bank(int limitForDoubtful, double percent, double commission, int period)
        {
            accountList = new List<Account>();
            clientList = new List<Client>();
            this.limitForDoubtful = limitForDoubtful;
            this.percent = percent;
            this.commission = commission;
            this.period = period;
        }

        public void TransactionCancelling(double money, OperationType operationType, Account firstAccount, Account secondAccount)
        {
            firstAccount.TransactionCancelling(money, operationType, firstAccount, secondAccount);
        }

        public void CreateClient(string name, string surname)
        {
            int id = clientList.Count;
            clientList.Add(new Client(name, surname, id));
        }

        public void CreateClient(string name, string surname, string address)
        {
            int id = clientList.Count;
            clientList.Add(new Client(name, surname, address, id));
        }

        public void CreateClient(string name, string surname, int passport)
        {
            int id = clientList.Count;
            clientList.Add(new Client(name, surname, passport, id));
        }

        public void CreateClient(string name, string surname, string address, int passport)
        {
            int id = clientList.Count;
            clientList.Add(new Client(name, surname, address, passport, id));
        }

        public void CreateAccount(Client client, double sum, AccountType accountType)
        {
            int id = accountList.Count;
            switch (accountType)
            {
                case AccountType.CreditAccount:
                    CreditAccount creditAccount = new CreditAccount(id, client.id, sum, commission, limitForDoubtful);
                    creditAccount.MakeAccountInTheBank(client, this);
                    break;
                case AccountType.DebitAccount:
                    DebitAccount debitAccount = new DebitAccount(percent, id, client.id, sum, limitForDoubtful);
                    debitAccount.MakeAccountInTheBank(client, this);
                    break;
                case AccountType.DepositAccount:
                    DepositAccount depositAccount = new DepositAccount(id, client.id, sum, period, limitForDoubtful);
                    depositAccount.MakeAccountInTheBank(client, this);
                    break;
                default:
                    throw new Exception("Error while creating account. Wrong Account type");
            }
        }

    }
}

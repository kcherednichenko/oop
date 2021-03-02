using System;
using System.Collections.Generic;

namespace Project5
{
    public class Client
    {
        string name;
        string surname;
        string address;
        int passport;
        public List<Account> clientAccountList;
        public bool isDoubtful;
        public int id;


        public Client(string name, string surname, int id)
        {
            this.name = name;
            this.surname = surname;
            isDoubtful = true;
            this.id = id;
            clientAccountList = new List<Account>();
        }

        public Client(string name, string surname, string address, int id)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            isDoubtful = true;
            this.id = id;
            clientAccountList = new List<Account>();
        }

        public Client(string name, string surname, int passport, int id)
        {
            this.name = name;
            this.surname = surname;
            this.passport = passport;
            isDoubtful = true;
            this.id = id;
            clientAccountList = new List<Account>();
        }

        public Client(string name, string surname, string address, int passport, int id)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.passport = passport;
            isDoubtful = false;
            this.id = id;
            clientAccountList = new List<Account>();
        }

        public void AddAddress(string address, Bank bank)
        {
            this.address = address;
            if (passport != null)
            {
                isDoubtful = false;
                foreach (var account in bank.accountList)
                {
                    if (account.clientId == id)
                    {
                        account.isDoubtful = false;
                    }
                }
            }
        }

        public void AddPassport(int passport, Bank bank)
        {
            this.passport = passport;
            if (address != "" || address != null)
            {
                isDoubtful = false;
                foreach (var account in bank.accountList)
                {
                    if (account.clientId == id)
                    {
                        account.isDoubtful = false;
                    }
                }
            }
        }

        public Account GetAccount(int index)
        {
            return clientAccountList[index];
        }

       
    }
}

using System;
namespace Project5
{
    public class Account
    {
        public int clientId;
        protected int id;
        public double sum;
        protected double percent;
        protected double percentRemain = 0;
        public bool isDoubtful;
        public double limitForDoubtful;
        public double additionalSum = 0;

        public int period;
        public double commission;

        public Account(int id, int clientId, double sum, double limitForDoubtful)
        {
            this.id = id;
            this.clientId = clientId;
            this.sum = sum;
            this.limitForDoubtful = limitForDoubtful;
        }

        public virtual void TakeMoney(double money) { }

        public virtual void Recharge(double money) { }

        public virtual void Transfer(double money, Account account) { }

        public virtual void CountPercentRemain() { }

        public virtual void AddPercentRemain() { }

        public virtual void TransactionCancelling(double money, OperationType operationType, Account firstAccount, Account secondAccount)
        {
            switch (operationType)
            {
                case OperationType.TakeMoney:
                    firstAccount.TakeMoneyCancelling(money);
                    break;
                case OperationType.Recharge:
                    firstAccount.RechargeCancelling(money);
                    break;
                case OperationType.Transfer:
                    firstAccount.TransferCancelling(money, secondAccount);
                    break;
            }
        }

        public virtual void TakeMoneyCancelling(double money) { }

        public virtual void RechargeCancelling(double money) { }

        public virtual void TransferCancelling(double money, Account account) { }

        public void MakeAccountInTheBank(Client client, Bank bank)
        {
            isDoubtful = client.isDoubtful;
            bank.accountList.Add(this);
            client.clientAccountList.Add(this);
        }

    }
}

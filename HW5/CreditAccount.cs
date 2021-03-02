using System;
namespace Project5
{
    public class CreditAccount : Account
    {

        public CreditAccount(int id, int clientId, double sum, double commission, double limitForDoubtful) : base (id, clientId, sum, limitForDoubtful)
        {
            percent = 0;
            this.commission = commission;
        }

        public override void TakeMoney(double money)
        {
            if (isDoubtful && money > limitForDoubtful)
            {
                throw new Exception("You are doubtful client, you can't exceed the limit");
            }
            else
            {
                sum -= money;
                if (sum < 0)
                {
                    sum -= commission;
                }
            }
        }

        public override void Recharge(double money)
        {
            sum += money;
        }

        public override void Transfer(double money, Account account)
        {
            if (isDoubtful && money > limitForDoubtful)
            {
                throw new Exception("You are doubtful client, you can't exceed the limit");
            }
            else
            {
                sum -= money;
                if (sum < 0)
                {
                    sum -= commission;
                }
                account.Recharge(money);
            }
        }

        public override void TakeMoneyCancelling(double money)
        {
            sum += money;
        }

        public override void RechargeCancelling(double money)
        {
            sum -= money;
        }

        public override void TransferCancelling(double money, Account account)
        {
            account.sum -= money;
            sum += money;
        }
    }
}

using System;
namespace Project5
{
    public class DebitAccount : Account
    {
        

        public DebitAccount(double percent, int id, int clientId, double sum, double limitForDoubtful) : base (id, clientId, sum, limitForDoubtful)
        {
            this.percent = percent;
        }

        public override void TakeMoney(double money)
        {
            if (isDoubtful && money > limitForDoubtful)
            {
                throw new Exception("You are doubtful client, you can't exceed the limit");
            }
            else
            {
                if (sum >= money)
                {
                    sum -= money;
                }
                else
                {
                    throw new Exception("There is not enough money to take");
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
                if (sum >= money)
                {
                    sum -= money;
                    account.Recharge(money);
                }
                else
                {
                    throw new Exception("There is not enough money to transfer");
                }
            }
        }

        public override void CountPercentRemain()
        {
            additionalSum += (sum * percent / 100 / 365);
        }

        public override void AddPercentRemain() // добавление процентов к сумме 
        {
            CountPercentRemain();
            sum += additionalSum;
            additionalSum = 0;
            percentRemain = 0;
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

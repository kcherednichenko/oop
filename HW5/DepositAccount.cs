using System;
namespace Project5
{
    public class DepositAccount : Account
    {

        public DepositAccount(int id, int clientId, double sum, int period, double limitForDoubtful) : base (id, clientId, sum, limitForDoubtful)
        {
            this.period = period;
            percent = percentCount();
        }

        private double percentCount()
        {
            if (sum < 50000) return 3;
            else if (sum >= 50000 && sum <= 100000) return 3.5;
            else return 4;
        }

        public override void TakeMoney(double money) // можно уйти в минус?
        {
            if (isDoubtful && money > limitForDoubtful)
            {
                throw new Exception("You are doubtful client, you can't exceed the limit");
            }
            else
            {
                if (period == 0)
                {
                    sum -= money;
                }
                else
                {
                    throw new Exception("You can't take money! The perion haven't finished");
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
                if (period == 0)
                {
                    sum -= money;
                    account.Recharge(money);
                }
                else
                {
                    throw new Exception("You can't take money! The perion haven't finished");
                }
            }
        }

        public override void CountPercentRemain()
        {
            additionalSum += (sum * percent / 100 / 365);
        }

        public override void AddPercentRemain() // добавление процентов к сумме 
        {
            //CountPercentRemain();
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

using System;
namespace Project5
{
    public class TakeMoneyTransactionDeposit : Transaction
    {
        public TakeMoneyTransactionDeposit(Participants participants) : base(participants)
        {
        }

        public override void Do()
        {
            if (participants.Account1.isDoubtful && participants.Money > participants.Account1.limitForDoubtful)
            {
                throw new Exception("You are doubtful client, you can't exceed the limit");
            }
            else
            {   if (participants.Account1 is DepositAccount)
                {
                    if (participants.Account1.period == 0)
                    {
                        participants.Account1.sum -= participants.Money;
                        CountOfTransactions += 1;
                    }
                    else
                    {
                        throw new Exception("You can't take money! The perion haven't finished");
                    }
                }
                else throw new Exception("Wrong type of Account! You can't do TakeMoneyTransactionDeposit with not DepositAccount");
            }
        }

        public override void Undo()
        {
            participants.Account1.sum += participants.Money;
            CountOfTransactions -= 1;
            Check();
        }
    }
}


using System;
namespace Project5
{
    public class TakeMoneyTransactionCredit : Transaction
    {
        public TakeMoneyTransactionCredit(Participants participants) : base(participants)
        {
        }

        public override void Do()
        {
            if (participants.Account1.isDoubtful && participants.Money > participants.Account1.limitForDoubtful)
            {
                throw new Exception("You are doubtful client, you can't exceed the limit");
            }
            else
            {
                if (participants.Account1 is CreditAccount)
                {
                    participants.Account1.sum -= participants.Money;
                    CountOfTransactions += 1;
                    if (participants.Account1.sum < 0)
                    {
                        participants.Account1.sum -= participants.Account1.commission;
                    }
                }
                else throw new Exception("Wrong type of Account! You can't do TakeMoneyTransactionCredit with not CreditAccount");
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

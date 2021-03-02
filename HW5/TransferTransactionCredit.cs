using System;
namespace Project5
{
    public class TransferTransactionCredit : Transaction
    {
        public TransferTransactionCredit(Participants participants) : base(participants)
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
                participants.Account1.sum -= participants.Money;
                CountOfTransactions += 1;
                if (participants.Account1.sum < 0)
                {
                    participants.Account1.sum -= participants.Account1.commission;
                }
                participants.Account2.sum += participants.Money;
            }
        }

        public override void Undo()
        {
            participants.Account2.sum -= participants.Money;
            participants.Account1.sum += participants.Money;
            CountOfTransactions -= 1;
            Check();
        }
    }
}

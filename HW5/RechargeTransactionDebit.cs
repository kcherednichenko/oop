using System;
namespace Project5
{
    public class RechargeTransactionDebit : Transaction
    {
        public RechargeTransactionDebit(Participants participants) : base(participants)
        {
        }

        public override void Do()
        {
            participants.Account1.sum += participants.Money;
            CountOfTransactions += 1;
        }

        public override void Undo()
        {
            participants.Account1.sum -= participants.Money;
            CountOfTransactions -= 1;
            Check();
        }
    }
}

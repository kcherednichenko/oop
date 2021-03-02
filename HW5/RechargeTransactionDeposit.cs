using System;
namespace Project5
{
    public class RechargeTransactionDeposit : Transaction
    {
        public RechargeTransactionDeposit(Participants participants) : base(participants)
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

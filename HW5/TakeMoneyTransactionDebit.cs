﻿using System;
namespace Project5
{
    public class TakeMoneyTransactionDebit : Transaction
    {
        public TakeMoneyTransactionDebit(Participants participants) : base(participants)
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
                if (participants.Account1.sum >= participants.Money)
                {
                    participants.Account1.sum -= participants.Money;
                    CountOfTransactions += 1;
                }
                else
                {
                    throw new Exception("There is not enough money to take");
                }
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

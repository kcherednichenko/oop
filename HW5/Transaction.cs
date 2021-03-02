using System;
namespace Project5
{
    public class Transaction
    {
        public int CountOfTransactions = 0;
        public Participants participants;

        public Transaction(Participants participants)
        {
            this.participants = participants;
        }

        public virtual void Do()
        {
        }

        public virtual void Undo()
        {
        }

        public void Check()
        {
            if (CountOfTransactions < 0) throw new Exception("Error! You can't cancel transaction which hasn't been done");
        }
    }
}

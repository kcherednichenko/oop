using System;
namespace Project5
{
    public class Participants
    {
        public Account Account1 { get; set; }
        public int Money { get; set; }
        public Account Account2 { get; set; }

        public Participants(Account account1, int money)
        {
            Account1 = account1;
            Money = money;
        }

        public Participants(Account account1, Account account2, int money)
        {
            Account1 = account1;
            Money = money;
            Account2 = account2;
        }
    }
}

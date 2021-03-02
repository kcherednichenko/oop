using NUnit.Framework;

namespace Project5
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Bank bank1 = new Bank(10000, 4, 500, 5);
            Client client1 = new Client("Petya", "Petrov", 1);
            Client client2 = new Client("Ivanov", "Ivan", "Voznesenskiy pr.", 401358, 2);
            bank1.CreateAccount(client1, 50000, AccountType.DebitAccount);
            bank1.CreateAccount(client2, 12000, AccountType.DebitAccount);

            Assert.AreEqual(true, client1.GetAccount(0).isDoubtful);

            
            Participants participants = new Participants(client1.GetAccount(0), 9000);
            Transaction tr = new TakeMoneyTransactionDebit(participants);
            tr.Do();
            Assert.AreEqual(41000, client1.GetAccount(0).sum);

            client1.AddAddress("Nevskiy pr.", bank1);
            Assert.AreEqual(false, client1.GetAccount(0).isDoubtful);


            
            Participants participants2 = new Participants(client1.GetAccount(0), client2.GetAccount(0), 1000);
            Transaction tr2 = new TransferTransactionDebit(participants2);
            tr2.Do();
            Assert.AreEqual(40000, client1.GetAccount(0).sum);
            Assert.AreEqual(13000, client2.GetAccount(0).sum);
        }

        [Test]
        public void Test2()
        {
            Bank bank1 = new Bank(10000, 4, 500, 0);
            Client client1 = new Client("Petya", "Petrov", "Nevskiy pr.", 401223);
            Client client2 = new Client("Ivanov", "Ivan", "Voznesenskiy pr.", 401358);
            bank1.CreateAccount(client1, 50000, AccountType.CreditAccount);
            bank1.CreateAccount(client2, 12000, AccountType.DebitAccount);

           
            Participants participants = new Participants(client1.GetAccount(0), 10000);
            Transaction tr = new TakeMoneyTransactionCredit(participants);
            tr.Do();
            Assert.AreEqual(40000, client1.GetAccount(0).sum);
            
            tr.Undo();
            Assert.AreEqual(50000, client1.GetAccount(0).sum);

            
            Participants participants2 = new Participants(client1.GetAccount(0), client2.GetAccount(0), 1000);
            Transaction tr2 = new TransferTransactionCredit(participants2);
            tr2.Do();
            
            tr2.Undo();
            Assert.AreEqual(50000, client1.GetAccount(0).sum);
            Assert.AreEqual(12000, client2.GetAccount(0).sum);
        }

        [Test]
        public void Test3()
        {
            Bank bank1 = new Bank(10000, 4, 500, 0);
            Client client1 = new Client("Petya", "Petrov", "Nevskiy pr.", 401223, 1);
            bank1.CreateAccount(client1, 100000, AccountType.DepositAccount);
            client1.GetAccount(0).CountPercentRemain(); //создал счет с деньгами

            //прошел 1 день
            
            Participants participants = new Participants(client1.GetAccount(0), 100000);
            Transaction tr = new RechargeTransactionDeposit(participants);
            tr.Do();
            client1.GetAccount(0).CountPercentRemain();

            //прошел 2-й день
            
            Participants participants2 = new Participants(client1.GetAccount(0), 150000);
            Transaction tr2 = new TakeMoneyTransactionDeposit(participants2);
            tr2.Do();
            client1.GetAccount(0).CountPercentRemain();

            //..прошел месяц - время выплаты процентов
            client1.GetAccount(0).AddPercentRemain();
            Assert.GreaterOrEqual(50034, client1.GetAccount(0).sum);
            Assert.LessOrEqual(50033, client1.GetAccount(0).sum);
        }

        [Test]
        public void Test4()
        {
            Bank bank1 = new Bank(10000, 4, 500, 5);
            Client client1 = new Client("Petya", "Petrov", 401223);
            bank1.CreateAccount(client1, 50000, AccountType.DebitAccount);

            
            Participants participants = new Participants(client1.GetAccount(0), 20000);
            Transaction tr = new TakeMoneyTransactionDebit(participants);
            tr.Do();
            Assert.AreEqual(30000, client1.GetAccount(0).sum);
        }

        [Test]
        public void Test5()
        {
            Bank bank1 = new Bank(10000, 4, 500, 5);
            Client client1 = new Client("Petya", "Petrov", "Nevsiy pr.", 401223, 1);
            bank1.CreateAccount(client1, 50000, AccountType.DebitAccount);

            Participants participants = new Participants(client1.GetAccount(0), 20000);
            Transaction tr = new TakeMoneyTransactionDebit(participants);
            tr.Do();

            Participants participants2 = new Participants(client1.GetAccount(0), 10000);
            Transaction tr2 = new TakeMoneyTransactionDebit(participants2);
            tr2.Do();

            tr.Do();

            Participants participants3 = new Participants(client1.GetAccount(0), 5000);
            Transaction tr3 = new RechargeTransactionDebit(participants3);
            tr3.Do();

            tr3.Undo();
            //tr3.Undo(); //будет ошибка, тк нельзя отметить действие, которого не было
            
            Assert.AreEqual(0, client1.GetAccount(0).sum);
        }
    }
}
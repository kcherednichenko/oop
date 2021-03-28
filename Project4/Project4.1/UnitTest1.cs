using System;
using NUnit.Framework;

namespace Project4._1
{
    [TestFixture]
    public class Tests
    {
       
        [Test]
        public void Test2()
        {

            BackUpInfo b = new BackUpInfo(1, DateTime.Now, new SeparateSavings(), new CleaningByAmount(1));
            FullRestorePoint r = new FullRestorePoint(1, b);
            r.AddFile(new FileRestoreCopyInfo("qwerty", 123, DateTime.Now));
            r.AddFile(new FileRestoreCopyInfo("asdfgh", 500, DateTime.Now));

            b.AddRestorePoint(r);

            Assert.AreEqual(2, r.restoreFiles.Count);

            FullRestorePoint r2 = new FullRestorePoint(2, b);
            b.AddRestorePoint(r2);
            
            b.cleaningAlgo.Clean(b);

            Assert.AreEqual(1, b.listOfRestorePoints.Count);

        }

        [Test]
        public void Test3()
        {
            CleaningBySize cleaning = new CleaningBySize(0);
            BackUpInfo b2 = new BackUpInfo(11, DateTime.Now, new SeparateSavings(), cleaning);
            FullRestorePoint r2 = new FullRestorePoint(11, b2);
            r2.AddFile(new FileRestoreCopyInfo("lol1", 50, DateTime.Now));
            r2.AddFile(new FileRestoreCopyInfo("lol2", 50, DateTime.Now));

            cleaning.maxBackupSize = r2.size;
            b2.AddRestorePoint(r2);
            FullRestorePoint r3 = new FullRestorePoint(11, b2);

            cleaning.maxBackupSize = r3.size;
            b2.AddRestorePoint(r3);

            Assert.AreEqual(2, b2.listOfRestorePoints.Count);
            Assert.AreEqual(200, b2.BackupSize);

            cleaning.maxBackupSize = 150;
            b2.cleaningAlgo.Clean(b2);

            Assert.AreEqual(true, b2.isNotEmpty());
        }

        [Test]
        public void Test4()
        {
            BackUpInfo b3 = new BackUpInfo(111, DateTime.Now, new SeparateSavings(), new CleaningByDate());
            IncrementalRestorePoint r3 = new IncrementalRestorePoint(111, -1, b3);
            r3.AddFile(new FileRestoreCopyInfo("kek1", 128, DateTime.Now));
            r3.AddFile(new FileRestoreCopyInfo("kek2", 256, DateTime.Now));

            b3.AddRestorePoint(r3);

            IncrementalRestorePoint r4 = new IncrementalRestorePoint(222, 111, b3);
            r4.AddFile(new FileRestoreCopyInfo("kek3", 512, DateTime.Now));
            b3.AddRestorePoint(r4);

            Assert.AreEqual(1, r4.restoreFiles.Count);


            BackUpInfo b4 = new BackUpInfo(112, DateTime.Now, new SeparateSavings(), new CleaningByDate());
            IncrementalRestorePoint restP = new IncrementalRestorePoint(362, -1, b4);
            restP.AddFile(new FileRestoreCopyInfo("chebyrek1", 128, DateTime.Now));
            restP.AddFile(new FileRestoreCopyInfo("chebyrek2", 256, DateTime.Now));

            b4.AddRestorePoint(restP);

            IncrementalRestorePoint restP2 = new IncrementalRestorePoint(378, 112, b4);
            //FullRestorePoint restP2 = new FullRestorePoint(378, b4);
            restP2.AddFile(new FileRestoreCopyInfo("chebyrek3", 512, DateTime.Now));
            b4.AddRestorePoint(restP2);

            Assert.AreEqual(1, restP2.restoreFiles.Count);
        }

        [Test]
        public void Test5()
        {
            CleaningByHybrid clean = new CleaningByHybrid(true, 2, true, true, 100, true, false);
            BackUpInfo backup = new BackUpInfo(1111, DateTime.Now, new CommonSavings(), clean);
            FullRestorePoint r3 = new FullRestorePoint(1111, backup);
            r3.AddFile(new FileRestoreCopyInfo("shsjsj1", 128, DateTime.Now));
            r3.AddFile(new FileRestoreCopyInfo("shsjsj2", 256, DateTime.Now));
            r3.AddFile(new FileRestoreCopyInfo("shsjsj3", 64, DateTime.Now));

            backup.AddRestorePoint(r3);

            FullRestorePoint r33 = new FullRestorePoint(2222, backup);
            r33.AddFile(new FileRestoreCopyInfo("lalala", 99, DateTime.Now));
            backup.AddRestorePoint(r33);

            FullRestorePoint r44 = new FullRestorePoint(3333, backup);
            r44.AddFile(new FileRestoreCopyInfo("alalal", 128, DateTime.Now));
            backup.AddRestorePoint(r44);

            backup.cleaningAlgo.Clean(backup);
            Assert.AreEqual(0, backup.listOfRestorePoints.Count);

        }

        [Test]
        public void Test6()
        {
            CleaningByHybrid clean = new CleaningByHybrid(true, 4, false, true, 10000, true, true);
            BackUpInfo backup = new BackUpInfo(222, DateTime.Now, new CommonSavings(), clean);
            IncrementalRestorePoint r3 = new IncrementalRestorePoint(222, 0, backup);
            r3.AddFile(new FileRestoreCopyInfo("shsjsj1", 128, DateTime.Now));
            r3.AddFile(new FileRestoreCopyInfo("shsjsj2", 256, DateTime.Now));
            r3.AddFile(new FileRestoreCopyInfo("shsjsj3", 64, DateTime.Now));

            backup.AddRestorePoint(r3);

            FullRestorePoint r33 = new FullRestorePoint(852, backup);
            r33.AddFile(new FileRestoreCopyInfo("lalala", 99, DateTime.Now));
            backup.AddRestorePoint(r33);

            FullRestorePoint r44 = new FullRestorePoint(932, backup);
            r44.AddFile(new FileRestoreCopyInfo("alalal", 128, DateTime.Now));
            backup.AddRestorePoint(r44);

            backup.cleaningAlgo.Clean(backup);
            Assert.AreEqual(3, backup.listOfRestorePoints.Count);
        }
    }
}
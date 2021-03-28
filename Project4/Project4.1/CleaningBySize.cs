using System;
namespace Project4
{
    public class CleaningBySize : Cleaning
    {
        public int maxBackupSize;

        public CleaningBySize(int maxBackupSize) : base()
        {
            this.maxBackupSize = maxBackupSize;
        }

        public override void Clean(BackUpInfo backUp)
        {
            if (backUp.BackupSize > maxBackupSize)
            {
                int i = 0;
                while (backUp.BackupSize > maxBackupSize && i < backUp.listOfRestorePoints.Count)
                {
                    if (backUp.listOfRestorePoints[i] is IncrementalRestorePoint)
                    {
                        IncrementalRestorePoint tmp = (IncrementalRestorePoint)backUp.listOfRestorePoints[i];
                        if (tmp.id == tmp.deltaPointId)
                        {
                            throw new Exception("Error! You can't delete this restore point");
                        }
                    }
                    else
                    {
                        backUp.BackupSize -= backUp.listOfRestorePoints[i].size;
                        backUp.listOfRestorePoints.RemoveAt(i);
                    }
                    i += 1;
                }
            }
            backUp.saveAlgo.Save(backUp);

        }

        public override int AmountOfCleaning(BackUpInfo backUp)
        {
            int cnt = 0;
            if (backUp.BackupSize > maxBackupSize)
            {
                int i = 0;
                int currentBackupSize = backUp.BackupSize;
                while (currentBackupSize > maxBackupSize && i < backUp.listOfRestorePoints.Count)
                {
                    currentBackupSize -= backUp.listOfRestorePoints[i].size;
                    cnt += 1;
                }
                return cnt;
            }
            else return cnt;
        }

        public override bool isGoOutOfLimit(BackUpInfo backUp, int i)
        {
            if (backUp.BackupSize > maxBackupSize) return true;
            else return false;
        }
    }
}

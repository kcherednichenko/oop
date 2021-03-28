using System;
using System.Collections.Generic;

namespace Project4
{
    public class CleaningByHybrid : Cleaning
    {
        public bool isCleaningByAmount;
        public bool isCleaningByDate;
        public bool isCleaningBySize;
        public bool isCleaningByMax;
        public bool flag;
        public int maxRestorePointsCount;
        public int maxBackupSize;
        public List<int> indexesToRemove;

        public CleaningByHybrid(bool isCleaningByAmount, int maxRestorePointsCount, bool isCleaningByDate, bool isCleaningBySize, int maxBackupSize, bool isCleaningByMax, bool flag) : base()
        {
            this.isCleaningByAmount = isCleaningByAmount;
            this.isCleaningByDate = isCleaningByDate;
            this.isCleaningBySize = isCleaningBySize;
            this.isCleaningByMax = isCleaningByMax;
            this.flag = flag;
            this.maxRestorePointsCount = maxRestorePointsCount;
            this.maxBackupSize = maxBackupSize;
        }

        public void RemoveByIndex(BackUpInfo backUp)
        {
            for (int i = indexesToRemove.Count - 1; i >= 0; i--)
            {
                backUp.BackupSize -= backUp.listOfRestorePoints[i].size;
                backUp.listOfRestorePoints.RemoveAt(indexesToRemove[i]);
            }
        }

        public override void Clean(BackUpInfo backUp)
        {
            CleaningByAmount cleaningByAmount = new CleaningByAmount(maxRestorePointsCount);
            CleaningByDate cleaningByDate = new CleaningByDate();
            CleaningBySize cleaningBySize = new CleaningBySize(maxBackupSize);

            indexesToRemove = new List<int>();
            for (int i = 0; i < backUp.listOfRestorePoints.Count; i++)
            {
                int currentCnt = CountOfLimits(backUp, i, cleaningByAmount, cleaningByDate, cleaningBySize);
                if (currentCnt > 0)
                {
                    if (flag || (!flag && currentCnt == 3))
                    {
                        if (backUp.listOfRestorePoints[i] is IncrementalRestorePoint)
                        {
                            IncrementalRestorePoint tmp = (IncrementalRestorePoint)backUp.listOfRestorePoints[i];
                            if (tmp.id == tmp.deltaPointId)
                            {
                                throw new Exception("Error! You can't delete this restore point");
                            }
                            else indexesToRemove.Add(i);
                        }
                        else
                        {
                            indexesToRemove.Add(i);

                        }
                    }
                }
                
            }
            RemoveByIndex(backUp);
            backUp.saveAlgo.Save(backUp);
        }

        public override int AmountOfCleaning(BackUpInfo backUp)
        {
            throw new Exception("Error! Invalid operation");
        }

        public override bool isGoOutOfLimit(BackUpInfo backUp, int i)
        {
            throw new NotImplementedException();
        }

        public int CountOfLimits(BackUpInfo backUp, int index, CleaningByAmount cleaningByAmount, CleaningByDate cleaningByDate, CleaningBySize cleaningBySize)
        {
            int cnt = 0;
            if (isCleaningByAmount && cleaningByAmount.isGoOutOfLimit(backUp, index)) cnt++;
            if (isCleaningByDate && cleaningByDate.isGoOutOfLimit(backUp, index)) cnt++;
            if (isCleaningBySize && cleaningBySize.isGoOutOfLimit(backUp, index)) cnt++;
            return cnt;
        }
    }
}

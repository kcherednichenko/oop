using System;
namespace Project4
{
    public class CleaningByAmount : Cleaning
    {
        public int maxRestorePointsCount;

        public CleaningByAmount(int a) : base()
        {
            maxRestorePointsCount = a;
        }

        public override void Clean(BackUpInfo backUp)
        {
            if (backUp.listOfRestorePoints.Count > maxRestorePointsCount)
            {
                for (int i = 0; i < backUp.listOfRestorePoints.Count -  maxRestorePointsCount; i++)
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
                }
            }
            backUp.saveAlgo.Save(backUp);
        }

        public override int AmountOfCleaning(BackUpInfo backUp)
        {
            return backUp.listOfRestorePoints.Count - maxRestorePointsCount;
        }

        public override bool isGoOutOfLimit(BackUpInfo backUp, int i)
        {
            if (backUp.listOfRestorePoints.Count > maxRestorePointsCount) return true;
            else return false;
        }
    }
}

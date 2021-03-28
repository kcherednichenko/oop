using System;
using System.IO;
namespace Project4
{
    public class CleaningByDate : Cleaning
    {
        public override void Clean(BackUpInfo backUp)
        {
            for (int i = 0; i < backUp.listOfRestorePoints.Count; i++)
            {
                if (backUp.listOfRestorePoints[i].creationTime > maxData)
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
            int cnt = 0;
            for (int i = 0; i < backUp.listOfRestorePoints.Count; i++)
            {
                if (backUp.listOfRestorePoints[i].creationTime > maxData)
                {
                    cnt += 1;
                }
            }
            return cnt;
        }

        public override bool isGoOutOfLimit(BackUpInfo backUp, int i)
        {
            
                if (backUp.listOfRestorePoints[i].creationTime > maxData)
                {
                    return true;
                }
            
            return false;
        }
    }
}

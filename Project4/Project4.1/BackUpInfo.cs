using System;
using System.Collections.Generic;

namespace Project4
{
    public class BackUpInfo
    {
        public int Id { get; set; }
        DateTime CreationTime { get; set; }
        public int BackupSize { get; set; }
        public SaveAlgorithm saveAlgo;
        public Cleaning cleaningAlgo;
        public List<RestorePoint> listOfRestorePoints;

        public BackUpInfo(int id, DateTime creationTime, SaveAlgorithm saveAlgo, Cleaning cleaningAlgo)
        {
            Id = id;
            CreationTime = creationTime;
            BackupSize = 0;
            listOfRestorePoints = new List<RestorePoint>();
            this.saveAlgo = saveAlgo;
            this.cleaningAlgo = cleaningAlgo;
        }

        public void AddRestorePoint(RestorePoint restorePoint)
        {
            listOfRestorePoints.Add(restorePoint);
            cleaningAlgo.Clean(this);
            BackupSize += restorePoint.size;
        }

        public void Save()
        {
            saveAlgo.Save(this);
        }

        public bool isNotEmpty()
        {
            if (listOfRestorePoints.Count != 0) return true;
            else return false;
        }
    }
}

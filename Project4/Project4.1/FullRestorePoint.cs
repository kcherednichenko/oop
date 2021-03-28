using System;
using System.Collections.Generic;

namespace Project4
{
    public class FullRestorePoint : RestorePoint
    {
        public FullRestorePoint(int id, BackUpInfo backUpInfo) : base(id, backUpInfo)
        {
            creationTime = DateTime.Now;
            this.id = id;
            restoreFiles = new List<FileRestoreCopyInfo>();
            size = 0;
            if (backUpInfo.listOfRestorePoints.Count != 0)
            {
                int i = 0;
                foreach (var oldRestorePOints in backUpInfo.listOfRestorePoints)
                {
                    if (i == backUpInfo.listOfRestorePoints.Count - 1)
                    {
                        foreach (var restoreFile in oldRestorePOints.restoreFiles)
                        {
                            restoreFiles.Add(restoreFile);
                            size += restoreFile.FileSize;
                        }
                    }
                    i++;
                }
            }
        }

        public override void AddFile(FileRestoreCopyInfo file)
        {
            restoreFiles.Add(file);
            size += file.FileSize;
        }
    }
}

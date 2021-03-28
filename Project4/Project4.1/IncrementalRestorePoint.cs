using System;
using System.Collections.Generic;

namespace Project4
{
    public class IncrementalRestorePoint : RestorePoint
    {
        
        int prevPointId;
        public int deltaPointId; 
        public IncrementalRestorePoint(int id, int prevPointId, BackUpInfo backUpInfo) : base(id, backUpInfo)
        {
            this.prevPointId = prevPointId;

            creationTime = DateTime.Now;
            this.id = id;
            restoreFiles = new List<FileRestoreCopyInfo>();
            size = 0;
        }

        public override void AddFile(FileRestoreCopyInfo file)
        {
            restoreFiles.Add(file);
            size += file.FileSize;
        }
    }
}

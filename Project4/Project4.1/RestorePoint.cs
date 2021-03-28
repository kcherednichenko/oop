using System;
using System.Collections.Generic;

namespace Project4
{
    public abstract class RestorePoint
    {
        public List<FileRestoreCopyInfo> restoreFiles;
        public DateTime creationTime;
        public int size;
        public int id;

        public abstract void AddFile(FileRestoreCopyInfo file);

        public RestorePoint(int id, BackUpInfo backUpInfo) { }
    }
}

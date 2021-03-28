using System;
using System.IO;

namespace Project4
{
    public class FileRestoreCopyInfo
    {
        public string FilePath { get; set; }
        public int FileSize { get; set; }
        public DateTime CreationTime { get; set; }
        public FileRestoreCopyInfo(string FilePath, int FileSize, DateTime CreationTime)
        {
            this.FilePath = FilePath;
            this.FileSize = FileSize;
            this.CreationTime = CreationTime;
        }
    }
}

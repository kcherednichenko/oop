using System;
using System.IO;

namespace Project4
{
    public class CommonSavings :  SaveAlgorithm
    {
        public override void Save(BackUpInfo backUp)
        {
            string filePath = @"/Users/ekaterinacerednicenko/VisualStudioProjects/Project4.1/Project4.1/Data";
            using (StreamWriter sv = new StreamWriter(filePath + "/" + backUp.Id.ToString() + ".txt", false))
            {
                foreach (var restorePoint in backUp.listOfRestorePoints)
                {
                    sv.WriteLine("Restore point ID: " + restorePoint.id);
                    foreach (var restoreFile in restorePoint.restoreFiles)
                    {
                        sv.WriteLine(restoreFile.FilePath + " added to restore point. Creation time: " + restoreFile.CreationTime + ". Backup size is " + restoreFile.FileSize.ToString());
                    }
                    sv.WriteLine();
                }
            }
        }
    }
}

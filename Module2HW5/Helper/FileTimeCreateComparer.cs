using System.Collections.Generic;
using System.IO;

namespace Module2HW5.Helper
{
    public class FileTimeCreateComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo file1, FileInfo file2)
        {
            if (file1.CreationTime < file2.CreationTime)
            {
                return 1;
            }
            else if (file1.CreationTime > file2.CreationTime)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}

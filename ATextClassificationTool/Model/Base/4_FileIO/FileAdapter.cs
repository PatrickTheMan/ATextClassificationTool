using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.FileIO
{
    public abstract class FileAdapter
    {
        private string _fileType;
        public FileAdapter(string fileType)
        {
            _fileType = fileType;
        }
        public abstract List<string> GetAllFileNames(string filePath);
        public abstract string GetAllTextFromFileA(string filePath);

        public abstract string GetAllTextFromFileB(string filePath);

        public string GetFileType()
        {
            return _fileType;
        }
    }
}

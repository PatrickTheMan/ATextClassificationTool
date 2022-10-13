using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATextClassificationTool.Foundation;

namespace ATextClassificationTool.FileIO
{
    public class TextFile:FileAdapter
    {
        const string PROJECTPATH = "C:\\Users\\Patrick\\Source\\Repos\\PatrickTheMan\\ATextClassificationTool\\ATextClassificationTool\\bin\\Debug\\";

        const string FOLDERA = "ClassA";
        const string FOLDERB = "ClassB";

        string FILETYPE;

        public TextFile(string fileType):base(fileType)
        {
            this.FILETYPE = fileType;
        }
        public override List<string> GetAllFileNames(string folderName)
        {
            List<string> filePaths = new List<string>();
            string[] paths = Directory.GetFiles(PROJECTPATH + folderName, "*."+GetFileType());
           
            foreach (string path in paths)
            {
                filePaths.Add(path);
            }
            return filePaths;
        }

        public string GetFilePathA(string fileName)
        {
            return @PROJECTPATH + FOLDERA + "\\" + fileName + "."+base.GetFileType();
        }

        public override string GetAllTextFromFileA(string path)
        {
            string text = File.ReadAllText(path);

            return text;
        }

        public override string GetAllTextFromFileB(string path)
        {
            string text = File.ReadAllText(path);

            return text;
        }

        public void CreateTextFileInClassA(string fileName, string content)
        {
            foreach (var item in GetAllFileNames(FOLDERA))
            {
                if (StringOperations.getFileName(item).Equals(fileName))
                {
                    throw new Exception("File already exists in folder");
                }
            }

            File.WriteAllText(PROJECTPATH + FOLDERA + "\\" + fileName + "." + FILETYPE, content);

        }

        public void CreateTextFileInClassB(string fileName, string content)
        {
            foreach (var item in GetAllFileNames(FOLDERB))
            {
                if (StringOperations.getFileName(item).Equals(fileName))
                {
                    throw new Exception("File already exists in folder");
                }
            }

            File.WriteAllText(PROJECTPATH + FOLDERB + "\\" + fileName + "." + FILETYPE, content);

        }

        public void DeleteTextFileFromClassA(string fileName)
        {
            File.Delete(PROJECTPATH + FOLDERA + "\\" + fileName + "." + FILETYPE);
        }

        public void DeleteTextFileFromClassB(string fileName)
        {
            File.Delete(PROJECTPATH + FOLDERB + "\\" + fileName + "." + FILETYPE);
        }

    }
}

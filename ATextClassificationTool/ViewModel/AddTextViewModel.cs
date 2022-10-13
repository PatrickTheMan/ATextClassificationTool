using ATextClassificationTool.FileIO;
using ATextClassificationTool.Foundation;
using ATextClassificationTool.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.ViewModel
{
	public class AddTextViewModel
	{

		public AddTextViewModel()
		{

		}

		public void AddToFolderA(string fileName, string content)
		{
			new TextFile("txt").CreateTextFileInClassA(fileName,content);
            KnowledgeBuilderSingleton.Instance.BuildFileLists();
        }

        public void AddToFolderB(string fileName, string content)
        {
            new TextFile("txt").CreateTextFileInClassB(fileName, content);
            KnowledgeBuilderSingleton.Instance.BuildFileLists();
        }

		public void DeleteFromFolderA(string fileName)
		{
			new TextFile("txt").DeleteTextFileFromClassA(fileName);
            KnowledgeBuilderSingleton.Instance.BuildFileLists();
        }

        public void DeleteFromFolderB(string fileName)
        {
            new TextFile("txt").DeleteTextFileFromClassB(fileName);
            KnowledgeBuilderSingleton.Instance.BuildFileLists();
        }

        public void AddKNN(string fileName)
        {
            foreach (var item in KnowledgeBuilderSingleton.Instance.GetKnowledge().GetFileLists().GetA())
            {
                if (StringOperations.getFileName(item).Equals(fileName))
                {
                    KnowledgeBuilderSingleton.Instance.GetKnowledge().GetKNN().InsertEntryA(item);
                    KnowledgeBuilderSingleton.Instance.GetKnowledge().GetKNN().InsertEntryB(item);
                }
            }
        }

    }
}

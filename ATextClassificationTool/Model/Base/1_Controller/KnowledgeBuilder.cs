using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using ATextClassificationTool.Business;
using ATextClassificationTool.Domain;
using ATextClassificationTool.FileIO;
using ATextClassificationTool.Foundation;

namespace ATextClassificationTool.Controller
{
    public class KnowledgeBuilder:AbstractKnowledgeBuilder
    {
        private Knowledge _knowledge; // the composite object

        private FileLists _fileLists;
        private BagOfWords _bagOfWords;
        private Vectors _vectors;

        private KNN _knn;

        private FileAdapter _fileAdapter;

        public KnowledgeBuilder()
        {
            _fileAdapter = new TextFile("txt");
            _knowledge = new Knowledge();
        }

        public override void BuildFileLists()
        {
            
            FileListBuilder flb = new FileListBuilder();

            flb.GenerateFileNamesInA();

            flb.GenerateFileNamesInB();

            _fileLists = flb.GetFileLists();
            _knowledge.SetFileLists(_fileLists);
        }

        public override void Train()
        {
            // (1) 
            BuildFileLists();
            // (2)
            BuildBagOfWords();
            // (3)
            BuildVectors();
            // (4)
            BuildKNN();
        }

        private void AddToBagOfWords(string folderName)
        {
            List<string> list;
            if (folderName.Equals("ClassA")){
                list = _fileLists.GetA();
            }
            else{
                list = _fileLists.GetB();
            }
            for (int i = 0; i < list.Count; i++)
            {
                string text;
                if (folderName.Equals("ClassA")){
                    text = _fileAdapter.GetAllTextFromFileA(list[i]);
					List<string> wordsInFile = Tokenization.Tokenize(text);
					foreach (string word in wordsInFile)
					{
						_bagOfWords.InsertEntryA(word);
					}
				}
                else{
                    text = _fileAdapter.GetAllTextFromFileB(list[i]);
					List<string> wordsInFile = Tokenization.Tokenize(text);
					foreach (string word in wordsInFile)
					{
						_bagOfWords.InsertEntryB(word);
					}
				}  
            }
        }
       
        public override void BuildBagOfWords()
        {
            if (_fileLists == null)
            {
                BuildFileLists();
            }
            _bagOfWords = new BagOfWords();

            AddToBagOfWords("ClassA");
            AddToBagOfWords("ClassB");

            _knowledge.SetBagOfWords(_bagOfWords);
        }

		public List<bool> GetVectorsFromFile(string fileName, string folderName)
		{
			List<bool> vector = new List<bool>();
			string text = "";

            foreach (var item in _fileLists.GetA())
            {
                if (item.Equals(fileName))
                {
					text = _fileAdapter.GetAllTextFromFileA(fileName);
				}
            }
            foreach (var item in _fileLists.GetB())
            {
                if (item.Equals(fileName))
                {
					text = _fileAdapter.GetAllTextFromFileB(fileName);
				}
            }

            if (folderName.Equals("ClassA"))
            {
				foreach (string key in _bagOfWords.GetAWordsInDictionary())
				{
					List<string> wordsInFile = Tokenization.Tokenize(text);
					if (wordsInFile.Contains(key))
					{
						vector.Add(true);
					}
					else
					{
						vector.Add(false);
					}
                }
            } else
            {
				foreach (string key in _bagOfWords.GetBWordsInDictionary())
				{
					List<string> wordsInFile = Tokenization.Tokenize(text);
					if (wordsInFile.Contains(key))
					{
						vector.Add(true);
					}
					else
					{
						vector.Add(false);
					}
				}
			}

            return vector;
		}

		private void AddToVectors(string folderName, VectorsBuilder vb)
        {
            List<string> list;

            if (folderName.Equals("ClassA")){
                list = _fileLists.GetA();
            }
            else{
                list = _fileLists.GetB();
            }
			for (int i = 0; i < list.Count; i++)
            {
                List<bool> vector = new List<bool>();
                foreach (string key in _bagOfWords.GetAllWordsInDictionary())
                {
                    string text;
                    if (folderName.Equals("ClassA")){
                        text = _fileAdapter.GetAllTextFromFileA(_fileLists.GetA()[i]);
                    }
                    else{
                        text = _fileAdapter.GetAllTextFromFileB(_fileLists.GetB()[i]);
                    }
                    List<string> wordsInFile = Tokenization.Tokenize(text);
                    if (wordsInFile.Contains(key)){
                        vector.Add(true);
                    }
                    else{
                        vector.Add(false);
                    }
                }
                if (folderName.Equals("ClassA"))
                {
                    vb.AddVectorToA(vector);
                }
                else
                {
                    vb.AddVectorToB(vector);
                }
            }
        }

        public override void BuildVectors()
        {
            if (_fileLists == null)
            {
                BuildFileLists();
            }
            if (_bagOfWords == null)
            {
                BuildBagOfWords();
            }
            _vectors = new Vectors();
            VectorsBuilder vb = new VectorsBuilder();
            AddToVectors("ClassA",vb);
            AddToVectors("ClassB",vb);

            _vectors = vb.GetVectors();
            _knowledge.SetVectors(_vectors);
        }

        private void AddToKNN(string folderName)
        {
			List<string> list;
			if (folderName.Equals("ClassA"))
			{
				list = _fileLists.GetA();
			}
			else
			{
				list = _fileLists.GetB();
			}
			for (int i = 0; i < list.Count; i++)
			{
				_knn.InsertEntryA(list[i]);
				_knn.InsertEntryB(list[i]);
			}

		}

		public override void BuildKNN()
		{
            if (_vectors == null)
            {
                BuildVectors();
            }

            _knn = new KNN();

			AddToKNN("ClassA");
			AddToKNN("ClassB");

            _knowledge.SetKNN(_knn);
		}

        public ObservableCollection<string> GetDictionaryFromFile(string chosenFileName)
        {
            ObservableCollection<string> ShowListTokens = new ObservableCollection<string>();
			foreach (var filePath in GetKnowledge().GetFileLists().GetBoth())
			{
				if (StringOperations.getFileName(filePath).Equals(chosenFileName))
				{
					foreach (var token in Tokenization.Tokenize(_fileAdapter.GetAllTextFromFileA(filePath)))
					{
						if (!ShowListTokens.Contains(token) && !token.Equals(""))
						{
							ShowListTokens.Add(token);
						}
					}
				}
			}
            return ShowListTokens;
		}

		public override Knowledge GetKnowledge()
        {
            return _knowledge;
        }

    }
}

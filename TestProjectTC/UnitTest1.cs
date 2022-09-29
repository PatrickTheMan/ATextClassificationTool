using ATextClassificationTool.Business;
using ATextClassificationTool.Domain;
using ATextClassificationTool.FileIO;
using ATextClassificationTool.Foundation;
using Microsoft.VisualBasic.FileIO;
using System.Reflection;

namespace TestProjectTC
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestWordItemGetWord()
        {
            // arrange
            string expected = "nice";
            WordItem wI = new WordItem("nice", 0);

            // act
            string actual = wI.GetWord();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStringOperationsGetFileName()
        {
            // deprecated - use 
            // arrange
            string expected = "Suduko";
            string path = "c:\\users\\tha\\documents\\Suduko.txt";

            // act
            string actual = StringOperations.getFileName(path);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFileGetAllFileNames()
        {
            // arrange
			string folderA = "ClassA";
            string fileType = "txt";

            List<string> expected = new List<string>();
            expected.Add("C:\\Users\\patri\\source\\repos\\PatrickTheMan\\ATextClassificationTool\\ATextClassificationTool\\bin\\Debug\\" + folderA + "\\bbcsportsfootball." + fileType);
            expected.Add("C:\\Users\\patri\\source\\repos\\PatrickTheMan\\ATextClassificationTool\\ATextClassificationTool\\bin\\Debug\\" + folderA + "\\dailymirrornfl." + fileType);
            expected.Add("C:\\Users\\patri\\source\\repos\\PatrickTheMan\\ATextClassificationTool\\ATextClassificationTool\\bin\\Debug\\" + folderA + "\\sunsportsboxing." + fileType);

            // act
            FileAdapter fa = new TextFile(fileType);
            List<string> actual = fa.GetAllFileNames(folderA);

            // assert
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
        }
        [TestMethod]
        public void TestGetFilePathA()
        {
            // arrange
            string folderA = "ClassA";
            string fileType = "txt";
            string fileName = "filnavn";
            string expected = "C:\\Users\\patri\\source\\repos\\PatrickTheMan\\ATextClassificationTool\\ATextClassificationTool\\bin\\Debug\\" + folderA + "\\filnavn." + fileType;

            // act
            TextFile tf = new TextFile(fileType);
            string actual = tf.GetFilePathA(fileName);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestGetFileName()
        {
            // I have here followed the earlyer tests setup
            // First the different file and folder parts is declared and initiated
            // Then I have used the StringOperations class with the getFileName to get the actual value
            // Lastly the expected and actual values are compared

			// arrange
			string folderA = "ClassA";
			string fileType = ".txt";
			string filePath = "C:\\Users\\patri\\source\\repos\\PatrickTheMan\\ATextClassificationTool\\ATextClassificationTool\\bin\\Debug\\" + folderA + "\\nameoffile" + fileType;
			string expected = "nameoffile";

            // act
			string actual = StringOperations.getFileName(filePath);

			// assert
			Assert.AreEqual(expected, actual);
		}
        [TestMethod]
        public void TestRemovePunctuation()
        {
			// arrange
			string token = "Token-/.,...\"!:;'@(){}[]*\\_";
			string expected = "token";

			// act
			string actual = Tokenization.RemovePunctuation(token);

			// assert
			Assert.AreEqual(expected, actual);
		}

    }
}
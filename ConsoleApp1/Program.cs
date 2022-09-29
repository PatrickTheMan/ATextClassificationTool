
using System.Reflection;

//C:\Users\patri\Source\Repos\PatrickTheMan\ATextClassificationTool\ATextClassificationTool\4_FileIO\Files\ClassA\bbcsportsfootball.txt

var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


Console.WriteLine(outPutDirectory);

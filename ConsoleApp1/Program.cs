
using System.Reflection;

var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
var iconPath = Path.Combine(outPutDirectory, "Folder\\Img.jpg");
string icon_path = new Uri(iconPath).LocalPath;

Console.WriteLine(icon_path);

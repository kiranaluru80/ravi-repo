using System;
using System.IO;
using Xamarin.Forms;
using ReadDataFromJson.iOS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace ReadDataFromJson.iOS
{
    public class SQLite_iOS:ISQLite
    {
		public string GetFilePath(String fileName)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Database");
			Console.WriteLine(libFolder);
			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}
			return Path.Combine(libFolder, fileName);
		}
    }
}

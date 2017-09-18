using System;
using SQLite;
namespace ReadDataFromJson
{
    public class MajorgroupModelTable
    {
		[PrimaryKey]
		public string MajorGroup_Id
		{
			get;
			set;
		}
		public string MajorGroup_Name
		{
			get;
			set;
		}
    }
}

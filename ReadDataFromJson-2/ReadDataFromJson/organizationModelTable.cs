using System;
using SQLite;
namespace ReadDataFromJson
{
    public class organizationModelTable
    {
		[PrimaryKey]
		public string Org_Id
		{
			get;
			set;
		}
		public string Org_Name
		{
			get;
			set;
		}
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

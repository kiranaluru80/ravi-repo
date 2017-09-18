using System;
using SQLite;
namespace ReadDataFromJson
{
    public class RequestTable
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
		public string User_Id
		{
			get;
			set;
		}
		public string Email_Body
		{
			get;
			set;
		}

	}
}

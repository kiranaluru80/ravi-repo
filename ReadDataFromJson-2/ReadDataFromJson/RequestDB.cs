using System;
using System.Threading.Tasks;
using SQLite;
namespace ReadDataFromJson
{
    public class RequestDB
    {
		readonly SQLiteAsyncConnection database;
		public RequestDB(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<MajorgroupModelTable>().Wait();
            database.CreateTableAsync<organizationModelTable>().Wait();

		}
        public Task<System.Collections.Generic.List<MajorgroupModelTable>> GetMajorGroupAsync()
		{
            return database.Table<MajorgroupModelTable>().ToListAsync();
		}

		public async Task<MajorgroupModelTable> GetMajorGroupAsync(string id)
		{
            var result = await database.Table<MajorgroupModelTable>().Where(i => i.MajorGroup_Id == id).FirstOrDefaultAsync();

			return result;
		}
        public Task<int> SaveJSSEAsync(MajorgroupModelTable mgrobj)
		{
           
				return database.InsertAsync(mgrobj);
		}

		public Task<int> DeleteJSSEAsync(MajorgroupModelTable mgr)
		{
			return database.DeleteAsync(mgr);
		}
        public Task<System.Collections.Generic.List<organizationModelTable>> GetOrganizationAsync()
		{
			return database.Table<organizationModelTable>().ToListAsync();
		}

		public async Task<organizationModelTable> GetOrganizationAsync(string id)
		{
            var result = await database.Table<organizationModelTable>().Where(i => i.Org_Id == id).FirstOrDefaultAsync();

			return result;
		}
		public Task<int> SaveOrginazationJSSEAsync(organizationModelTable orgobj)
		{
   //         organizationModelTable obj = database.Table<organizationModelTable>().Where(i => i.Org_Id == orgobj.Org_Id).FirstOrDefaultAsync().Result;

			//if (obj != null)
			//{
			//	return database.UpdateAsync(orgobj);
			//}
			//else
			//{
				return database.InsertAsync(orgobj);
			//}
		}

		public Task<int> DeleteJSSEAsync(organizationModelTable org)
		{
            return database.DeleteAsync(org);
		}
    }
}

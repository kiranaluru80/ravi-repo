using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace ReadDataFromJson
{
	public class ReadDataViewModel : ViewModelBase
	{
		public class MajorGroupClass
		{
			public string MajorGroup_Id { get; set; }
			public string MajorGroup_Name { get; set; }
		}

      //  public List<MajorGroupClass> MajorgroupsObj;
        //public List<string> Majorgroups => maroupsObj;

		public ReadDataViewModel()
		{
           // MajorgroupsObj = new List<MajorGroupClass>();
            List<string> datasss = new List<string>();
			var assembly = typeof(ReadDataViewModel).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("ReadDataFromJson.getbannerdata.json");

			using (var reader = new System.IO.StreamReader(stream))
			{
				var json = reader.ReadToEnd();
				List<RootObjectSecond> data = JsonConvert.DeserializeObject<List<RootObjectSecond>>(json);

				for (int i = 0; i < data.Count; i++)
				{
					RootObjectSecond dataObject = data[i];
					Debug.WriteLine("First Major ID :" +i + "= " +dataObject.MajorGroup_Id);
					Debug.WriteLine("First Major Name :" +i + "= " +dataObject.MajorGroup_Name);



                    MajorGroupClass obj = new MajorGroupClass();
                    obj.MajorGroup_Id = dataObject.MajorGroup_Id;
                    obj.MajorGroup_Name = dataObject.MajorGroup_Name;
                    MajorgroupModelTable objjjj = new MajorgroupModelTable();
                    objjjj.MajorGroup_Id = dataObject.MajorGroup_Id;
                    objjjj.MajorGroup_Name = dataObject.MajorGroup_Name;

                    App.Database.SaveJSSEAsync(objjjj);
                    //MajorgroupsObj.Add(obj);
                    //datasss.Add(dataObject.MajorGroup_Name);

					List<Organization> organizationData = dataObject.Organizations;
					for (int j = 0; j < organizationData.Count; j++)
					{
						Organization orgData = organizationData[j];
						Debug.WriteLine("Organization ID :" +j + "= " +orgData.Org_Id);
						Debug.WriteLine("Organization Name :" +j + "= " +orgData.Org_Name);

                        organizationModelTable orjjjj = new organizationModelTable();
                        orjjjj.Org_Id = orgData.Org_Id;
                        orjjjj.Org_Name = orgData.Org_Name;
                        orjjjj.MajorGroup_Id = dataObject.MajorGroup_Id;
                        orjjjj.MajorGroup_Name = dataObject.MajorGroup_Name;



                        App.Database.SaveOrginazationJSSEAsync(orjjjj);

						List<Department> departMentData = orgData.Departments;
						for (int k = 0; k < departMentData.Count; k++)
						{
							Department deptData = departMentData[k];
							Debug.WriteLine("Dept ID :" + k + "= " + deptData.Dept_Id);
							Debug.WriteLine("Dept Name :" + k + "= " + deptData.Dept_Name);

							List<Section> sectionData = deptData.Sections;
							for (int l = 0; l < sectionData.Count; l++)
							{
								Section sectionsData = sectionData[l];
								Debug.WriteLine("Section ID :" +l+ "= " + sectionsData.Section_Id);
								Debug.WriteLine("Section Name :" +l + "= " + sectionsData.Section_Name);
							}

						}



					}


				}
                Debug.WriteLine(datasss.Count);
                //maroupsObj = datasss;

			}
		}
	}
}

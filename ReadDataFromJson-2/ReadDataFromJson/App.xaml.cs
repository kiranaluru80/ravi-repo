using Xamarin.Forms;

namespace ReadDataFromJson
{
	public partial class App : Application
	{
        static RequestDB database;

		public App()
		{
			InitializeComponent();

            //MainPage = new ReadDataFromJsonPage();
            MainPage = new NavigationPage(new ReadDataFromJsonPage());


		}
        public static RequestDB Database
		{
			get
			{
				if (database == null)
				{
					database = new RequestDB(DependencyService.Get<ISQLite>().GetFilePath("jsse.db3"));
				}
				return database;
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

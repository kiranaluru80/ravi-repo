using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ReadDataFromJson.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());
			Reachability.ReachabilityChanged += c_ReachabilityChanged;


			return base.FinishedLaunching(app, options);
		}
		public string updateStatus()
		{
			string updateStatusValue = "";

			NetworkStatus remoteHostStatus = Reachability.InternetConnectionStatus();

			switch (remoteHostStatus)
			{
				case NetworkStatus.NotReachable:
					//Debug.WriteLine ("Not Reachable Appdelegate");
					updateStatusValue = "Not Rechable";
					break;
				case NetworkStatus.ReachableViaCarrierDataNetwork:
					//Debug.WriteLine ("Reachable Appdelegate");
					updateStatusValue = "Available";

					break;
				case NetworkStatus.ReachableViaWiFiNetwork:
					//Debug.WriteLine ("Reachable Appdelegate");
					updateStatusValue = "Available";

					break;
			}
			return updateStatusValue;
		}

		static void c_ReachabilityChanged(object sender, EventArgs e)
		{
			string updateStatusValue = "";

			NetworkStatus remoteHostStatus = Reachability.InternetConnectionStatus();

			switch (remoteHostStatus)
			{
				case NetworkStatus.NotReachable:
					//Debug.WriteLine ("Not Reachable Appdelegate");
					updateStatusValue = "Not Rechable";
					UIAlertView alert = new UIAlertView()
					{
						Title = "alert title",
						Message = "Network Not Rechable"
					};
					alert.AddButton("OK");
					alert.Show();

					break;
				case NetworkStatus.ReachableViaCarrierDataNetwork:
					//Debug.WriteLine ("Reachable Appdelegate");
					updateStatusValue = "Available";
					UIAlertView alert1 = new UIAlertView()
					{
						Title = "alert title",
						Message = "Network Rechable"
					};
					alert1.AddButton("OK");
					alert1.Show();

					break;
				case NetworkStatus.ReachableViaWiFiNetwork:
					//Debug.WriteLine ("Reachable Appdelegate");
					updateStatusValue = "Available";
					UIAlertView alert2 = new UIAlertView()
					{
						Title = "alert title",
						Message = "Network Rechable"
					};
					alert2.AddButton("OK");
					alert2.Show();

					break;
			}

			/*if (updateStatusValue.Equals(ConstantsFile.NETWORK_NOT_REACHABLE))
            {

                //UIAlertView alert = new UIAlertView(ConstantsFile.NETWORK_ERROR, ConstantsFile.NETWORK_ERROR_MSG, null, ConstantsFile.Alert_Ok_Constant, null);
                //alert.Clicked += (senderV, eventArgs) =>
                //{
                //  new Helper().Exit();

                //};
                //alert.Show();

                var page = App.GetPage();
                if (page.GetType() == typeof(PanelLoginpage))
                {
                    var panelPage = (PanelLoginpage)page;
                    panelPage.showNetworkErrorMessage();
                }
                else if (page.GetType() == typeof(LoginPage))
                {
                    var loginPage = (LoginPage)page;
                    loginPage.showNetworkErrorMessage();
                }
                else if (page.GetType() == typeof(Homepage))
                {
                    var loginPage = (Homepage)page;
                    loginPage.showNetworkErrorMessage();
                }

            }*/
		}
	}
}

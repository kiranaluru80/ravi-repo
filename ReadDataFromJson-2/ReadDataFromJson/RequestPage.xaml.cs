using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ReadDataFromJson
{
    public partial class RequestPage : ContentPage
    {
        public RequestPage()
        {
            InitializeComponent();
            this.BindingContext= new RequestPageViewModel();
        }
    }
}

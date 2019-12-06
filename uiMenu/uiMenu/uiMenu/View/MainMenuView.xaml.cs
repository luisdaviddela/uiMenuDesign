using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace uiMenu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuView : ContentPage
	{
        List<DTO_MenuCard> info = new List<DTO_MenuCard>();
        private static readonly HttpClient client = new HttpClient();
        public MainMenuView ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            var responseString = await client.GetStringAsync("");
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            info = JsonConvert.DeserializeObject<List<DTO_MenuCard>>(data);
            if (info.Count>0)
            {
                VM_TemplateMainMenu AppBinding = new VM_TemplateMainMenu(info);
                listView.ItemsSource = AppBinding.CardDataCollection;
            }
            base.OnAppearing(); 
        }
        public class DTO_MenuCard
        {
            public int IdMenu { get; set; }
            public string Titulo { get; set; }
            public string Subitulo { get; set; }
            public string CardIcon { get; set; }
            public string AlertColor { get; set; }
        }
        private async void EvetClicked(object s, SelectedItemChangedEventArgs e)
        {

        }
    }
}
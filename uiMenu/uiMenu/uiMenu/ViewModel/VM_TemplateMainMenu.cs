using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
namespace uiMenu
{
    class VM_TemplateMainMenu
    {
        
        public IList<CardDaraModel> CardDataCollection { get; set; }
        public object SelectedItem { get; set; }
        private static readonly HttpClient client = new HttpClient();
        public VM_TemplateMainMenu(List<MainMenuView.DTO_MenuCard> info)
        {
            CardDataCollection = new List<CardDaraModel>();
            GenerateCardModel(infoMenu:info);
        }
        public void GenerateCardModel(List<MainMenuView.DTO_MenuCard> infoMenu)
        {
            foreach (var item in infoMenu)
            {
                
                var cardDataAprobaciones = new CardDaraModel()
                {
                    IdView = item.IdMenu,
                    Cantidad = Convert.ToString(100),
                    Color = Color.Aqua,
                    Title = item.Titulo,
                    Owner = item.Subitulo,
                    CardIcon = "cover_medium.JPG",
                    AlertColor = Color.FromHex("#C0392B")
                };
                CardDataCollection.Add(cardDataAprobaciones);
            }
        }
    }
    
    class CardDaraModel
    {
        public int IdView { get; set; }
        public string Cantidad { get; set; }
        public string Title { get; set; }
        public Color Color { get; set; }
        public string Owner { get; set; }
        public string CardIcon { get; set; }
        public Color AlertColor { get; set; }
    }
}

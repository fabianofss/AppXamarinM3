using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using AppXamarinM3.Views;
using AppXamarinM3.Models;

namespace AppXamarinM3
{

    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList = new List<MasterPageItem>();

        public MainPage()
        { 
            InitializeComponent();

            //Detail = new Home();

            // incluindo items de menu e definindo : title ,page and icon
            menuList.Add(new MasterPageItem() {Title = "Home",Icon = "home.png",TargetType =typeof(Home)});
            menuList.Add(new MasterPageItem() { Title = "Usuários", Icon = "home.png", TargetType = typeof(cstUsuarios) });
            menuList.Add(new MasterPageItem() { Title = "Sincronizar", Icon = "home.png", TargetType = typeof(Sincronizar) });
            menuList.Add(new MasterPageItem() { Title = "Sobre", Icon = "home.png", TargetType = typeof(Sobre) });

            // Configurando o ItemSource fpara o ListView na MainPage.xaml
            paginaMestreList.ItemsSource = menuList;

            // navegação inicial
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));
        }

        // Evento para a seleção de item no menu
        // trata a seleção do usuário no ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
        /*
        private void BtHome_Clicked(object sender, EventArgs e)
        {
            Detail = new Home();
            IsPresented = false;
        }
        private void BtUsuarios_Clicked(object sender, EventArgs e)
        {
            Detail = new cstUsuarios();
            IsPresented = false;
        }
        private void BtSobre_Clicked(object sender, EventArgs e)
        {
            Detail = new Sobre();
            IsPresented = false;
        }*/
    }
}

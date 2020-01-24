using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppXamarinM3.Models;
using AppXamarinM3.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using static AppXamarinM3.Models.ApiUsuario;

namespace AppXamarinM3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class cstUsuarios : ContentPage
	{

        public cstUsuarios ()
		{
            InitializeComponent ();
        }

        private void BtInserir_Clicked(object sender, EventArgs e)
        {
            InserirUsuario();
        }

        private async void BtListar_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var jsonRetorno = await client.GetStringAsync($"http://projetos.temptable.com.br/APIRest/Login/listaUsuarios");
            Rootobject retorno = JsonConvert.DeserializeObject<Rootobject>(jsonRetorno);
            lblStatus.Text = retorno.status;

            lvUsers.ItemsSource = retorno.dados;
        }

        public void InserirUsuario()
        {
           ServicesDBUsuarios dbUsuario = new ServicesDBUsuarios();

            Usuarios usuario = new Usuarios();

            usuario.nome = "Administrador";
            usuario.login = "admin";
            usuario.senha = "admin";
            usuario.email = "admin@email.com";
            
            dbUsuario.Inserir(usuario);

            DisplayAlert("Resultado:", dbUsuario.StatusMessege, "OK");
        }
    }
}
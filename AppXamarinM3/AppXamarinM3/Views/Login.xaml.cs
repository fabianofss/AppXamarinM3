using AppXamarinM3.Models;
using AppXamarinM3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinM3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
        }

        private async void btLogin_Clicked(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            ServicesDBUsuarios dbUsuario = new ServicesDBUsuarios();

            if (etLogin.Text == "")
            {
                await DisplayAlert("Aviso", "Informe um login válido", "OK");
                return;
            }

            if (etSenha.Text == "")
            {
                await DisplayAlert("Aviso", "Informe um login válido", "OK");
                return;
            }

            /* consulta usuairo no banco local */
            if (dbUsuario.ValidaLogin(etLogin.Text) == true)
            {
                if (dbUsuario.ValidaSenha(etSenha.Text) == true)
                {
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                    return;
                }
            }

            await DisplayAlert("Aviso", dbUsuario.StatusMessege, "OK");
        }

        //Dá uma pausa de 5 segundos
        async Task DandoUmTempo(int valor)
        {
            await Task.Delay(valor);
        }
    }
}
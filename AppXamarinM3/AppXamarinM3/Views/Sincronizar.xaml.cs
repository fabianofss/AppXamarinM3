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
using System.Diagnostics;
using Xamarin.Essentials;

namespace AppXamarinM3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sincronizar : ContentPage
	{
		public Sincronizar ()
		{
			InitializeComponent ();
		}

        private async void BtnUsuarios_Clicked(object sender, EventArgs e)
        {
            ServicesDBUsuarios dbUsuario = new ServicesDBUsuarios();

            var current = Connectivity.NetworkAccess;

            // Connection to internet is available
            if (current != NetworkAccess.Internet)
            {
                lblStatus.Text = "Sem conexão com internet!";
                return;
            }

            var client = new HttpClient();
            var jsonRetorno = await client.GetStringAsync($"http://projetos.temptable.com.br/APIRest/Login/listaUsuarios");
            Rootobject retorno = JsonConvert.DeserializeObject<Rootobject>(jsonRetorno);
            lblStatus.Text = retorno.status;

            //Loop nos usuarios, se não tiver cria, se dt_update for menor atualiza
            for(int i=0; i <= retorno.dados.Length; i++)
            {
                //Busca o usuario
                Usuarios usuario = dbUsuario.BuscaUsuarioLogin(retorno.dados[i].login);

                if (usuario is null)
                {
                    Usuarios novoUsuario = new Usuarios();

                    novoUsuario.ID = Int32.Parse(retorno.dados[i].id);
                    novoUsuario.login = retorno.dados[i].login;
                    novoUsuario.nome = retorno.dados[i].nome;
                    novoUsuario.email = retorno.dados[i].email;
                    novoUsuario.senha = retorno.dados[i].senha;
                    novoUsuario.pontuacao = retorno.dados[i].pontuacao;
                    novoUsuario.level = retorno.dados[i].level;
                    novoUsuario.dt_update = retorno.dados[i].dt_update;

                    dbUsuario.Inserir(novoUsuario);
                    lblStatus.Text = dbUsuario.StatusMessege;
                } 
                else {
                    DateTime dtWeb = DateTime.ParseExact(retorno.dados[i].dt_update, "yyyy-MM-dd HH:mm:ss", null);
                    DateTime dtLocal = DateTime.ParseExact(usuario.dt_update, "yyyy-MM-dd HH:mm:ss", null);

                    if (dtWeb != dtLocal)
                    {
                        if (dtWeb > dtLocal)
                        {
                            //Atualiza o usuario local
                            Usuarios novoUsuario = new Usuarios();

                            novoUsuario.ID = Int32.Parse(retorno.dados[i].id);
                            novoUsuario.login = retorno.dados[i].login;
                            novoUsuario.nome = retorno.dados[i].nome;
                            novoUsuario.email = retorno.dados[i].email;
                            novoUsuario.senha = retorno.dados[i].senha;
                            novoUsuario.pontuacao = retorno.dados[i].pontuacao;
                            novoUsuario.level = retorno.dados[i].level;
                            novoUsuario.dt_update = retorno.dados[i].dt_update;

                            dbUsuario.UpdateUsuario(novoUsuario);
                        }
                        else
                        {
                            string url = "http://projetos.temptable.com.br/APIRest/Login/atualizarLogin?";
                            url = url + "login=" + usuario.login + 
                                "&nome="+ usuario.nome + 
                                "&email=" + usuario.email +
                                "&senha=" + usuario.senha +
                                "&level=" + usuario.level +
                                "&pontuacao=" + usuario.pontuacao +
                                "&dt_update=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            //Atualiza o usuario na web
                            jsonRetorno = await client.GetStringAsync(url);

                            retorno = JsonConvert.DeserializeObject<Rootobject>(jsonRetorno);
                            lblStatus.Text = retorno.status;
                        }

                    }
                }


            }

        }
    }
}
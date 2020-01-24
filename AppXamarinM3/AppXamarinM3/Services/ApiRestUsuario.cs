using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using AppXamarinM3.Models;
using static AppXamarinM3.Models.ApiUsuario;

namespace AppXamarinM3.Services
{
    class ApiUsuario
    {
        async public void ListaUsuarios()
        {
            var client = new HttpClient();
            var jsonRetorno = await client.GetStringAsync($"http://projetos.temptable.com.br/APIRest/Login/listaUsuarios");
            Rootobject retorno = JsonConvert.DeserializeObject<Rootobject>(jsonRetorno);
        }
    }
}

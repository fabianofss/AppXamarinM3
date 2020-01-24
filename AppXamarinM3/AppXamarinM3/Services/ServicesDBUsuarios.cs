using System;
using System.Collections.Generic;
using System.Text;
using AppXamarinM3.Models;
using SQLite;
using System.Linq;

namespace AppXamarinM3.Services
{
    class ServicesDBUsuarios
    {
        SQLiteConnection conn;
        public string StatusMessege { get; set; }

        public ServicesDBUsuarios()
        {
            conn = new SQLiteConnection(App.DbPath); //Define o banco de dados
            conn.CreateTable<Usuarios>(); //Cria a tabela de usuarios

            var dados = conn.Table<Usuarios>();
            var retorno = dados.Where(x => x.login == "admin").FirstOrDefault();

            if (retorno == null)
            {
                Usuarios admin = new Usuarios();
                admin.nome = "Administrador";
                admin.login = "admin";
                admin.senha = "admin";
                admin.email = "temptable@temptable.com.br";

                conn.Insert(admin);
            }
        }

        public void Inserir(Usuarios usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.login)) throw new Exception("Login não informado!");
                if (string.IsNullOrEmpty(usuario.senha)) throw new Exception("Senha não informada!");
                if (string.IsNullOrEmpty(usuario.email)) throw new Exception("E-mail não informado!");

                int result = conn.Insert(usuario);

                if (result != 0) StatusMessege = string.Format("Usuário {0} criado com sucesso!", usuario.login);
                else throw new Exception("Falha ao criar usuário!");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Usuarios> BuscarTodos()
        {
            return (from data in conn.Table<Usuarios>() select data).ToList();
        }

        public Usuarios BuscaUsuarioID(int id)
        {
            return conn.Table<Usuarios>().FirstOrDefault(usu => usu.ID == id);
        }

        public void DeleteTodos()
        {
            conn.DeleteAll<Usuarios>();
        }

        public void DeleteUsuario(int id)
        {
            conn.Delete<Usuarios>(id);
        }

        public void UpdateUsuario(Usuarios usuario)
        {
            conn.Update(usuario);
        }

        public Usuarios BuscaUsuarioLogin(string login)
        {
            return conn.Table<Usuarios>().FirstOrDefault(usu => usu.login == login);
        }

        public Usuarios BuscaUsuarioSenha(string senha)
        {
            return conn.Table<Usuarios>().FirstOrDefault(usu => usu.senha == senha);
        }

        public Boolean ValidaLogin(string login)
        {
            var dados = conn.Table<Usuarios>();
            var retorno = dados.Where(x => x.login == login).FirstOrDefault();

            if (retorno != null)
            {
                StatusMessege = "Login localizado com sucesso!";
                return true;
            }
            else
            {
                StatusMessege = "Login não cadstrado";
                return false;
            }

        }

        public Boolean ValidaSenha(string senha)
        {
            var dados = conn.Table<Usuarios>();
            var retorno = dados.Where(x => x.senha == senha).FirstOrDefault();

            if (retorno != null)
            {
                StatusMessege = "Login localizado com sucesso!";
                return true;
            }
            else
            {
                StatusMessege = "Senha inválida!";
                return false;
            }

        }
    }
}

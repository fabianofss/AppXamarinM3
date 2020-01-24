using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppXamarinM3.Models
{
    [Table("Usuarios")]
    class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string email { get; set; }

        public Usuarios()
        {
            ID = 0;
            nome = "";
            login = "";
            senha = "";
            email = "";
        }
    }
}

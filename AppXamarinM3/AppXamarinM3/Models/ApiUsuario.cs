using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarinM3.Models
{
    class ApiUsuario
    {
        public class Rootobject
        {
            public string status { get; set; }
            public Dado[] dados { get; set; }
        }

        public class Dado
        {
            public string id { get; set; }
            public string login { get; set; }
            public string nome { get; set; }
            public string email { get; set; }
            public string senha { get; set; }
            public string level { get; set; }
            public string pontuacao { get; set; }
        }

    }
}

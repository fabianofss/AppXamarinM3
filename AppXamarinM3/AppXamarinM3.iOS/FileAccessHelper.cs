using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace AppXamarinM3.iOS
{
    class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            //Pega o diretorio do sistema onde podemos armazenar arquivos
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

            if (!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }
            //Retorna o diretório e o nome do arquivo
            return System.IO.Path.Combine(libFolder, fileName);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace AppXamarinM3.Services
{
    class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            //Pega o diretorio do sistema onde podemos armazenar arquivos
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //string path = FileSystem.AppDataDirectory;
            //Retorna o diretório e o nome do arquivo
            return Path.Combine(path, fileName);
        }
    }
}

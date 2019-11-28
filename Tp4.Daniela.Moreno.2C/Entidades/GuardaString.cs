﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
   public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            string aux = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter str = new StreamWriter(aux +"\\"+ archivo, File.Exists(archivo)))
            {
                str.WriteLine(texto);
                retorno = true;
            }
            return retorno;
        }
    }
}

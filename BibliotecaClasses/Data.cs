using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClasses
{
    public class Data
    {
        public string Dia { get; set; }

        public string Mes { get; set; }

        public string Ano { get; set; }

        public Data(string linha)
        {
            string[] data = new string[3];
            data = linha.Split('/');

            Dia = data[0];
            Mes = data[1];
            Ano = data[2];
        }

        public override string ToString()
        {
            return $"{Dia}/{Mes}/{Ano}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorPalavras
{
    class Definicao
    {
        public List<string> NaoTerminais { get; set; }
        public List<string> Terminais { get; set; }
        public List<Regra> Regras { get; set; }
        public string Inicio { get; set; }
    }
}

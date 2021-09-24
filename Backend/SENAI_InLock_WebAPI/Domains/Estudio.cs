using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Domains
{
    public class Estudio
    {
        public int IdEstudio { get; set; }
        public string NomeEstudio { get; set; }
        public List<Jogo> ListaJogos { get; set; }
    }
}

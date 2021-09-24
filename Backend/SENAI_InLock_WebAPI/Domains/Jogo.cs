using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Domains
{
    public class Jogo
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public int IdEstudio { get; set; }
        public Estudio Estudio { get; set; }
    }
}

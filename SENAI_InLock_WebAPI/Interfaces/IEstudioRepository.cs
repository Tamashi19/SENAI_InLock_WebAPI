using senai.inLock.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudio> ListarComJogos();
    }
}

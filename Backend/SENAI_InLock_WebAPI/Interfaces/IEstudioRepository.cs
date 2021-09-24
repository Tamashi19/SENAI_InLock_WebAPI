using senai.inLock.webAPI.Domains;
using SENAI_InLock_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Interfaces
{
    interface IEstudiosRepository
    {
        List<Estudio> ListarComJogos();
    }
}

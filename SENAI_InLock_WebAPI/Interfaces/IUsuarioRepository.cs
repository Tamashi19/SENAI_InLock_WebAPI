using SENAI_InLock_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}

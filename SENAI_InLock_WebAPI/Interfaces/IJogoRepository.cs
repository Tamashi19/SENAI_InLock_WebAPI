using SENAI_InLock_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> ListarTodos();

        Jogo BuscarPorId(int id);
        void Cadastrar(Jogo novoJogo);
        void Atualizar(int id, Jogo jogoAtualizado);
        void Deletar(int id);
    }
}

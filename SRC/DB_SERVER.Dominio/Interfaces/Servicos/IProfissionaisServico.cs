using DB_SERVER.Dominio.Model;
using System;

namespace DB_SERVER.Dominio.Interfaces.Servicos
{
    public interface IProfissionaisServico : IDisposable
    {
        Profissionais Adicionar(Profissionais profissional);
        Profissionais Atualizar(Profissionais profissional);
        void Remover(Profissionais pessoa);

    }
}
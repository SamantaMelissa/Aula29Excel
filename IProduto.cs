using System;
using System.Collections.Generic;

namespace Aula29Excell
{
    public interface IProduto
    {
        List<Produto> Ler();

        void Cadastrar(Produto prod);
        
        void Remover(string _termo);

        void Alterar (Produto produtoAlterado );
    }
}
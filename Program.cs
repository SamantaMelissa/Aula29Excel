using System;

using System.Collections.Generic;


namespace Aula29Excell
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 2;
            p1.Nome = "Fender";
            p1.Preco = 5500f;

            p1.Cadastrar(p1);

            Produto alterado = new Produto();
            alterado.Codigo = 3;
            alterado.Nome = "Fender";
            alterado.Preco = 6800f;

            p1.Alterar(alterado);

            p1.Remover("Tagma");

            List<Produto> lista = p1.Ler();
           // List<Produto> lista = p1.Filtrar("Ibanez");

            foreach (Produto item in lista)
            {
                Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }
        }
    }
}
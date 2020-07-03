using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Aula29Excell
{
    public class Produto : IProduto
    {
        
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";

    
        public Produto()
        {   

            // Solução do desafio
            string pasta = PATH.Split('/')[0];
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            // Cria o arquivo caso não exista
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public void Cadastrar(Produto prod)
        {            
            string[] linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Produto> Ler()
        {
            // Criamos uma lista para guardar o retorno
            List<Produto> prod = new List<Produto>();

            // Lemos o .csv e separamos em um array de linhas
            string[] linhas = File.ReadAllLines(PATH);

            // Varremos nossas linhas
            foreach(string linha in linhas)
            {
                // codigo=1;nome=Gibson;preco=5500
                string[] dado = linha.Split(";");

                // dado[0] = codigo=1
                // dado[1] = nome=Gibson
                // dado[2] = preco=5500

                Produto p   = new Produto();
                p.Codigo    = Int32.Parse( Separar(dado[0]) );
                p.Nome      = Separar(dado[1]);
                p.Preco     = float.Parse( Separar(dado[2]) );

                prod.Add(p);
 
            }

             prod = prod.OrderBy(y => y.Nome).ToList();
             
            return prod;
        }

        public void Remover(string _termo){
          //Criamos uma lista que servirá como uma espécie de backup para as linhas do csv
          List<string> linhas = new List<string>(); 

          // Utilizamos a biblioteca StreamReader para ler nosso csv
          using(StreamReader arquivo = new StreamReader(PATH)){
              string linha;
              while((linha = arquivo.ReadLine()) != null){

                  linhas.Add(linha);

              }
          }

          //enovamos as linhas que tiverem o termo passado como argumento
          // codigo = 1; nome = Tagma; preco = 7200
          linhas.RemoveAll(l => l.Contains(_termo)); 

          using(StreamWriter output = new StreamWriter(PATH)){

              foreach(string In in linhas){
                  output.Write(In + "\n");
              }


          }
        }

        public void Alterar (Produto produtoAlterado ){

            List<string> linhas = new List<string>(); 

          // Utilizamos a biblioteca StreamReader para ler nosso csv
             Reescrever(linhas);

            linhas.RemoveAll( x => x.Split(";").Contains(produtoAlterado.Codigo.ToString()));

            //linhas.RemoveAll(z => z.Split(";")[0].Split("=")[1] == produtoAlterado.Codigo.ToString());

            linhas.Add(PrepararLinha(produtoAlterado));
           
            ReescreverCSV(linhas);
            
        
          }

        
            private void Reescrever(List<string> lines){

            using(StreamReader arquivo = new StreamReader(PATH)){
              string linha;
              while((linha = arquivo.ReadLine()) != null){

                  lines.Add(linha);

              }
          }
        }

        private void ReescreverCSV(List<string> lines){

            using(StreamWriter output = new StreamWriter(PATH)){

              foreach(string In in lines){
                  output.Write(In + "\n");
              }
          }
        }
    
        public List<Produto> Filtrar(string _nome){

            return Ler().FindAll(x => x.Nome == _nome);
        }

        /// <summary>
        /// Método que separa o símbolo de = da string do csv
        /// </summary>
        /// <param name="dado">Coluna do csv separada</param>
        /// <returns>string somente com o valor da coluna</returns>
        public string Separar(string dado)
        {
            // codigo=1
            // [0] = codigo
            // [1] = 1
            return dado.Split("=")[1];
        }

        // 1;Sapato;34,90
        
        private string PrepararLinha(Produto p)
       {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
      }

    
    }
}

// Reescrita de um código com o propósito de melhorar --> Refatoração

//DESAFIO

       
        
         
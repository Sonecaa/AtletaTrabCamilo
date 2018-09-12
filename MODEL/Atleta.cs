using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabCamilo.MODEL
{
   public class Atleta
    {

        public int id { get; set; }
        public String Nome { get; set; }
        public Double Peso { get; set; }
        public Double Altura { get; set; }

        public Atleta()
        {

        }


        public Atleta(string nome, double peso, double altura)
        {
            this.Nome = nome;
            this.Peso = peso;
            this.Altura = altura;
        }
        public Atleta(int id, string nome, double peso, double altura)
        {
            this.id = id;
            Nome = nome;
            Peso = peso;
            Altura = altura;
        }



    }
}

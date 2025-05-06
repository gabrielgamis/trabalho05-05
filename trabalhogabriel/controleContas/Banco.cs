using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Banco
    {
        private readonly string _nome;
        private readonly int _numero;

        public string Nome => _nome;
        public int Numero => _numero;

        public Banco(string nome, int numero)
        {
            _nome = nome;
            _numero = numero;
        }
    }
}

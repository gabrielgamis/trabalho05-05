using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int AnoNascimento { get; private set; }

        public Cliente(string nome, string cpf, int anoNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            AnoNascimento = anoNascimento;
        }

        public int ObterIdade()
        {
            int idade = DateTime.Now.Year - AnoNascimento;
            return idade;
        }

        public string ConverterIdadeParaRomanos()
        {
            int idade = ObterIdade();
            if (idade < 1) return "0";

            return GerarNumeroRomano(idade);
        }

        private string GerarNumeroRomano(int numero)
        {
            string[] unidades = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] dezenas = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] centenas = { "", "C" };

            int centenasValue = numero / 100;
            int dezenasValue = (numero % 100) / 10;
            int unidadesValue = numero % 10;

            return centenas[centenasValue] + dezenas[dezenasValue] + unidades[unidadesValue];
        }
    }
}

        }
    }
}
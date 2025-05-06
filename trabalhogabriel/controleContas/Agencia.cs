using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleContas
{
    public class Agencia
    {
        // Propriedades imutáveis
        public int Numero { get; private set; }
        public string CEP { get; private set; }
        public string Telefone { get; private set; }
        public Banco Banco { get; private set; }

        // Construtor com validação básica
        public Agencia(int numero, string cep, string telefone, Banco banco)
        {
            if (banco == null)
                throw new ArgumentNullException(nameof(banco), "O banco não pode ser nulo");

            Numero = numero;
            CEP = cep ?? throw new ArgumentNullException(nameof(cep));
            Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
            Banco = banco;
        }

        // Método para representação textual
        public override string ToString()
        {
            return $"Agência {Numero} - Banco {Banco?.Nome ?? "Sem nome"}";
        }
    }
}

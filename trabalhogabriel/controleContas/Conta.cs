using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controleContas;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleContas
{
    public class Conta
    {
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public Cliente Titular { get; private set; }
        public Agencia Agencia { get; private set; }

        public Conta(int numero, Cliente titular, Agencia agencia)
        {
            if (titular == null)
                throw new ArgumentNullException(nameof(titular), "A conta deve ter um titular válido.");
            if (agencia == null)
                throw new ArgumentNullException(nameof(agencia), "A conta deve pertencer a uma agência válida.");

            Numero = numero;
            Titular = titular;
            Agencia = agencia;
            Saldo = 0;
        }

        public void Depositar(decimal valor)
        {
            ValidarValorPositivo(valor, "depósito");
            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            ValidarValorPositivo(valor, "saque");

            decimal valorComTaxa = CalcularTaxaDeSaque(valor);

            if (Saldo < valorComTaxa)
                throw new InvalidOperationException("Saldo insuficiente para o saque.");

            Saldo -= valorComTaxa;
        }

        public void Transferir(decimal valor, Conta contaDestino)
        {
            if (contaDestino == null)
                throw new ArgumentNullException(nameof(contaDestino), "Conta de destino inválida.");

            ValidarValorPositivo(valor, "transferência");

            if (Saldo < valor)
                throw new InvalidOperationException("Saldo insuficiente para transferência.");

            Saldo -= valor;
            contaDestino.Saldo += valor;

            ExibirDetalhesTransferencia(contaDestino);
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Conta {Numero} - Titular: {Titular.Nome}");
            Console.WriteLine($"Saldo atual: {Saldo:C}");
        }

        // Métodos auxiliares
        private void ValidarValorPositivo(decimal valor, string tipoOperacao)
        {
            if (valor <= 0)
                throw new ArgumentException($"O valor do {tipoOperacao} deve ser positivo.");
        }

        private decimal CalcularTaxaDeSaque(decimal valor)
        {
            const decimal taxaSaque = 0.10m; // Taxa de R$0,10 por saque
            return valor + taxaSaque;
        }

        private void ExibirDetalhesTransferencia(Conta contaDestino)
        {
            Console.WriteLine("Transferência realizada:");
            Console.WriteLine($"- Conta {Numero}: Saldo atual = {Saldo:C}");
            Console.WriteLine($"- Conta {contaDestino.Numero}: Saldo atual = {contaDestino.Saldo:C}");
        }
    }
}

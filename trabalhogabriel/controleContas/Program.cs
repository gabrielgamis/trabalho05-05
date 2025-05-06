using System;
using controleContas;
using System.Xml.Linq;

namespace ControleContas
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Inicialização do banco
                Banco banco = InicializarBanco("Banco Digital", 1);

                // Criação da agência
                Agencia agencia = InicializarAgencia(1234, "01001000", "(11) 9999-8888", banco);

                // Criação dos clientes
                Cliente cliente1 = CriarCliente("João Silva", "12345678901", 1985);
                Cliente cliente2 = CriarCliente("Maria Souza", "98765432109", 1990);

                // Criação das contas
                Conta conta1 = CriarConta(123456, cliente1, agencia);
                Conta conta2 = CriarConta(654321, cliente2, agencia);

                // Realizando operações bancárias
                ExecutarOperacoes(conta1, conta2);

                // Exibindo as idades dos clientes em números romanos
                ExibirIdadesRomanas(cliente1, cliente2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        static Banco InicializarBanco(string nome, int codigo)
        {
            return new Banco(nome, codigo);
        }

        static Agencia InicializarAgencia(int numero, string cep, string telefone, Banco banco)
        {
            return new Agencia(numero, cep, telefone, banco);
        }

        static Cliente CriarCliente(string nome, string cpf, int anoNascimento)
        {
            ValidarCliente(nome, cpf, anoNascimento);
            return new Cliente(nome, cpf, anoNascimento);
        }

        static void ValidarCliente(string nome, string cpf, int anoNascimento)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do cliente é obrigatório.");

            if (cpf?.Length != 11 || !cpf.All(char.IsDigit))
                throw new ArgumentException("CPF deve conter 11 dígitos numéricos.");

            int idade = DateTime.Now.Year - anoNascimento;
            if (idade < 18)
                throw new ArgumentException("Cliente deve ter mais de 18 anos.");
        }

        static Conta CriarConta(int numero, Cliente titular, Agencia agencia)
        {
            ValidarNumeroConta(numero);
            return new Conta(numero, titular, agencia);
        }

        static void ValidarNumeroConta(int numero)
        {
            if (numero <= 0)
                throw new ArgumentException("Número da conta deve ser positivo.");
        }

        static void ExecutarOperacoes(Conta conta1, Conta conta2)
        {
            // Realizando depósitos
            conta1.Depositar(1000.00m);
            conta2.Depositar(500.00m);

            Console.WriteLine("=== Saldos Iniciais ===");
            conta1.ExibirSaldo();
            conta2.ExibirSaldo();

            // Realizando saque
            Console.WriteLine("\n=== Realizando Saque ===");
            conta1.Sacar(200.00m); // Será cobrada R$0,10 de taxa
            conta1.ExibirSaldo();

            // Realizando transferência
            Console.WriteLine("\n=== Realizando Transferência ===");
            conta1.Transferir(300.00m, conta2);
        }

        static void ExibirIdadesRomanas(Cliente cliente1, Cliente cliente2)
        {
            Console.WriteLine($"\nIdade de {cliente1.Nome}: {cliente1.IdadeEmRomanos()}");
            Console.WriteLine($"Idade de {cliente2.Nome}: {cliente2.IdadeEmRomanos()}");
        }
    }
}




using System;
using System.Collections.Generic;

namespace bank.Dio
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                   switch (opcaoUsuario)
                   {
                       case "1":
                       ListarContas();
                       break;

                       case "2":
                       InserirConta();
                       break;

                       case "3":
                       Transferir();
                       break;

                       case "4":
                       Sacar();
                       break;

                       case "5":
                       Depositar();
                       break;
                       
                       case "c":
                       Console.Clear();
                       break;

                       default:
                       throw new ArgumentOutOfRangeException();

                   } 
                   opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido:");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Tranferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {

            Console.WriteLine("Digite o numero da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta:");
            int indiceConta= int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas:");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("#{0} -", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta fisica ou 2 para conta juridica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
            saldo:entradaSaldo,
            credito:entradaCredito,
            nome:entradaNome);

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao Andropolis Bank");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 Listar contas");
            Console.WriteLine("2 Inserir nova conta");
            Console.WriteLine("3 Transferencias");
            Console.WriteLine("4 Saques");
            Console.WriteLine("5 Depositar");
            Console.WriteLine("C - Limpar a tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}

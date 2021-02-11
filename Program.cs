using System;
using System.Collections.Generic;
using DIO.Bank.Classes;
using DIO.Bank.Classes.Enum;
namespace DIO.Bank
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
                        Transferencia();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Opção invalida");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços. ");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            System.Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser sacado: ");
            double valorDepositar = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDepositar);
        }

        private static void Transferencia()
        {
            System.Console.WriteLine("Digite o número da conta de origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o número da consta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }

        private static void Sacar()
        {
            System.Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("LISTAR CONTAS: ");
            if (listContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada!");
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                System.Console.Write("#{0} - ", i);
                System.Console.WriteLine(conta);


            }
        }


        private static void InserirConta()
        {
            System.Console.WriteLine("Inserir conta");
            System.Console.WriteLine("Digite 1 para conta fisica ou 2 para Juridica: ");
            
            int entradaTipoConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                saldo: entradaSaldo,
                                credito: entradaCredito,
                                nome: entradaNome);
            listContas.Add(novaConta);
            Console.Clear();

        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine("Dio Bank a seu dispor!!!");
            System.Console.WriteLine("------------------------");
            System.Console.WriteLine("Informa a opção desejada: ");
            System.Console.WriteLine("1 - Listar conta");
            System.Console.WriteLine("2 - Inserir nova conta");
            System.Console.WriteLine("3 - Transferir");
            System.Console.WriteLine("4 - Sacar");
            System.Console.WriteLine("5 - Depositar");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return ObterOpcaoUsuario;
        }
    }
}

using DIO.Bank.Classes.Enum;

namespace DIO.Bank.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        public Conta() { }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        { //Se ele conseguir completar a operação 
            if (Saldo - valorSaque < (Credito * -1))
            {//Ele retorna a operação true se não reorna false e não muda o valor
                System.Console.WriteLine("Saldo insulficiente!");
                return false;
            }

            Saldo -= valorSaque;
            System.Console.WriteLine("Saldo atual da conta {0} é {1}", Nome, Saldo);
            return true;

        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            System.Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + TipoConta + " | ";
            retorno += "Nome: " + Nome + " | ";
            retorno += "Saldo: " + Saldo + " | ";
            retorno += "Crédito: " + Credito + " | ";
            return retorno;
        }



    }

}

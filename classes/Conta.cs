using System;

namespace bank.Dio  

{
    public class Conta
    {
        private TipoConta tipoConta { get; set;}

        private string Nome {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}

        public Conta (TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.tipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar (double valorSaque){
            //Validação do Saque
            if(this.Saldo - valorSaque < (this.Credito *-1)) {
                Console.WriteLine ("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("O Saldo atual da conta de {0} é {1}", this.Nome , this.Saldo);
        }

        public void Tranferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta" + this.tipoConta + " | ";
            retorno += "Nome" + this.Nome + " | ";
            retorno += "Saldo" + this.Saldo + " | ";
            retorno += "Credito" + this.Credito + " | ";
            return retorno;
        } 
    }

}


using System.ComponentModel;

namespace ContaCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double saldo1 = 1000;
            double saldo2 = 3000;

            bool especial1 = true;
            bool especial2 = false;

            double limite1 = 4000;
            double limite2 = 6000;



            ContaCorrente conta1 = new ContaCorrente("1", saldo1, especial1, limite1);
            ContaCorrente conta2 = new ContaCorrente("2", saldo2, especial2, limite2);



            Console.WriteLine($"O saldo da Conta 1 é: {conta1.Saldo}");
            Console.WriteLine();
            Console.WriteLine("Depositando 1000: ");
            conta1.Deposito(1000, "Deposito");
            conta1.VerSaldo();
            Console.WriteLine("Sacando 300: ");
            conta1.Saque(300, "Debito");
            conta1.VerSaldo();
            Console.WriteLine("Transferindo 400 para a conta 2: ");
            conta1.Transferencia(conta2, 400, "Transferencia");
            conta1.VerSaldo();

            Console.WriteLine("Extrato da conta 1: ");
            conta1.VerExtrato();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"O saldo da Conta 2 é: {conta2.Saldo}");
            Console.WriteLine();
            Console.WriteLine("Depositando 1700: ");
            conta2.Deposito(1700, "Deposito");
            conta2.VerSaldo();
            Console.WriteLine("Sacando 600: ");
            conta2.Saque(600, "Credito");
            conta2.VerSaldo();

            Console.WriteLine("Estrato da conta 2: ");
            conta2.VerExtrato();







        }
    }
}
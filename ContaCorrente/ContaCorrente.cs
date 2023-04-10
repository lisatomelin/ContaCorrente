using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    public class ContaCorrente
    {
        public string Numero { get; set; }
        public double Saldo { get; set; }
        public bool Especial { get; set; }
        public double Limite { get; set; }
        public List<Movimentacao> Movimentacoes { get; set; }

        public ContaCorrente(string numero, double saldo, bool especial, double limite)
        {
            Numero = numero;
            Saldo = saldo;
            Especial = especial;
            Limite = limite;
            Movimentacoes = new List<Movimentacao>();
        }

        public void Saque(double valor, string tipo)
        {
            if (Saldo + Limite >= valor)
            {
                Movimentacao movimentacao = new Movimentacao(-valor, tipo);
                Movimentacoes.Add(movimentacao);
                Saldo = Saldo - valor;
            }
            else
            {
                Console.WriteLine("Valor invalido!");
                Console.WriteLine();
            }
        }

        public void Deposito(double valor, string tipoDeposito)
        {
            Movimentacao movimentacao = new Movimentacao(valor, tipoDeposito);
            Movimentacoes.Add(movimentacao);
            Saldo = Saldo + valor;
        }

        public void VerSaldo()
        {
            Console.WriteLine($"O saldo atual é: {Saldo}");
            Console.WriteLine();
        }

        public void VerExtrato()
        {
            foreach (var movimentacao in Movimentacoes)
            {
                Console.Write($"Valor: ");
                if (movimentacao.Valor < 0 && movimentacao.Tipo != "Transferencia")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (movimentacao.Valor > 0 && movimentacao.Tipo != "Transferencia")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (movimentacao.Tipo == "Transferencia")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write(movimentacao.Valor);
                Console.WriteLine();
                Console.ResetColor();
                Console.Write("Tipo: ");
                if (movimentacao.Tipo == "Deposito")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (movimentacao.Tipo == "Transferencia")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (movimentacao.Tipo == "Credito" || movimentacao.Tipo == "Debito")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(movimentacao.Tipo);
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public void Transferencia(ContaCorrente contaDestino, double valor, string tipo)
        {
            Saque(valor, tipo);
            contaDestino.Deposito(valor, tipo);

            Console.WriteLine($"Valor enviado para a conta {contaDestino.Numero}: R${valor}");
            Console.WriteLine();


        }

    }
}


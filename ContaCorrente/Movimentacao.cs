namespace ContaCorrente
{

    public class Movimentacao
    {
        public double Valor { get; set; }
        public string Tipo { get; set; }

        public Movimentacao(double valor, string tipo)
        {
            Valor = valor;
            Tipo = tipo;
        }
    }
}
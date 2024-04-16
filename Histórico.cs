namespace ContaCorrente.ConsoleApp
{
    public class Historico
    {

        public char tipo;
        public string tipoTransacao = "";


        public void transacoes(char tipo)
        {
            if (tipo == '1')
            {
                tipoTransacao = "Débito";
                Console.WriteLine($"{tipoTransacao}\n");
            }
            else if (tipo == '2')
            {
                tipoTransacao = "Crédito";
                Console.WriteLine($"{tipoTransacao}\n");
            }
            else
            {
                Console.WriteLine("Tipo de transação não encontrado.");
            }
        }
    }
}
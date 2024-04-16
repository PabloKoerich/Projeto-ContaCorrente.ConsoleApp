using System.Reflection.Metadata;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Desafio Conta Corrente, Academia de Programação!\n");

            #region Instaciamento
            #region pessoa1
            PessoaFisica novaPessoa = new PessoaFisica();
            ContaCorrente novaConta = new ContaCorrente();
            novaConta.Titular = novaPessoa;
            novaConta.Extrato = new Historico();
            #endregion
            #region pessoal2
            PessoaFisica novaPessoa2 = new PessoaFisica();
            ContaCorrente novaConta2 = new ContaCorrente();
            novaConta2.Titular = novaPessoa2;
            novaConta2.Extrato = new Historico();
            #endregion
            #endregion
            #region Passagem de valores para novaPessoa

            novaPessoa.nome = "Pablo";
            novaPessoa.sobrenome = "Koerich";
            novaPessoa.cpf = "000.000.000-00";

            #endregion
            #region Passagem de valores para novaPessoa2

            novaPessoa2.nome = "Letica";
            novaPessoa2.sobrenome = "Koerich";
            novaPessoa2.cpf = "123.456.789-10";

            #endregion

            #region Passagem de valor para novaConta

            novaConta.numeroIdentificador = 1;
            novaConta.saldo = 1000.50;
            novaConta.limite = 300.50;
            novaConta.status = '0';  // status: 0 = Especial , status:1 = Normal , status:2 = desativada

            #endregion 
            #region Passagem de valor para novaConta2

            novaConta2.numeroIdentificador = 2;
            novaConta2.saldo = 1000.50;
            novaConta2.limite = 300.50;
            novaConta2.status = '1';  // status: 0 = Especial , status:1 = Normal , status:2 = desativada

            #endregion
            #region Atividades novaConta
            novaConta.Sacar(100.5);
            novaConta.Depositar(1100);
            novaConta.Sacar(1000);
            novaConta.Depositar(455);
            novaConta.Sacar(55);
            novaConta.VisualizarSaldo();
            novaConta.DefinirTipo(novaConta.status);
            novaConta.VisualizarTransacoes();
            novaConta.Tranferir(399.5, novaConta2);
            #endregion
            #region Atividades novaConta2

            novaConta2.VisualizarSaldo();
            novaConta2.DefinirTipo(novaConta2.status);
            novaConta2.VisualizarTransacoes();
            #endregion
        }
    }
}
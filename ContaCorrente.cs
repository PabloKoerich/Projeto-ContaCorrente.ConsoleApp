namespace ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        public int numeroIdentificador;
        public double saldo;
        public double limite;
        public char status;
        public int contador = 0;
        public string[] historicoMovimentacoes = new string[100];
        public PessoaFisica Titular;
        public Historico Extrato;
        public string movimentacao;

        public void Sacar(double valor)
        {


            if (this.saldo >= valor)
            {
                Extrato.tipo = '1';
                Extrato.transacoes(Extrato.tipo);
                this.saldo -= valor;

                Console.WriteLine($"Saque de R${valor:F} efetuado com sucesso!\nNovo saldo disponível: R${this.saldo:F}");

                historicoMovimentacoes[0] = $"{AdicionarTransacao(Extrato.tipo)} {valor:F} efetuado com Sucesso!";
                Console.WriteLine("----------------------------------------------------------------------------------------------");

            }
            else if (limite >= valor)
            {
                Extrato.tipo = '1';
                Extrato.transacoes(Extrato.tipo);
                this.limite -= valor;

                Console.WriteLine("----------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("Saldo insuficiente para saque!");
            }

        }
        public void Depositar(double valor)
        {
            Extrato.tipo = '2';
            Extrato.transacoes(Extrato.tipo);

            this.saldo += valor;

            Console.WriteLine($"Depósito de R${valor:F} efetuado com sucesso!\nNovo saldo disponível: R${this.saldo:F}");

            historicoMovimentacoes[0] = $"{AdicionarTransacao(Extrato.tipo)} {valor:F} efetuado com Sucesso!";
            Console.WriteLine("----------------------------------------------------------------------------------------------");

        }
        public void VisualizarSaldo()
        {

            Console.WriteLine($"Numero da conta: {numeroIdentificador}\tTitular da conta: {Titular.nome} {Titular.sobrenome}\n");
            Console.WriteLine($"Saldo disponível: {this.saldo}\nLimite disponível: {limite}");

            Console.WriteLine($"Ultimas transações:" +
                                                       $"\n\t1 . {historicoMovimentacoes[0]}" +
                                                       $"\n\t2 . {historicoMovimentacoes[1]}" +
                                                       $"\n\t3 . {historicoMovimentacoes[2]}");

            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }
        public string AdicionarTransacao(char tipo)
        {
            DefinirOrdem();

            return movimentacao;
        }

        public void DefinirOrdem()
        {
            if (Extrato.tipo == '1')
            {
                movimentacao = $"{"Saque".PadRight(13)}: R$";
            }
            else if (Extrato.tipo == '2')
            {

                movimentacao = $"{"depósito".PadRight(13)}: R$";
            }
            else if (Extrato.tipo == '3')
            {
                movimentacao = $"{"Transferencia".PadRight(13)}: R$";
            }
            for (int i = historicoMovimentacoes.Length - 1; i > 0; i--)
            {
                historicoMovimentacoes[i] = historicoMovimentacoes[i - 1];
            }
            historicoMovimentacoes[0] = movimentacao;
        }

        public void Tranferir(double valor, ContaCorrente Recebedor)
        {
            if (this.saldo >= valor)
            {
                this.saldo -= valor;
                Recebedor.saldo += valor;
                historicoMovimentacoes[0] = $"{AdicionarTransacao(Extrato.tipo)} Transferência para {Recebedor.Titular.nome} no valor de R${valor:F} efetuada com Sucesso!";
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Recebedor.historicoMovimentacoes[0] = $"{Recebedor.AdicionarTransacao(Extrato.tipo)} Transferência recebida de {this.Titular.nome} no valor de R${valor:F} efetuada com Sucesso!";
                Console.WriteLine("----------------------------------------------------------------------------------------------");


            }
            else
            {
                Console.WriteLine("Saldo insuficiente para transferência!");
            }
        }
        public void VisualizarTransacoes()
        {
            Console.WriteLine($"Extrato de Transações da Conta de {Titular.nome}:\t\t Saldo Atual: {saldo}");
            Array.Reverse(historicoMovimentacoes);
            for (int i = 0; i < historicoMovimentacoes.Length; i++)
            {
                if (historicoMovimentacoes[i] != null)
                {
                    historicoMovimentacoes[i] = historicoMovimentacoes[i];
                    Console.WriteLine($"\t{Math.Abs(i - 100)} - {historicoMovimentacoes[i]}");
                }
            }

        }

        public void DefinirTipo(char status)
        {
            switch (status)
            {
                case '0':
                    Console.WriteLine("Esta é uma conta com privilégios especiais.");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    break;
                case '1':
                    Console.WriteLine("Esta é uma conta normal.");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    break;
                case '2':
                    Console.WriteLine("Esta está desativada.");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    break;
            }
        }
    }
}
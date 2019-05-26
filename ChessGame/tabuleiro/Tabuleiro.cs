namespace tabuleiro
{
    class Tabuleiro
    {
        //Propriedades
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas { get; set; }

        //Construtor
        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        //Métodos
        public bool ValidarPosicao(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public bool VerificarPecaPosicao(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna] != null;
        }

        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (!ValidarPosicao(posicao))
            {
                throw new TabuleiroException("Posição Inválida");
            }
            if (VerificarPecaPosicao(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

    }
}

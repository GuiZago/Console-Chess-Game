namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Tabuleiro = tab;
            Cor = cor;
            QtdMovimentos = 0;
        }

        public void IncrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }

        public abstract bool[,] MovimentosPossiveis();

        protected bool VerificarMovimento(Posicao posicao)
        {
            Peca peca = Tabuleiro.Peca(posicao.Linha, posicao.Coluna);
            return peca == null || peca.Cor != Cor;
        }

    }
}

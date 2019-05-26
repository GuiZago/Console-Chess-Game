using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Norte
            pos.DefinirCoordenadas(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Nordeste
            pos.DefinirCoordenadas(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Leste
            pos.DefinirCoordenadas(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Sudeste
            pos.DefinirCoordenadas(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Sul
            pos.DefinirCoordenadas(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Sudoeste
            pos.DefinirCoordenadas(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Oeste
            pos.DefinirCoordenadas(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //Noroeste
            pos.DefinirCoordenadas(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            return matriz;
        }
      
        public override string ToString()
        {
            return "R";
        }
    }
}

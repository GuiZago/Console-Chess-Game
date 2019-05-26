using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Norte 
            pos.DefinirCoordenadas(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos.Linha, pos.Coluna) != null && Tabuleiro.Peca(pos.Linha, pos.Coluna).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //Sul
            pos.DefinirCoordenadas(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos.Linha, pos.Coluna) != null && Tabuleiro.Peca(pos.Linha, pos.Coluna).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //Leste
            pos.DefinirCoordenadas(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos.Linha, pos.Coluna) != null && Tabuleiro.Peca(pos.Linha, pos.Coluna).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //Oeste
            pos.DefinirCoordenadas(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.ValidarPosicao(pos) && VerificarMovimento(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos.Linha, pos.Coluna) != null && Tabuleiro.Peca(pos.Linha, pos.Coluna).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return matriz;
        }


        public override string ToString()
        {
            return "T";
        }
    }
}

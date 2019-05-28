using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class Partida
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get;private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        private HashSet<Peca> pecasJogo;
        private HashSet<Peca> pecasCapturadas;

        public Partida()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            pecasJogo = new HashSet<Peca>();
            pecasCapturadas = new HashSet<Peca>();
            IniciarPartida();
            Terminada = false;
        }

        private void AdicionarPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecasJogo.Add(peca);
        }

        private void IniciarPartida()
        {
            //Brancas
            AdicionarPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            AdicionarPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            AdicionarPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            AdicionarPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
            AdicionarPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            AdicionarPeca('d', 1, new Torre(Tabuleiro, Cor.Branca));

            //Pretas
            AdicionarPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            AdicionarPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            AdicionarPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            AdicionarPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
            AdicionarPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            AdicionarPeca('d', 8, new Torre(Tabuleiro, Cor.Preta));

        }

        public HashSet<Peca> ListaPecasCapturadas(Cor cor)
        {
            HashSet<Peca> lista = new HashSet<Peca>();
            foreach(Peca p in pecasCapturadas)
            {
                if (p.Cor == cor)
                {
                    lista.Add(p);
                }
            }
            return lista;
        }

        public HashSet<Peca> ListaPecasAtivas(Cor cor)
        {
            HashSet<Peca> lista = new HashSet<Peca>();
            foreach (Peca p in pecasJogo)
            {
                if (p.Cor == cor)
                {
                    lista.Add(p);
                }
            }
            lista.ExceptWith(ListaPecasCapturadas(cor));
            return lista;
        }

        public void ValidarPosicaoOrigem(Posicao origem)
        {
            if (Tabuleiro.Peca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if (JogadorAtual != Tabuleiro.Peca(origem).Cor)
            {
                throw new TabuleiroException("Escolha uma peça " + JogadorAtual);
            }
            if (!Tabuleiro.Peca(origem).VerificarMovimentosPossiveis())
            {
                throw new TabuleiroException("Peça Bloqueada");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).MovimentosPossiveis()[destino.Linha, destino.Coluna])
            {
                throw new TabuleiroException("Posicao de destino invalida");
            }
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetirarPeca(origem);
            peca.IncrementarQtdMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
            if (pecaCapturada != null)
            {
                pecasCapturadas.Add(pecaCapturada);
            }

            Turno++;

            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
    }
}

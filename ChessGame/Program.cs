using System;
using tabuleiro;
using xadrez;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(0, 1));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 2));
                Tela.ImprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}

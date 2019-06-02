using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char _coluna { get; set; }
        public int _linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            _coluna = coluna;
            _linha = linha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - _linha, _coluna - 'a');
        }

        public override string ToString()
        {
            return "" + _coluna + _linha;
        }
    }
}
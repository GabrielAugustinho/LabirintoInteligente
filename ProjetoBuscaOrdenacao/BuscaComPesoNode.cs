using System.Collections.Generic;

namespace ProjetoBuscaOrdenacao
{
    public class BuscaComPesoNode
    {
        public BuscaComPesoNode(Node atual, int pesoCaminho, int peso)
        {
            posicaoX = atual.posicaoX;
            posicaoY = atual.posicaoY;
            Peso = peso;
            PesoCaminho = pesoCaminho;
            Pai = null;
            Principal = new List<BuscaComPesoNode>();
            Verificacao = new List<BuscaComPesoNode>();
        }

        public int posicaoX { get; set; }
        public int posicaoY { get; set; }
        public int Peso { get; set; }
        public int PesoCaminho { get; set; }
        public BuscaComPesoNode Pai { get; set; }
        public List<BuscaComPesoNode> Principal { get; set; }
        public List<BuscaComPesoNode> Verificacao { get; set; }
    }

    public class Node
    {
        public int posicaoX { get; set; }
        public int posicaoY { get; set; }
    }
}

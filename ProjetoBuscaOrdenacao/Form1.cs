using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoBuscaOrdenacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DefinirDataGrid(13, 17);
            DefinirMovimentos(1, 1, 1, 1);

            // Adiciona o manipulador de eventos ao evento SelectedIndexChanged do ComboBox
            cmb_Element.SelectedIndexChanged += cmb_Element_SelectedIndexChanged;
            cmb_Ordenacao.SelectedIndexChanged += cmb_Ordenacao_SelectedIndexChanged;
        }

        private List<PosicoesCardeais> PosicoesCardeais;
        private Color CorVisitado = Color.LightGray;
        private Color CorCaminho = Color.Yellow;

        private void DefinirMovimentos(int pN, int pS, int pO, int pL)
        {
            PosicoesCardeais = new List<PosicoesCardeais>()
            {
                new PosicoesCardeais()
                {
                    Nome = "Norte",
                    X = 0,
                    Y = -1,
                    Peso = pN
                },
                new PosicoesCardeais()
                {
                    Nome = "Sul",
                    X = 0,
                    Y = 1,
                    Peso = pS
                },
                new PosicoesCardeais()
                {
                    Nome = "Leste",
                    X = 1,
                    Y = 0,
                    Peso = pL
                },
                new PosicoesCardeais()
                {
                    Nome = "Oeste",
                    X = -1,
                    Y = 0,
                    Peso = pO
                },
            };
        }

        private void DefinirDataGrid(int linhas, int colunas)
        {
            // Define o número de linhas e colunas do DataGridView
            int numLinhas = linhas;
            int numColunas = colunas;

            dataGridView1.RowCount = numLinhas;
            dataGridView1.ColumnCount = numColunas;

            // Define o tamanho de cada célula em pixels
            int tamanhoCelula = 30;

            // Define a largura e a altura de cada coluna e linha
            for (int i = 0; i < numColunas; i++)
            {
                dataGridView1.Columns[i].Width = tamanhoCelula;
            }

            for (int i = 0; i < numLinhas; i++)
            {
                dataGridView1.Rows[i].Height = tamanhoCelula;
            }

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtém a célula clicada
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Verifica qual opção foi selecionada no ComboBox
                if (cmb_Element.SelectedItem != null)
                {
                    switch (cmb_Element.SelectedItem.ToString())
                    {
                        case "Personagem":
                            RemoveUltimoSelecionado(Color.Blue);
                            cell.Style.BackColor = Color.Blue;
                            break;
                        case "Barreira":
                            cell.Style.BackColor = Color.Red;
                            break;
                        case "Chegada":
                            RemoveUltimoSelecionado(Color.Green);
                            cell.Style.BackColor = Color.Green;
                            break;
                    }
                }
            }
        }

        private void RemoveUltimoSelecionado(Color color)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell c in row.Cells)
                {
                    if (c.Style.BackColor == color)
                    {
                        // Altera a cor da célula azul para branca
                        c.Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void cmb_Element_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpa a seleção anterior no DataGridView
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (cmb_Element.SelectedItem != null)
                {
                    switch (cmb_Element.SelectedItem.ToString())
                    {
                        case "Personagem":
                            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
                            break;
                        case "Barreira":
                            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
                            break;
                        case "Chegada":
                            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;
                            break;
                    }
                }
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            btn_Limpar_Click(sender, e);

            if (cmb_Ordenacao.SelectedItem != null)
            {
                var celulaInicial = BuscarCelula(Color.Blue);
                var celulaFinal = BuscarCelula(Color.Green);

                if (celulaInicial != null && celulaFinal != null)
                {
                    switch (cmb_Ordenacao.SelectedItem.ToString())
                    {
                        case "Amplitude":
                            BuscaPorAmplitude(celulaInicial, celulaFinal);
                            break;
                        case "Profundidade":
                            BuscaPorProfundidade(celulaInicial, celulaFinal);
                            break;
                        case "Prof Lim":
                            long resultado;
                            if (long.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Digite um número:"), out resultado))
                            {
                                BuscaPorProfundidadeLimitada(celulaInicial, celulaFinal, resultado);
                            }
                            else
                            {
                                MessageBox.Show("O número digitado não foi um númro válido.");
                            }
                            break;
                        case "Bidirecional":
                            BuscaPorAmplitudeBidirecional(celulaInicial, celulaFinal);
                            break;
                        case "Aprof Interativo":
                            BuscaPorProfundidadeIterativa(celulaInicial, celulaFinal);
                            break;
                        case "Custo Uniforme":
                            BuscaPorCustoUniforme(celulaInicial, celulaFinal);
                            break;
                        case "Greedy":
                            BuscaPorGreedy(celulaInicial, celulaFinal);
                            break;
                        case "A*":
                            BuscaPorAStar(celulaInicial, celulaFinal);
                            break;
                    }

                    celulaInicial.Style.BackColor = Color.Blue;
                    celulaFinal.Style.BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("Selecione uma célula inicial e uma célula final.");
                }
            }
        }

        private DataGridViewCell BuscarCelula(Color color)
        {
            DataGridViewCell celula = null;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor == color)
                    {
                        celula = cell;
                        break;
                    }
                }
                if (celula != null) break;
            }

            return celula;
        }

        private void BuscaPorAmplitude(DataGridViewCell celulaInicial, DataGridViewCell celulaFinal)
        {
            var fila = new Queue<DataGridViewCell>();
            fila.Enqueue(celulaInicial);

            // Cria um dicionário para armazenar o caminho percorrido
            var caminho = new Dictionary<DataGridViewCell, DataGridViewCell> { [celulaInicial] = null };

            // Inicia o loop de busca por amplitude
            while (fila.Count > 0)
            {
                // Obtém o próximo nó a ser visitado
                var celulaAtual = fila.Dequeue();
                if (celulaAtual == celulaFinal) break;

                // Marca a célula atual como visitada
                celulaAtual.Style.BackColor = CorVisitado;

                // Percorre os movimentos possíveis a partir da célula atual
                foreach (var movimento in PosicoesCardeais)
                {
                    var celulaVizinhaNode = new Node()
                    {
                        posicaoX = celulaAtual.RowIndex + movimento.Y,
                        posicaoY = celulaAtual.ColumnIndex + movimento.X
                    };

                    if (celulaVizinhaNode.posicaoX >= 0 && celulaVizinhaNode.posicaoX < dataGridView1.Rows.Count && celulaVizinhaNode.posicaoY >= 0 && celulaVizinhaNode.posicaoY < dataGridView1.Columns.Count)
                    {
                        // Verifica se a célula vizinha pode ser visitada
                        DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaNode.posicaoX].Cells[celulaVizinhaNode.posicaoY];
                        if (celulaVizinha.Style.BackColor != Color.Red && !caminho.ContainsKey(celulaVizinha))
                        {
                            // Adiciona a célula vizinha à fila de visitados e ao caminho percorrido
                            fila.Enqueue(celulaVizinha);
                            caminho[celulaVizinha] = celulaAtual;
                        }
                    }
                }
            }

            if (!caminho.ContainsKey(celulaFinal))
            {
                MessageBox.Show("Célula final não alcançável a partir da célula inicial.");
                return;
            }

            // Pinta o caminho percorrido de amarelo, mantendo a célula inicial como azul e final como verde
            var celulaCaminho = caminho[celulaFinal];
            PintarCaminho(celulaCaminho, caminho, CorCaminho);
        }

        private void BuscaPorProfundidade(DataGridViewCell celulaInicial, DataGridViewCell celulaFinal)
        {
            var pilha = new Stack<DataGridViewCell>();
            pilha.Push(celulaInicial);

            // Cria um dicionário para armazenar o caminho percorrido
            var caminho = new Dictionary<DataGridViewCell, DataGridViewCell> { [celulaInicial] = null };

            // Inicia o loop de busca por amplitude
            while (pilha.Count > 0)
            {
                // Obtém o próximo nó a ser visitado
                var celulaAtual = pilha.Pop();
                if (celulaAtual == celulaFinal) break;

                // Marca a célula atual como visitada
                celulaAtual.Style.BackColor = CorVisitado;

                // Percorre os movimentos possíveis a partir da célula atual
                foreach (var movimento in PosicoesCardeais)
                {
                    var celulaVizinhaNode = new Node()
                    {
                        posicaoX = celulaAtual.RowIndex + movimento.Y,
                        posicaoY = celulaAtual.ColumnIndex + movimento.X
                    };

                    if (celulaVizinhaNode.posicaoX >= 0 && celulaVizinhaNode.posicaoX < dataGridView1.Rows.Count && celulaVizinhaNode.posicaoY >= 0 && celulaVizinhaNode.posicaoY < dataGridView1.Columns.Count)
                    {
                        // Verifica se a célula vizinha pode ser visitada
                        DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaNode.posicaoX].Cells[celulaVizinhaNode.posicaoY];
                        if (celulaVizinha.Style.BackColor != Color.Red && !caminho.ContainsKey(celulaVizinha))
                        {
                            // Adiciona a célula vizinha à pilha de visitados e ao caminho percorrido
                            pilha.Push(celulaVizinha);
                            caminho[celulaVizinha] = celulaAtual;
                        }
                    }
                }
            }

            if (!caminho.ContainsKey(celulaFinal))
            {
                MessageBox.Show("Célula final não alcançável a partir da célula inicial.");
                return;
            }

            // Pinta o caminho percorrido de amarelo, mantendo a célula inicial como azul e final como verde
            var celulaCaminho = caminho[celulaFinal];
            PintarCaminho(celulaCaminho, caminho, CorCaminho);
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Style.BackColor != Color.Red && cell.Style.BackColor != Color.Green && cell.Style.BackColor != Color.Blue)
                        cell.Style.BackColor = Color.White;
                }
            }
        }

        private void BuscaPorAmplitudeBidirecional(DataGridViewCell celulaInicial, DataGridViewCell celulaFinal)
        {
            Color corCaminhoFinal = Color.Orange;

            var filaInicial = new Queue<DataGridViewCell>();
            filaInicial.Enqueue(celulaInicial);

            var filaFinal = new Queue<DataGridViewCell>();
            filaFinal.Enqueue(celulaFinal);

            // Cria os dicionários para armazenar o caminho percorrido a partir da célula inicial e final
            var caminhoInicial = new Dictionary<DataGridViewCell, DataGridViewCell> { [celulaInicial] = null };
            var caminhoFinal = new Dictionary<DataGridViewCell, DataGridViewCell> { [celulaFinal] = null };

            // Pinta as células inicial e final com as cores correspondentes
            celulaInicial.Style.BackColor = CorCaminho;
            celulaFinal.Style.BackColor = corCaminhoFinal;

            // Inicia o loop de busca por amplitude
            while (filaInicial.Count > 0 && filaFinal.Count > 0)
            {
                // Obtém o próximo nó a ser visitado a partir da célula inicial
                var celulaAtualInicial = filaInicial.Dequeue();

                // Marca a célula atual como visitada ou como parte do caminho inicial
                if (celulaAtualInicial.Style.BackColor != CorCaminho)
                {
                    celulaAtualInicial.Style.BackColor = CorVisitado;
                }

                // Percorre os movimentos possíveis a partir da célula atual
                foreach (var movimento in PosicoesCardeais)
                {
                    // Obtém a célula vizinha
                    var celulaVizinhaAtual = new Node()
                    {
                        posicaoX = celulaAtualInicial.RowIndex + movimento.X,
                        posicaoY = celulaAtualInicial.ColumnIndex + movimento.Y
                    };

                    if (celulaVizinhaAtual.posicaoX >= 0 && celulaVizinhaAtual.posicaoX < dataGridView1.Rows.Count && celulaVizinhaAtual.posicaoY >= 0 && celulaVizinhaAtual.posicaoY < dataGridView1.Columns.Count)
                    {
                        DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaAtual.posicaoX].Cells[celulaVizinhaAtual.posicaoY];

                        // Verifica se a célula vizinha pode ser acessada e se ainda não foi visitada
                        if (celulaVizinha.Style.BackColor != Color.Red && celulaVizinha.Style.BackColor != CorVisitado && celulaVizinha.Style.BackColor != CorCaminho)
                        {
                            // Adiciona a célula vizinha à fila de busca
                            filaInicial.Enqueue(celulaVizinha);

                            // Armazena o caminho percorrido até a célula vizinha
                            caminhoInicial[celulaVizinha] = celulaAtualInicial;

                            // Pinta a célula vizinha como parte do caminho inicial ou como visitada
                            if (caminhoFinal.ContainsKey(celulaVizinha))
                            {
                                // Célula vizinha foi visitada a partir da célula final, ou seja, encontramos o caminho
                                MostrarCaminhoBidirecional(celulaVizinha, caminhoInicial, caminhoFinal, CorCaminho, corCaminhoFinal);
                                return;
                            }
                        }
                    }
                }

                // Obtém o próximo nó a ser visitado a partir da célula final
                var celulaAtualFinal = filaFinal.Dequeue();

                // Marca a célula atual como visitada
                celulaAtualFinal.Style.BackColor = CorVisitado;

                // Percorre os movimentos possíveis a partir da célula atual
                foreach (var movimento in PosicoesCardeais)
                {
                    // Obtém a célula vizinha
                    var celulaVizinhaFinal = new Node()
                    {
                        posicaoX = celulaAtualFinal.RowIndex + movimento.X,
                        posicaoY = celulaAtualFinal.ColumnIndex + movimento.Y
                    };

                    if (celulaVizinhaFinal.posicaoX >= 0 && celulaVizinhaFinal.posicaoX < dataGridView1.Rows.Count && celulaVizinhaFinal.posicaoY >= 0 && celulaVizinhaFinal.posicaoY < dataGridView1.Columns.Count)
                    {
                        DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaFinal.posicaoX].Cells[celulaVizinhaFinal.posicaoY];

                        // Verifica se a célula vizinha pode ser acessada e se ainda não foi visitada
                        if (celulaVizinha.Style.BackColor != Color.Red && celulaVizinha.Style.BackColor != CorVisitado && celulaVizinha.Style.BackColor != corCaminhoFinal)
                        {
                            // Adiciona a célula vizinha à fila de busca
                            filaFinal.Enqueue(celulaVizinha);

                            // Armazena o caminho percorrido até a célula vizinha
                            caminhoFinal[celulaVizinha] = celulaAtualFinal;

                            // Verifica se a célula vizinha já foi visitada a partir da célula inicial
                            if (caminhoInicial.ContainsKey(celulaVizinha))
                            {
                                // Célula vizinha foi visitada a partir da célula inicial, ou seja, encontramos o caminho
                                MostrarCaminhoBidirecional(celulaVizinha, caminhoInicial, caminhoFinal, CorCaminho, corCaminhoFinal);
                                return;
                            }
                        }
                    }
                }
            }

            // Caminho não encontrado
            MessageBox.Show("Caminho não encontrado.");
        }

        private void MostrarCaminhoBidirecional(DataGridViewCell celula, Dictionary<DataGridViewCell, DataGridViewCell> caminhoInicial, Dictionary<DataGridViewCell, DataGridViewCell> caminhoFinal, Color corCaminhoInicial, Color corCaminhoFinal)
        {
            // Pinta o caminho inicial
            PintarCaminho(celula, caminhoInicial, corCaminhoInicial);

            // Pinta o caminho final
            PintarCaminho(celula, caminhoFinal, corCaminhoFinal);

            celula.Style.BackColor = Color.Purple;
        }

        private void BuscaPorProfundidadeLimitada(DataGridViewCell celulaInicial, DataGridViewCell celulaFinal, long limiteProfundidade)
        {
            var pilha = new Stack<DataGridViewCell>();
            pilha.Push(celulaInicial);

            // Cria um dicionário para armazenar o caminho percorrido
            var caminho = new Dictionary<DataGridViewCell, DataGridViewCell> { [celulaInicial] = null };

            // Inicia o loop de busca por profundidade limitada
            int profundidadeAtual = 0;
            while (pilha.Count > 0)
            {
                // Obtém o próximo nó a ser visitado
                var celulaAtual = pilha.Pop();
                if (celulaAtual == celulaFinal) break;

                // Marca a célula atual como visitada
                celulaAtual.Style.BackColor = CorVisitado;

                // Verifica se a profundidade atual excede o limite de profundidade
                if (caminho[celulaAtual] != null && caminho[celulaAtual] == celulaInicial)
                {
                    profundidadeAtual = 0;
                }
                else if (profundidadeAtual > limiteProfundidade)
                {
                    continue;
                }

                // Percorre os movimentos possíveis a partir da célula atual
                foreach (var movimento in PosicoesCardeais)
                {
                    var celulaVizinhaNode = new Node()
                    {
                        posicaoX = celulaAtual.RowIndex + movimento.Y,
                        posicaoY = celulaAtual.ColumnIndex + movimento.X
                    };

                    if (celulaVizinhaNode.posicaoX >= 0 && celulaVizinhaNode.posicaoX < dataGridView1.Rows.Count && celulaVizinhaNode.posicaoY >= 0 && celulaVizinhaNode.posicaoY < dataGridView1.Columns.Count)
                    {
                        // Verifica se a célula vizinha pode ser visitada
                        DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaNode.posicaoX].Cells[celulaVizinhaNode.posicaoY];
                        if (profundidadeAtual <= limiteProfundidade)
                        {
                            if (celulaVizinha.Style.BackColor != Color.Red && !caminho.ContainsKey(celulaVizinha))
                            {
                                // Adiciona a célula vizinha à pilha de visitados e ao caminho percorrido
                                pilha.Push(celulaVizinha);
                                caminho[celulaVizinha] = celulaAtual;
                                profundidadeAtual++;
                            }
                        }
                    }
                }
            }

            if (!caminho.ContainsKey(celulaFinal))
            {
                MessageBox.Show("Célula final não alcançável a partir da célula inicial.");
                return;
            }

            // Pinta o caminho percorrido de amarelo, mantendo a célula inicial como azul e final como verde
            var celulaCaminho = caminho[celulaFinal];
            PintarCaminho(celulaCaminho, caminho, CorCaminho);
        }

        private void BuscaPorProfundidadeIterativa(DataGridViewCell celulaInicial, DataGridViewCell celulaFinal)
        {
            int profundidade = 0;
            while (true)
            {
                var pilha = new Stack<DataGridViewCell>();
                var visitados = new HashSet<DataGridViewCell>();
                var caminho = new Dictionary<DataGridViewCell, DataGridViewCell>();
                pilha.Push(celulaInicial);
                visitados.Add(celulaInicial);

                // Inicia o loop de busca por profundidade iterativa
                while (pilha.Count > 0)
                {
                    // Obtém o próximo nó a ser visitado
                    var celulaAtual = pilha.Pop();
                    if (celulaAtual == celulaFinal)
                    {
                        PintarCaminho(celulaAtual, caminho, CorCaminho);
                        return;
                    }

                    // Marca a célula atual como visitada
                    celulaAtual.Style.BackColor = CorVisitado;

                    // Percorre os movimentos possíveis a partir da célula atual
                    foreach (var movimento in PosicoesCardeais)
                    {
                        // Obtém a célula vizinha
                        var celulaVizinhaNode = new Node()
                        {
                            posicaoX = celulaAtual.RowIndex + movimento.Y,
                            posicaoY = celulaAtual.ColumnIndex + movimento.X
                        };

                        if (celulaVizinhaNode.posicaoX >= 0 && celulaVizinhaNode.posicaoX < dataGridView1.Rows.Count && celulaVizinhaNode.posicaoY >= 0 && celulaVizinhaNode.posicaoY < dataGridView1.Columns.Count)
                        {
                            DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaNode.posicaoX].Cells[celulaVizinhaNode.posicaoY];

                            // Verifica se a célula vizinha pode ser visitada
                            if (celulaVizinha.Style.BackColor != Color.Red && !visitados.Contains(celulaVizinha))
                            {
                                // Adiciona a célula vizinha à pilha de visitados e ao caminho percorrido
                                pilha.Push(celulaVizinha);
                                visitados.Add(celulaVizinha);
                                caminho[celulaVizinha] = celulaAtual;
                            }
                        }
                    }
                }

                profundidade++;
                if (profundidade > dataGridView1.Rows.Count * dataGridView1.Columns.Count)
                {
                    MessageBox.Show("Célula final não alcançável a partir da célula inicial.");
                    return;
                }
            }
        }

        private void PintarCaminho(DataGridViewCell celula, Dictionary<DataGridViewCell, DataGridViewCell> caminho, Color cor)
        {
            while (celula != null)
            {
                celula.Style.BackColor = cor;
                if (!caminho.ContainsKey(celula))
                {
                    break;
                }
                celula = caminho[celula];
            }
        }

        private void cmb_Ordenacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            var item = cmb_Ordenacao.SelectedItem.ToString();

            if (item == "Custo Uniforme" || item == "Greedy" || item == "A*")
            {
                gpb_Peso.Visible = true;
            }
            else
            {
                gpb_Peso.Visible = false;
            }
        }

        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
        }

        private void btn_DefinirGrafo_Click(object sender, EventArgs e)
        {
            btn_Limpar_Click(sender, e);

            DefinirDataGrid(int.Parse(num_Linhas.Value.ToString()), int.Parse(num_Colunas.Value.ToString()));
            if (gpb_Peso.Visible)
            {
                DefinirMovimentos(pN: int.Parse(num_Norte.Value.ToString()),
                                  pS: int.Parse(num_Sul.Value.ToString()),
                                  pO: int.Parse(num_Oeste.Value.ToString()),
                                  pL: int.Parse(num_Leste.Value.ToString()));
            }
            else
            {
                DefinirMovimentos(0, 0, 0, 0);
            }
        }

        private void BuscaPorCustoUniforme(DataGridViewCell celulaInicial, DataGridViewCell celulaFinal)
        {
            // Cria o nó inicial
            var noCelulaInicial = new Node { posicaoX = celulaInicial.ColumnIndex, posicaoY = celulaInicial.RowIndex };
            var noInicial = new BuscaComPesoNode(noCelulaInicial, 0, 0);
            noInicial.Peso = 0;
            noInicial.Principal.Add(noInicial);

            while (noInicial != null)
            {
                var noAtual = noInicial.Principal.OrderBy(n => n.PesoCaminho).FirstOrDefault();
                noInicial.Principal.Remove(noAtual);
                noInicial.Verificacao.Add(noAtual);

                // Verifica se chegou ao nó final
                if (noAtual.posicaoX == celulaFinal.ColumnIndex && noAtual.posicaoY == celulaFinal.RowIndex)
                {
                    var caminho = new List<DataGridViewCell>();
                    var celula = dataGridView1.Rows[noAtual.posicaoY].Cells[noAtual.posicaoX];

                    noAtual = noInicial.Verificacao.Last();

                    while (noAtual.Pai != null)
                    {
                        celula = dataGridView1.Rows[noAtual.posicaoY].Cells[noAtual.posicaoX];
                        celula.Style.BackColor = CorCaminho;
                        noAtual = noAtual.Pai;
                    }

                    return;
                }

                // Percorre os vizinhos do nó atual
                foreach (var vizinho in ObterVizinhosCustoUniforme(noAtual))
                {
                    // Verifica se o vizinho já está na lista principal
                    var noExistente = noInicial.Principal.FirstOrDefault(n => n.posicaoX == vizinho.posicaoX && n.posicaoY == vizinho.posicaoY);
                    if (noExistente != null)
                    {
                        if (vizinho.Peso < noExistente.Peso)
                        {
                            noInicial.Principal.Remove(noExistente);
                            noInicial.Principal.Add(vizinho);
                            vizinho.Principal = noInicial.Principal;
                            noInicial.Verificacao.Add(vizinho);
                        }
                    }
                    else
                    {
                        noInicial.Principal.Add(vizinho);
                        vizinho.Principal = noInicial.Principal;
                        noInicial.Verificacao.Add(vizinho);
                    }
                }
            }

            MessageBox.Show("Célula final não alcançável a partir da célula inicial.");
            return;
        }

        private List<BuscaComPesoNode> ObterVizinhosCustoUniforme(BuscaComPesoNode noAtual)
        {
            var vizinhos = new List<BuscaComPesoNode>();

            // Percorre os movimentos possíveis a partir da célula atual
            foreach (var movimento in PosicoesCardeais)
            {
                // Obtém a célula vizinha
                var celulaVizinhaNode = new Node()
                {
                    posicaoX = noAtual.posicaoX + movimento.X,
                    posicaoY = noAtual.posicaoY + movimento.Y
                };

                if (celulaVizinhaNode.posicaoX >= 0 && celulaVizinhaNode.posicaoX < dataGridView1.Columns.Count && celulaVizinhaNode.posicaoY >= 0 && celulaVizinhaNode.posicaoY < dataGridView1.Rows.Count)
                {
                    DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaNode.posicaoY].Cells[celulaVizinhaNode.posicaoX];

                    // Verifica se a célula vizinha pode ser visitada
                    if (celulaVizinha.Style.BackColor != Color.Red)
                    {
                        celulaVizinha.Style.BackColor = CorVisitado;

                        // Calcula a distância heurística
                        var pesoCaminho = noAtual.PesoCaminho + movimento.Peso;

                        // Cria um novo nó com PesoCaminho e Peso atualizados
                        var noVizinho = new Node { posicaoX = celulaVizinha.ColumnIndex, posicaoY = celulaVizinha.RowIndex };
                        var vizinho = new BuscaComPesoNode(atual: noVizinho, peso: pesoCaminho, pesoCaminho: pesoCaminho)
                        {
                            Principal = noAtual.Principal,
                            Pai = noAtual
                        };

                        vizinhos.Add(vizinho);
                    }
                }
            }

            return vizinhos;
        }

        private void BuscaPorGreedy(DataGridViewCell celulaInicial, DataGridViewCell celulaFinal)
        {
            // Cria o nó inicial
            var noCelulaInicial = new Node { posicaoX = celulaInicial.ColumnIndex, posicaoY = celulaInicial.RowIndex };
            var noInicial = new BuscaComPesoNode(noCelulaInicial, 0, DistanciaEuclidiana(celulaInicial, celulaFinal));
            noInicial.Principal.Add(noInicial);

            while (noInicial != null)
            {
                var noAtual = noInicial.Principal.OrderBy(n => n.PesoCaminho).FirstOrDefault();
                noInicial.Principal.Remove(noAtual);
                noInicial.Verificacao.Add(noAtual);

                // Verifica se chegou ao nó final
                if (noAtual.posicaoX == celulaFinal.ColumnIndex && noAtual.posicaoY == celulaFinal.RowIndex)
                {
                    var caminho = new List<DataGridViewCell>();
                    var celula = dataGridView1.Rows[noAtual.posicaoY].Cells[noAtual.posicaoX];

                    noAtual = noInicial.Verificacao.Last();

                    while (noAtual.Pai != null)
                    {
                        celula = dataGridView1.Rows[noAtual.posicaoY].Cells[noAtual.posicaoX];
                        celula.Style.BackColor = CorCaminho;
                        noAtual = noAtual.Pai;
                    }

                    return;
                }

                // Percorre os vizinhos do nó atual
                foreach (var vizinho in ObterVizinhosGreedy(noAtual, celulaFinal))
                {
                    // Verifica se o vizinho já está na lista principal
                    var noExistente = noInicial.Principal.FirstOrDefault(n => n.posicaoX == vizinho.posicaoX && n.posicaoY == vizinho.posicaoY);
                    if (noExistente != null)
                    {
                        if (vizinho.Peso < noExistente.Peso)
                        {
                            noInicial.Principal.Remove(noExistente);
                            noInicial.Principal.Add(vizinho);
                            vizinho.Principal = noInicial.Principal;
                            noInicial.Verificacao.Add(vizinho);
                        }
                    }
                    else
                    {
                        noInicial.Principal.Add(vizinho);
                        vizinho.Principal = noInicial.Principal;
                        noInicial.Verificacao.Add(vizinho);
                    }
                }
            }

            MessageBox.Show("Célula final não alcançável a partir da célula inicial.");
            return;
        }

        private List<BuscaComPesoNode> ObterVizinhosGreedy(BuscaComPesoNode noAtual, DataGridViewCell celulaFinal)
        {
            var vizinhos = new List<BuscaComPesoNode>();

            // Percorre os movimentos possíveis a partir da célula atual
            foreach (var movimento in PosicoesCardeais)
            {
                // Obtém a célula vizinha
                var celulaVizinhaNode = new Node()
                {
                    posicaoX = noAtual.posicaoX + movimento.X,
                    posicaoY = noAtual.posicaoY + movimento.Y
                };

                if (celulaVizinhaNode.posicaoX >= 0 && celulaVizinhaNode.posicaoX < dataGridView1.Columns.Count && celulaVizinhaNode.posicaoY >= 0 && celulaVizinhaNode.posicaoY < dataGridView1.Rows.Count)
                {
                    DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaNode.posicaoY].Cells[celulaVizinhaNode.posicaoX];

                    // Verifica se a célula vizinha pode ser visitada
                    if (celulaVizinha.Style.BackColor != Color.Red)
                    {
                        celulaVizinha.Style.BackColor = CorVisitado;

                        // Calcula a distância heurística
                        var pesoCaminho = noAtual.PesoCaminho + DistanciaEuclidiana(celulaVizinha, celulaFinal);

                        // Cria um novo nó com PesoCaminho e Peso atualizados
                        var noVizinho = new Node { posicaoX = celulaVizinha.ColumnIndex, posicaoY = celulaVizinha.RowIndex };
                        var vizinho = new BuscaComPesoNode(atual: noVizinho, peso: pesoCaminho, pesoCaminho: pesoCaminho)
                        {
                            Principal = noAtual.Principal,
                            Pai = noAtual
                        };

                        vizinhos.Add(vizinho);
                    }
                }
            }

            return vizinhos;
        }

        public int DistanciaEuclidiana(DataGridViewCell inicio, DataGridViewCell fim)
        {
            return Math.Abs(fim.ColumnIndex - inicio.ColumnIndex) + Math.Abs(fim.RowIndex - inicio.RowIndex);
        }

        private void BuscaPorAStar(DataGridViewCell celulaInicial, DataGridViewCell celulaFinal)
        {
            // Cria o nó inicial
            var noCelulaInicial = new Node { posicaoX = celulaInicial.ColumnIndex, posicaoY = celulaInicial.RowIndex };
            var noInicial = new BuscaComPesoNode(noCelulaInicial, 0, DistanciaEuclidiana(celulaInicial, celulaFinal));
            noInicial.Principal.Add(noInicial);

            while (noInicial != null)
            {
                var noAtual = noInicial.Principal.OrderBy(n => n.PesoCaminho).FirstOrDefault();
                noInicial.Principal.Remove(noAtual);
                noInicial.Verificacao.Add(noAtual);

                // Verifica se chegou ao nó final
                if (noAtual.posicaoX == celulaFinal.ColumnIndex && noAtual.posicaoY == celulaFinal.RowIndex)
                {
                    var caminho = new List<DataGridViewCell>();
                    var celula = dataGridView1.Rows[noAtual.posicaoY].Cells[noAtual.posicaoX];

                    noAtual = noInicial.Verificacao.Last();

                    while (noAtual.Pai != null)
                    {
                        celula = dataGridView1.Rows[noAtual.posicaoY].Cells[noAtual.posicaoX];
                        celula.Style.BackColor = CorCaminho;
                        noAtual = noAtual.Pai;
                    }

                    return;
                }

                // Percorre os vizinhos do nó atual
                foreach (var vizinho in ObterVizinhosAStar(noAtual, celulaFinal))
                {
                    // Verifica se o vizinho já está na lista principal
                    var noExistente = noInicial.Principal.FirstOrDefault(n => n.posicaoX == vizinho.posicaoX && n.posicaoY == vizinho.posicaoY);
                    if (noExistente != null)
                    {
                        if (vizinho.Peso < noExistente.Peso)
                        {
                            noInicial.Principal.Remove(noExistente);
                            noInicial.Principal.Add(vizinho);
                            vizinho.Principal = noInicial.Principal;
                            noInicial.Verificacao.Add(vizinho);
                        }
                    }
                    else
                    {
                        noInicial.Principal.Add(vizinho);
                        vizinho.Principal = noInicial.Principal;
                        noInicial.Verificacao.Add(vizinho);
                    }
                }
            }

            MessageBox.Show("Célula final não alcançável a partir da célula inicial.");
            return;
        }

        private List<BuscaComPesoNode> ObterVizinhosAStar(BuscaComPesoNode noAtual, DataGridViewCell celulaFinal)
        {
            var vizinhos = new List<BuscaComPesoNode>();

            // Percorre os movimentos possíveis a partir da célula atual
            foreach (var movimento in PosicoesCardeais)
            {
                // Obtém a célula vizinha
                var celulaVizinhaNode = new Node()
                {
                    posicaoX = noAtual.posicaoX + movimento.X,
                    posicaoY = noAtual.posicaoY + movimento.Y
                };

                if (celulaVizinhaNode.posicaoX >= 0 && celulaVizinhaNode.posicaoX < dataGridView1.Columns.Count && celulaVizinhaNode.posicaoY >= 0 && celulaVizinhaNode.posicaoY < dataGridView1.Rows.Count)
                {
                    DataGridViewCell celulaVizinha = dataGridView1.Rows[celulaVizinhaNode.posicaoY].Cells[celulaVizinhaNode.posicaoX];

                    // Verifica se a célula vizinha pode ser visitada
                    if (celulaVizinha.Style.BackColor != Color.Red)
                    {
                        celulaVizinha.Style.BackColor = CorVisitado;

                        // Calcula a distância heurística
                        var distanciaHeuristica = DistanciaEuclidiana(celulaVizinha, celulaFinal);
                        var pesoCaminho = noAtual.PesoCaminho + movimento.Peso + distanciaHeuristica;

                        // Cria um novo nó com PesoCaminho e Peso atualizados
                        var noVizinho = new Node { posicaoX = celulaVizinha.ColumnIndex, posicaoY = celulaVizinha.RowIndex };
                        var vizinho = new BuscaComPesoNode(atual: noVizinho, peso: pesoCaminho, pesoCaminho: pesoCaminho)
                        {
                            Principal = noAtual.Principal,
                            Pai = noAtual
                        };

                        vizinhos.Add(vizinho);
                    }
                }
            }

            return vizinhos;
        }
    }
}

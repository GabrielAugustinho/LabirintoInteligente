
namespace ProjetoBuscaOrdenacao
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmb_Element = new System.Windows.Forms.ComboBox();
            this.cmb_Ordenacao = new System.Windows.Forms.ComboBox();
            this.btn_Limpar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Apagar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_Colunas = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.num_Linhas = new System.Windows.Forms.NumericUpDown();
            this.btn_DefinirGrafo = new System.Windows.Forms.Button();
            this.num_Norte = new System.Windows.Forms.NumericUpDown();
            this.num_Oeste = new System.Windows.Forms.NumericUpDown();
            this.num_Leste = new System.Windows.Forms.NumericUpDown();
            this.num_Sul = new System.Windows.Forms.NumericUpDown();
            this.gpb_Peso = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Colunas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Linhas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Norte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Oeste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Leste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Sul)).BeginInit();
            this.gpb_Peso.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(558, 415);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // cmb_Element
            // 
            this.cmb_Element.FormattingEnabled = true;
            this.cmb_Element.Items.AddRange(new object[] {
            "Personagem",
            "Barreira",
            "Chegada"});
            this.cmb_Element.Location = new System.Drawing.Point(593, 41);
            this.cmb_Element.Name = "cmb_Element";
            this.cmb_Element.Size = new System.Drawing.Size(186, 23);
            this.cmb_Element.TabIndex = 1;
            this.cmb_Element.SelectedIndexChanged += new System.EventHandler(this.cmb_Element_SelectedIndexChanged);
            // 
            // cmb_Ordenacao
            // 
            this.cmb_Ordenacao.FormattingEnabled = true;
            this.cmb_Ordenacao.Items.AddRange(new object[] {
            "Amplitude",
            "Profundidade",
            "Prof Lim",
            "Bidirecional",
            "Aprof Interativo",
            "Custo Uniforme",
            "Greedy",
            "A*"});
            this.cmb_Ordenacao.Location = new System.Drawing.Point(593, 85);
            this.cmb_Ordenacao.Name = "cmb_Ordenacao";
            this.cmb_Ordenacao.Size = new System.Drawing.Size(186, 23);
            this.cmb_Ordenacao.TabIndex = 2;
            this.cmb_Ordenacao.SelectedIndexChanged += new System.EventHandler(this.cmb_Ordenacao_SelectedIndexChanged);
            // 
            // btn_Limpar
            // 
            this.btn_Limpar.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_Limpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Limpar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Limpar.ForeColor = System.Drawing.Color.White;
            this.btn_Limpar.Location = new System.Drawing.Point(593, 178);
            this.btn_Limpar.Name = "btn_Limpar";
            this.btn_Limpar.Size = new System.Drawing.Size(90, 35);
            this.btn_Limpar.TabIndex = 3;
            this.btn_Limpar.Text = "Limpar";
            this.btn_Limpar.UseVisualStyleBackColor = false;
            this.btn_Limpar.Click += new System.EventHandler(this.btn_Limpar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Buscar.ForeColor = System.Drawing.Color.White;
            this.btn_Buscar.Location = new System.Drawing.Point(593, 137);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(186, 35);
            this.btn_Buscar.TabIndex = 4;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Apagar
            // 
            this.btn_Apagar.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Apagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Apagar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Apagar.ForeColor = System.Drawing.Color.White;
            this.btn_Apagar.Location = new System.Drawing.Point(689, 178);
            this.btn_Apagar.Name = "btn_Apagar";
            this.btn_Apagar.Size = new System.Drawing.Size(90, 35);
            this.btn_Apagar.TabIndex = 5;
            this.btn_Apagar.Text = "Apagar";
            this.btn_Apagar.UseVisualStyleBackColor = false;
            this.btn_Apagar.Click += new System.EventHandler(this.btn_Apagar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(593, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Eventos :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Caminhos :";
            // 
            // num_Colunas
            // 
            this.num_Colunas.Location = new System.Drawing.Point(591, 415);
            this.num_Colunas.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.num_Colunas.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_Colunas.Name = "num_Colunas";
            this.num_Colunas.Size = new System.Drawing.Size(80, 23);
            this.num_Colunas.TabIndex = 8;
            this.num_Colunas.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Colunas :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(591, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Linhas :";
            // 
            // num_Linhas
            // 
            this.num_Linhas.Location = new System.Drawing.Point(591, 371);
            this.num_Linhas.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.num_Linhas.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_Linhas.Name = "num_Linhas";
            this.num_Linhas.Size = new System.Drawing.Size(80, 23);
            this.num_Linhas.TabIndex = 10;
            this.num_Linhas.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // btn_DefinirGrafo
            // 
            this.btn_DefinirGrafo.BackColor = System.Drawing.Color.LightGray;
            this.btn_DefinirGrafo.Location = new System.Drawing.Point(704, 397);
            this.btn_DefinirGrafo.Name = "btn_DefinirGrafo";
            this.btn_DefinirGrafo.Size = new System.Drawing.Size(75, 41);
            this.btn_DefinirGrafo.TabIndex = 12;
            this.btn_DefinirGrafo.Text = "Definir";
            this.btn_DefinirGrafo.UseVisualStyleBackColor = false;
            this.btn_DefinirGrafo.Click += new System.EventHandler(this.btn_DefinirGrafo_Click);
            // 
            // num_Norte
            // 
            this.num_Norte.Location = new System.Drawing.Point(15, 36);
            this.num_Norte.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_Norte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Norte.Name = "num_Norte";
            this.num_Norte.Size = new System.Drawing.Size(65, 23);
            this.num_Norte.TabIndex = 0;
            this.num_Norte.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_Oeste
            // 
            this.num_Oeste.Location = new System.Drawing.Point(113, 88);
            this.num_Oeste.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_Oeste.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Oeste.Name = "num_Oeste";
            this.num_Oeste.Size = new System.Drawing.Size(65, 23);
            this.num_Oeste.TabIndex = 14;
            this.num_Oeste.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_Leste
            // 
            this.num_Leste.Location = new System.Drawing.Point(113, 36);
            this.num_Leste.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_Leste.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Leste.Name = "num_Leste";
            this.num_Leste.Size = new System.Drawing.Size(65, 23);
            this.num_Leste.TabIndex = 15;
            this.num_Leste.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_Sul
            // 
            this.num_Sul.Location = new System.Drawing.Point(15, 88);
            this.num_Sul.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_Sul.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Sul.Name = "num_Sul";
            this.num_Sul.Size = new System.Drawing.Size(65, 23);
            this.num_Sul.TabIndex = 16;
            this.num_Sul.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gpb_Peso
            // 
            this.gpb_Peso.Controls.Add(this.label8);
            this.gpb_Peso.Controls.Add(this.label7);
            this.gpb_Peso.Controls.Add(this.label6);
            this.gpb_Peso.Controls.Add(this.label5);
            this.gpb_Peso.Controls.Add(this.num_Sul);
            this.gpb_Peso.Controls.Add(this.num_Leste);
            this.gpb_Peso.Controls.Add(this.num_Oeste);
            this.gpb_Peso.Controls.Add(this.num_Norte);
            this.gpb_Peso.Location = new System.Drawing.Point(591, 219);
            this.gpb_Peso.Name = "gpb_Peso";
            this.gpb_Peso.Size = new System.Drawing.Size(188, 123);
            this.gpb_Peso.TabIndex = 17;
            this.gpb_Peso.TabStop = false;
            this.gpb_Peso.Text = "Peso";
            this.gpb_Peso.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "O";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "L";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "S";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "N";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 445);
            this.Controls.Add(this.gpb_Peso);
            this.Controls.Add(this.btn_DefinirGrafo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.num_Linhas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_Colunas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Apagar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.btn_Limpar);
            this.Controls.Add(this.cmb_Ordenacao);
            this.Controls.Add(this.cmb_Element);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Comportamento de buscas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Colunas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Linhas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Norte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Oeste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Leste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Sul)).EndInit();
            this.gpb_Peso.ResumeLayout(false);
            this.gpb_Peso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmb_Element;
        private System.Windows.Forms.ComboBox cmb_Ordenacao;
        private System.Windows.Forms.Button btn_Limpar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_Apagar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_Colunas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_Linhas;
        private System.Windows.Forms.Button btn_DefinirGrafo;
        private System.Windows.Forms.NumericUpDown num_Norte;
        private System.Windows.Forms.NumericUpDown num_Oeste;
        private System.Windows.Forms.NumericUpDown num_Leste;
        private System.Windows.Forms.NumericUpDown num_Sul;
        private System.Windows.Forms.GroupBox gpb_Peso;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}


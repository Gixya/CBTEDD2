using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoAtendimentoWFA
{
    public partial class Form1 : Form
    {
        private Senhas senhas = new Senhas();
        private Guiches guiches = new Guiches();

        private ComboBox cmbGuiche = new ComboBox();
        private NumericUpDown numGuiches = new NumericUpDown();
        private ListBox lstSenhas = new ListBox();
        private ListBox lstAtendimentos = new ListBox();

        public Form1()
        {
            InitializeComponent();
            MontarTela();
        }

        private void MontarTela()
        {
            Text = "Projeto Atendimento";
            Size = new Size(800, 550);
            StartPosition = FormStartPosition.CenterScreen;

            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade de guichês:";
            lblQuantidade.Location = new Point(20, 20);
            lblQuantidade.AutoSize = true;
            Controls.Add(lblQuantidade);

            numGuiches.Location = new Point(170, 17);
            numGuiches.Minimum = 1;
            numGuiches.Maximum = 20;
            numGuiches.Value = 1;
            Controls.Add(numGuiches);

            Button btnAdicionar = new Button();
            btnAdicionar.Text = "Adicionar guichês";
            btnAdicionar.Location = new Point(300, 15);
            btnAdicionar.Size = new Size(140, 30);
            btnAdicionar.Click += BtnAdicionar_Click;
            Controls.Add(btnAdicionar);

            Button btnGerar = new Button();
            btnGerar.Text = "Gerar senha";
            btnGerar.Location = new Point(20, 65);
            btnGerar.Size = new Size(120, 35);
            btnGerar.Click += BtnGerar_Click;
            Controls.Add(btnGerar);

            Label lblGuiche = new Label();
            lblGuiche.Text = "Guichê:";
            lblGuiche.Location = new Point(180, 75);
            lblGuiche.AutoSize = true;
            Controls.Add(lblGuiche);

            cmbGuiche.Location = new Point(240, 70);
            cmbGuiche.Size = new Size(120, 30);
            cmbGuiche.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGuiche.SelectedIndexChanged += CmbGuiche_SelectedIndexChanged;
            Controls.Add(cmbGuiche);

            Button btnChamar = new Button();
            btnChamar.Text = "Chamar próxima senha";
            btnChamar.Location = new Point(390, 65);
            btnChamar.Size = new Size(170, 35);
            btnChamar.Click += BtnChamar_Click;
            Controls.Add(btnChamar);

            Label lblSenhas = new Label();
            lblSenhas.Text = "Senhas aguardando";
            lblSenhas.Location = new Point(20, 125);
            lblSenhas.AutoSize = true;
            Controls.Add(lblSenhas);

            lstSenhas.Location = new Point(20, 150);
            lstSenhas.Size = new Size(350, 330);
            Controls.Add(lstSenhas);

            Label lblAtendimentos = new Label();
            lblAtendimentos.Text = "Atendimentos do guichê";
            lblAtendimentos.Location = new Point(400, 125);
            lblAtendimentos.AutoSize = true;
            Controls.Add(lblAtendimentos);

            lstAtendimentos.Location = new Point(400, 150);
            lstAtendimentos.Size = new Size(350, 330);
            Controls.Add(lstAtendimentos);

            AtualizarSenhas();
        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            int quantidade = (int)numGuiches.Value;
            int proximoId = guiches.ListaGuiches.Count + 1;

            for (int i = 0; i < quantidade; i++)
            {
                Guiche guiche = new Guiche(proximoId++);
                guiches.adicionar(guiche);
                cmbGuiche.Items.Add(guiche);
            }

            if (cmbGuiche.Items.Count > 0 && cmbGuiche.SelectedIndex == -1)
                cmbGuiche.SelectedIndex = 0;

            MessageBox.Show("Guichês cadastrados.");
        }

        private void BtnGerar_Click(object sender, EventArgs e)
        {
            senhas.gerar();
            AtualizarSenhas();
        }

        private void BtnChamar_Click(object sender, EventArgs e)
        {
            if (cmbGuiche.SelectedItem == null)
            {
                MessageBox.Show("Cadastre e selecione um guichê.");
                return;
            }

            Guiche guiche = (Guiche)cmbGuiche.SelectedItem;

            if (!guiche.chamar(senhas.FilaSenhas))
            {
                MessageBox.Show("Não há senhas aguardando atendimento.");
                return;
            }

            AtualizarSenhas();
            AtualizarAtendimentos();

            MessageBox.Show("Senha chamada com sucesso.");
        }

        private void CmbGuiche_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarAtendimentos();
        }

        private void AtualizarSenhas()
        {
            lstSenhas.Items.Clear();

            foreach (Senha senha in senhas.FilaSenhas)
                lstSenhas.Items.Add(senha.dadosParciais());
        }

        private void AtualizarAtendimentos()
        {
            lstAtendimentos.Items.Clear();

            if (cmbGuiche.SelectedItem == null)
                return;

            Guiche guiche = (Guiche)cmbGuiche.SelectedItem;

            foreach (Senha senha in guiche.Atendimentos)
                lstAtendimentos.Items.Add(senha.dadosCompletos());
        }
    }
}
namespace Bilheteria
{
    public partial class Form1 : Form
    {
        private int[,] poltronas = new int[15, 40];

        private Button btnFaturamento;
        private Label lblFaturamento;
        public Form1()
        {
            InitializeComponent();

                this.Text = "Bilheteria do Teatro";
                this.Width = 1200;
                this.Height = 700;

                CriarPoltronas();
                CriarBotaoFaturamento();
                CriarLabelFaturamento();
            }

            private void CriarPoltronas()
            {
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        Button botao = new Button();

                        botao.Width = 24;
                        botao.Height = 25;

                        botao.Left = 20 + (j * 27);
                        botao.Top = 20 + (i * 32);

                        botao.Text = "";

                        botao.Tag = new int[] { i, j };

                        botao.Click += BotaoPoltrona_Click;

                        this.Controls.Add(botao);
                    }
                }
            }

            private void BotaoPoltrona_Click(object sender, EventArgs e)
            {
                Button botao = (Button)sender;

                int[] posicao = (int[])botao.Tag;

                int fileira = posicao[0];
                int poltrona = posicao[1];

                if (poltronas[fileira, poltrona] == 0)
                {
                    DialogResult resultado = MessageBox.Show(
                        "Deseja reservar como INTEIRA?\n\n" +
                        "Sim = Inteira\n" +
                        "Não = Meia entrada",
                        "Tipo de entrada",
                        MessageBoxButtons.YesNo
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        poltronas[fileira, poltrona] = 1;
                        botao.Text = "I";
                    }
                    else
                    {
                        poltronas[fileira, poltrona] = 2;
                        botao.Text = "M";
                    }
                }
                else
                {
                    if (poltronas[fileira, poltrona] == 1)
                    {
                        MessageBox.Show(
                            "Esta poltrona está ocupada com entrada inteira."
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Esta poltrona está ocupada com meia entrada."
                        );
                    }
                }
            }

            private double ObterPreco(int fileira)
            {
                if (fileira >= 0 && fileira <= 4)
                {
                    return 50.00;
                }
                else if (fileira >= 5 && fileira <= 9)
                {
                    return 30.00;
                }
                else
                {
                    return 15.00;
                }
            }

            private void CriarBotaoFaturamento()
            {
                btnFaturamento = new Button();

                btnFaturamento.Text = "Faturamento";
                btnFaturamento.Width = 150;
                btnFaturamento.Height = 40;

                btnFaturamento.Left = 20;
                btnFaturamento.Top = 520;

                btnFaturamento.Click += BtnFaturamento_Click;

                this.Controls.Add(btnFaturamento);
            }

            private void CriarLabelFaturamento()
            {
                lblFaturamento = new Label();

                lblFaturamento.Width = 500;
                lblFaturamento.Height = 50;

                lblFaturamento.Left = 200;
                lblFaturamento.Top = 520;

                lblFaturamento.Text =
                    "Faturamento ainda não calculado.";

                this.Controls.Add(lblFaturamento);
            }

            private void BtnFaturamento_Click(object sender, EventArgs e)
            {
                int quantidadeOcupados = 0;
                double valorTotal = 0;

                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        if (poltronas[i, j] == 1)
                        {
                            quantidadeOcupados++;

                            valorTotal += ObterPreco(i);
                        }
                        else if (poltronas[i, j] == 2)
                        {
                            quantidadeOcupados++;

                            valorTotal += ObterPreco(i) / 2;
                        }
                    }
                }

                lblFaturamento.Text =
                    $"Qtde de lugares ocupados: {quantidadeOcupados}\n" +
                    $"Valor da bilheteria: R$ {valorTotal:F2}";
            }
        }
    }

   


using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace ProjetoAgendaWFA
{
     public partial class Form1 : Form
    {
        private Contatos contatos = new Contatos();

        private TextBox txtNome = new TextBox();
        private TextBox txtEmail = new TextBox();
        private TextBox txtDia = new TextBox();
        private TextBox txtMes = new TextBox();
        private TextBox txtAno = new TextBox();
        private TextBox txtTipo = new TextBox();
        private TextBox txtNumero = new TextBox();

        private CheckBox chkPrincipal = new CheckBox();
        private ListBox lista = new ListBox();

        public Form1()
        {
            Text = "Projeto Agenda - Contatos";
            Size = new Size(850, 650);
            StartPosition = FormStartPosition.CenterScreen;

            CriarInterface();
        }

        private void CriarInterface()
        {
            Label titulo = new Label();
            titulo.Text = "AGENDA DE CONTATOS";
            titulo.Font = new Font("Arial", 16, FontStyle.Bold);
            titulo.Location = new Point(20, 15);
            titulo.Size = new Size(350, 30);
            Controls.Add(titulo);

            Campo("Nome:", txtNome, 20, 60);
            Campo("E-mail:", txtEmail, 20, 100);
            Campo("Dia de nascimento:", txtDia, 20, 140);
            Campo("Mês:", txtMes, 20, 180);
            Campo("Ano:", txtAno, 20, 220);
            Campo("Tipo de telefone:", txtTipo, 20, 260);
            Campo("Número:", txtNumero, 20, 300);

            chkPrincipal.Text = "Telefone principal";
            chkPrincipal.Location = new Point(150, 340);
            chkPrincipal.AutoSize = true;
            chkPrincipal.Checked = true;
            Controls.Add(chkPrincipal);

            Botao("Adicionar", 20, 390, Adicionar);
            Botao("Pesquisar", 145, 390, Pesquisar);
            Botao("Alterar", 270, 390, Alterar);
            Botao("Remover", 395, 390, Remover);
            Botao("Listar", 520, 390, Listar);

            Label tituloLista = new Label();
            tituloLista.Text = "Contatos cadastrados:";
            tituloLista.Location = new Point(20, 440);
            tituloLista.AutoSize = true;
            Controls.Add(tituloLista);

            lista.Location = new Point(20, 465);
            lista.Size = new Size(790, 130);
            lista.HorizontalScrollbar = true;
            lista.SelectedIndexChanged += SelecionarContato;
            Controls.Add(lista);
        }

        private void Campo(string texto, TextBox campo, int x, int y)
        {
            Label label = new Label();
            label.Text = texto;
            label.Location = new Point(x, y);
            label.Size = new Size(125, 25);
            Controls.Add(label);

            campo.Location = new Point(x + 130, y);
            campo.Size = new Size(220, 25);
            Controls.Add(campo);
        }

        private void Botao(string texto, int x, int y, Action acao)
        {
            Button botao = new Button();
            botao.Text = texto;
            botao.Location = new Point(x, y);
            botao.Size = new Size(110, 35);

            botao.Click += (s, e) => acao();

            Controls.Add(botao);
        }

        private Contato CriarContato()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                throw new Exception("Preencha o nome e o e-mail.");
            }

            if (!txtEmail.Text.Contains("@"))
                throw new Exception("Digite um e-mail válido.");

            int dia = int.Parse(txtDia.Text);
            int mes = int.Parse(txtMes.Text);
            int ano = int.Parse(txtAno.Text);

            Data nascimento = new Data(dia, mes, ano);

            if (new DateTime(ano, mes, dia) > DateTime.Today)
                throw new Exception("A data de nascimento não pode ser futura.");

            Contato contato = new Contato(
                txtEmail.Text.Trim(),
                txtNome.Text.Trim(),
                nascimento);

            if (!string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                Telefone telefone = new Telefone(
                    string.IsNullOrWhiteSpace(txtTipo.Text)
                        ? "Não informado" : txtTipo.Text,
                    txtNumero.Text,
                    chkPrincipal.Checked);

                contato.adicionarTelefone(telefone);
            }

            return contato;
        }

        private void Adicionar()
        {
            try
            {
                Contato contato = CriarContato();

                if (contatos.adicionar(contato))
                {
                    MessageBox.Show("Contato adicionado!");
                    Listar();
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Este e-mail já está cadastrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique os dados informados.\n" + ex.Message);
            }
        }

        private void Pesquisar()
        {
            try
            {
                Contato busca = new Contato(
                    txtEmail.Text.Trim(), "", new Data(1, 1, 2000));

                Contato contato = contatos.pesquisar(busca);

                if (contato == null)
                {
                    MessageBox.Show("Contato não encontrado.");
                    return;
                }

                PreencherCampos(contato);

                for (int i = 0; i < lista.Items.Count; i++)
                {
                    if (((Contato)lista.Items[i]).Equals(contato))
                    {
                        lista.SelectedIndex = i;
                        break;
                    }
                }

                MessageBox.Show(contato.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Informe o e-mail para pesquisar.\n" + ex.Message);
            }
        }

        private void Alterar()
        {
            try
            {
                if (lista.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um contato na lista.");
                    return;
                }

                Contato antigo = (Contato)lista.SelectedItem;
                Contato novo = CriarContato();

                // Mantém o e-mail como identificador do contato.
                if (!antigo.Email.Equals(
                    novo.Email, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Não altere o e-mail do contato.");
                    return;
                }

                // Preserva todos os telefones cadastrados.
                foreach (Telefone telefone in antigo.Telefones)
                    novo.adicionarTelefone(new Telefone(
                        telefone.Tipo, telefone.Numero, telefone.Principal));

                if (contatos.alterar(novo))
                {
                    MessageBox.Show("Contato alterado!");
                    Listar();
                    Limpar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique os dados informados.\n" + ex.Message);
            }
        }

        private void Remover()
        {
            if (lista.SelectedItem == null)
            {
                MessageBox.Show("Selecione um contato na lista.");
                return;
            }

            Contato contato = (Contato)lista.SelectedItem;

            if (MessageBox.Show(
                "Deseja remover " + contato.Nome + "?",
                "Confirmar remoção",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                contatos.remover(contato);
                Listar();
                Limpar();
                MessageBox.Show("Contato removido!");
            }
        }

        private void Listar()
        {
            lista.Items.Clear();

            foreach (Contato contato in contatos.Agenda)
                lista.Items.Add(contato);
        }

        private void SelecionarContato(object sender, EventArgs e)
        {
            if (lista.SelectedItem is Contato contato)
                PreencherCampos(contato);
        }

        private void PreencherCampos(Contato contato)
        {
            txtNome.Text = contato.Nome;
            txtEmail.Text = contato.Email;

            DateTime nascimento = DateTime.ParseExact(
                contato.DtNasc.ToString(),
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture);

            txtDia.Text = nascimento.Day.ToString();
            txtMes.Text = nascimento.Month.ToString();
            txtAno.Text = nascimento.Year.ToString();

            txtTipo.Text = "";
            txtNumero.Text = "";
            chkPrincipal.Checked = true;

            foreach (Telefone telefone in contato.Telefones)
            {
                if (telefone.Principal)
                {
                    txtTipo.Text = telefone.Tipo;
                    txtNumero.Text = telefone.Numero;
                    chkPrincipal.Checked = true;
                    break;
                }
            }
        }

        private void Limpar()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtDia.Clear();
            txtMes.Clear();
            txtAno.Clear();
            txtTipo.Clear();
            txtNumero.Clear();
            chkPrincipal.Checked = true;
            lista.ClearSelected();
        }
    }
}

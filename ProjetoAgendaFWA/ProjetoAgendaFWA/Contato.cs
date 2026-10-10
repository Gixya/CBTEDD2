using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoAgendaWFA
{
    public class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones = new List<Telefone>();

        public Contato(string email, string nome, Data dtNasc)
        {
            this.email = email;
            this.nome = nome;
            this.dtNasc = dtNasc;
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public Data DtNasc
        {
            get { return dtNasc; }
            set { dtNasc = value; }
        }

        public List<Telefone> Telefones
        {
            get { return telefones; }
        }

        public int getIdade()
        {
            DateTime nascimento = DateTime.ParseExact(
                dtNasc.ToString(), "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture);

            int idade = DateTime.Today.Year - nascimento.Year;

            if (nascimento.Date > DateTime.Today.AddYears(-idade))
                idade--;

            return idade;
        }

        public void adicionarTelefone(Telefone t)
        {
            if (t.Principal)
            {
                foreach (Telefone telefone in telefones)
                    telefone.Principal = false;
            }

            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            foreach (Telefone telefone in telefones)
            {
                if (telefone.Principal)
                    return telefone.Numero;
            }

            return "Não informado";
        }

        public override string ToString()
        {
            return nome + " | " + email +
                   " | Nascimento: " + dtNasc +
                   " | Idade: " + getIdade() +
                   " | Telefone principal: " + getTelefonePrincipal();
        }

        public override bool Equals(object obj)
        {
            if (obj is not Contato outro)
                return false;

            return email.Equals(
                outro.email, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return email.ToLowerInvariant().GetHashCode();
        }
    }
}

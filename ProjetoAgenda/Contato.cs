using System;
using System.Collections.Generic;

namespace ProjetoAgenda
{
    public class Contato
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }

        public List<Telefone> Telefones { get; set; }

        public Contato(string email, string nome, Data dtNasc)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            Telefones = new List<Telefone>();
        }

        public int GetIdade()
        {
            DateTime nascimento = new DateTime(
                DtNasc.Ano, DtNasc.Mes, DtNasc.Dia);

            int idade = DateTime.Today.Year - nascimento.Year;

            if (DateTime.Today < nascimento.AddYears(idade))
                idade--;

            return idade;
        }

        public void AdicionarTelefone(Telefone t)
        {
            Telefones.Add(t);
        }

        public string GetTelefonePrincipal()
        {
            foreach (Telefone t in Telefones)
            {
                if (t.Principal)
                    return t.Numero;
            }

            return "Não cadastrado";
        }

        public override string ToString()
        {
            string dados = "Nome: " + Nome +
                           "\nEmail: " + Email +
                           "\nNascimento: " + DtNasc +
                           "\nIdade: " + GetIdade() +
                           "\nTelefone principal: " + GetTelefonePrincipal() +
                           "\nTelefones:";

            foreach (Telefone t in Telefones)
            {
                dados += "\n- " + t;
                if (t.Principal)
                    dados += " (Principal)";
            }

            return dados;
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato outro)
                return Email.Equals(
                    outro.Email,
                    StringComparison.OrdinalIgnoreCase);

            return false;
        }

        public override int GetHashCode()
        {
            return Email.ToLower().GetHashCode();
        }
    }
}

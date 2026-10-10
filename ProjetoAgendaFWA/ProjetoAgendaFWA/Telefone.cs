using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoAgendaWFA
{
    public class Telefone
    {
        private string tipo;
        private string numero;
        private bool principal;

        public Telefone(string tipo, string numero, bool principal)
        {
            this.tipo = tipo;
            this.numero = numero;
            this.principal = principal;
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public bool Principal
        {
            get { return principal; }
            set { principal = value; }
        }

        public override string ToString()
        {
            return tipo + ": " + numero;
        }
    }
}

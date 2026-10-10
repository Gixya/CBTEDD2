using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoAgendaWFA
{
    public class Contatos
    {
        private List<Contato> agenda = new List<Contato>();

        public IReadOnlyList<Contato> Agenda
        {
            get { return agenda.AsReadOnly(); }
        }

        public bool adicionar(Contato c)
        {
            if (pesquisar(c) != null)
                return false;

            agenda.Add(c);
            return true;
        }

        public Contato pesquisar(Contato c)
        {
            foreach (Contato contato in agenda)
            {
                if (contato.Equals(c))
                    return contato;
            }

            return null;
        }

        public bool alterar(Contato c)
        {
            Contato antigo = pesquisar(c);

            if (antigo == null)
                return false;

            int indice = agenda.IndexOf(antigo);
            agenda[indice] = c;

            return true;
        }

        public bool remover(Contato c)
        {
            Contato contato = pesquisar(c);

            if (contato == null)
                return false;

            agenda.Remove(contato);
            return true;
        }
    }
}

using System.Collections.Generic;

namespace ProjetoAgenda
{
    public class Contatos
    {
        private readonly List<Contato> agenda = new List<Contato>();

        public bool Adicionar(Contato c)
        {
            if (Pesquisar(c) != null)
                return false;

            agenda.Add(c);
            return true;
        }

        public Contato Pesquisar(Contato c)
        {
            foreach (Contato contato in agenda)
            {
                if (contato.Equals(c))
                    return contato;
            }

            return null;
        }

        public bool Alterar(Contato c)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Equals(c))
                {
                    agenda[i] = c;
                    return true;
                }
            }

            return false;
        }

        public bool Remover(Contato c)
        {
            Contato contato = Pesquisar(c);

            if (contato == null)
                return false;

            agenda.Remove(contato);
            return true;
        }

        public void Listar()
        {
            foreach (Contato c in agenda)
            {
                System.Console.WriteLine(c);
                System.Console.WriteLine("--------------------");
            }
        }
    }
}

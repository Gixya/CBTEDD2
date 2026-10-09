using System.Collections.Generic;

namespace ProjetoGerenciador
{
    public class Projetos
    {
        private List<Projeto> itens = new List<Projeto>();

        public bool Adicionar(Projeto p)
        {
            if (Buscar(p) != null)
                return false;

            itens.Add(p);
            return true;
        }

        public bool Remover(Projeto p)
        {
            Projeto projeto = Buscar(p);

            if (projeto == null || projeto.Tarefas.Count > 0)
                return false;

            itens.Remove(projeto);
            return true;
        }

        public Projeto Buscar(Projeto p)
        {
            foreach (Projeto projeto in itens)
            {
                if (projeto.Id == p.Id)
                    return projeto;
            }

            return null;
        }

        public List<Projeto> Listar()
        {
            return itens;
        }
    }
}

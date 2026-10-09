using System.Collections.Generic;

namespace ProjetoGerenciador
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Tarefa> Tarefas { get; set; }

        public Projeto(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Tarefas = new List<Tarefa>();
        }

        public void AdicionarTarefa(Tarefa t)
        {
            Tarefas.Add(t);
        }

        public bool RemoverTarefa(Tarefa t)
        {
            return Tarefas.Remove(t);
        }

        public Tarefa BuscarTarefa(Tarefa t)
        {
            foreach (Tarefa tarefa in Tarefas)
            {
                if (tarefa.Id == t.Id)
                    return tarefa;
            }

            return null;
        }

        public List<Tarefa> TarefasPorStatus(string s)
        {
            List<Tarefa> resultado = new List<Tarefa>();

            foreach (Tarefa t in Tarefas)
            {
                if (t.Status.ToLower() == s.ToLower())
                    resultado.Add(t);
            }

            return resultado;
        }

        public List<Tarefa> TarefasPorPrioridade(int p)
        {
            List<Tarefa> resultado = new List<Tarefa>();

            foreach (Tarefa t in Tarefas)
            {
                if (t.Prioridade == p)
                    resultado.Add(t);
            }

            return resultado;
        }

        public int TotalAbertas()
        {
            return TarefasPorStatus("Aberta").Count;
        }

        public int TotalFechadas()
        {
            return TarefasPorStatus("Fechada").Count;
        }
    }
}

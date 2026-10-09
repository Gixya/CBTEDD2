using System;

namespace ProjetoGerenciador
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }

        public Tarefa(int id, string titulo, string descricao, int prioridade)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = "Aberta";
            DataCriacao = DateTime.Now;
            DataConclusao = DateTime.MinValue;
        }

        public void Concluir()
        {
            if (Status == "Aberta")
            {
                Status = "Fechada";
                DataConclusao = DateTime.Now;
            }
        }

        public void Cancelar()
        {
            if (Status == "Aberta")
            {
                Status = "Cancelada";
            }
        }

        public void Reabrir()
        {
            if (Status == "Fechada" || Status == "Cancelada")
            {
                Status = "Aberta";
                DataConclusao = DateTime.MinValue;
            }
        }

        public override string ToString()
        {
            string prioridadeTexto = Prioridade == 1 ? "Alta" :
                                    Prioridade == 2 ? "Média" : "Baixa";

            return "ID: " + Id +
                   "\nTítulo: " + Titulo +
                   "\nDescrição: " + Descricao +
                   "\nPrioridade: " + prioridadeTexto +
                   "\nStatus: " + Status +
                   "\nData de criação: " + DataCriacao.ToString("dd/MM/yyyy") +
                   "\nData de conclusão: " +
                   (DataConclusao == DateTime.MinValue
                       ? "Não concluída"
                       : DataConclusao.ToString("dd/MM/yyyy"));
        }
    }
}

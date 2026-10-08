using System;

namespace ProjetoBiblioteca
{
    public class Emprestimo
    {
        public DateTime DtEmprestimo { get; set; }
        public DateTime? DtDevolucao { get; set; }

        public Emprestimo()
        {
            DtEmprestimo = DateTime.Now;
            DtDevolucao = null;
        }

        public void Devolver()
        {
            DtDevolucao = DateTime.Now;
        }

        public override string ToString()
        {
            string devolucao = DtDevolucao.HasValue
                ? DtDevolucao.Value.ToString("dd/MM/yyyy")
                : "Em aberto";

            return "Empréstimo: " + DtEmprestimo.ToString("dd/MM/yyyy") +
                   " | Devolução: " + devolucao;
        }
    }
}

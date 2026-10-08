using System.Collections.Generic;

namespace ProjetoBiblioteca
{
    public class Exemplar
    {
        public int Tombo { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }

        public Exemplar(int tombo)
        {
            Tombo = tombo;
            Emprestimos = new List<Emprestimo>();
        }

        public bool Disponivel()
        {
            if (Emprestimos.Count == 0)
                return true;

            Emprestimo ultimo = Emprestimos[Emprestimos.Count - 1];

            return ultimo.DtDevolucao != null;
        }

        public bool Emprestar()
        {
            if (!Disponivel())
                return false;

            Emprestimos.Add(new Emprestimo());
            return true;
        }

        public bool Devolver()
        {
            if (Disponivel())
                return false;

            Emprestimos[Emprestimos.Count - 1].Devolver();
            return true;
        }

        public int QtdeEmprestimos()
        {
            return Emprestimos.Count;
        }
    }
}

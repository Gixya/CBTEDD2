using System.Collections.Generic;

namespace ProjetoBiblioteca
{
    public class Livro
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }

        public List<Exemplar> Exemplares { get; set; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Exemplares = new List<Exemplar>();
        }

        public void AdicionarExemplar(Exemplar exemplar)
        {
            Exemplares.Add(exemplar);
        }

        public int QtdeExemplares()
        {
            return Exemplares.Count;
        }

        public int QtdeDisponiveis()
        {
            int total = 0;

            foreach (Exemplar e in Exemplares)
            {
                if (e.Disponivel())
                    total++;
            }

            return total;
        }

        public int QtdeEmprestimos()
        {
            int total = 0;

            foreach (Exemplar e in Exemplares)
            {
                total += e.QtdeEmprestimos();
            }

            return total;
        }

        public double PercDisponibilidade()
        {
            if (QtdeExemplares() == 0)
                return 0;

            return (double)QtdeDisponiveis() / QtdeExemplares() * 100;
        }

        public override string ToString()
        {
            return "ISBN: " + Isbn +
                   "\nTítulo: " + Titulo +
                   "\nAutor: " + Autor +
                   "\nEditora: " + Editora +
                   "\nTotal de exemplares: " + QtdeExemplares() +
                   "\nExemplares disponíveis: " + QtdeDisponiveis() +
                   "\nEmpréstimos realizados: " + QtdeEmprestimos() +
                   "\nDisponibilidade: " + PercDisponibilidade().ToString("F2") + "%";
        }
    }
}

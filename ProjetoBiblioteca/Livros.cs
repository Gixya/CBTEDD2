using System.Collections.Generic;

namespace ProjetoBiblioteca
{
    public class Livros
    {
        private List<Livro> acervo = new List<Livro>();

        public void Adicionar(Livro livro)
        {
            if (Pesquisar(livro) == null)
                acervo.Add(livro);
        }

        public Livro Pesquisar(Livro livro)
        {
            foreach (Livro l in acervo)
            {
                if (l.Isbn == livro.Isbn)
                    return l;
            }

            return null;
        }

        public List<Livro> Listar()
        {
            return acervo;
        }
    }
}

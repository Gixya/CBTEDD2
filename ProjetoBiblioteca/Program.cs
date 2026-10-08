using System;
using System.Globalization;

namespace ProjetoBiblioteca
{
    class Program
    {
        static Livros biblioteca = new Livros();
        static int proximoTombo = 1;

        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\n===== BIBLIOTECA =====");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar livro");
                Console.WriteLine("2 - Pesquisar livro (sintético)");
                Console.WriteLine("3 - Pesquisar livro (analítico)");
                Console.WriteLine("4 - Adicionar exemplar");
                Console.WriteLine("5 - Registrar empréstimo");
                Console.WriteLine("6 - Registrar devolução");
                Console.Write("Escolha: ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        PesquisarSintetico();
                        break;
                    case 3:
                        PesquisarAnalitico();
                        break;
                    case 4:
                        AdicionarExemplar();
                        break;
                    case 5:
                        RegistrarEmprestimo();
                        break;
                    case 6:
                        RegistrarDevolucao();
                        break;
                    case 0:
                        Console.WriteLine("Programa encerrado.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static Livro BuscarLivro()
        {
            Console.Write("ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro pesquisa = new Livro(isbn, "", "", "");

            Livro livro = biblioteca.Pesquisar(pesquisa);

            if (livro == null)
                Console.WriteLine("Livro não encontrado.");

            return livro;
        }

        static void AdicionarLivro()
        {
            Console.Write("ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro pesquisa = new Livro(isbn, "", "", "");

            if (biblioteca.Pesquisar(pesquisa) != null)
            {
                Console.WriteLine("Esse ISBN já está cadastrado.");
                return;
            }

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Editora: ");
            string editora = Console.ReadLine();

            Livro livro = new Livro(isbn, titulo, autor, editora);
            biblioteca.Adicionar(livro);

            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        static void PesquisarSintetico()
        {
            Livro livro = BuscarLivro();

            if (livro != null)
                Console.WriteLine("\n" + livro);
        }

        static void PesquisarAnalitico()
        {
            Livro livro = BuscarLivro();

            if (livro == null)
                return;

            Console.WriteLine("\n" + livro);
            Console.WriteLine("\n===== EXEMPLARES =====");

            foreach (Exemplar e in livro.Exemplares)
            {
                Console.WriteLine("\nTombo: " + e.Tombo);
                Console.WriteLine("Disponível: " +
                    (e.Disponivel() ? "Sim" : "Não"));

                Console.WriteLine("Histórico de empréstimos:");

                if (e.Emprestimos.Count == 0)
                    Console.WriteLine("Nenhum empréstimo realizado.");

                foreach (Emprestimo emp in e.Emprestimos)
                    Console.WriteLine(emp);
            }
        }

        static void AdicionarExemplar()
        {
            Livro livro = BuscarLivro();

            if (livro == null)
                return;

            Exemplar exemplar = new Exemplar(proximoTombo++);
            livro.AdicionarExemplar(exemplar);

            Console.WriteLine("Exemplar adicionado!");
            Console.WriteLine("Número do tombo: " + exemplar.Tombo);
        }

        static void RegistrarEmprestimo()
        {
            Livro livro = BuscarLivro();

            if (livro == null)
                return;

            foreach (Exemplar e in livro.Exemplares)
            {
                if (e.Emprestar())
                {
                    Console.WriteLine("Empréstimo registrado!");
                    Console.WriteLine("Tombo do exemplar: " + e.Tombo);
                    return;
                }
            }

            Console.WriteLine("Não existem exemplares disponíveis.");
        }

        static void RegistrarDevolucao()
        {
            Livro livro = BuscarLivro();

            if (livro == null)
                return;

            Console.Write("Tombo do exemplar: ");
            int tombo = int.Parse(Console.ReadLine());

            foreach (Exemplar e in livro.Exemplares)
            {
                if (e.Tombo == tombo)
                {
                    if (e.Devolver())
                        Console.WriteLine("Devolução registrada!");
                    else
                        Console.WriteLine("Esse exemplar não está emprestado.");

                    return;
                }
            }

            Console.WriteLine("Exemplar não encontrado.");
        }
    }
}b

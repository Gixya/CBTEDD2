using System;

namespace ProjetoAgenda
{
    class Program
    {
        static Contatos agenda = new Contatos();

        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\n===== AGENDA DE CONTATOS =====");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar contato");
                Console.WriteLine("2 - Pesquisar contato");
                Console.WriteLine("3 - Alterar contato");
                Console.WriteLine("4 - Remover contato");
                Console.WriteLine("5 - Listar contatos");
                Console.Write("Escolha: ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        Adicionar();
                        break;

                    case 2:
                        Pesquisar();
                        break;

                    case 3:
                        Alterar();
                        break;

                    case 4:
                        Remover();
                        break;

                    case 5:
                        agenda.Listar();
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

        static Contato CriarContato(string email)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Data de nascimento:");
            Console.Write("Dia: ");
            int dia = int.Parse(Console.ReadLine());

            Console.Write("Mês: ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            Data data = new Data(dia, mes, ano);

            Contato contato = new Contato(email, nome, data);

            string resposta;

            do
            {
                Console.Write("Tipo de telefone (celular, casa etc.): ");
                string tipo = Console.ReadLine();

                Console.Write("Número: ");
                string numero = Console.ReadLine();

                Console.Write("É o telefone principal? (s/n): ");
                resposta = Console.ReadLine().ToLower();

                bool principal = resposta == "s";

                contato.AdicionarTelefone(
                    new Telefone(tipo, numero, principal));

                Console.Write("Adicionar outro telefone? (s/n): ");
                resposta = Console.ReadLine().ToLower();

            } while (resposta == "s");

            return contato;
        }

        static string LerEmail()
        {
            Console.Write("Email do contato: ");
            return Console.ReadLine();
        }

        static Contato BuscarPorEmail(string email)
        {
            Contato pesquisa = new Contato(
                email, "", new Data(1, 1, 2000));

            return agenda.Pesquisar(pesquisa);
        }

        static void Adicionar()
        {
            string email = LerEmail();

            Contato contato = CriarContato(email);

            if (agenda.Adicionar(contato))
                Console.WriteLine("Contato adicionado!");
            else
                Console.WriteLine("Esse email já está cadastrado.");
        }

        static void Pesquisar()
        {
            string email = LerEmail();

            Contato contato = BuscarPorEmail(email);

            if (contato != null)
                Console.WriteLine(contato);
            else
                Console.WriteLine("Contato não encontrado.");
        }

        static void Alterar()
        {
            string email = LerEmail();

            Contato antigo = BuscarPorEmail(email);

            if (antigo == null)
            {
                Console.WriteLine("Contato não encontrado.");
                return;
            }

            Contato novo = CriarContato(antigo.Email);

            if (agenda.Alterar(novo))
                Console.WriteLine("Contato alterado!");
        }

        static void Remover()
        {
            string email = LerEmail();

            Contato contato = BuscarPorEmail(email);

            if (contato != null && agenda.Remover(contato))
                Console.WriteLine("Contato removido!");
            else
                Console.WriteLine("Contato não encontrado.");
        }
    }
}

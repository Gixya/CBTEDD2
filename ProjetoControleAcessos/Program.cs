using System;

namespace ProjetoControleAcessos
{
    internal class Program
    {
        static Cadastro cadastro = new Cadastro();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("\n--- CONTROLE DE ACESSOS ---");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Cadastrar ambiente");
                Console.WriteLine("2 - Consultar ambiente");
                Console.WriteLine("3 - Excluir ambiente");
                Console.WriteLine("4 - Cadastrar usuário");
                Console.WriteLine("5 - Consultar usuário");
                Console.WriteLine("6 - Excluir usuário");
                Console.WriteLine("7 - Conceder permissão");
                Console.WriteLine("8 - Revogar permissão");
                Console.WriteLine("9 - Registrar acesso");
                Console.WriteLine("10 - Consultar logs");
                Console.Write("Opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                    opcao = -1;

                switch (opcao)
                {
                    case 1:
                        CadastrarAmbiente();
                        break;

                    case 2:
                        ConsultarAmbiente();
                        break;

                    case 3:
                        ExcluirAmbiente();
                        break;

                    case 4:
                        CadastrarUsuario();
                        break;

                    case 5:
                        ConsultarUsuario();
                        break;

                    case 6:
                        ExcluirUsuario();
                        break;

                    case 7:
                        AlterarPermissao(true);
                        break;

                    case 8:
                        AlterarPermissao(false);
                        break;

                    case 9:
                        RegistrarAcesso();
                        break;

                    case 10:
                        ConsultarLogs();
                        break;

                    case 0:
                        Console.WriteLine("Programa encerrado.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 0);
        }

        static void CadastrarAmbiente()
        {
            Console.Write("ID do ambiente: ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Ambiente ambiente = cadastro.pesquisarAmbiente(
                new Ambiente(id, ""));

            if (ambiente.Id != 0)
            {
                Console.WriteLine("Esse ambiente já existe.");
                return;
            }

            Console.Write("Nome do ambiente: ");
            string nome = Console.ReadLine();

            cadastro.adicionarAmbiente(new Ambiente(id, nome));

            Console.WriteLine("Ambiente cadastrado.");
        }

        static void ConsultarAmbiente()
        {
            Console.Write("ID do ambiente: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Ambiente ambiente = cadastro.pesquisarAmbiente(
                new Ambiente(id, ""));

            if (ambiente.Id == 0)
            {
                Console.WriteLine("Ambiente não encontrado.");
                return;
            }

            Console.WriteLine(ambiente);
            Console.WriteLine("Quantidade de logs: " + ambiente.Logs.Count);
        }

        static void ExcluirAmbiente()
        {
            Console.Write("ID do ambiente: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            bool resultado = cadastro.removerAmbiente(
                new Ambiente(id, ""));

            Console.WriteLine(resultado
                ? "Ambiente removido."
                : "Ambiente não encontrado.");
        }

        static void CadastrarUsuario()
        {
            Console.Write("ID do usuário: ");

            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Usuario usuario = cadastro.pesquisarUsuario(
                new Usuario(id, ""));

            if (usuario.Id != 0)
            {
                Console.WriteLine("Esse usuário já existe.");
                return;
            }

            Console.Write("Nome do usuário: ");
            string nome = Console.ReadLine();

            cadastro.adicionarUsuario(new Usuario(id, nome));

            Console.WriteLine("Usuário cadastrado.");
        }

        static void ConsultarUsuario()
        {
            Console.Write("ID do usuário: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Usuario usuario = cadastro.pesquisarUsuario(
                new Usuario(id, ""));

            if (usuario.Id == 0)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            Console.WriteLine(usuario);
            Console.WriteLine("Ambientes autorizados:");

            foreach (Ambiente ambiente in usuario.Ambientes)
                Console.WriteLine(ambiente);
        }

        static void ExcluirUsuario()
        {
            Console.Write("ID do usuário: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            bool resultado = cadastro.removerUsuario(
                new Usuario(id, ""));

            Console.WriteLine(resultado
                ? "Usuário removido."
                : "Usuário não encontrado.");
        }

        static void AlterarPermissao(bool conceder)
        {
            Console.Write("ID do usuário: ");

            if (!int.TryParse(Console.ReadLine(), out int idUsuario))
                return;

            Usuario usuario = cadastro.pesquisarUsuario(
                new Usuario(idUsuario, ""));

            if (usuario.Id == 0)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            Console.Write("ID do ambiente: ");

            if (!int.TryParse(Console.ReadLine(), out int idAmbiente))
                return;

            Ambiente ambiente = cadastro.pesquisarAmbiente(
                new Ambiente(idAmbiente, ""));

            if (ambiente.Id == 0)
            {
                Console.WriteLine("Ambiente não encontrado.");
                return;
            }

            bool resultado;

            if (conceder)
                resultado = usuario.concederPermissao(ambiente);
            else
                resultado = usuario.revogarPermissao(ambiente);

            if (resultado)
                Console.WriteLine("Permissão alterada com sucesso.");
            else
                Console.WriteLine("Não foi possível alterar a permissão.");
        }

        static void RegistrarAcesso()
        {
            Console.Write("ID do ambiente: ");

            if (!int.TryParse(Console.ReadLine(), out int idAmbiente))
                return;

            Ambiente ambiente = cadastro.pesquisarAmbiente(
                new Ambiente(idAmbiente, ""));

            if (ambiente.Id == 0)
            {
                Console.WriteLine("Ambiente não encontrado.");
                return;
            }

            Console.Write("ID do usuário: ");

            if (!int.TryParse(Console.ReadLine(), out int idUsuario))
                return;

            Usuario usuario = cadastro.pesquisarUsuario(
                new Usuario(idUsuario, ""));

            if (usuario.Id == 0)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            bool autorizado = usuario.possuiPermissao(ambiente);

            Log log = new Log(usuario, autorizado);

            ambiente.registrarLog(log);

            if (autorizado)
                Console.WriteLine("Acesso autorizado!");
            else
                Console.WriteLine("Acesso negado!");
        }

        static void ConsultarLogs()
        {
            Console.Write("ID do ambiente: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Ambiente ambiente = cadastro.pesquisarAmbiente(
                new Ambiente(id, ""));

            if (ambiente.Id == 0)
            {
                Console.WriteLine("Ambiente não encontrado.");
                return;
            }

            Console.WriteLine("\n1 - Todos os logs");
            Console.WriteLine("2 - Somente autorizados");
            Console.WriteLine("3 - Somente negados");
            Console.Write("Escolha: ");

            if (!int.TryParse(Console.ReadLine(), out int filtro) ||
                filtro < 1 || filtro > 3)
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            Console.WriteLine("\n--- LOGS DE " + ambiente.Nome + " ---");

            foreach (Log log in ambiente.Logs)
            {
                if (filtro == 1 ||
                    (filtro == 2 && log.TipoAcesso) ||
                    (filtro == 3 && !log.TipoAcesso))
                {
                    Console.WriteLine(log);
                }
            }
        }
    }
}

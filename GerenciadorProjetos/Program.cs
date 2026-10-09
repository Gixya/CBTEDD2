using System;
using System.Collections.Generic;

namespace ProjetoGerenciador
{
    class Program
    {
        static Projetos projetos = new Projetos();
        static int proximoProjeto = 1;
        static int proximaTarefa = 1;

        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("\nGERENCIADOR DE PROJETOS");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar projeto");
                Console.WriteLine("2 - Pesquisar projeto");
                Console.WriteLine("3 - Remover projeto");
                Console.WriteLine("4 - Adicionar tarefa");
                Console.WriteLine("5 - Concluir tarefa");
                Console.WriteLine("6 - Cancelar tarefa");
                Console.WriteLine("7 - Reabrir tarefa");
                Console.WriteLine("8 - Listar tarefas de um projeto");
                Console.WriteLine("9 - Filtrar tarefas de um projeto");
                Console.WriteLine("10 - Filtrar tarefas de todos os projetos");
                Console.WriteLine("11 - Resumo geral");
                Console.Write("Escolha: ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1: AdicionarProjeto(); break;
                    case 2: PesquisarProjeto(); break;
                    case 3: RemoverProjeto(); break;
                    case 4: AdicionarTarefa(); break;
                    case 5: AlterarStatus("concluir"); break;
                    case 6: AlterarStatus("cancelar"); break;
                    case 7: AlterarStatus("reabrir"); break;
                    case 8: ListarTarefas(); break;
                    case 9: FiltrarProjeto(); break;
                    case 10: FiltrarTodos(); break;
                    case 11: ResumoGeral(); break;
                    case 0: Console.WriteLine("Programa encerrado."); break;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        static Projeto BuscarProjeto()
        {
            Console.Write("ID do projeto: ");
            int id = int.Parse(Console.ReadLine());

            return projetos.Buscar(new Projeto(id, ""));
        }

        static void AdicionarProjeto()
        {
            Console.Write("Nome do projeto: ");
            string nome = Console.ReadLine();

            Projeto p = new Projeto(proximoProjeto, nome);

            if (projetos.Adicionar(p))
            {
                Console.WriteLine("Projeto cadastrado. ID: " + proximoProjeto);
                proximoProjeto++;
            }
        }

        static void PesquisarProjeto()
        {
            Projeto p = BuscarProjeto();

            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            Console.WriteLine("\nProjeto: " + p.Nome);
            Console.WriteLine("Tarefas abertas: " + p.TotalAbertas());
            Console.WriteLine("Tarefas fechadas: " + p.TotalFechadas());

            Console.WriteLine("\nTarefas abertas:");
            MostrarTarefas(p.TarefasPorStatus("Aberta"));

            Console.WriteLine("\nTarefas fechadas:");
            MostrarTarefas(p.TarefasPorStatus("Fechada"));

            Console.WriteLine("\nTarefas canceladas:");
            MostrarTarefas(p.TarefasPorStatus("Cancelada"));
        }

        static void RemoverProjeto()
        {
            Projeto p = BuscarProjeto();

            if (p != null && projetos.Remover(p))
                Console.WriteLine("Projeto removido.");
            else
                Console.WriteLine("Não foi possível remover. Verifique se o projeto existe e não possui tarefas.");
        }

        static void AdicionarTarefa()
        {
            Projeto p = BuscarProjeto();

            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Prioridade: 1-Alta, 2-Média, 3-Baixa");
            Console.Write("Escolha: ");
            int prioridade = int.Parse(Console.ReadLine());

            if (prioridade < 1 || prioridade > 3)
            {
                Console.WriteLine("Prioridade inválida.");
                return;
            }

            Tarefa t = new Tarefa(proximaTarefa, titulo, descricao, prioridade);

            p.AdicionarTarefa(t);

            Console.WriteLine("Tarefa cadastrada. ID: " + proximaTarefa);
            proximaTarefa++;
        }

        static void AlterarStatus(string acao)
        {
            Projeto p = BuscarProjeto();

            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            Console.Write("ID da tarefa: ");
            int id = int.Parse(Console.ReadLine());

            Tarefa t = p.BuscarTarefa(new Tarefa(id, "", "", 1));

            if (t == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }

            if (acao == "concluir")
                t.Concluir();
            else if (acao == "cancelar")
                t.Cancelar();
            else
                t.Reabrir();

            Console.WriteLine("Status atual: " + t.Status);
        }

        static void ListarTarefas()
        {
            Projeto p = BuscarProjeto();

            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            MostrarTarefas(p.Tarefas);
        }

        static void FiltrarProjeto()
        {
            Projeto p = BuscarProjeto();

            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            Filtrar(p.Tarefas);
        }

        static void FiltrarTodos()
        {
            foreach (Projeto p in projetos.Listar())
            {
                Console.WriteLine("\nProjeto: " + p.Nome);
                Filtrar(p.Tarefas);
            }
        }

        static void Filtrar(List<Tarefa> tarefas)
        {
            Console.WriteLine("1 - Filtrar por status");
            Console.WriteLine("2 - Filtrar por prioridade");
            Console.Write("Escolha: ");
            int tipo = int.Parse(Console.ReadLine());

            List<Tarefa> resultado = new List<Tarefa>();

            if (tipo == 1)
            {
                Console.Write("Status (Aberta, Fechada ou Cancelada): ");
                string status = Console.ReadLine();

                foreach (Tarefa t in tarefas)
                {
                    if (t.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                        resultado.Add(t);
                }
            }
            else if (tipo == 2)
            {
                Console.Write("Prioridade (1-Alta, 2-Média, 3-Baixa): ");
                int prioridade = int.Parse(Console.ReadLine());

                foreach (Tarefa t in tarefas)
                {
                    if (t.Prioridade == prioridade)
                        resultado.Add(t);
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            MostrarTarefas(resultado);
        }

        static void MostrarTarefas(List<Tarefa> tarefas)
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }

            foreach (Tarefa t in tarefas)
            {
                Console.WriteLine("\n" + t);
                Console.WriteLine("--------------------");
            }
        }

        static void ResumoGeral()
        {
            int totalProjetos = projetos.Listar().Count;
            int abertas = 0;
            int fechadas = 0;
            int canceladas = 0;

            foreach (Projeto p in projetos.Listar())
            {
                abertas += p.TarefasPorStatus("Aberta").Count;
                fechadas += p.TarefasPorStatus("Fechada").Count;
                canceladas += p.TarefasPorStatus("Cancelada").Count;
            }

            double percentual = abertas + fechadas == 0
                ? 0
                : (double)fechadas / (abertas + fechadas) * 100;

            Console.WriteLine("\n===== RESUMO GERAL =====");
            Console.WriteLine("Projetos: " + totalProjetos);
            Console.WriteLine("Tarefas abertas: " + abertas);
            Console.WriteLine("Tarefas fechadas: " + fechadas);
            Console.WriteLine("Tarefas canceladas: " + canceladas);
            Console.WriteLine("Percentual concluído: " + percentual.ToString("F2") + "%");
        }
    }
}

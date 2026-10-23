using System;

namespace ProjetoMedicamentos
{
    internal class Program
    {
        static Medicamentos medicamentos = new Medicamentos();
        static int proximoLote = 1;

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("\n--- FARMÁCIA ---");
                Console.WriteLine("0 - Finalizar processo");
                Console.WriteLine("1 - Cadastrar medicamento");
                Console.WriteLine("2 - Consultar medicamento (sintético)");
                Console.WriteLine("3 - Consultar medicamento (analítico)");
                Console.WriteLine("4 - Comprar medicamento");
                Console.WriteLine("5 - Vender medicamento");
                Console.WriteLine("6 - Listar medicamentos");
                Console.Write("Opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                    opcao = -1;

                switch (opcao)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Consultar(false);
                        break;
                    case 3:
                        Consultar(true);
                        break;
                    case 4:
                        Comprar();
                        break;
                    case 5:
                        Vender();
                        break;
                    case 6:
                        Listar();
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

        static void Cadastrar()
        {
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            if (medicamentos.pesquisar(new Medicamento(id, "", "")).Id != 0)
            {
                Console.WriteLine("Já existe um medicamento com esse ID.");
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Laboratório: ");
            string laboratorio = Console.ReadLine();

            medicamentos.adicionar(new Medicamento(id, nome, laboratorio));

            Console.WriteLine("Medicamento cadastrado.");
        }

        static void Consultar(bool analitico)
        {
            Console.Write("ID do medicamento: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Medicamento medicamento =
                medicamentos.pesquisar(new Medicamento(id, "", ""));

            if (medicamento.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado.");
                return;
            }

            Console.WriteLine(medicamento);

            if (analitico)
            {
                Console.WriteLine("Lotes:");

                foreach (Lote lote in medicamento.Lotes)
                    Console.WriteLine(lote);
            }
        }

        static void Comprar()
        {
            Console.Write("ID do medicamento: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Medicamento medicamento =
                medicamentos.pesquisar(new Medicamento(id, "", ""));

            if (medicamento.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado.");
                return;
            }

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) ||
                quantidade <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            Console.Write("Data de vencimento (dd/MM/yyyy): ");
            if (!DateTime.TryParseExact(
                Console.ReadLine(),
                "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime vencimento))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            Lote lote = new Lote(proximoLote++, quantidade, vencimento);
            medicamento.comprar(lote);

            Console.WriteLine("Lote cadastrado.");
        }

        static void Vender()
        {
            Console.Write("ID do medicamento: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            Medicamento medicamento =
                medicamentos.pesquisar(new Medicamento(id, "", ""));

            if (medicamento.Id == 0)
            {
                Console.WriteLine("Medicamento não encontrado.");
                return;
            }

            Console.Write("Quantidade para vender: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade))
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            if (medicamento.vender(quantidade))
                Console.WriteLine("Venda realizada.");
            else
                Console.WriteLine("Quantidade indisponível ou inválida.");
        }

        static void Listar()
        {
            if (medicamentos.listar().Count == 0)
            {
                Console.WriteLine("Nenhum medicamento cadastrado.");
                return;
            }

            foreach (Medicamento medicamento in medicamentos.listar())
                Console.WriteLine(medicamento);
        }
    }
}

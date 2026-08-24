using System;

public class Class1
{
	public Class1()
	{
	}
}

class Program
{
    static void Main(string[] args)
    {
        Vendedores vendedores = new Vendedores();
        int opcao;

        do
        {
            Console.Clear();

            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Cadastrar vendedor");
            Console.WriteLine("2 - Consultar vendedor");
            Console.WriteLine("3 - Excluir vendedor");
            Console.WriteLine("4 - Registrar venda");
            Console.WriteLine("5 - Listar vendedores");
            Console.Write("Opcao: ");

            int.TryParse(Console.ReadLine(), out opcao);

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    Cadastrar(vendedores);
                    break;

                case 2:
                    Consultar(vendedores);
                    break;

                case 3:
                    Excluir(vendedores);
                    break;

                case 4:
                    RegistrarVenda(vendedores);
                    break;

                case 5:
                    Listar(vendedores);
                    break;

                case 0:
                    Console.WriteLine("Fim do programa.");
                    break;

                default:
                    Console.WriteLine("Opcao invalida.");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para continuar.");
                Console.ReadLine();
            }

        } while (opcao != 0);
    }

    static void Cadastrar(Vendedores vendedores)
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        if (vendedores.SearchVendedor(new Vendedor(id, "", 0)) != null)
        {
            Console.WriteLine("ID ja cadastrado.");
            return;
        }

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Percentual de comissao: ");
        double comissao = double.Parse(Console.ReadLine());

        Vendedor vendedor = new Vendedor(id, nome, comissao);

        if (vendedores.AddVendedor(vendedor))
            Console.WriteLine("Vendedor cadastrado.");
        else
            Console.WriteLine("Limite de 10 vendedores atingido.");
    }

    static void Consultar(Vendedores vendedores)
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Vendedor vendedor = vendedores.SearchVendedor(
            new Vendedor(id, "", 0)
        );

        if (vendedor == null)
        {
            Console.WriteLine("Vendedor nao encontrado.");
            return;
        }

        Console.WriteLine("ID: " + vendedor.Id);
        Console.WriteLine("Nome: " + vendedor.Nome);
        Console.WriteLine("Valor das vendas: R$ " + vendedor.ValorVendas().ToString("F2"));
        Console.WriteLine("Comissao: R$ " + vendedor.ValorComissao().ToString("F2"));
        Console.WriteLine("Media diaria: R$ " + vendedor.ValorMedioVendas().ToString("F2"));
    }

    static void Excluir(Vendedores vendedores)
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Vendedor vendedor = vendedores.SearchVendedor(
            new Vendedor(id, "", 0)
        );

        if (vendedor == null)
        {
            Console.WriteLine("Vendedor nao encontrado.");
            return;
        }

        if (vendedor.PossuiVendas())
        {
            Console.WriteLine("Vendedor possui vendas e nao pode ser excluido.");
            return;
        }

        if (vendedores.DelVendedor(vendedor))
            Console.WriteLine("Vendedor excluido.");
    }

    static void RegistrarVenda(Vendedores vendedores)
    {
        Console.Write("ID do vendedor: ");
        int id = int.Parse(Console.ReadLine());

        Vendedor vendedor = vendedores.SearchVendedor(
            new Vendedor(id, "", 0)
        );

        if (vendedor == null)
        {
            Console.WriteLine("Vendedor nao encontrado.");
            return;
        }

        Console.Write("Dia (1-31): ");
        int dia = int.Parse(Console.ReadLine());

        if (dia < 1 || dia > 31)
        {
            Console.WriteLine("Dia invalido.");
            return;
        }

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Valor total: R$ ");
        double valor = double.Parse(Console.ReadLine());

        Venda venda = new Venda(quantidade, valor);

        vendedor.RegistrarVenda(dia, venda);

        Console.WriteLine("Venda registrada.");
    }

    static void Listar(Vendedores vendedores)
    {
        if (vendedores.Quantidade == 0)
        {
            Console.WriteLine("Nenhum vendedor cadastrado.");
            return;
        }

        for (int i = 0; i < vendedores.Quantidade; i++)
        {
            Vendedor vendedor = vendedores.GetVendedor(i);

            Console.WriteLine("ID: " + vendedor.Id);
            Console.WriteLine("Nome: " + vendedor.Nome);
            Console.WriteLine("Vendas: R$ " + vendedor.ValorVendas().ToString("F2"));
            Console.WriteLine("Comissao: R$ " + vendedor.ValorComissao().ToString("F2"));
            Console.WriteLine();
        }

        Console.WriteLine("Total de vendas: R$ " + vendedores.ValorVendas().ToString("F2"));
        Console.WriteLine("Total de comissoes: R$ " + vendedores.ValorComissao().ToString("F2"));
    }
}
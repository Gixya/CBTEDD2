using System;
using ProjetoRestaurante.Models;
using ProjetoRestaurante.Views;

namespace ProjetoRestaurante.Controllers
{
    public class Controller
    {
        private Restaurante restaurante;
        private View view;

        public Controller()
        {
            restaurante = new Restaurante();
            view = new View();
        }

        public void Executar()
        {
            int opcao;

            do
            {
                Console.Clear();

                view.MostrarMenu();
                opcao = view.LerInt("");

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        CriarPedido();
                        break;

                    case 2:
                        AdicionarItem();
                        break;

                    case 3:
                        RemoverItem();
                        break;

                    case 4:
                        ConsultarPedido();
                        break;

                    case 5:
                        CancelarPedido();
                        break;

                    case 6:
                        ListarPedidos();
                        break;

                    case 0:
                        view.MostrarMensagem("Programa encerrado.");
                        break;

                    default:
                        view.MostrarMensagem("Opção inválida.");
                        break;
                }

                if (opcao != 0)
                    view.Pausar();

            } while (opcao != 0);
        }

        private void CriarPedido()
        {
            string cliente = view.LerTexto("Nome do cliente: ");

            int id = restaurante.ProximoPedido();

            Pedido pedido = new Pedido(id, cliente);

            if (restaurante.NovoPedido(pedido))
            {
                view.MostrarMensagem(
                    "Pedido criado com sucesso! ID: " + id
                );
            }
            else
            {
                view.MostrarMensagem("Limite de pedidos atingido.");
            }
        }

        private void AdicionarItem()
        {
            int idPedido = view.LerInt("ID do pedido: ");

            Pedido pedido = restaurante.BuscarPedido(idPedido);

            if (pedido == null)
            {
                view.MostrarMensagem("Pedido não encontrado.");
                return;
            }

            int id = view.LerInt("ID do item: ");
            string descricao = view.LerTexto("Descrição: ");
            double preco = view.LerDouble("Preço: ");

            Item item = new Item(id, descricao, preco);

            if (pedido.AdicionarItem(item))
            {
                view.MostrarMensagem("Item adicionado.");
            }
            else
            {
                view.MostrarMensagem("O pedido já possui 10 itens.");
            }
        }

        private void RemoverItem()
        {
            int idPedido = view.LerInt("ID do pedido: ");

            Pedido pedido = restaurante.BuscarPedido(idPedido);

            if (pedido == null)
            {
                view.MostrarMensagem("Pedido não encontrado.");
                return;
            }

            int idItem = view.LerInt("ID do item para remover: ");

            Item item = new Item(idItem, "", 0);

            if (pedido.RemoverItem(item))
            {
                view.MostrarMensagem("Item removido.");
            }
            else
            {
                view.MostrarMensagem("Item não encontrado.");
            }
        }

        private void ConsultarPedido()
        {
            int id = view.LerInt("ID do pedido: ");

            Pedido pedido = restaurante.BuscarPedido(id);

            if (pedido == null)
            {
                view.MostrarMensagem("Pedido não encontrado.");
                return;
            }

            Console.WriteLine(pedido.DadosDoPedido());
        }

        private void CancelarPedido()
        {
            int id = view.LerInt("ID do pedido: ");

            if (restaurante.CancelarPedido(id))
            {
                view.MostrarMensagem("Pedido cancelado.");
            }
            else
            {
                view.MostrarMensagem("Pedido não encontrado.");
            }
        }

        private void ListarPedidos()
        {
            Pedido[] pedidos = restaurante.ListarPedidos();

            double soma = 0;
            bool encontrou = false;

            Console.WriteLine("===== PEDIDOS DO DIA =====");

            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null)
                {
                    encontrou = true;

                    Console.WriteLine(
                        "Pedido " + pedidos[i].Id +
                        " - R$ " + pedidos[i].CalcularTotal().ToString("F2")
                    );

                    soma += pedidos[i].CalcularTotal();
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum pedido cadastrado.");
            }

            Console.WriteLine();
            Console.WriteLine(
                "Soma geral do dia: R$ " + soma.ToString("F2")
            );
        }
    }
}

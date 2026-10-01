using ProjetoRestaurante.Models;

namespace ProjetoRestaurante.Models
{
    public class Restaurante
    {
        private int proxPedido = 1;
        private Pedido[] pedidos = new Pedido[50];

        public bool NovoPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == null)
                {
                    pedidos[i] = pedido;
                    proxPedido++;
                    return true;
                }
            }

            return false;
        }

        public Pedido BuscarPedido(int id)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].Id == id)
                {
                    return pedidos[i];
                }
            }

            return null;
        }

        public bool CancelarPedido(int id)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].Id == id)
                {
                    pedidos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public int ProximoPedido()
        {
            return proxPedido;
        }

        public Pedido[] ListarPedidos()
        {
            return pedidos;
        }
    }
}

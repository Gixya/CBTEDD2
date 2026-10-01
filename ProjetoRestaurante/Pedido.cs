using System;
using ProjetoRestaurante.Models;

namespace ProjetoRestaurante.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }

        private Item[] itens = new Item[10];

        public Pedido(int id, string cliente)
        {
            Id = id;
            Cliente = cliente;
        }

        public bool AdicionarItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                {
                    itens[i] = item;
                    return true;
                }
            }

            return false;
        }

        public bool RemoverItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].Id == item.Id)
                {
                    itens[i] = null;
                    return true;
                }
            }

            return false;
        }

        public double CalcularTotal()
        {
            double total = 0;

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    total += itens[i].Preco;
                }
            }

            return total;
        }

        public string DadosDoPedido()
        {
            string dados = "";

            dados += "Pedido: " + Id + "\n";
            dados += "Cliente: " + Cliente + "\n";
            dados += "Itens:\n";

            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    dados += " - " + itens[i].Descricao;
                    dados += " - R$ " + itens[i].Preco.ToString("F2") + "\n";
                }
            }

            dados += "Total: R$ " + CalcularTotal().ToString("F2");

            return dados;
        }
    }
}

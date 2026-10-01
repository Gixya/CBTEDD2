using System;

namespace ProjetoRestaurante.Views
{
    public class View
    {
        public void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== RESTAURANTE =====");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Criar novo pedido");
            Console.WriteLine("2 - Adicionar item ao pedido");
            Console.WriteLine("3 - Remover item do pedido");
            Console.WriteLine("4 - Consultar pedido");
            Console.WriteLine("5 - Cancelar pedido");
            Console.WriteLine("6 - Listar todos os pedidos");
            Console.Write("Escolha: ");
        }

        public string LerTexto(string mensagem)
        {
            Console.Write(mensagem);
            return Console.ReadLine();
        }

        public int LerInt(string mensagem)
        {
            Console.Write(mensagem);
            return int.Parse(Console.ReadLine());
        }

        public double LerDouble(string mensagem)
        {
            Console.Write(mensagem);
            return double.Parse(Console.ReadLine());
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

        public void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

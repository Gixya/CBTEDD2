using ProjetoRestaurante.Controllers;

namespace ProjetoRestaurante
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            controller.Executar();
        }
    }
}

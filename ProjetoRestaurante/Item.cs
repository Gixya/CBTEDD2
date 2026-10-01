namespace ProjetoRestaurante.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public Item(int id, string descricao, double preco)
        {
            Id = id;
            Descricao = descricao;
            Preco = preco;
        }

        public override string ToString()
        {
            return Id + " - " + Descricao + " - R$ " + Preco.ToString("F2");
        }
    }
}

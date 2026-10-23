using System;

namespace ProjetoMedicamentos
{
    public class Lote
    {
        public int Id { get; set; }
        public int Qtde { get; set; }
        public DateTime Venc { get; set; }

        public Lote()
        {
            Id = 0;
            Qtde = 0;
            Venc = DateTime.MinValue;
        }

        public Lote(int id, int qtde, DateTime venc)
        {
            Id = id;
            Qtde = qtde;
            Venc = venc;
        }

        public override string ToString()
        {
            return Id + " - " + Qtde + " - " + Venc.ToString("dd/MM/yyyy");
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProjetoMedicamentos
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Laboratorio { get; set; }
        public Queue<Lote> Lotes { get; set; }

        public Medicamento()
        {
            Id = 0;
            Nome = "";
            Laboratorio = "";
            Lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            Id = id;
            Nome = nome;
            Laboratorio = laboratorio;
            Lotes = new Queue<Lote>();
        }

        public int qtdeDisponivel()
        {
            int total = 0;

            foreach (Lote lote in Lotes)
                total += lote.Qtde;

            return total;
        }

        public void comprar(Lote lote)
        {
            if (lote.Qtde > 0)
            {
                Queue<Lote> novaFila = new Queue<Lote>();
                bool inserido = false;

                foreach (Lote atual in Lotes)
                {
                    if (!inserido && lote.Venc < atual.Venc)
                    {
                        novaFila.Enqueue(lote);
                        inserido = true;
                    }

                    novaFila.Enqueue(atual);
                }

                if (!inserido)
                    novaFila.Enqueue(lote);

                Lotes = novaFila;
            }
        }

        public bool vender(int qtde)
        {
            if (qtde <= 0 || qtdeDisponivel() < qtde)
                return false;

            while (qtde > 0 && Lotes.Count > 0)
            {
                Lote lote = Lotes.Peek();

                if (lote.Qtde <= qtde)
                {
                    qtde -= lote.Qtde;
                    Lotes.Dequeue();
                }
                else
                {
                    lote.Qtde -= qtde;
                    qtde = 0;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return Id + " - " + Nome + " - " +
                   Laboratorio + " - " + qtdeDisponivel();
        }

        public override bool Equals(object obj)
        {
            if (obj is Medicamento medicamento)
                return Id == medicamento.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

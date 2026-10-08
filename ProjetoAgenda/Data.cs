using System;

namespace ProjetoAgenda
{
    public class Data
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public Data(int dia, int mes, int ano)
        {
            SetData(dia, mes, ano);
        }

        public void SetData(int dia, int mes, int ano)
        {
            DateTime data = new DateTime(ano, mes, dia);

            Dia = dia;
            Mes = mes;
            Ano = ano;
        }

        public override string ToString()
        {
            return Dia.ToString("D2") + "/" +
                   Mes.ToString("D2") + "/" +
                   Ano.ToString("D4");
        }
    }
}

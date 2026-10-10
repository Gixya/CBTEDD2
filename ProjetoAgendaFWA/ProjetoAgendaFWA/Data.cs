using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoAgendaWFA
{
    public class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public Data(int dia, int mes, int ano)
        {
            setData(dia, mes, ano);
        }

        public void setData(int dia, int mes, int ano)
        {
            DateTime data = new DateTime(ano, mes, dia);

            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public override string ToString()
        {
            return $"{dia:D2}/{mes:D2}/{ano:D4}";
        }
    }
}

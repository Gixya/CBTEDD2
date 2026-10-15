using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoAtendimentoWFA
{
    public class Senha
    {
        public int Id { get; set; }
        public DateTime DataGerac { get; set; }
        public DateTime HoraGerac { get; set; }
        public DateTime DataAtend { get; set; }
        public DateTime HoraAtend { get; set; }

        public Senha(int id)
        {
            Id = id;
            DataGerac = DateTime.Now;
            HoraGerac = DateTime.Now;
        }

        public void RegistrarAtendimento()
        {
            DataAtend = DateTime.Now;
            HoraAtend = DateTime.Now;
        }

        public string dadosParciais()
        {
            return Id + " - " +
                   DataGerac.ToString("dd/MM/yyyy") + " - " +
                   HoraGerac.ToString("HH:mm:ss");
        }

        public string dadosCompletos()
        {
            return dadosParciais() + " - " +
                   DataAtend.ToString("dd/MM/yyyy") + " - " +
                   HoraAtend.ToString("HH:mm:ss");
        }

        public override string ToString()
        {
            return dadosParciais();
        }
    }
}
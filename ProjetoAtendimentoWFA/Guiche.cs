using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimentoWFA
{
    public class Guiche
    {
        public int Id { get; set; }
        public Queue<Senha> Atendimentos { get; set; }

        public Guiche()
        {
            Id = 0;
            Atendimentos = new Queue<Senha>();
        }

        public Guiche(int id)
        {
            Id = id;
            Atendimentos = new Queue<Senha>();
        }

        public bool chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas.Count == 0)
                return false;

            Senha senha = filaSenhas.Dequeue();
            senha.RegistrarAtendimento();
            Atendimentos.Enqueue(senha);

            return true;
        }

        public override string ToString()
        {
            return "Guichê " + Id;
        }
    }
}
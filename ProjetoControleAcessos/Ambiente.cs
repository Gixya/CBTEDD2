using System.Collections.Generic;

namespace ProjetoControleAcessos
{
    public class Ambiente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Queue<Log> Logs { get; set; }

        public Ambiente(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Logs = new Queue<Log>();
        }

        public void registrarLog(Log log)
        {
            if (Logs.Count >= 100)
                Logs.Dequeue();

            Logs.Enqueue(log);
        }

        public override string ToString()
        {
            return Id + " - " + Nome;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace ProjetoControleAcessos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Ambiente> Ambientes { get; set; }

        public Usuario(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Ambientes = new List<Ambiente>();
        }

        public bool concederPermissao(Ambiente ambiente)
        {
            if (Ambientes.Any(a => a.Id == ambiente.Id))
                return false;

            Ambientes.Add(ambiente);
            return true;
        }

        public bool revogarPermissao(Ambiente ambiente)
        {
            Ambiente encontrado = Ambientes.FirstOrDefault(
                a => a.Id == ambiente.Id);

            if (encontrado == null)
                return false;

            Ambientes.Remove(encontrado);
            return true;
        }

        public bool possuiPermissao(Ambiente ambiente)
        {
            return Ambientes.Any(a => a.Id == ambiente.Id);
        }

        public override string ToString()
        {
            return Id + " - " + Nome;
        }
    }
}

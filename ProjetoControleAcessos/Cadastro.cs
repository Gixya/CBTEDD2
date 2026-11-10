using System.Collections.Generic;
using System.Linq;

namespace ProjetoControleAcessos
{
    public class Cadastro
    {
        private List<Usuario> usuarios;
        private List<Ambiente> ambientes;

        public Cadastro()
        {
            usuarios = new List<Usuario>();
            ambientes = new List<Ambiente>();
        }

        public void adicionarUsuario(Usuario usuario)
        {
            if (pesquisarUsuario(usuario).Id == 0)
                usuarios.Add(usuario);
        }

        public bool removerUsuario(Usuario usuario)
        {
            Usuario encontrado = pesquisarUsuario(usuario);

            if (encontrado.Id == 0)
                return false;

            usuarios.Remove(encontrado);
            return true;
        }

        public Usuario pesquisarUsuario(Usuario usuario)
        {
            return usuarios.FirstOrDefault(u => u.Id == usuario.Id)
                   ?? new Usuario(0, "");
        }

        public void adicionarAmbiente(Ambiente ambiente)
        {
            if (pesquisarAmbiente(ambiente).Id == 0)
                ambientes.Add(ambiente);
        }

        public bool removerAmbiente(Ambiente ambiente)
        {
            Ambiente encontrado = pesquisarAmbiente(ambiente);

            if (encontrado.Id == 0)
                return false;

            ambientes.Remove(encontrado);

            foreach (Usuario usuario in usuarios)
                usuario.revogarPermissao(encontrado);

            return true;
        }

        public Ambiente pesquisarAmbiente(Ambiente ambiente)
        {
            return ambientes.FirstOrDefault(a => a.Id == ambiente.Id)
                   ?? new Ambiente(0, "");
        }

        public List<Usuario> listarUsuarios()
        {
            return usuarios;
        }

        public List<Ambiente> listarAmbientes()
        {
            return ambientes;
        }

        public void upload()
        {
            // Método reservado para salvar os dados.
        }

        public void download()
        {
            // Método reservado para carregar os dados.
        }
    }
}

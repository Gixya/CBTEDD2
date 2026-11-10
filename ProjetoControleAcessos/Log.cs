using System;

namespace ProjetoControleAcessos
{
    public class Log
    {
        public DateTime DtAcesso { get; set; }
        public Usuario Usuario { get; set; }
        public bool TipoAcesso { get; set; }

        public Log(Usuario usuario, bool tipoAcesso)
        {
            DtAcesso = DateTime.Now;
            Usuario = usuario;
            TipoAcesso = tipoAcesso;
        }

        public override string ToString()
        {
            string resultado = TipoAcesso ? "Autorizado" : "Negado";

            return DtAcesso.ToString("dd/MM/yyyy HH:mm:ss") +
                   " - Usuário: " + Usuario.Nome +
                   " - " + resultado;
        }
    }
}

using System.Collections.Generic;

namespace ProjetoMedicamentos
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public void adicionar(Medicamento medicamento)
        {
            if (pesquisar(medicamento).Id == 0 && medicamento.Id != 0)
                listaMedicamentos.Add(medicamento);
        }

        public bool deletar(Medicamento medicamento)
        {
            Medicamento encontrado = pesquisar(medicamento);

            if (encontrado.Id != 0 && encontrado.qtdeDisponivel() == 0)
            {
                listaMedicamentos.Remove(encontrado);
                return true;
            }

            return false;
        }

        public Medicamento pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento atual in listaMedicamentos)
            {
                if (atual.Id == medicamento.Id)
                    return atual;
            }

            return new Medicamento();
        }

        public List<Medicamento> listar()
        {
            return listaMedicamentos;
        }
    }
}

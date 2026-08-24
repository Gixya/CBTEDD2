using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Curso
    {
    }
}

public class Curso
{
    private int id;
    private string descricao;
    private Disciplina[] disciplinas;

    public Curso(int id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
        disciplinas = new Disciplina[12];
    }

    public int Id
    {
        get { return id; }
    }

    public string Descricao
    {
        get { return descricao; }
    }

    public int QuantidadeDisciplinas
    {
        get
        {
            int quantidade = 0;

            for (int i = 0; i < 12; i++)
            {
                if (disciplinas[i] != null)
                {
                    quantidade++;
                }
            }

            return quantidade;
        }
    }

    public bool AdicionarDisciplina(Disciplina disciplina)
    {
        if (PesquisarDisciplina(disciplina) != null)
        {
            return false;
        }

        for (int i = 0; i < 12; i++)
        {
            if (disciplinas[i] == null)
            {
                disciplinas[i] = disciplina;
                return true;
            }
        }

        return false;
    }

    public Disciplina PesquisarDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < 12; i++)
        {
            if (disciplinas[i] != null &&
                disciplinas[i].Id == disciplina.Id)
            {
                return disciplinas[i];
            }
        }

        return null;
    }

    public bool RemoverDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < 12; i++)
        {
            if (disciplinas[i] != null &&
                disciplinas[i].Id == disciplina.Id)
            {
                disciplinas[i] = null;
                return true;
            }
        }

        return false;
    }

    public Disciplina GetDisciplina(int indice)
    {
        if (indice >= 0 && indice < 12)
        {
            return disciplinas[indice];
        }

        return null;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Escola
    {
    }
}

public class Escola
{
    private Curso[] cursos;

    public Escola()
    {
        cursos = new Curso[5];
    }

    public int Quantidade
    {
        get
        {
            int quantidade = 0;

            for (int i = 0; i < 5; i++)
            {
                if (cursos[i] != null)
                {
                    quantidade++;
                }
            }

            return quantidade;
        }
    }

    public bool AdicionarCurso(Curso curso)
    {
        if (PesquisarCurso(curso) != null)
        {
            return false;
        }

        for (int i = 0; i < 5; i++)
        {
            if (cursos[i] == null)
            {
                cursos[i] = curso;
                return true;
            }
        }

        return false;
    }

    public Curso PesquisarCurso(Curso curso)
    {
        for (int i = 0; i < 5; i++)
        {
            if (cursos[i] != null &&
                cursos[i].Id == curso.Id)
            {
                return cursos[i];
            }
        }

        return null;
    }

    public bool RemoverCurso(Curso curso)
    {
        for (int i = 0; i < 5; i++)
        {
            if (cursos[i] != null &&
                cursos[i].Id == curso.Id)
            {
                cursos[i] = null;
                return true;
            }
        }

        return false;
    }

    public Curso GetCurso(int indice)
    {
        if (indice >= 0 && indice < 5)
        {
            return cursos[indice];
        }

        return null;
    }
}
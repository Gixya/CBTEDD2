using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Disciplina
    {
    }
}

public class Disciplina
{
    private int id;
    private string descricao;
    private Aluno[] alunos;

    public Disciplina(int id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
        alunos = new Aluno[15];
    }

    public int Id
    {
        get { return id; }
    }

    public string Descricao
    {
        get { return descricao; }
    }

    public bool MatricularAluno(Aluno aluno)
    {
        for (int i = 0; i < 15; i++)
        {
            if (alunos[i] != null && alunos[i].Id == aluno.Id)
            {
                return false;
            }
        }

        for (int i = 0; i < 15; i++)
        {
            if (alunos[i] == null)
            {
                alunos[i] = aluno;
                return true;
            }
        }

        return false;
    }

    public bool DesmatricularAluno(Aluno aluno)
    {
        for (int i = 0; i < 15; i++)
        {
            if (alunos[i] != null && alunos[i].Id == aluno.Id)
            {
                alunos[i] = null;
                return true;
            }
        }

        return false;
    }

    public bool PossuiAluno(Aluno aluno)
    {
        for (int i = 0; i < 15; i++)
        {
            if (alunos[i] != null && alunos[i].Id == aluno.Id)
            {
                return true;
            }
        }

        return false;
    }

    public int QuantidadeAlunos()
    {
        int quantidade = 0;

        for (int i = 0; i < 15; i++)
        {
            if (alunos[i] != null)
            {
                quantidade++;
            }
        }

        return quantidade;
    }
}
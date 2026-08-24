using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Aluno
    {
    }
}
public class Aluno
{
    private int id;
    private string nome;

    public Aluno(int id, string nome)
    {
        this.id = id;
        this.nome = nome;
    }

    public int Id
    {
        get { return id; }
    }

    public string Nome
    {
        get { return nome; }
    }

    public bool PodeMatricular(Escola escola)
    {
        int quantidade = 0;

        for (int i = 0; i < escola.Quantidade; i++)
        {
            Curso curso = escola.GetCurso(i);

            for (int j = 0; j < curso.QuantidadeDisciplinas; j++)
            {
                Disciplina disciplina = curso.GetDisciplina(j);

                if (disciplina != null && disciplina.PossuiAluno(this))
                {
                    quantidade++;
                }
            }
        }

        return quantidade < 6;
    }
}
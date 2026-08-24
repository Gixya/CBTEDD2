using ProjetoCursos;

class Program
{
    static Escola escola = new Escola();

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.Clear();

            Console.WriteLine("1 - Adicionar curso");
            Console.WriteLine("2 - Adicionar disciplina");
            Console.WriteLine("3 - Cadastrar aluno");
            Console.WriteLine("4 - Matricular aluno");
            Console.WriteLine("5 - Desmatricular aluno");
            Console.WriteLine("6 - Listar cursos");
            Console.WriteLine("0 - Sair");
            Console.Write("Opcao: ");

            int.TryParse(Console.ReadLine(), out opcao);

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    AdicionarCurso();
                    break;

                case 2:
                    AdicionarDisciplina();
                    break;

                case 3:
                    CadastrarAluno();
                    break;

                case 4:
                    MatricularAluno();
                    break;

                case 5:
                    DesmatricularAluno();
                    break;

                case 6:
                    Listar();
                    break;

                case 0:
                    Console.WriteLine("Fim do programa.");
                    break;

                default:
                    Console.WriteLine("Opcao invalida.");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para continuar.");
                Console.ReadLine();
            }

        } while (opcao != 0);
    }

    static void AdicionarCurso()
    {
        Console.Write("ID do curso: ");
        int id = int.Parse(Console.ReadLine());

        if (escola.PesquisarCurso(new Curso(id, "")) != null)
        {
            Console.WriteLine("Curso ja cadastrado.");
            return;
        }

        Console.Write("Descricao: ");
        string descricao = Console.ReadLine();

        Curso curso = new Curso(id, descricao);

        if (escola.AdicionarCurso(curso))
        {
            Console.WriteLine("Curso adicionado.");
        }
        else
        {
            Console.WriteLine("Limite de 5 cursos atingido.");
        }
    }

    static void AdicionarDisciplina()
    {
        Console.Write("ID do curso: ");
        int idCurso = int.Parse(Console.ReadLine());

        Curso curso = escola.PesquisarCurso(
            new Curso(idCurso, "")
        );

        if (curso == null)
        {
            Console.WriteLine("Curso nao encontrado.");
            return;
        }

        Console.Write("ID da disciplina: ");
        int id = int.Parse(Console.ReadLine());

        if (curso.PesquisarDisciplina(
            new Disciplina(id, "")) != null)
        {
            Console.WriteLine("Disciplina ja cadastrada.");
            return;
        }

        Console.Write("Descricao: ");
        string descricao = Console.ReadLine();

        Disciplina disciplina = new Disciplina(id, descricao);

        if (curso.AdicionarDisciplina(disciplina))
        {
            Console.WriteLine("Disciplina adicionada.");
        }
        else
        {
            Console.WriteLine("Limite de 12 disciplinas atingido.");
        }
    }

    static void CadastrarAluno()
    {
        Console.Write("ID do aluno: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Aluno aluno = new Aluno(id, nome);

        Console.WriteLine("Aluno cadastrado.");
    }

    static void MatricularAluno()
    {
        Console.Write("ID do aluno: ");
        int idAluno = int.Parse(Console.ReadLine());

        Console.Write("Nome do aluno: ");
        string nomeAluno = Console.ReadLine();

        Aluno aluno = new Aluno(idAluno, nomeAluno);

        Console.Write("ID do curso: ");
        int idCurso = int.Parse(Console.ReadLine());

        Curso curso = escola.PesquisarCurso(
            new Curso(idCurso, "")
        );

        if (curso == null)
        {
            Console.WriteLine("Curso nao encontrado.");
            return;
        }

        Console.Write("ID da disciplina: ");
        int idDisciplina = int.Parse(Console.ReadLine());

        Disciplina disciplina = curso.PesquisarDisciplina(
            new Disciplina(idDisciplina, "")
        );

        if (disciplina == null)
        {
            Console.WriteLine("Disciplina nao encontrada.");
            return;
        }

        if (!aluno.PodeMatricular(escola))
        {
            Console.WriteLine("Aluno ja esta matriculado em 6 disciplinas.");
            return;
        }

        if (disciplina.MatricularAluno(aluno))
        {
            Console.WriteLine("Aluno matriculado.");
        }
        else
        {
            Console.WriteLine("Nao foi possivel realizar a matricula.");
        }
    }

    static void DesmatricularAluno()
    {
        Console.Write("ID do curso: ");
        int idCurso = int.Parse(Console.ReadLine());

        Curso curso = escola.PesquisarCurso(
            new Curso(idCurso, "")
        );

        if (curso == null)
        {
            Console.WriteLine("Curso nao encontrado.");
            return;
        }

        Console.Write("ID da disciplina: ");
        int idDisciplina = int.Parse(Console.ReadLine());

        Disciplina disciplina = curso.PesquisarDisciplina(
            new Disciplina(idDisciplina, "")
        );

        if (disciplina == null)
        {
            Console.WriteLine("Disciplina nao encontrada.");
            return;
        }

        Console.Write("ID do aluno: ");
        int idAluno = int.Parse(Console.ReadLine());

        Aluno aluno = new Aluno(idAluno, "");

        if (disciplina.DesmatricularAluno(aluno))
        {
            Console.WriteLine("Aluno desmatriculado.");
        }
        else
        {
            Console.WriteLine("Aluno nao encontrado na disciplina.");
        }
    }

    static void Listar()
    {
        if (escola.Quantidade == 0)
        {
            Console.WriteLine("Nenhum curso cadastrado.");
            return;
        }

        for (int i = 0; i < escola.Quantidade; i++)
        {
            Curso curso = escola.GetCurso(i);

            Console.WriteLine("Curso: " + curso.Id);
            Console.WriteLine("Descricao: " + curso.Descricao);

            for (int j = 0; j < curso.QuantidadeDisciplinas; j++)
            {
                Disciplina disciplina = curso.GetDisciplina(j);

                if (disciplina != null)
                {
                    Console.WriteLine(
                        "  Disciplina: " +
                        disciplina.Id +
                        " - " +
                        disciplina.Descricao +
                        " - Alunos: " +
                        disciplina.QuantidadeAlunos()
                    );
                }
            }

            Console.WriteLine();
        }
    }
}
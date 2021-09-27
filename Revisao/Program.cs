using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsu();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Write("Informe o nome do Aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.Write("Informe a nota do Aluno: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;                     
                        }
                        else
                        {
                            throw new ArgumentException("O Valor da nota deve ser decimal!");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        foreach (var gente in alunos)
                        {
                            if (!string.IsNullOrEmpty(gente.Nome))
                            {
                                Console.WriteLine($"ALUNO: {gente.Nome} - NOTA: {gente.Nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var numAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                numAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / numAlunos;
                        Conceito conGeral;

                        if (mediaGeral < 2)
                        {
                            conGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conGeral = Conceito.D;    
                        }
                        else if (mediaGeral < 6)
                        {
                            conGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conGeral = Conceito.B;
                        }
                        else
                        {
                            conGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média Geral: {mediaGeral} - CONCEITO: {conGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsu();
            }
        }
        private static string ObterOpcaoUsu()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada! ");
            Console.WriteLine("1 - Inserir novo Aluno! ");
            Console.WriteLine("2 - Listar Alunos! ");
            Console.WriteLine("3 - Calcular média geral! ");
            Console.WriteLine("X - Sair!");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

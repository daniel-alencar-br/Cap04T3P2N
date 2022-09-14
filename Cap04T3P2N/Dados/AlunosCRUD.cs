using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Cap04T3P2N.Models;

namespace Cap04T3P2N.Dados
{
    // Repositório : Conjunto de Classes que acessam o EF
    public class AlunosCRUD
    {
        // Inclui um aluno
        public static void NovoAluno(Alunos Novo)
        {
            using (var BD = new CursoAspEntities())
            {
                BD.Alunos.Add(Novo);
                BD.SaveChanges();
            }
        }

        // Pesquisa um aluno

        public static Alunos BuscarAluno(int Codigo)
        {
            using (var BD = new CursoAspEntities())
            {
                return BD.Alunos.FirstOrDefault(p =>
                       p.Cod.Equals(Codigo));
            }
        }

        // Listagem total dos alunos

        public static IEnumerable<Alunos> ListarAlunos()
        {
            using (var BD = new CursoAspEntities())
            {
                return BD.Alunos.ToList();
            }
        }

        // Alterar um aluno

        public static void AlterarAluno(Alunos Alterado)
        {
            using (var BD = new CursoAspEntities())
            {
                BD.Entry<Alunos>(Alterado).State =
                                  EntityState.Modified;
                BD.SaveChanges();
            }
        }

        // Deletar um aluno

        public static void DeletarAluno(Alunos Apagado)
        {
            using (var BD = new CursoAspEntities())
            {
                BD.Entry<Alunos>(Apagado).State =
                                  EntityState.Deleted;
                BD.SaveChanges();
            }
        }

    }

}





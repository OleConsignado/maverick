using System;
using System.Linq;
using Dapper;
using Maverick.Application.IntegrationTest.Configuracoes;
using Maverick.Domain.Models;
using Xunit;

namespace Maverick.Application.IntegrationTest
{
    public class FilmeDatabaseTest : BaseDatabaseTest
    {
        
        [Fact]
        public void InsereFilmeBanco()
        {
            string sql = "INSERT INTO Filme (Nome, Descricao) Values (@Nome,@Descricao);";
            var conn = InMemoryDatabase.GetInMemoryOpenSqliteConnection();
            conn.Execute(sql, new { Nome = "Teste", Descricao = "Descricao teste" });
            var filmes = conn.Query<Filme>("Select * FROM Filme").ToList();
            Assert.True(filmes.Count == 1);
            var filme = filmes[0];
            Assert.True(filme.Nome == "Teste");
            Assert.True(filme.Descricao == "Descricao teste");
        }

        [Fact]
        public void AtualizarFilmeBanco()
        {
            string sql = " UPDATE Filme SET Nome=@Nome, Descricao=@Descricao WHERE Id=@Id;";
            var conn = InMemoryDatabase.GetInMemoryOpenSqliteConnection();
            conn.Execute(sql, new { Id= 1, Nome = "Teste 2", Descricao = "Descricao teste 2" });
            var filmes = conn.Query<Filme>("Select * FROM Filme").ToList();
            Assert.True(filmes.Count == 1);
            var filme = filmes[0];
            Assert.True(filme.Nome == "Teste 2");
            Assert.True(filme.Descricao == "Descricao teste 2");
        }

        [Fact]
        public void DeletarFilmeBanco()
        {
            string sql = " DELETE FROM Filme WHERE Id=@Id;";
            var conn = InMemoryDatabase.GetInMemoryOpenSqliteConnection();
            conn.Execute(sql, new { Id = 1 });
            var filmes = conn.Query<Filme>("Select * FROM Filme").ToList();
            Assert.True(filmes.Count == 0);
        }
    }
}

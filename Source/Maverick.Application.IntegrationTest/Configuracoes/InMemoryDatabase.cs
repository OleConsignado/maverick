using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using Maverick.Domain.Models;

namespace Maverick.Application.IntegrationTest.Configuracoes
{
    public static class InMemoryDatabase
    {

        private static SqliteConnection Connection;



        //public InMemoryDatabase() 
        //{
        //    CreateDatabase();
        //}

        public static SqliteConnection GetInMemoryOpenSqliteConnection()
        {
            if (Connection == null)
                Connection = new SqliteConnection("Data Source=:memory:;");

            return Connection;
        }


        public static void CreateDatabase()
        {
            var conn = GetInMemoryOpenSqliteConnection();
           
            conn.Open();
            conn.Execute(DatabaseScripts.CREATE_FILME_DATABASE);            
        }
    }
}

using Microsoft.Data.Sqlite;
using Dapper;

namespace Maverick.Application.IntegrationTest.Configuracoes
{
    public static class InMemoryDatabase
    {
        private static SqliteConnection connection;

        public static SqliteConnection GetInMemoryOpenSqliteConnection()
        {
            if (connection == null)
            {
                connection = new SqliteConnection("Data Source=:memory:;");
            }

            return connection;
        }
        
        public static void CreateDatabase()
        {
            var conn = GetInMemoryOpenSqliteConnection();
           
            conn.Open();
            conn.Execute(DatabaseScripts.CREATE_FILME_DATABASE);            
        }
    }
}

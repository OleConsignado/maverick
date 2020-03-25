using System;
using System.Collections.Generic;
using System.Text;

namespace Maverick.Application.IntegrationTest
{
    internal class DatabaseScripts
    {
        public static readonly string CREATE_FILME_DATABASE =
            @"CREATE TABLE IF NOT EXISTS  Filme (
        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
        Nome VARCHAR(50)  NULL, 
        DataLancamento VARCHAR(50) NULL,
        Descricao VARCHAR(500)  NULL);";

    }
}

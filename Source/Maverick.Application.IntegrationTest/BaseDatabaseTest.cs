using System;
using System.Collections.Generic;
using System.Text;
using Maverick.Application.IntegrationTest.Configuracoes;

namespace Maverick.Application.IntegrationTest
{
    public class BaseDatabaseTest 
    {
        public BaseDatabaseTest()
        {
            InMemoryDatabase.CreateDatabase();
        }
    }
}

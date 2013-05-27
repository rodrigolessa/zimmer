using BSI.Zimmer.Infraestrutura.Comuns.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Test.Mock.Infraestrutura.Comuns.Security
{
    public class MockApplicationContext : IApplicationContext
    {
        public string Login
        {
            get;
            set;
        }
    }
}

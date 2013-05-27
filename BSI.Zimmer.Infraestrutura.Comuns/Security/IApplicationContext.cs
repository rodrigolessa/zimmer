using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Comuns.Security
{
    public interface IApplicationContext
    {
        string Login { get; set; }
    }
}

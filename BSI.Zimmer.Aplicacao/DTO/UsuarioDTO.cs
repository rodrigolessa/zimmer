using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Aplicacao.DTO
{
    public class UsuarioDTO
    {
        public Guid Id
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public bool EhPrimeiroAcesso
        {
            get;
            set;
        }
    }
}

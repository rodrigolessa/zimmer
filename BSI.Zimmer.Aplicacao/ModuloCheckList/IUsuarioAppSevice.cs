using BSI.Zimmer.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Aplicacao.ModuloCheckList
{
    public interface IUsuarioAppSevice
    {
        UsuarioDTO GetUsuario(string loginActiveDirectory);
    }
}

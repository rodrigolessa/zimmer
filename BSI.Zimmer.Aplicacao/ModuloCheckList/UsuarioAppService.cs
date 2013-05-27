using BSI.Zimmer.Aplicacao.DTO;
using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Dominio.Repository;
using BSI.Zimmer.Dominio.Services.Tarefas;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Aplicacao.ModuloCheckList
{
    public class UsuarioAppService : IUsuarioAppSevice
    {
        private IUsuarioRepository _iUsuarioRepository = null;
        private IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _iUsuarioRepository;
            }
        }

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _iUsuarioRepository = usuarioRepository;
        }

        public UsuarioDTO GetUsuario(string loginActiveDirectory)
        {
            Usuario usuario = UsuarioRepository.GetFiltered(s => s.Login == loginActiveDirectory).FirstOrDefault();

            return new UsuarioDTO()
            {
                Nome = loginActiveDirectory,
                EhPrimeiroAcesso = true
            };
        }
    }
}

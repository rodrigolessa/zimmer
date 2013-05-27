using AutoMapper;
using BSI.Zimmer.Aplicacao.DTO;
using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.UI.Web.Controller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.UI.Web.Controller.ProfileMapper
{
   public class UsuarioProfile : Profile
    {
        protected override void Configure()
        {
            var mapPrimeiroAcesso = Mapper.CreateMap<Usuario, CriarViewModel>();
            mapPrimeiroAcesso.ForMember(model => model.Login, mc => mc.MapFrom(e => e.Login));
        }
    }
}

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
    public class CriarViewModelProfile : Profile
    {
        protected override void Configure()
        {
            var mapPrimeiroAcesso = Mapper.CreateMap<CriarViewModel, Usuario>();
            mapPrimeiroAcesso.ForMember(entity => entity.Nome, mc => mc.MapFrom(model => model.Nome));
            mapPrimeiroAcesso.ForMember(entity => entity.PerfilAcesso, mc => mc.MapFrom(model => model.PerfilAcesso != null ? (PerfilAcesso?)model.PerfilAcesso.Id : null));
            mapPrimeiroAcesso.ForMember(entity => entity.Id, mc => mc.MapFrom(model => model.UsuarioId));
        }
    }
}

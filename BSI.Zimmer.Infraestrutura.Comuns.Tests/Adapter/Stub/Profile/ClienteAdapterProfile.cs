using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BSI.Zimmer.Infraestrutura.Comuns.Tests.Adapter.Stub.Entity;
using BSI.Zimmer.Infraestrutura.Comuns.Tests.Adapter.Stub.DTO;


namespace BSI.Zimmer.Infraestrutura.Comuns.Tests.Adapter.Stub.Profile
{
  public  class ClienteAdapterProfile:AutoMapper.Profile
    {
      protected override void Configure()
      {
          var map = Mapper.CreateMap<Cliente, ClienteDTO>();
          map.ForMember(dto => dto.Codigo, entity => entity.MapFrom(p => p.Id.ToString()));
          map.ForMember(dto => dto.NomeCliente, entity => entity.MapFrom(p => p.Nome));
          map.ForMember(dto => dto.DataNascimentoCliente, entity => entity.MapFrom(p => p.DataNascimento.ToShortDateString()));
      }
    }
}

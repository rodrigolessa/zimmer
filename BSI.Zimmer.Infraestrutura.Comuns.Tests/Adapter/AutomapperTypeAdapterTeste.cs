using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using BSI.Zimmer.Infraestrutura.Comuns.Tests.Adapter.Stub.Profile;
using BSI.Zimmer.Infraestrutura.Comuns.Adapter;
using BSI.Zimmer.Infraestrutura.Comuns.Tests.Adapter.Stub.Entity;
using BSI.Zimmer.Infraestrutura.Comuns.Tests.Adapter.Stub.DTO;
using System.Collections.Generic;

namespace BSI.Zimmer.Infraestrutura.Comuns.Tests.Adapter
{
    [TestClass]
    public class AutomapperTypeAdapterTeste
    {
        [TestMethod]
        public void AdapterToDTOUnitario()
        {
            //Prepara
            Mapper.Initialize(cfg => cfg.AddProfile(new ClienteAdapterProfile()));

            var adapter = new AutomapperTypeAdapter();

            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nome = "Marcus Dorbação",
                Endereco = "Rua Campo Grande 2104",
                DataNascimento = new DateTime(1986, 06, 18)
            };

            //Executa
            var clienteDTO = adapter.Adapt<Cliente, ClienteDTO>(cliente);

            //Valida
            Assert.IsNotNull(clienteDTO);
            Assert.AreEqual(clienteDTO.Codigo, cliente.Id.ToString());
            Assert.AreEqual(clienteDTO.NomeCliente, cliente.Nome);
            Assert.AreEqual(clienteDTO.DataNascimentoCliente, cliente.DataNascimento.ToShortDateString());

        }

        [TestMethod]
        public void AdapterToDTOLista()
        {
            //Prepara
            Mapper.Initialize(cfg => cfg.AddProfile(new ClienteAdapterProfile()));

            var adapter = new AutomapperTypeAdapter();

            Cliente cliente = new Cliente()
            {
                Id = 1,
                Nome = "Marcus Dorbação",
                Endereco = "Rua Campo Grande 2104",
                DataNascimento = new DateTime(1986, 06, 18)
            };

            //Executa
            var clienteDTO = adapter.Adapt<IEnumerable<Cliente>, List<ClienteDTO>>(new Cliente[] { cliente });

            //Valida
            Assert.IsNotNull(clienteDTO);
            Assert.IsTrue(clienteDTO.Count == 1);
            Assert.AreEqual(clienteDTO[0].Codigo, cliente.Id.ToString());
            Assert.AreEqual(clienteDTO[0].NomeCliente, cliente.Nome);
            Assert.AreEqual(clienteDTO[0].DataNascimentoCliente, cliente.DataNascimento.ToShortDateString());

        }

    }
}

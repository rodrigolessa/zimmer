using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MainUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        private const string _QUERY_IMPORTACAO_CLIENTE = "insert into {ZIMMER}.dbo.cliente(Id, Nome, PackageId) select NEWID(), t_package.Name, t_package.Package_ID from EA.dbo.t_package where t_package.Parent_ID = 177 and t_package.Package_ID not in (select PackageId from {ZIMMER}.dbo.cliente)";
        private const string _QUERY_IMPORTACAO_PROJETO = "insert into {ZIMMER}.dbo.projeto(Id, Nome, Cliente_Id, PackageId) select NEWID(), P.Name, C.Id, P.Package_ID from EA.dbo.t_package P inner join {ZIMMER}.dbo.cliente C 	on P.Parent_ID = C.PackageId where P.Package_ID not in (select PackageId from {ZIMMER}.dbo.projeto)";
        private const string _QUERY_IMPORTACAO_ARTEFATO = "insert into {ZIMMER}.dbo.artefato(Id,CodigoArtefatoEA,Nome,Descricao) select NEWID(), Object_ID id_artefato, Name nome_artefato,(select name from EA.dbo.t_package tp2 where Name <> 'Use Case Model' and tp2.Package_ID in (select Parent_ID	from EA.dbo.t_package tp3 where tp3.Package_ID = to1.Package_ID)) from EA.dbo.t_object to1 where Object_Type = 'UseCase'and (select name from EA.dbo.t_package tp2 where Name <> 'Use Case Model' and tp2.Package_ID in (select Parent_ID from EA.dbo.t_package tp3	where tp3.Package_ID = to1.Package_ID)) is not null UNION select NEWID(),Object_ID id_artefato, Name nome_artefato,(select name from EA.dbo.t_package tp2 where tp2.Package_ID in (select Parent_ID from EA.dbo.t_package tp3 where Name = 'Use Case Model' and tp3.Package_ID in (select Parent_ID from EA.dbo.t_package tp4 where tp4.Package_ID = to1.Package_ID))) from EA.dbo.t_object to1 where Object_Type = 'UseCase' and ((select name from EA.dbo.t_package tp2 where tp2.Package_ID in (select Parent_ID from EA.dbo.t_package tp3 where Name = 'Use Case Model' and tp3.Package_ID in (select Parent_ID from EA.dbo.t_package tp4 where tp4.Package_ID = to1.Package_ID)))) is not null";

        protected override void Seed(MainUnitOfWork context)
        {
            var artefato = new Artefato() { Nome = "Caso de Uso" };
            artefato.Nome = "Marcus";
            artefato.Descricao = "Luiz";
            artefato.CodigoArtefatoEA = 10;
            artefato.GenerateNewIdentity();

            //context.Artefatos.Add(artefato);

            context.ExecuteCommand(_QUERY_IMPORTACAO_CLIENTE);
            context.ExecuteCommand(_QUERY_IMPORTACAO_PROJETO);
            //context.ExecuteCommand(_QUERY_IMPORTACAO_ARTEFATO);


        }
    }
}

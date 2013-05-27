using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.Common;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Tests.Initializers
{
    public class MainUnitOfWorkInitializer : DropCreateDatabaseAlways<MainUnitOfWork>
    {
        private const string _QUERY_IMPORTACAO_CLIENTE = "insert into {ZIMMER}.dbo.cliente(Id, Nome, PackageId) select NEWID(), t_package.Name, t_package.Package_ID from EA.dbo.t_package where t_package.Parent_ID = 177 and t_package.Package_ID not in (select PackageId from {ZIMMER}.dbo.cliente)";
        private const string _QUERY_IMPORTACAO_PROJETO = "insert into {ZIMMER}.dbo.projeto(Id, Nome, Cliente_Id, PackageId) select NEWID(), P.Name, C.Id, P.Package_ID from EA.dbo.t_package P inner join {ZIMMER}.dbo.cliente C 	on P.Parent_ID = C.PackageId where P.Package_ID not in (select PackageId from {ZIMMER}.dbo.projeto)";
        private const string _QUERY_IMPORTACAO_ARTEFATO = "insert into {ZIMMER}.dbo.artefato(Id,CodigoArtefatoEA,Nome,Descricao) select NEWID(), Object_ID id_artefato, Name nome_artefato,(select name from EA.dbo.t_package tp2 where Name <> 'Use Case Model' and tp2.Package_ID in (select Parent_ID	from EA.dbo.t_package tp3 where tp3.Package_ID = to1.Package_ID)) from EA.dbo.t_object to1 where Object_Type = 'UseCase'and (select name from EA.dbo.t_package tp2 where Name <> 'Use Case Model' and tp2.Package_ID in (select Parent_ID from EA.dbo.t_package tp3	where tp3.Package_ID = to1.Package_ID)) is not null UNION select NEWID(),Object_ID id_artefato, Name nome_artefato,(select name from EA.dbo.t_package tp2 where tp2.Package_ID in (select Parent_ID from EA.dbo.t_package tp3 where Name = 'Use Case Model' and tp3.Package_ID in (select Parent_ID from EA.dbo.t_package tp4 where tp4.Package_ID = to1.Package_ID))) from EA.dbo.t_object to1 where Object_Type = 'UseCase' and ((select name from EA.dbo.t_package tp2 where tp2.Package_ID in (select Parent_ID from EA.dbo.t_package tp3 where Name = 'Use Case Model' and tp3.Package_ID in (select Parent_ID from EA.dbo.t_package tp4 where tp4.Package_ID = to1.Package_ID)))) is not null";

        protected override void Seed(MainUnitOfWork unitOfWork)
        {
            string queryImportacaoCliente = _QUERY_IMPORTACAO_CLIENTE.Replace("{ZIMMER}", "Zimmer_Teste");
            string queryImportacaoProjeto = _QUERY_IMPORTACAO_PROJETO.Replace("{ZIMMER}", "Zimmer_Teste");
            string queryImportacaoArtefato = _QUERY_IMPORTACAO_ARTEFATO.Replace("{ZIMMER}", "Zimmer_Teste");

            unitOfWork.ExecuteCommand(queryImportacaoCliente);
            unitOfWork.ExecuteCommand(queryImportacaoProjeto);
            unitOfWork.ExecuteCommand(queryImportacaoArtefato);
        }

            
            

    }
}

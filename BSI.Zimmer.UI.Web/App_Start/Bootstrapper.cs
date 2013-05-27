using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using BSI.Zimmer.Dominio.Repository;
using BSI.Zimmer.Infraestrutura.Persistencia.Repository;
using BSI.Zimmer.Infraestrutura.Comuns.Logging;
using BSI.Zimmer.Infraestrutura.Comuns.Adapter;
using BSI.Zimmer.Infraestrutura.Comuns.Validator;
using BSI.Zimmer.Aplicacao.ModuloCheckList;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Infraestrutura.Comuns.Security;
using System.Web;
using BSI.Zimmer.UI.Web;
using BSI.Zimmer.Dominio;

namespace BSI.Zimmer.UI.Web
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IQueryableUnitOfWork, MainUnitOfWork>();

            //registra o UnityOfWork
            container.RegisterType(typeof(MainUnitOfWork), new PerResolveLifetimeManager());

            //registra a fábrica de Adaptadores
            container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());

            //registra os repositórios
            RegistraRepositorios(container);

            //registra os Servicos da camada de aplicação
            RegistraServicosDeAplicacao(container);

            //registra as fábricas
            RegistraFabricas(container);

            //registra os servicos de Domínio
            RegistraServicosDeDominio(container);


        }

        private static void RegistraFabricas(IUnityContainer container)
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            var typeAdapterFactory = container.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);

        }

        private static void RegistraServicosDeDominio(IUnityContainer container)
        {

        }

        private static void RegistraServicosDeAplicacao(IUnityContainer container)
        {
            container.RegisterType<IUsuarioAppSevice, UsuarioAppService>();
            container.RegisterType<IApplicationContext, WebApplicationContext>();

        }

        private static void RegistraRepositorios(IUnityContainer container)
        {
            container.RegisterType<IArtefatoRepository, ArtefatoRepository>();
            container.RegisterType<IAvaliacaoRepository, AvaliacaoRepository>();
            container.RegisterType<ICategoriaQuestaoRepository, CategoriaQuestaoRepository>();
            container.RegisterType<ICheckListRepository, CheckListRepository>();
            container.RegisterType<IClienteRepository, ClienteRepository>();
            container.RegisterType<IProjetoRepository, ProjetoRepository>();
            container.RegisterType<IQuestaoAvaliadaRepository, QuestaoAvaliadaRepository>();
            container.RegisterType<IQuestaoRepository, QuestaoRepository>();
            container.RegisterType<IUsuarioRepository, UsuarioRepository>();
        }
    }

    public class WebApplicationContext : IApplicationContext
    {
        public WebApplicationContext()
        {

        }

        public string Login
        {
            get
            {
                if (HttpContext.Current.Session["LOGIN"] != null)
                    return HttpContext.Current.Session["LOGIN"].ToString();

                return null;
            }
            set
            {
                HttpContext.Current.Session["LOGIN"] = value;
            }
        }
    }
    
}
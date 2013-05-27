using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Infraestrutura.Comuns.Adapter;
using BSI.Zimmer.UI.Web.Controller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.UI.Web.Controller
{
    public static class ProjectionsExtensionMethods
    {
        public static TProjection Traduzir<TProjection>(this EntityBase item)
            where TProjection : class,new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        public static List<TProjection> TraduzirLista<TProjection>(this IEnumerable<EntityBase> items)
            where TProjection : class,new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }


        public static TProjection Traduzir<TProjection>(this ViewModelBase item)
            where TProjection : class,new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<TProjection>(item);
        }

        public static List<TProjection> TraduzirLista<TProjection>(this IEnumerable<ViewModelBase> items)
            where TProjection : class,new()
        {
            var adapter = TypeAdapterFactory.CreateAdapter();
            return adapter.Adapt<List<TProjection>>(items);
        }
    }
}

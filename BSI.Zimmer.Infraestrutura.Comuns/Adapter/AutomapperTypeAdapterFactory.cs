
namespace BSI.Zimmer.Infraestrutura.Comuns.Adapter
{
    using System;
    using System.Linq;
    using AutoMapper;
    using System.Collections.Generic;

    public class AutomapperTypeAdapterFactory
        :ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(s=>s.FullName.StartsWith("BSI."));
            List<Type> types = new List<Type>();            
            
            assemblies.Each(s=>
                    types.AddRange(s.GetTypes().AsEnumerable<Type>())
                );

            //scan all assemblies finding Automapper Profile
            var profiles = types.Where(s=>s.BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2")
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                } 
            });
        }

        #endregion

        #region ITypeAdapterFactory Members

        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}

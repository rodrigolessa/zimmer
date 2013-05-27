using AutoMapper;
using BSI.Zimmer.Infraestrutura.Comuns.Adapter;
using BSI.Zimmer.Infraestrutura.Comuns.Validator;
using BSI.Zimmer.UI.Web.Controller.ProfileMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Test.Mock
{
    public class MockInitialize
    {
        public static void InitializeTypeAdapter()
        {
            TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
        }

        public static void InitializeEntityValidator()
        {
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }

        public static void InitializeProfileMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new CriarViewModelProfile()));
        }
    }
}

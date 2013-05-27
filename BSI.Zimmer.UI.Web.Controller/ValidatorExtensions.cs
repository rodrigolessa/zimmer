using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Infraestrutura.Comuns.Validator;
using BSI.Zimmer.UI.Web.Controller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.UI.Web.Controller
{
    public static class ValidatorExtensions
    {
        public delegate void ExecutarSeValido();

        public static IEnumerable<string> DoIfIsValid<T>(this EntityBase entidadeASerValidada, ExecutarSeValido executarSeValido) where T : EntityBase
        {
            var validator = EntityValidatorFactory.CreateValidator();

            if (validator.IsValid((T)entidadeASerValidada))
            {
                executarSeValido();
                return null;
            }

            return validator.GetInvalidMessages((T)entidadeASerValidada);
        }

        public static bool HasErros(this IEnumerable<string> erros)
        {
            return erros != null && erros.Count() > 0;
        }

        public static ViewModelBase GetViewModel(this IEnumerable<string> erros)
        {
            return ViewModelBase.Error(erros, "Ops !");
        }
    }

}

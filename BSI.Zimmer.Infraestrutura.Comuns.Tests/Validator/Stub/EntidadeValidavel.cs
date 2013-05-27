using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Comuns.Tests.Validator.Stub
{
    public class EntidadeValidavel : IValidatableObject
    {
        public string PropriedadeObrigatoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (String.IsNullOrWhiteSpace(PropriedadeObrigatoria))
            {
                validationResults.Add(new ValidationResult("Propriedade Obrigatória", new string[] { "PropriedadeObrigatoria" }));
            }

            return validationResults;
        }
    }
}

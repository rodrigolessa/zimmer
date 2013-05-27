
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Dominio.Entity
{
    public partial class Artefato : EntityBase, IValidatableObject
    {

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            //-->Check first name property
            if (String.IsNullOrWhiteSpace(this.Nome))
            {
                validationResults.Add(new ValidationResult(Messages.Validation_CampoNomeObrigatorio,
                                                           new string[] { "Nome" }));
            }

            return validationResults;
        }
    }
}

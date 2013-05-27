using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Comuns.Tests.Validator.Stub
{
    internal class EntidadeComAtributoDeValidacao
    {
        [Required(ErrorMessage = "Essa propriedade é obrigatória")]
        public string PropriedadeObrigatoria{ get; set; }
    }
}

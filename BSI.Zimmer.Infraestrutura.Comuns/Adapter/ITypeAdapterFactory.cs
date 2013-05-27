using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSI.Zimmer.Infraestrutura.Comuns.Adapter
{
    public interface  ITypeAdapterFactory
    {
        ITypeAdapter Create();
    }
}

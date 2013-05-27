using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.UI.Web.Controller.ViewModel
{
    public class ItemListaModel
    {
        public ItemListaModel()
        {
        }


        public ItemListaModel(int? id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        int? idInt;
        public int? Id
        {
            get
            {
                return idInt;
            }
            set
            {
                idInt = value;
            }
        }


        public long? IdLong
        {
            get
            {
                if (idInt.HasValue)
                    return Convert.ToInt64(idInt.Value);

                return idInt;
            }
        }


        public string Descricao
        {
            get;
            set;
        }


    }
}

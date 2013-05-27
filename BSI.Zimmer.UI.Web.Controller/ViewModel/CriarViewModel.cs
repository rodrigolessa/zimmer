using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.UI.Web.Controller.ViewModel
{
    public class CriarViewModel : ViewModelBase
    {
        public CriarViewModel() : base() { }
        public Guid UsuarioId
        {
            get;
            set;
        }

        public string Login
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }


        public string Senha
        {
            get;
            set;
        }

        public string ConfirmaSenha
        {
            get;
            set;
        }

        public ItemListaModel PerfilAcesso
        {
            get;
            set;
        }

        public List<ItemListaModel> Perfis
        {
            get;
            set;
        }

        internal static CriarViewModel Empty()
        {
            return new CriarViewModel()
            {
                Perfis = new List<ItemListaModel>() 
                { 
                    new ItemListaModel(null,"Seu Perfil"),
                    new ItemListaModel(((int)PerfilUsuarioEnum.Desenvolvedor), "Desenvolvedor"),
                    new ItemListaModel(((int)PerfilUsuarioEnum.AnalistaRequisitos), "Analista de requisitos"),
                    new ItemListaModel(((int)PerfilUsuarioEnum.AnalistaQualidade), "Analista de qualidade"),
                    new ItemListaModel(((int)PerfilUsuarioEnum.AnalistaRequisitoEQualidade), "Um gênio, analista de qualidade e requisitos ao mesmo tempo")
                }
            };
        }



    }
}

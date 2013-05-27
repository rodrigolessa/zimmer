
var CriarViewModel = function (data)
{
    var self = ko.mapping.fromJS(data);    

    self.Salvar = function()
    {
        var url = config.urlDefinirPerfil;

        doAjx(url, self, function (resultado) {

            self.HasError(resultado.HasError);
            self.HasSuccess(resultado.HasSuccess);
            self.Mensagem(resultado.Mensagem);
            setTimeout("window.location = config.urlDashBoard", 3000);

        });
    }

    return self;
}



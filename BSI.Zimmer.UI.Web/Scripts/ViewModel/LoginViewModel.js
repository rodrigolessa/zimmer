
var LoginViewModel = function (data) {
    var self = ko.mapping.fromJS(data);

    self.Logar = function (contexto) {
        doAjx(config.urlLogar, self, function (resultado) {

            self.HasSuccess(resultado.HasSuccess);
            self.HasError(resultado.HasError);
            self.Mensagem(resultado.Mensagem);

            if (resultado.HasSuccess == true) {
                setTimeout("window.location = config.urlAutenticado", "3000");
            }

        });
    }

    self.CriarLogin = function () {
        window.location = config.urlCriarLogin;
    }



    return self;
}



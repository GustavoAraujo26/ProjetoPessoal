angular.module('gustavo').controller('HomeController', function ($scope, $http, $uibModal, $location) {

    var url = 'http://api.gustavodearaujo.com/v1/public/contatoProfissional/';

    $scope.contato = {};
    $scope.mensagem = '';
    $scope.loading = false;

    $scope.submeter = function() {
        if ($scope.formContato.$valid) {
            $scope.loading = true;
            //Setando os valores do id e data no objeto contato
            $scope.contato.id = 0;
            $scope.contato.data = new Date();
            //postando o objeto no servidor
            $http.post(url, $scope.contato)
                .success(function(result) {
                    console.log(result);
                    $scope.mensagem = 'Mensagem enviada com sucesso! Em breve retornarei o seu contato!';
                    $scope.contato = {};
                    $scope.loading = false;
                    $uibModal.open({
                        animation: $scope.animationsEnabled,
                        templateUrl: 'partials/modal/modal-sucesso.html',
                        controller: 'ModalController',
                        size: 'sm',
                        resolve: {
                            mensagem: function () {
                                return $scope.mensagem;
                            }
                        }
                    });
                    $location.path('/contato');
                })
                .error(function(error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um problema ao enviar sua mensagem! Por favor tente mais tarde!';
                    $scope.loading = false;
                    $uibModal.open({
                        animation: $scope.animationsEnabled,
                        templateUrl: 'partials/modal/modal-erro.html',
                        controller: 'ModalController',
                        size: 'sm',
                        resolve: {
                            mensagem: function () {
                                return $scope.mensagem;
                            }
                        }
                    });
                });
        }
    }

});

angular.module('gustavo').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});
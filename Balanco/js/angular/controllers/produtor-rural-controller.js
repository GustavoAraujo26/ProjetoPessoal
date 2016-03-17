angular.module('balanco').controller('ProdutorRuralController', function ($scope, recursoProdutor, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.produtores = [];
    $scope.produtor = {};
    $scope.fazendas = [];
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //Buscando todos os produtores no banco de dados
    recursoProdutor.query(function(produtores) {
        $scope.produtores = produtores;
        $scope.carregandoTabela = false;
    }, function(error) {
        console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar os produtores no banco de dados! Por favor tente mais tarde!';
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

    //Buscando o produtor rural especificado na URL
    if ($routeParams.produtorId) {
        recursoProdutor.get({ produtorId: $routeParams.produtorId }, function(produtor) {
            $scope.produtor = produtor;
        }, function(error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar o produtor nº ' + $routeParams.produtorId + '! Por favor tente mais tarde!';
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

    //Método para submeter as informações do formulário
    //Se tiver um id objeto será feito um update, senão será feito um insert
    $scope.submeterProdutor = function() {
        if ($scope.formProdutor.$valid) {
            $scope.loading = true;
            if ($routeParams.produtorId) {
                recursoProdutor.update({ produtorId: $scope.produtor.id }, $scope.produtor, function() {
                    $scope.mensagem = 'Produtor nº ' + $routeParams.produtorId + ' alterado com sucesso!';
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
                    $location.path(history.back());
                }, function(error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao atualizar o produtor nº ' + $routeParams.produtorId + '! Por favor tente mais tarde!';
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
            } else {
                $scope.produtor.id = 0;
                recursoProdutor.save($scope.produtor, function() {
                    $scope.produtor = {};
                    $scope.mensagem = 'Produtor incluido com sucesso!';
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
                    $location.path('/produtor');
                }, function(error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir o produtor! Por favor tente mais tarde!';
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
    };

    //Removendo o produtor selecionado
    $scope.removerProdutor = function(produtor) {
        if (confirm("Deseja realmente apagar " + produtor.nome + "?")) {
            $scope.loading = true;
            recursoProdutor.delete({ produtorId: produtor.id }, function () {
                $scope.mensagem = 'Produtor ' + produtor.nome + ' excluído com sucesso!';
                $scope.loading = false;
                $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'partials/modal/modal-sucesso.html',
                    controller: 'ModalController',
                    size: 'sm',
                    resolve: {
                        mensagem: function() {
                            return $scope.mensagem;
                        }
                    }
                });
                var indiceDoProdutor = $scope.produtores.indexOf(produtor);
                $scope.produtores.splice(indiceDoProdutor, 1);
            }, function(error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir o produtor! Por favor tente mais tarde!';
                $scope.loading = false;
                $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'partials/modal/modal-erro.html',
                    controller: 'ModalController',
                    size: 'sm',
                    resolve: {
                        mensagem: function() {
                            return $scope.mensagem;
                        }
                    }
                });
            });
        }
    };

    //Voltando para a página anterior
    $scope.voltarPagina = function() {
        $location.path(history.back());
    };

    //Carrega produtor para ser usado em outros controllers
    var carregaProdutor = function(id) {
        recursoProdutor.get({ produtorId: id }, function (produtor) {
            $scope.produtor = produtor;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar o produtor nº ' + $routeParams.produtorId + '! Por favor tente mais tarde!';
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
});

angular.module('balanco').controller('ModalController', function($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function() {
        $uibModalInstance.dismiss('cancel');
    }
});

angular.module('balanco').controller('ModalProdutorController', function ($scope, $uibModalInstance, recursoProdutor, $uibModal, $routeParams) {

    $scope.produtores = [];
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.loading = false;
    $scope.carregandoTabela = true;

    //Buscando todos os produtores no banco de dados
    recursoProdutor.query(function (produtores) {
        $scope.produtores = produtores;
        $scope.carregandoTabela = false;
    }, function (error) {
        console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar os produtores no banco de dados! Por favor tente mais tarde!';
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

    //Passando o id no modal de pesquisa
    $scope.ok = function (idDoProdutor) {
        $uibModalInstance.close(idDoProdutor);
    };

    //Fechando o modal de pesquisa
    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
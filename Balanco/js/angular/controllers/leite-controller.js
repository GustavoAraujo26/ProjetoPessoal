angular.module('balanco').controller('LeiteController', function ($scope, recursoLeite, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.leites = [];
    $scope.leite = {};
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //Buscando todas as vendas de leite no banco de dados
    recursoLeite.query(function (leites) {
        $scope.leites = leites;
        $scope.carregandoTabela = false;
    }, function (error) {
        console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar as vendas no banco de dados! Por favor tente mais tarde!';
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

    //Buscando a venda de leite especificada na URL
    if ($routeParams.vendaleiteId) {
        recursoLeite.get({ vendaleiteId: $routeParams.vendaleiteId }, function (leite) {
            $scope.leite = leite;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar a venda nº ' + $routeParams.vendaleiteId + '! Por favor tente mais tarde!';
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
    };

    //Método para submeter as informações do formulário
    //Se tiver um id objeto será feito um update, senão será feito um insert
    $scope.submeterLeite = function () {
        if ($scope.formLeite.$valid) {
            $scope.loading = true;
            if ($routeParams.vendaleiteId) {
                recursoLeite.update({ vendaleiteId: $scope.leite.id }, $scope.leite, function (result) {
                    $scope.mensagem = 'Venda nº ' + $routeParams.vendaleiteId + ' alterada com sucesso!';
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
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao atualizar a venda nº ' + $routeParams.vendaleiteId + '! Por favor tente mais tarde!';
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
                $scope.leite.id = 0;
                $scope.leite.produtorRural = null;
                recursoLeite.save($scope.leite, function (result) {
                    $scope.leite = {};
                    $scope.mensagem = 'Venda incluida com sucesso!';
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
                    $location.path('/leite');
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir a venda! Por favor tente mais tarde!';
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

    //Removendo a venda selecionada
    $scope.removerLeite = function (leite) {
        if (confirm("Deseja realmente apagar a venda nº" + leite.id + "?")) {
            $scope.loading = true;
            recursoLeite.delete({ vendaleiteId: leite.id }, function () {
                $scope.mensagem = 'Venda nº ' + leite.id + ' excluído(a) com sucesso!';
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
                var indiceDoLeite = $scope.leites.indexOf(leite);
                $scope.leites.splice(indiceDoLeite, 1);
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir a venda! Por favor tente mais tarde!';
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
    };

    //Voltando para a página anterior
    $scope.voltarPagina = function () {
        $location.path(history.back());
    };

    $scope.buscaProp = function () {
        $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'partials/modal/modal-produtor.html',
            controller: 'ModalProdutorController',
            size: 'lg',
            resolve: {
                mensagem: function () {
                    return $scope.mensagem;
                }
            }
        }).result.then(function (result) {
            $scope.leite.produtorRuralId = result;
        });
    }

});

angular.module('balanco').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});
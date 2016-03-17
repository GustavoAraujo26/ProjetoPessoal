angular.module('balanco').controller('VendaGadoController', function ($scope, recursoVendaGado, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.vendas = [];
    $scope.venda = {};
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //Buscando todas as vendas de gado no banco de dados
    recursoVendaGado.query(function (vendas) {
        $scope.vendas = vendas;
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

    //Buscando a compras especificada na URL
    if ($routeParams.vendagadoId) {
        recursoVendaGado.get({ vendagadoId: $routeParams.vendagadoId }, function (venda) {
            $scope.venda = venda;
            console.log($scope.venda);
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar a venda nº ' + $routeParams.vendagadoId + '! Por favor tente mais tarde!';
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
    $scope.submeterVenda = function () {
        if ($scope.formVenda.$valid) {
            $scope.loading = true;
            if ($routeParams.vendagadoId) {
                recursoVendaGado.update({ vendagadoId: $scope.venda.id }, $scope.venda, function (result) {
                    $scope.mensagem = 'Venda nº ' + $routeParams.vendagadoId + ' alterada com sucesso!';
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
                    $scope.mensagem = 'Houve um erro ao atualizar a venda nº ' + $routeParams.vendagadoId + '! Por favor tente mais tarde!';
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
                $scope.venda.id = 0;
                $scope.venda.produtorRural = null;
                recursoVendaGado.save($scope.venda, function (result) {
                    $scope.receita = {};
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
                    $location.path('/vendagado');
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

    //Removendo a despesa selecionada
    $scope.removerVenda = function (venda) {
        if (confirm("Deseja realmente apagar a venda nº" + venda.id + "?")) {
            $scope.loading = true;
            recursoVendaGado.delete({ vendagadoId: venda.id }, function () {
                $scope.mensagem = 'Venda nº ' + venda.id + ' excluído(a) com sucesso!';
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
                var indiceDaVenda = $scope.vendas.indexOf(venda);
                $scope.vendas.splice(indiceDaVenda, 1);
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
            $scope.venda.produtorRuralId = result;
        });
    }

});

angular.module('balanco').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});
angular.module('balanco').controller('DespesaController', function ($scope, recursoDespesa, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.despesas = [];
    $scope.despesa = {};
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //Buscando todas as despesas no banco de dados
    recursoDespesa.query(function (despesas) {
        $scope.despesas = despesas;
        $scope.carregandoTabela = false;
    }, function (error) {
        console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar as despesas no banco de dados! Por favor tente mais tarde!';
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

    //Buscando a despesa especificada na URL
    if ($routeParams.despesageralId) {
        recursoDespesa.get({ despesageralId: $routeParams.despesageralId }, function (despesa) {
            $scope.despesa = despesa;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar a despesa nº ' + $routeParams.despesageralId + '! Por favor tente mais tarde!';
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
    $scope.submeterDespesa = function () {
        if ($scope.formDespesa.$valid) {
            $scope.loading = true;
            if ($routeParams.despesageralId) {
                recursoDespesa.update({ despesageralId: $scope.despesa.id }, $scope.despesa, function (result) {
                    $scope.mensagem = 'Despesa nº ' + $routeParams.despesageralId + ' alterada com sucesso!';
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
                    $scope.mensagem = 'Houve um erro ao atualizar a despesa nº ' + $routeParams.despesageralId + '! Por favor tente mais tarde!';
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
                $scope.despesa.id = 0;
                $scope.despesa.produtorRural = null;
                recursoDespesa.save($scope.despesa, function (result) {
                    $scope.despesa = {};
                    $scope.mensagem = 'Despesa incluida com sucesso!';
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
                    $location.path('/despesa');
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir a despesa! Por favor tente mais tarde!';
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
    $scope.removerDespesa = function (despesa) {
        if (confirm("Deseja realmente apagar a despesa nº" + despesa.id + "?")) {
            $scope.loading = true;
            recursoDespesa.delete({ despesageralId: despesa.id }, function () {
                $scope.mensagem = 'Despesa nº ' + despesa.id + ' excluído(a) com sucesso!';
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
                var indiceDaDespesa = $scope.despesas.indexOf(despesa);
                $scope.despesas.splice(indiceDaDespesa, 1);
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir a despesa! Por favor tente mais tarde!';
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
            $scope.despesa.produtorRuralId = result;
        });
    }

});

angular.module('balanco').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});
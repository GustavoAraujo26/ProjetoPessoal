angular.module('balanco').controller('ReceitaController', function ($scope, recursoReceita, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.receitas = [];
    $scope.receita = {};
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //Buscando todas as receitas no banco de dados
    recursoReceita.query(function (receitas) {
        $scope.receitas = receitas;
        $scope.carregandoTabela = false;
    }, function (error) {
        console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar as receitas no banco de dados! Por favor tente mais tarde!';
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

    //Buscando a receita especificada na URL
    if ($routeParams.receitageralId) {
        recursoReceita.get({ receitageralId: $routeParams.receitageralId }, function (receita) {
            $scope.receita = receita;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar a receita nº ' + $routeParams.receitageralId + '! Por favor tente mais tarde!';
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
    $scope.submeterReceita = function () {
        if ($scope.formReceita.$valid) {
            $scope.loading = true;
            if ($routeParams.receitageralId) {
                recursoReceita.update({ receitageralId: $scope.receita.id }, $scope.receita, function (result) {
                    $scope.mensagem = 'Receita nº ' + $routeParams.receitageralId + ' alterada com sucesso!';
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
                    $scope.mensagem = 'Houve um erro ao atualizar a receita nº ' + $routeParams.receitageralId + '! Por favor tente mais tarde!';
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
                $scope.receita.id = 0;
                $scope.receita.produtorRural = null;
                recursoReceita.save($scope.receita, function (result) {
                    $scope.receita = {};
                    $scope.mensagem = 'Receita incluida com sucesso!';
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
                    $location.path('/receita');
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir a receita! Por favor tente mais tarde!';
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
    $scope.removerReceita = function (receita) {
        if (confirm("Deseja realmente apagar a receita nº" + receita.id + "?")) {
            $scope.loading = true;
            recursoReceita.delete({ receitageralId: receita.id }, function () {
                $scope.mensagem = 'Receita nº ' + receita.id + ' excluído(a) com sucesso!';
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
                var indiceDaReceita = $scope.receitas.indexOf(receita);
                $scope.receitas.splice(indiceDaReceita, 1);
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir a receita! Por favor tente mais tarde!';
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
            $scope.receita.produtorRuralId = result;
        });
    }

});

angular.module('balanco').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});
angular.module('balanco').controller('PosseController', function ($scope, recursoPosse, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.posses = [];
    $scope.posse = {};
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //Buscando todas as posses no banco de dados
    recursoPosse.query(function (posses) {
        $scope.posses = posses;
        $scope.carregandoTabela = false;
    }, function (error) {
        console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar as posses no banco de dados! Por favor tente mais tarde!';
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

    //Buscando a posse especificada na URL
    if ($routeParams.posseId) {
        recursoPosse.get({ posseId: $routeParams.posseId }, function (posse) {
            $scope.posse = posse;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar a posse nº ' + $routeParams.posseId + '! Por favor tente mais tarde!';
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
    $scope.submeterPosse = function () {
        if ($scope.formPosse.$valid) {
            $scope.loading = true;
            if ($routeParams.posseId) {
                recursoPosse.update({ posseId: $scope.posse.id }, $scope.posse, function (result) {
                    $scope.mensagem = 'Posse nº ' + $routeParams.posseId + ' alterada com sucesso!';
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
                    $scope.mensagem = 'Houve um erro ao atualizar a posse nº ' + $routeParams.posseId + '! Por favor tente mais tarde!';
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
                $scope.posse.id = 0;
                $scope.posse.produtorRural = null;
                recursoPosse.save($scope.posse, function (result) {
                    $scope.posse = {};
                    $scope.mensagem = 'Posse incluida com sucesso!';
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
                    $location.path('/posse');
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir a posse! Por favor tente mais tarde!';
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

    //Removendo a posse selecionada
    $scope.removerPosse = function (posse) {
        if (confirm("Deseja realmente apagar " + posse.descricao + "?")) {
            $scope.loading = true;
            recursoPosse.delete({ posseId: posse.id }, function () {
                $scope.mensagem = '' + posse.descricao + ' excluído(a) com sucesso!';
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
                var indiceDaPosse = $scope.posses.indexOf(posse);
                $scope.posses.splice(indiceDaPosse, 1);
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir a posse! Por favor tente mais tarde!';
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
            $scope.posse.produtorRuralId = result;
        });
    }

});

angular.module('balanco').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});
angular.module('cotacao').controller('RepresentanteController', function ($scope, recursoRepresentante, recursoFornecedor, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.fornecedores = [];
    $scope.representantes = [];
    $scope.representante = {};
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;
    $scope.selecao = [];

    //buscando todos os representantes
    recursoRepresentante.query(function (representantes) {
        $scope.representantes = representantes;
        $scope.carregandoTabela = false;
    }, function (error) {
        console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar os representantes no banco de dados. Por favor tente mais tarde!';
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

    //Buscando o fornecedor especificado na URL
    if ($routeParams.representanteId) {
        recursoRepresentante.get({ representanteId: $routeParams.representanteId }, function (representante) {
            $scope.representante = representante;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar o representante nº ' + $routeParams.representanteId + '! Por favor tente mais tarde!';
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
    $scope.submeterRepresentante = function () {
        if ($scope.formRepresentante.$valid) {
            $scope.loading = true;
            if ($routeParams.representanteId) {
                recursoRepresentante.update({ representanteId: $scope.representante.id }, $scope.representante, function () {
                    $scope.mensagem = '' + $scope.representante.nome + ' alterado com sucesso!';
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
                    $scope.mensagem = 'Houve um erro ao atualizar ' + $scope.representante.nome + '! Por favor tente mais tarde!';
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
                $scope.representante.id = 0;
                recursoRepresentante.save($scope.representante, function () {
                    $scope.representante = {};
                    $scope.mensagem = 'Representante incluido com sucesso!';
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
                    $location.path('/representante');
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir o representante! Por favor tente mais tarde!';
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
    $scope.removerRepresentante = function (representante) {
        if (confirm("Deseja realmente apagar " + representante.nome + "?")) {
            $scope.loading = true;
            recursoRepresentante.delete({ representanteId: representante.id }, function () {
                $scope.mensagem = '' + representante.nome + ' excluído com sucesso!';
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
                var indiceDoRepresentante = $scope.fornecedores.indexOf(representante);
                $scope.representantes.splice(indiceDoRepresentante, 1);
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir o representante! Por favor tente mais tarde!';
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

    $scope.buscaForn = function() {
        $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'partials/modal/modal-fornecedor.html',
            controller: 'FornecedorModalController',
            size: 'lg',
            resolve: {
                mensagem: function() {
                    return $scope.mensagem;
                }
            }
        }).result.then(function(result) {
            $scope.representante.fornecedorId = result;
        });
    };

});

angular.module('cotacao').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});

angular.module('cotacao').controller('RepresentanteModalController', function ($scope, $uibModalInstance, $uibModal, recursoRepresentante) {

    $scope.animationsEnabled = true;

    $scope.fornecedores = [];
    $scope.representantes = [];
    $scope.representante = {};
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;
    $scope.selecao = [];

    //buscando todos os representantes
    recursoRepresentante.query(function (representantes) {
        $scope.representantes = representantes;
        $scope.carregandoTabela = false;
    }, function (error) {
        console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar os representantes no banco de dados. Por favor tente mais tarde!';
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
    $scope.ok = function (idDoFornecedor) {
        $uibModalInstance.close(idDoFornecedor);
    };

    //Fechando o modal de pesquisa
    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
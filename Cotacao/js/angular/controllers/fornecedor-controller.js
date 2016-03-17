angular.module('cotacao').controller('FornecedorController', function ($scope, recursoFornecedor, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.fornecedores = [];
    $scope.fornecedor = {};
    $scope.fazendas = [];
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //buscando todos os fornecedores
    recursoFornecedor.query(function (fornecedores) {
        $scope.fornecedores = fornecedores;
        $scope.carregandoTabela = false;
    }, function (error) {
        Console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar os fornecedores no banco de dados. Por favor tente mais tarde!';
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
    if ($routeParams.fornecedorId) {
        recursoFornecedor.get({ fornecedorId: $routeParams.fornecedorId }, function (fornecedor) {
            $scope.fornecedor = fornecedor;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar o fornecedor nº ' + $routeParams.fornecedorId + '! Por favor tente mais tarde!';
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
    $scope.submeterFornecedor = function () {
        if ($scope.formFornecedor.$valid) {
            $scope.loading = true;
            if ($routeParams.fornecedorId) {
                recursoFornecedor.update({ fornecedorId: $scope.fornecedor.id }, $scope.fornecedor, function () {
                    $scope.mensagem = '' + $scope.fornecedor.razaoSocial + ' alterado com sucesso!';
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
                    $scope.mensagem = 'Houve um erro ao atualizar ' + $scope.fornecedor.razaoSocial + '! Por favor tente mais tarde!';
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
                $scope.fornecedor.id = 0;
                recursoFornecedor.save($scope.fornecedor, function () {
                    $scope.fornecedor = {};
                    $scope.mensagem = 'Fornecedor incluido com sucesso!';
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
                    $location.path('/fornecedor');
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir o fornecedor! Por favor tente mais tarde!';
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
    $scope.removerFornecedor = function (fornecedor) {
        if (confirm("Deseja realmente apagar " + fornecedor.razaoSocial + "?")) {
            $scope.loading = true;
            recursoFornecedor.delete({ fornecedorId: fornecedor.id }, function () {
                $scope.mensagem = '' + fornecedor.razaoSocial + ' excluído com sucesso!';
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
                var indiceDoFornecedor = $scope.fornecedores.indexOf(fornecedor);
                $scope.fornecedores.splice(indiceDoFornecedor, 1);
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir o fornecedor! Por favor tente mais tarde!';
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

});

angular.module('cotacao').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});

angular.module('cotacao').controller('FornecedorModalController', function ($scope, $uibModalInstance, $uibModal, recursoFornecedor) {
    

    $scope.animationsEnabled = true;

    $scope.fornecedores = [];
    $scope.fornecedor = {};
    $scope.fazendas = [];
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //buscando todos os fornecedores
    recursoFornecedor.query(function (fornecedores) {
        $scope.fornecedores = fornecedores;
        $scope.carregandoTabela = false;
    }, function (error) {
        Console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar os fornecedores no banco de dados. Por favor tente mais tarde!';
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
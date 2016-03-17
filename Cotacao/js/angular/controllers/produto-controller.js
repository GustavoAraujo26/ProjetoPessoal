angular.module('cotacao').controller('ProdutoController', function ($scope, recursoProduto, $routeParams, $location, $uibModal) {

    $scope.animationsEnabled = true;

    $scope.produtos = [];
    $scope.produto = {};
    $scope.fazendas = [];
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //buscando todos os produtos
    recursoProduto.query(function(produtos) {
        $scope.produtos = produtos;
        $scope.carregandoTabela = false;
    }, function(error) {
        Console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar os produtos no banco de dados. Por favor tente mais tarde!';
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

    //Buscando o produto rural especificado na URL
    if ($routeParams.produtoId) {
        recursoProduto.get({ produtoId: $routeParams.produtoId }, function (produto) {
            $scope.produto = produto;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar o produto nº ' + $routeParams.produtoId + '! Por favor tente mais tarde!';
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
    $scope.submeterProduto = function () {
        if ($scope.formProduto.$valid) {
            $scope.loading = true;
            if ($routeParams.produtoId) {
                recursoProduto.update({ produtoId: $scope.produto.id }, $scope.produto, function () {
                    $scope.mensagem = '' + $scope.produto.nome + ' alterado com sucesso!';
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
                    $scope.mensagem = 'Houve um erro ao atualizar ' + $scope.produto.nome + '! Por favor tente mais tarde!';
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
                $scope.produto.id = 0;
                recursoProduto.save($scope.produto, function () {
                    $scope.produto = {};
                    $scope.mensagem = 'Produto incluido com sucesso!';
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
                    $location.path('/produto');
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir o produto! Por favor tente mais tarde!';
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
    $scope.removerProduto = function (produto) {
        if (confirm("Deseja realmente apagar " + produto.nome + "?")) {
            $scope.loading = true;
            recursoProduto.delete({ produtoId: produto.id }, function () {
                $scope.mensagem = '' + produto.nome + ' excluído com sucesso!';
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
                var indiceDoProduto = $scope.produtos.indexOf(produto);
                $scope.produtos.splice(indiceDoProduto, 1);
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir o produto! Por favor tente mais tarde!';
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

angular.module('cotacao').controller('ProdutoModalController', function ($scope, $uibModalInstance, $uibModal, recursoProduto) {

    $scope.animationsEnabled = true;

    $scope.produtos = [];
    $scope.produto = {};
    $scope.fazendas = [];
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //buscando todos os produtos
    recursoProduto.query(function (produtos) {
        $scope.produtos = produtos;
        $scope.carregandoTabela = false;
    }, function (error) {
        Console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar os produtos no banco de dados. Por favor tente mais tarde!';
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
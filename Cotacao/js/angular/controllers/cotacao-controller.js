angular.module('cotacao').controller('CotacaoController',
function ($scope, recursoCotacao, $routeParams, $location, $uibModal, menorPreco, 
    ofertaPorRepresentanteEPreco, ofertaPorProdutoEPreco) {

    $scope.animationsEnabled = true;

    $scope.cotacoes = [];
    $scope.cotacao = {};
    $scope.filtro = '';
    $scope.mensagem = '';
    $scope.pageSize = 10;
    $scope.currentPage = 1;
    $scope.carregandoTabela = true;
    $scope.loading = false;

    //Lista personalizada
    $scope.cotacoesPorMenorPreco = [];
    $scope.cotacoesPorRepresentanteEPreco = [];
    $scope.cotacoesPorProdutoEPreco = [];

    //buscando todas as ofertas
    recursoCotacao.query(function (cotacoes) {
        $scope.cotacoes = cotacoes;
        $scope.carregandoTabela = false;
    }, function (error) {
        Console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar as ofertas no banco de dados. Por favor tente mais tarde!';
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
    if ($routeParams.cotacaoId) {
        recursoCotacao.get({ cotacaoId: $routeParams.cotacaoId }, function (cotacao) {
            $scope.cotacao = cotacao;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um erro ao buscar a oferta nº ' + $routeParams.cotacaoId + '! Por favor tente mais tarde!';
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
    $scope.submeterOferta = function () {
        if ($scope.formOferta.$valid) {
            $scope.loading = true;
            $scope.cotacao.data = new Date();
            $scope.cotacao.produto = {};
            $scope.cotacao.representante = {};
            console.log($scope.cotacao);
            if ($routeParams.cotacaoId) {
                recursoCotacao.update({ cotacaoId: $scope.cotacao.id }, $scope.cotacao, function () {
                    $scope.mensagem = 'Oferta nº ' + $scope.cotacao.id + ' alterada com sucesso!';
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
                    $scope.mensagem = 'Houve um erro ao atualizar a oferta nº ' + $scope.cotacao.id + '! Por favor tente mais tarde!';
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
                $scope.cotacao.id = 0;
                $scope.cotacao.data = new Date();
                recursoCotacao.save($scope.cotacao, function () {
                    $scope.cotacao = {};
                    $scope.mensagem = 'Oferta incluida com sucesso!';
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
                    $location.path('/cotacao');
                }, function (error) {
                    console.log(error);
                    $scope.mensagem = 'Houve um erro ao incluir a oferta! Por favor tente mais tarde!';
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
    $scope.removerOferta = function (cotacao) {
        if (confirm("Deseja realmente apagar a oferta nº " + cotacao.id + "?")) {
            $scope.loading = true;
            recursoCotacao.delete({ cotacaoId: cotacao.id }, function () {
                $scope.mensagem = 'Oferta nº ' + cotacao.id + ' excluída com sucesso!';
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
                var indiceDaCotacao = $scope.cotacoes.indexOf(cotacao);
                $scope.cotacoes.splice(indiceDaCotacao, 1);
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao excluir a oferta! Por favor tente mais tarde!';
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

    $scope.buscaProd = function () {
        $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'partials/modal/modal-produto.html',
            controller: 'ProdutoModalController',
            size: 'lg',
            resolve: {
                mensagem: function () {
                    return $scope.mensagem;
                }
            }
        }).result.then(function (result) {
            $scope.cotacao.produtoId = result;
        });
    };

    $scope.buscaRepres = function () {
        $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'partials/modal/modal-representante.html',
            controller: 'RepresentanteModalController',
            size: 'lg',
            resolve: {
                mensagem: function () {
                    return $scope.mensagem;
                }
            }
        }).result.then(function (result) {
            $scope.cotacao.representanteId = result;
        });
    };

    //buscando todas as ofertas
    menorPreco.query(function (cotacoes) {
        $scope.cotacoesPorMenorPreco = cotacoes;
        $scope.carregandoTabela = false;
    }, function (error) {
        Console.log(error);
        $scope.mensagem = 'Houve um problema ao buscar as ofertas no banco de dados. Por favor tente mais tarde!';
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

    $scope.buscaRepresPrecos = function (id) {
        //buscando todas as ofertas
        ofertaPorRepresentanteEPreco.query({ representanteId: id }, function (cotacoes) {
            $scope.cotacoesPorRepresentanteEPreco = cotacoes;
            $scope.carregandoTabela = false;
        }, function (error) {
            console.log(error);
            $scope.mensagem = 'Houve um problema ao buscar as ofertas no banco de dados. Por favor tente mais tarde!';
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

    $scope.buscaProdPrecos = function (id) {
        //buscando todas as ofertas
        ofertaPorProdutoEPreco.query({ produtoId: id }, function (cotacoes) {
            $scope.cotacoesPorProdutoEPreco = cotacoes;
            $scope.carregandoTabela = false;
        }, function (error) {
            Console.log(error);
            $scope.mensagem = 'Houve um problema ao buscar as ofertas no banco de dados. Por favor tente mais tarde!';
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

});

angular.module('cotacao').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});
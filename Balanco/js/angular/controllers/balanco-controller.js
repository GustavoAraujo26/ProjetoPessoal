angular.module('balanco').controller('BalancoController',
    function ($scope, recursoProdutor, balancoCompraGado, balancoDespesa, balancoLeite, balancoPosse, balancoReceita, balancoVendaGado, $uibModal) {

    $scope.totalReceitas = 0;
    $scope.totalDespesas = 0;
    $scope.resultado = 0;
    $scope.produtor = '';
    $scope.ano = new Date().getFullYear();
    $scope.somaCompra = 0;
    $scope.somaVenda = 0;
    $scope.somaDespesa = 0;
    $scope.somaReceita = 0;
    $scope.somaLeite = 0;
    $scope.somaPosse = 0;
    $scope.somaQtdCabecasCompra = 0;
    $scope.somaQtdCabecasVenda = 0;
    $scope.produtorSelecionado = {};
    $scope.balancoDasComprasDeGado = [];
    $scope.balancoDasVendasDeGado = [];
    $scope.balancoDasDespesas = [];
    $scope.balancoDeVendasLeite = [];
    $scope.balancoDasPosses = [];
    $scope.balancoDasReceitas = [];
    $scope.pageSize = 6;
    $scope.currentPage = 1;
    $scope.loading = false;

    $scope.verBalanco = function(produtor, ano) {
        if ($scope.formBalanco.$valid) {
            $scope.loading = true;
            $scope.totalReceitas = 0;
            $scope.totalDespesas = 0;
            $scope.resultado = 0;

            balancoCompraGado.query({ produtorId: produtor, ano: ano }, function (balanco) {
                $scope.balancoDasComprasDeGado = balanco;
                var total = 0;
                var qtd = 0;
                for (var i = 0; i < $scope.balancoDasComprasDeGado.length; i++) {
                    total += $scope.balancoDasComprasDeGado[i].valor;
                    qtd += $scope.balancoDasComprasDeGado[i].quantidadeCabecas;
                }
                $scope.somaCompra = total;
                $scope.totalDespesas += total;
                $scope.resultado -= total;
                $scope.somaQtdCabecasCompra = qtd;
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao buscar o balanço das compras de gado! Por favor tente mais tarde!';
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
            recursoProdutor.get({ produtorId: produtor }, function (produtor) {
                $scope.produtorSelecionado = produtor;
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao buscar o produtor nº ' + produtor + '! Por favor tente mais tarde!';
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

            balancoDespesa.query({ produtorId: produtor, ano: ano }, function (balanco) {
                $scope.balancoDasDespesas = balanco;
                var total = 0;
                for (var i = 0; i < $scope.balancoDasDespesas.length; i++) {
                    total += $scope.balancoDasDespesas[i].valor;
                }
                $scope.somaDespesa = total;
                $scope.totalDespesas += total;
                $scope.resultado -= total;
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao buscar o balanço das despesas gerais! Por favor tente mais tarde!';
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

            balancoLeite.query({ produtorId: produtor, ano: ano }, function (balanco) {
                $scope.balancoDeVendasLeite = balanco;
                var total = 0;
                for (var i = 0; i < $scope.balancoDeVendasLeite.length; i++) {
                    total += $scope.balancoDeVendasLeite[i].valor;
                }
                $scope.somaLeite = total;
                $scope.totalReceitas += total;
                $scope.resultado += total;
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao buscar o balanço das vendas de leite! Por favor tente mais tarde!';
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

            balancoPosse.query({ produtorId: produtor, ano: ano }, function (balanco) {
                $scope.balancoDasPosses = balanco;
                var total = 0;
                for (var i = 0; i < $scope.balancoDasPosses.length; i++) {
                    total += $scope.balancoDasPosses[i].valor;
                }
                $scope.somaPosse = total;
                $scope.totalDespesas += total;
                $scope.resultado -= total;
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao buscar o balanço das posses! Por favor tente mais tarde!';
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

            balancoReceita.query({ produtorId: produtor, ano: ano }, function (balanco) {
                $scope.balancoDasReceitas = balanco;
                var total = 0;
                for (var i = 0; i < $scope.balancoDasReceitas.length; i++) {
                    total += $scope.balancoDasReceitas[i].valor;
                }
                $scope.somaReceita = total;
                $scope.totalReceitas += total;
                $scope.resultado += total;
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao buscar o balanço das receitas gerais! Por favor tente mais tarde!';
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

            balancoVendaGado.query({ produtorId: produtor, ano: ano }, function (balanco) {
                $scope.balancoDasVendasDeGado = balanco;
                var total = 0;
                var qtd = 0;
                for (var i = 0; i < $scope.balancoDasVendasDeGado.length; i++) {
                    total += $scope.balancoDasVendasDeGado[i].valor;
                    qtd += $scope.balancoDasVendasDeGado[i].quantidadeCabecas;
                }
                $scope.somaVenda = total;
                $scope.totalReceitas += total;
                $scope.resultado += total;
                $scope.somaQtdCabecasVenda = qtd;
            }, function (error) {
                console.log(error);
                $scope.mensagem = 'Houve um erro ao buscar o balanço das vendas de gado! Por favor tente mais tarde!';
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

            $scope.loading = false;
        }
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
            $scope.produtor = result;
        });
    }

});

angular.module('balanco').controller('ModalController', function ($scope, $uibModalInstance, mensagem) {
    $scope.mensagem = mensagem;

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    }
});
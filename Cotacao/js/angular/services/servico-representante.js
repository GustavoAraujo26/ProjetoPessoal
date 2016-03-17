angular.module('servicoRepresentante', ['ngResource'])
    .factory('recursoRepresentante', function ($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/representante/:representanteId', null, {
            'update': {
                method: 'PUT'
            }
        });
    });
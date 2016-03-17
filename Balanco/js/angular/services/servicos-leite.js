angular.module('servicoLeite', ['ngResource'])
    .factory('recursoLeite', function ($resource) {

        return $resource('http://api.gustavodearaujo.com/v1/public/vendaleite/:vendaleiteId', null, {
            'update': {
                method: 'PUT'
            }
        });
    })
    .factory('balancoLeite', function ($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/vendaleite/balanco/:produtorId/:ano', null, null);
    });
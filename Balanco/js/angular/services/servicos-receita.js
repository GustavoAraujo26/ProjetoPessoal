angular.module('servicoReceita', ['ngResource'])
    .factory('recursoReceita', function ($resource) {

        return $resource('http://api.gustavodearaujo.com/v1/public/receitageral/:receitageralId', null, {
            'update': {
                method: 'PUT'
            }
        });
    })
    .factory('balancoReceita', function ($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/receitageral/balanco/:produtorId/:ano', null, null);
    });
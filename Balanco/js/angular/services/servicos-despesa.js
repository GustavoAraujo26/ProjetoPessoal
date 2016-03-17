angular.module('servicoDespesa', ['ngResource'])
    .factory('recursoDespesa', function ($resource) {

        return $resource('http://api.gustavodearaujo.com/v1/public/despesageral/:despesageralId', null, {
            'update': {
                method: 'PUT'
            }
        });
    })
    .factory('balancoDespesa', function ($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/despesageral/balanco/:produtorId/:ano', null, null);
    });
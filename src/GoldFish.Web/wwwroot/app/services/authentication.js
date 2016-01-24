(function () {

    'use strict';
    angular
        .module('app.services')
        .factory('authService', authService);

    authService.$inject = ['$cookies'];

    function authService($cookies) {
        var service = {
            authenticate: authenticate
        }

        function authenticate(userName, password) {

        }

        return service;
    }
})();
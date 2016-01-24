(function () {
    'use strict';

    angular
        .module('app.account')
        .config(configureRoute);

    configureRoute.$inject = ['stateHelperProvider'];

    function configureRoute(stateHelperProvider) {
        stateHelperProvider.state({
            name: 'root.account',
            url: '/account',
            templateUrl: '/app/account/account.html',
            children: [
            {
                name: 'signup',
                url: '/signup',
                templateUrl: 'app/account/account.signup.html'
            },
            {
                name: 'signin',
                url: '/signin',
                templateUrl: 'app/account/account.signin.html'
            }]
        });
    }
})();
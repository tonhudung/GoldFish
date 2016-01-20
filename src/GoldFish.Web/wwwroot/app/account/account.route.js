(function() {
    'use strict';

    angular
        .module('app.account')
        .config(configureRoute);

    configureRoute.$inject = ['stateHelperProvider'];

    function configureRoute(stateHelperProvider) {
        stateHelperProvider.state({
            name: 'account',
            children:[
            {
                name: 'register',
                templateUrl: 'app/account/account.register.html'
            }]
        });
    }
})();
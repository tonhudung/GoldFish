(function () {
    'use strict';
    angular
        .module('app.layout')
        .config(configureRoute);

    configureRoute.$inject = ['stateHelperProvider'];

    function configureRoute(stateHelperProvider) {
        stateHelperProvider.state({
            name: 'root',
            abstract: true,
            views: {
                'header': {
                    templateUrl: 'app/shell/header.html'
                },
                'footer': {
                    templateUrl: 'app/shell/footer.html'
                }
            }
        });
    }
})();
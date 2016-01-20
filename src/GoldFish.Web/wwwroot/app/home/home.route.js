﻿(function () {
    'use strict';
    angular
        .module('app.home')
        .config(configureRoute);

    configureRoute.$inject = ['stateHelperProvider', '$urlRouterProvider'];

    function configureRoute(stateHelperProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/');

        stateHelperProvider.state({
            name: 'home',
            url: '/',
            templateUrl: 'app/home/home.html'
        });
    }
})();
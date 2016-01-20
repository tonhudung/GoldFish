(function () {
    'use strict';

    angular
        .module('app.layout')
        .controller('Shell', shell)
        .run(initialize);

    initialize.$inject = ['$state'];

    function initialize($state) {
        // a fix for https://github.com/angular-ui/ui-router/issues/679
    }

    function shell() {
        var vm = this;
    }
})();
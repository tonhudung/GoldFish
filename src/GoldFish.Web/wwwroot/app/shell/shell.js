(function () {
    'use strict';

    angular
        .module('app.layout')
        .controller('shellCtrl', shellCtrl)
        .controller('headerCtrl', headerCtrl)
        .run(initialize);

    initialize.$inject = ['$state'];
    function initialize($state) {
        // a fix for https://github.com/angular-ui/ui-router/issues/679
    }

    function shellCtrl() {
        var vm = this;
    }

    function headerCtrl() {
        var vm = this;
    }
})();
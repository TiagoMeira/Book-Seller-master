(function () {
    "use strict";

    function mainController($scope, $rootScope, booksService) {
        $rootScope.currency = 'R$'; // Default currency

        var vm = this;
        vm.editionMode = false;

        vm.editionMode = booksService.getEditionState().state;

        $scope.$on('edition-change', function () {
            vm.editionMode = booksService.getEditionState().state;
        });
    }

    angular
        .module("booksSeller")
        .controller("mainController",
        ["$scope", "$rootScope",'booksService', mainController]);
})();
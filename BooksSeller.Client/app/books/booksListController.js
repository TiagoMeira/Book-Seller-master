(function () {
    "use strict";

    function booksListController($rootScope, booksService) {
        var vm = this;
        vm.books = [];

        function getAll() {
            booksService.getAll.query(function (res) {
                vm.books = res;
            });
        }

        $rootScope.$on('edition-change', getAll);
        getAll();        

        vm.click = function (book) {
            booksService.setEditionState({ state: true, book: book });
            $rootScope.$broadcast('edition-change');
        };

        vm.toCreation = function () {
            booksService.setEditionState({ state: true, book: null });
            $rootScope.$broadcast('edition-change');
        };
    }    

    booksListController.$inject = ['$rootScope','booksService'];

    angular
        .module("booksSeller")
        .controller("booksListController",
            booksListController);
}());
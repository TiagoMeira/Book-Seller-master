(function () {
    "use strict";

    function booksEditController($rootScope, booksService) {
        var vm = this;
        vm.book = booksService.getEditionState().book || {};
        vm.originalBook = Object.assign({}, vm.book);
        vm.title = '';
        vm.message = '';

        // Query the book using a service
        if (vm.book && vm.book.Id) {
            vm.title = "Edit: " + vm.book.Title;
            booksService.get.get({ id: vm.book.Id }, function (object) {
                vm.book = object;
            });
        }
        else {
            vm.title = "New Book";
        }

        function returnPage() {
            booksService.setEditionState({ state: false, book: null });
            $rootScope.$broadcast('edition-change');
        }

        vm.submit = function () {
            vm.message = '';
            var re = new RegExp("^[A-Z]{3}-[0-9]{4}$");

            if (vm.book.Id) {
                if (!re.test(vm.book.Code)) {
                    alert("Code is not valid. It must be in ABC-9999 format.");

                    returnPage();
                }
                if (vm.book.Title === "" || vm.book.Price === "") {
                    alert("Test");

                    returnPage();
                }

                // Update Book
                booksService.update.update({ id: vm.book.Id }, vm.book, function () {
                    returnPage();
                });

            } else {
                if (vm.book.Title === "" || vm.book.Price === "") {
                    alert("Test");

                    returnPage();
                }

                if (!re.test(vm.book.Code)) {
                    alert("Code is not valid. It must be in ABC-9999 format.");

                    returnPage();
                }

                // Save a New Book
                booksService.save.save(vm.book, function () {
                    returnPage();
                });
            }
        };

        vm.delete = function () {
            booksService.delete.delete({ id: vm.book.Id }, function () {
                returnPage();
            });

        };


        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.book = angular.copy(vm.originalBook);
            vm.message = '';

            returnPage();
        };

    }

    booksEditController.$inject = ['$rootScope', 'booksService'];

    angular
    .module("booksSeller")
    .controller("booksEditController",
                 booksEditController);
}());

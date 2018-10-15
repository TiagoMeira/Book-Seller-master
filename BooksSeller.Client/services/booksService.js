(function () {
    "use strict";

    function booksService($resource, appSettings) {
        let editionState = { state: false, book: null };

        return {
            get: $resource(appSettings.serverPath + "/api/Books/:id", null),
            getAll: $resource(appSettings.serverPath + "/api/Books", null),
            save: $resource(appSettings.serverPath + "/api/Books", null,
                {
                    'save': { method: 'POST' }
                }),
            update: $resource(appSettings.serverPath + "/api/Books/:id", null,
                {
                    'update': { method: 'PUT' }
                }),
            delete: $resource(appSettings.serverPath + "/api/Books/:id", null, {
                'delete': { method: 'DELETE'}
            }),
            getEditionState: function () {
                return editionState;
            },
            setEditionState: function (value) {
                editionState = value;
            }
        };
    }

    angular
        .module("booksSeller")
        .factory("booksService",
                  ["$resource", "appSettings",
                   booksService]);
})();
(function () {
    angular
        .module("driviato")
        .controller("PositionController", PositionController);

    BookingController.$inject = ['$scope', 'PositionService'];

    function PositionController($scope, PositionService) {
        // jshint validthis=true
        var vm = this;
    }
})();
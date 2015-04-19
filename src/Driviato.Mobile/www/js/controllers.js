angular.module('driviato.controllers', [])

.controller('DashboardController', function($scope) {
	$scope.points = 16;
	$scope.balance = "4.75";
})

.controller('FlagController', function($scope, FlagService, PositionService) {
  $scope.flags = FlagService.getAll();
  PositionService.start();
})

.controller('AccountController', function($scope) {
			$scope.settings = {
				enableTracking: true,
				sendUpdates: true
			};
			$scope.profile = {
				name: "Joe Driver",
				email: "needforspeed99@example.com"
			};
		})

.controller('PaymentController', function($scope, PaymentService) {
			$scope.card = {
				name: "Jane Driver",
				cardNumber: "4111111111111111",
				expirationYear: 2016,
				expirationMonth: "January"
			};

			$scope.save = function () {
				console.log("Saving payment information");
				PaymentService.save($scope.card);
			};
		})

.controller('MapController', function($scope, FlagService) {
			var vm = this;

        vm.assignments = inspectionService.getInspections();
        vm.cancelSchedule = cancelSchedule;
        vm.map = {
            center: {
                latitude: 35.8279982,
                longitude: -78.8875135
            },
            zoom: 12,
            markers: [],
            options: {
                zoomControl: false,                
                streetViewControl: false,
                mapTypeControl: false,
                mapMaker: false,
            },
            events: {
                click: function (marker, eventName, args) {
                    vm.showAddressBar = false;
                    $scope.$apply();
                }
            }
        };
		})

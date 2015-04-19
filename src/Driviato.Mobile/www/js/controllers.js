angular.module('driviato.controllers', [])

.controller('DashboardController', function($scope) {
	$scope.points = 16;
})

.controller('FlagController', function($scope, FlagService) {
  $scope.flags = FlagService.getAll();
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

.controller('PaymentController', function($scope) {
			$scope.settings = {
				enableTracking: true,
				sendUpdates: true
			};
			$scope.profile = {
				name: "Joe Driver",
				email: "needforspeed99@example.com"
			};
		});

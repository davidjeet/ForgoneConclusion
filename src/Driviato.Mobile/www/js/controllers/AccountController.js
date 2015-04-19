(function () {
	"use strict";
	
	angular
		.module('driviato.controllers', [])
		.controller('AccountController', function($scope) {
			$scope.settings = {
				enableTracking: true,
				sendUpdates: true
			};
			$scope.profile = {
				name: "Joe Driver",
				email: "needforspeed99@example.com"
			};
		});
})();

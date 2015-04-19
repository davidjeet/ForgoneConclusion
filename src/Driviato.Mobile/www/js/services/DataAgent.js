(function () {
	"use strict";

	angular
    .module("driviato.services")
    .factory("DataAgent", function ($http) {
    	var baseApiUrl = "http://driviato.azurewebsites.net/api";

    	function send (data) {
    		$http({
    			method: "POST",
    			url: baseApiUrl + "/driverPositions",
    			headers: {
    				"Content-Type": "application/json",
    				"Accept": "application/json"
    			}
    		})
    		.success(function (response) {
    			
    		})
    		.error(function (reason) {
    			
    		});
    	}

    	return {
    		send: send
    	};
    });
})();
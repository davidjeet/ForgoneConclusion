(function () {
  "use strict";

  angular
    .module("driviato.services")
    .factory("PositionService", function($q, DataAgent) {
        var positions = [],
            intervalMs = 10000,
            intervalId = null;

        var onSuccess = function (position) {
                positions.push(position);
            },
            onError = function (error) {
                console.error(error);
            };

        function recordPosition() {
            if (navigator.geolocation && navigator.geolocation.getCurrentPosition) {
                navigator.geolocation.getCurrentPosition(onSuccess, onError);
            }
        }

        function sendData() {
            DataAgent.send(positions);
        }

        function start() {
            intervalId = window.setInterval(recordPosition, intervalMs)
        }

        function stop() {
            window.clearTimeout(intervalId);
        }

        start();

	    return {
	        sendData: sendData,
            start: start,
            stop: stop
	    };
    });
})();

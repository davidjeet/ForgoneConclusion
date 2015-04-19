angular.module('driviato.services', [])

.factory('FlagService', function() {
  // Might use a resource here that returns a JSON array

  // Some fake testing data
  var flags = [{
    id: 0,
    name: 'Speeding',
    lastText: 'Friday 4/17: 38 MPH on McCrimmon Pkwy',
    type: 'warning'
  }, {
    id: 1,
    name: 'Fast start',
    lastText: 'Thursday 4/14: Fast start on NC Hwy 55',
    type: 'error'
  }, {
    id: 2,
    name: 'Fast turn',
    lastText: 'Wednesday 4/15: 21 MPH NC Hwy 55 onto McCrimmon Pkwy',
    type: 'warning'
  }, {
    id: 3,
    name: 'Fast start',
    lastText: 'Monday 4/13: Fast start on Cary Glen Blvd',
    type: 'warning'
  }, {
    id: 4,
    name: 'Speeding',
    lastText: 'Friday 4/10: 41 MPH on McCrimmon Pkwy',
    type: 'error'
  }];

  return {
    getAll: function() {
      return flags;
    }
  };
})

.factory('PaymentService', function($http) {
  var baseApiUrl = "http://driviato.azurewebsites.net/api";

  var updateCard = function (card) {
    var data = {
        "FirstName": "Joe", 
        "LastName": "Driver",
        "Email": "battlehack@i1n.net",
        "CreditCard": {
            "FirstName": "Jane",
            "LastName": "Driver"
          },
          "CardholderName": "Jane Driver",
          "ExpirationMonth": card.expirationMonth,
          "ExpirationYear": card.expirationYear, 
          "ExpirationDate": "01/2016", 
          "Number": card.cardNumber
        };

    $http({
          method: "POST",
          url: baseApiUrl + "/CreateCustomer",
          data: JSON.stringify(data),
          headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
          }
        })
        .success(function (response) {
          console.log(response);
        })
        .error(function (error) {
          console.log(error);
        });
  };

  return {
    save: updateCard
  };
})

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
    })

    .factory("DataAgent", function ($http) {
      var baseApiUrl = "http://driviato.azurewebsites.net/api";

      function send (data) {
        $http({
          method: "POST",
          url: baseApiUrl + "/driverPositions",
          data: data,
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

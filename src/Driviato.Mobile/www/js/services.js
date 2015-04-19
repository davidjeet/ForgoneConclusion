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
});

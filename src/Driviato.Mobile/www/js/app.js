(function () {
angular.module('driviato', ['ionic', 'driviato.controllers', 'driviato.services'])

.run(function($ionicPlatform) {
  $ionicPlatform.ready(function() {
    // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
    // for form inputs)
    if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
      cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
    }
    if (window.StatusBar) {
      // org.apache.cordova.statusbar required
      StatusBar.styleLightContent();
    }
  });
})

.config(function($stateProvider, $urlRouterProvider) {
  $stateProvider
    .state('tab', {
    url: "/tab",
    abstract: true,
    templateUrl: "templates/tabs.html"
  })
  .state('tab.dash', {
    url: '/dash',
    views: {
      'tab-dash': {
        templateUrl: 'templates/tab-dash.html',
        controller: 'DashboardController'
      }
    }
  })
  .state('tab.flags', {
      url: '/flags',
      views: {
        'tab-flags': {
          templateUrl: 'templates/tab-flags.html',
          controller: 'FlagController'
        }
      }
    })
  // .state('tab.flag-detail', {
  //     url: '/flags/:flagId',
  //     views: {
  //       'tab-flags': {
  //         templateUrl: 'templates/flag-detail.html',
  //         controller: 'FlagDetailController'
  //       }
  //     }
  //   })
  .state('tab.account', {
    url: '/account',
    views: {
      'tab-account': {
        templateUrl: 'templates/tab-account.html',
        controller: 'AccountController'
      }
    }
  })
  .state('tab.payment-method', {
    url: '/account/payment',
    views: {
      'tab-account': {
        templateUrl: 'templates/payment-method.html',
        controller: 'PaymentController'
      }
    }
  });

  // if none of the above states are matched, use this as the fallback
  $urlRouterProvider.otherwise('/tab/dash');

});
})();

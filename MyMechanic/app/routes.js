
angular.module("codera.shopping").config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("/welcome");

    
    $stateProvider
        .state('welcome', {
            url: '/welcome',
            templateUrl: 'app/welcome/welcome.html',
            controller: 'WelcomeController',
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var userId = $cookies.get("userId");

                    if (userId) {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }

        })
        .state('myprofile', {
            url: '/myprofile',
            templateUrl: 'app/myprofile/myprofile.html',
            controller: "MyProfileController",
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var userRole = $cookies.get("userRole");

                    if (userRole == "1") {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }
        })
        .state('mymechanicprofile', {
            url: '/mymechanicprofile',
            templateUrl: 'app/mymechanicprofile/mymechanicprofile.html',
            controller: "MyMechanicProfileController",
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var isMechanic = $cookies.get("isMechanic");
                    if (isMechanic == false) {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }
        })
        .state('myvehicles', {
            url: '/myvehicles',
            templateUrl: 'app/myvehicles/myvehicles.html',
            controller: "MyVehiclesController",
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var userRole = $cookies.get("userRole");

                    if (userRole == "1") {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }
        })
        .state('mechanics', {
            url: '/mechanics',
            templateUrl: 'app/mechanics/mechanics.html',
            controller: "MechanicsController",
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var userRole = $cookies.get("userRole");

                    if (userRole != "1") {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }
        })
        .state('vehicles', {
            url: '/vehicles',
            templateUrl: 'app/vehicles/vehicles.html',
            controller: "VehiclesController",
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var userRole = $cookies.get("userRole");

                    if (userRole != "1") {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }
        })
        .state('users', {
            url: '/users',
            templateUrl: 'app/users/users.html',
            controller: "UsersController",
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var userRole = $cookies.get("userRole");

                    if (userRole != "1") {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }
        })
        .state('inspections', {
            url: '/inspections',
            templateUrl: 'app/inspections/inspections.html',
            controller: "InspectionsController",
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var userRole = $cookies.get("userRole");

                    if (userRole != "1") {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }
        })
        .state('admin-panel', {
            url: '/admin-panel/:id',
            templateUrl: 'app/admin-panel/admin-panel.html',
            controller: "AdminPanelController",
            resolve: {
                loggedIn: function ($q, $cookies) {
                    var userRole = $cookies.get("userRole");

                    if (userRole != "1") {
                        return $q.reject();
                    }
                    else {
                        return $q.resolve();
                    }
                }
            }
        })
});
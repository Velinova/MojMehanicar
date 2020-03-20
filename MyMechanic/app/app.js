
var app = angular.module("codera.shopping", [
    "ngMessages",
    "ui.bootstrap",
    "ui.router",
    "ngCookies"

]);
app.constant("serverUrl", "http://localhost:1246/");
app.constant("emailRegex", "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");

app.factory('notAuthorizedInterceptor', function ($q, $location, $cookies) {
    return {
        response: function (response) {
            return response;
        },
        responseError: function (response) {
            var userRole = $cookies.get('userRole');
            if (response.status === 401 ) {
                $location.path('welcome');
            }
            
            return $q.reject(response);
        }
    };
});

app.factory('')

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('notAuthorizedInterceptor');
});

$('img').on('dragstart', function (event) { event.preventDefault(); });

//index controller
app.controller("indexController" , [
    "$scope", "$cookies", "UsersService", "$state", "$rootScope",  "MechanicsService", "$window",
    function ($scope, $cookies, UsersService, $state, $rootScope, MechanicsService, $window) {
        $scope.user = null;
        $scope.dropdownStatus = false;

        $scope.statusToggle = function () {
            $scope.dropdownStatus = !$scope.dropdownStatus;
        }
        function fetchData() {
            var userId = $cookies.get('userId');

            if (userId) {
                var userName = $cookies.get('userName');
                var userRole = $cookies.get('userRole');
                var isMechanic = $cookies.get('isMechanic'); 
                $scope.user = {
                    Id: userId,
                    Name: userName,
                    Role: userRole,
                    IsMechanic: isMechanic
                }
            }
        }
        fetchData();

        //event listener for cookie
        $rootScope.$on("cookie-data", function (event, data) {
            fetchData();
            UsersService.getById(data.Id).then(
                function (response) {
                    $scope.user = response.data;
                    $cookies.put('userId', $scope.user.Id);
                    $cookies.put('userRole', $scope.user.Role);
                    $cookies.put('isMechanic', false);
                    $cookies.put('userName', $scope.user.Name);
                    if ($scope.user.Role == 1) {
                        $state.go('admin-panel');
                    }
                    else {
                        $state.go('myprofile');

                    }
                },
                function (response) {
                    alert(response.data);
                }
            );
        });
        //event listener for cookie
        $rootScope.$on("cookie-data2", function (event, data) {
            fetchData();
            MechanicsService.getById(data.Id).then(
                function (response) {
                    $scope.user = response.data;
                    $cookies.put('userId', $scope.user.Id);
                    $cookies.put('isMechanic', true);
                    $cookies.put('userName', $scope.user.CompanyName);
                    $state.go('mymechanicprofile');
                },
                function (response) {
                    alert(response.data);
                }
            );
        });

        //sign out function
        $scope.signOut = function () {
            $cookies.remove('userId');
            $cookies.remove('userRole');
            $cookies.remove('userName');
            $scope.user = null;
            $state.go("welcome");
        }

     
    }
])
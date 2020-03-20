app.controller("MyProfileController", [
    "$scope", "$uibModal", "MechanicsService", "UsersService", "$cookies", "$window",
    function ($scope, $uibModal, MechanicsService, UsersService, $cookies, $window) {
        $scope.activeTab = 1;
        $scope.activeItem = 2;
        $scope.isMechanic = $cookies.get('isMechanic');
        $scope.id = $cookies.get('userId');
        $scope.user = {};
        $scope.newPassword = null;
        $scope.oldPassword = null;
        $scope.infoSubmitted = false;
        $scope.accountSubmitted = false;
        $scope.oldPasswordInvalid = false;
        function getUser() {
            UsersService.getById($scope.id).then(
                function (response) {
                    $scope.user = response.data;
                    $scope.user.Id = $scope.id;
                },
                function (response) {
                    alert(response.data);
                }
            );
        }
        getUser();
        //change activetab function
        $scope.changeActiveTab = function (index) {
            $scope.activeTab = index;
        }
        //change activeitem function
        $scope.changeActiveItem = function (index) {
            $scope.activeItem = index;
        }
        //update personal info
        $scope.updatePersonlInfo = function (form) {
            $scope.infoSubmitted == true;
            if (form.$invalid) {
                return;
            }
            
            UsersService.update($scope.user).then(
                function (response) {
                    alert("Personal info updated");
                    $window.location.reload();
                },
                function (response) {
                    alert(response.data);
                }
            );
            
        }
        //update account info
        $scope.updateAccountInfo = function (form) {
            $scope.accountSubmitted = true;
            
            if ($scope.oldPassword == $scope.user.Password) {
                $scope.oldPasswordInvalid = false;
            }
            else {
                $scope.oldPasswordInvalid = true;
            }


            if (form.$invalid || $scope.oldPasswordInvalid) {
                return;
            }
            $scope.mechanic.Password = $scope.oldPassword;
            UsersService.update($scope.user).then(
                function (response) {
                    alert("Personal info updated");
                    $rootScope.$broadcast('cookie-data', { Id: $scope.user.Id });
                    $window.location.reload();
                },
                function (response) {
                    alert(response.data);
                }
            );
            }
        
    }
]);     
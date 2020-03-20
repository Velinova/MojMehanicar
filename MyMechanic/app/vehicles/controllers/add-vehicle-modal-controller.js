app.controller("AddVehicleModalController", [
    "$scope", "$uibModalInstance", "VehiclesService", "$cookies", "UsersService",
    function ($scope, $uibModalInstance, VehiclesService, $cookies, UsersService) {
        $scope.types = [{ key: 1, value: "Car" }, { key: 3, value: "Bus" }, { key: 3, value: "Train" }, { key: 4, value: "Motorcycle" }, { key: 5, value: "Bike" }, { key: 6, value: "Van" }];
        $scope.model = {
            Owner: null,
            Type: null,
            Model: "",
            License: ""
        };
        
        $scope.submitted = false;
        UsersService.getById($cookies.get('userId')).then(
            function (response) {
                $scope.model.Owner = response.data;
            },
            function (response) {
                alert(response.data);
            }
        );
        //add vehicle function
        $scope.submit = function (form) {
            $scope.typeEmpty = false;
            $scope.submitted = true;
            if ($scope.model.Type == null) {
                $scope.typeEmpty = true;
            }
            if (form.$invalid || $scope.typeEmpty) {
                return;
            }

            VehiclesService.addVehicle($scope.model)
                .then(
                    function (response) {
                        $uibModalInstance.close(true);
                    },
                    function (response) {
                        alert(response.data);
                    }
                );
        }
        //close modal function 
        $scope.cancel = function () {

            $uibModalInstance.close(false);
        }
    }
]);
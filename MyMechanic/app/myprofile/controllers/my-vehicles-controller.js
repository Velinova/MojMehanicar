app.controller("MyVehiclesController", [
    "$scope", "UsersService", "$cookies","$uibModal","$window", "VehiclesService",
    function ($scope, UsersService, $cookies, $uibModal, $window, VehiclesService) {
        $scope.vehicles = null;
        $scope.userId = $cookies.get('userId');
        $scope.filterIndex = null;
        $scope.searchText = null;
        //load my vehicles
        UsersService.getVehicles($scope.userId).then(
            function (response) {
                $scope.vehicles = response.data;
            },
            function (response) {
                alert(response.data);
            },

        );
        //add vehicle to user
        $scope.addVehicle = function () {
            var modalInstance = $uibModal.open(
                {
                    controller: "AddVehicleModalController",
                    templateUrl: "app/vehicles/add-vehicle-modal.html"
                }
            );
            modalInstance.result.then(
                function (result) {
                    UsersService.getVehicles($scope.userId).then(
                        function (response) {
                            $scope.vehicles = response.data;
                        },
                        function (response) {
                            alert(response.data);
                        },

                    );
                },
                function (result) {

                }
            );  
        }
        //filter vehicles function
        $scope.filter = function (index) {
            $scope.filterIndex = index;
        }
        //clear search text function
        $scope.clearSearch = function () {
            $scope.searchText = null;
            $scope.filterIndex = null;
        }
        //delete vehicle function
        $scope.deleteVehicle = function (id) {
            var modalInstance = $uibModal.open(
                {
                    controller: "DeleteModalController",
                    templateUrl: "app/common/delete-modal/delete-modal.html",
                    resolve: {
                        service: function () {
                            return VehiclesService.delete;
                    },
                    params: function () {
                        return id;
                    }
                }
                }
            );
            modalInstance.result.then(
                function (repsonse) {
                    UsersService.getVehicles($scope.userId).then(
                        function (response) {
                            $scope.vehicles = response.data;
                        },
                        function (response) {
                            alert(response.data);
                        },

                    );
                }
            );  
        }
        //edit vehicle function
        $scope.editVehicle = function(id){
            var modalInstance = $uibModal.open(
                {
                    controller: "EditVehicleModalController",
                    templateUrl: "app/vehicles/edit-vehicle-modal.html",
                    resolve: {
                        vehicleId: function () {
                            return id;
                        }
                    }
                }
            );
            modalInstance.result.then(
                function (result) {
                    UsersService.getVehicles($scope.userId).then(
                        function (response) {
                            $scope.vehicles = response.data;
                        },
                        function (response) {
                            alert(response.data);
                        },

                    );
                },
                function (result) {

                }
            );  
        }
    }
]);
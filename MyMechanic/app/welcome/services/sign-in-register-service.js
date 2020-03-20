app.factory("SignInRegisterService", [
    "$http", "serverUrl",
    function ($http, serverUrl) {
        var signInRegisterService = {};

        signInRegisterService.signIn = function (model) {
            return $http.post(serverUrl + "Users/SignInUser", model);
        };
        signInRegisterService.signInMechanic = function (model) {
            return $http.post(serverUrl + "Mechanics/SignInMechanic", model);
        };
        signInRegisterService.registerUser = function (model) {
            return $http.post(serverUrl + "Users/RegisterUser", model);
        };
        signInRegisterService.registerMechanic = function (model) {
            return $http.post(serverUrl + "Mechanics/RegisterMechanic", model);
        };
        return signInRegisterService;
    }
]);
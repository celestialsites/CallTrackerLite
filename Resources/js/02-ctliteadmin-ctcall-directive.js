var $nwsc = $nwsc || {};

$nwsc.ctcallAddEditDirective = function (ModulePath) {

    return {
        scope: {
            editCtcall: '=?',
            title: '@',
            cityList: '=',
            saveFunction: '&saveFunction',
            refreshCtcalls: '&'
        },
        restrict: 'E',
        templateUrl: ModulePath + 'Resources/js/templates/ctcall-addedit.html',
        controller: ['$scope', function ($scope) {
            if (typeof $scope.editCtcall === 'undefined') {
                $scope.editCtcall = new $nwsc.CTCall();
            }
            //if ($scope.editCtcall.CallDate === 0) {
            //    $scope.editCtcall.CallDate = new Date();
            //}
            $scope.showAddEdit = function () {
                $(".modal").hide();
                $("#mdlAddEditCtcall-" + $scope.editCtcall.CallId).modal();
            };
        }],
        link: function (scope, elem, attrs) {
            scope.Name = attrs['name'];

            scope.saveButton = function (e, form) {
                e.preventDefault();
                scope.invalidSubmitAttempt = false;
                if (form.$invalid) {
                    scope.invalidSubmitAttempt = true;
                    return;
                }

                // Call our passed in save CTCall function
                if (angular.isFunction(scope.saveFunction)) {
                    var saveFnExp = scope.saveFunction();
                    saveFnExp(scope.editCtcall);
                }

                // Hide the modal, reset the scope, reset the form validation
                $("#mdlAddEditCtcall-" + scope.editCtcall.CallId).modal('hide');
                $("#mdlAddEditCtcall-" + scope.editCtcall.CallId).on('hidden.bs.modal', function () {
                    if (angular.isFunction(scope.refreshCtcalls)) {
                        var refFnExp = scope.refreshCtcalls();
                        refFnExp();
                    }
                })
                if (scope.editCtcall.CallId === 0)
                    scope.editCtcall = new $nwsc.CTCall();
                form.$setPristine();
            }

            scope.cancelButton = function () {
                $("#mdlAddEditCtcall-" + scope.editCtcall.CallId).modal('hide');
                $("#mdlAddEditCtcall-" + scope.editCtcall.CallId).on('hidden.bs.modal', function () {
                    if (angular.isFunction(scope.refreshCtcalls)) {
                        var refFnExp = scope.refreshCtcalls();
                        refFnExp();
                    }
                })
            }
        }
    }
};

$nwsc.CTCall = function () {
    this.CallId = 0;
    this.CallDate = 0;
    this.CallerName = '';
    this.CallerAddress = '';
    this.CallerCity = '';
    this.CityId = '';
    this.CrossStreet = '';
    this.CallType = '';
    this.CallBackNumber = '';
    this.Comments = '';
};

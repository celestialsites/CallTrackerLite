var $nwsc = $nwsc || {};

$nwsc.AddEditDirective = function (ModulePath) {

    return {
        scope: {
            editDispatcher: '=?',
            title: '@',
            saveDispatcher: '&saveFunction',
            refreshDispatchers: '&'
        },
        restrict: 'E',
        templateUrl: ModulePath + 'Resources/js/templates/dispatcher-addedit.html',
        controller: ['$scope', function ($scope) {
            if (typeof $scope.editDispatcher === 'undefined') {
                $scope.editDispatcher = new $nwsc.Dispatcher();

            }
            $scope.showAddEdit = function () {
                $(".modal").hide();
                $("#mdlAddEditDispatcher-" + $scope.editDispatcher.DispatcherId).modal();
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

                // Call our passed in save Dispatcher function
                if (angular.isFunction(scope.saveDispatcher)) {
                    var saveFnExp = scope.saveDispatcher();
                    saveFnExp(scope.editDispatcher);
                }

                // Hide the modal, reset the scope, reset the form validation
                $("#mdlAddEditDispatcher-" + scope.editDispatcher.DispatcherId).modal('hide');
                if (scope.editDispatcher.DispatcherId === 0)
                    scope.editDispatcher = new $nwsc.Dispatcher();
                form.$setPristine();
            }

            scope.cancelButton = function () {
                $("#mdlAddEditDispatcher-" + scope.editDispatcher.DispatcherId).modal('hide');
                $("#mdlAddEditDispatcher-" + scope.editDispatcher.DispatcherId).on('hidden.bs.modal', function () {
                    if (angular.isFunction(scope.refreshDispatchers)) {
                        var refFnExp = scope.refreshDispatchers();
                        refFnExp();
                    }
                })
            }
        }
    }
};

$nwsc.Dispatcher = function () {
    this.DispatcherId = 0;
    this.DispatcherName = '';
    this.DispatcherType = '';
    this.CellPhone = '';
    this.HomePhone = '';
    this.AltPhone = '';
};
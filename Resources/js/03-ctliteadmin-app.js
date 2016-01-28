(function () {
    angular.module("myCTLAdminApp", ['nwscDnn'])

    //Directives
     .directive("addEditDispatcher", $nwsc.AddEditDirective)
     .directive("addEditDpcode", $nwsc.dpcodeAddEditDirective)
     .directive("addEditRegion", $nwsc.regionAddEditDirective)
     .directive("addEditCtcall", $nwsc.ctcallAddEditDirective)
     .directive("addEditCtdetail", $nwsc.ctdetailAddEditDirective)

    //Controllers
    .controller("mainController", ['$http', '$log', 'AppServiceFramework', $nwsc.mainController])
}());


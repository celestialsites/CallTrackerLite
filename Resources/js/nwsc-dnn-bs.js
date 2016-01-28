var $nwsc = $nwsc || {}

/*
    Add this after AngularJS registration
    It will then look for all nwsc-apps and initialize them, ensuring that $http is pre-configured to work with DNN
*/
$nwsc.ng = {
    appAttribute: 'nwsc-app',
    ngAttrPrefixes: ['ng-', 'data-ng-', 'ng:', 'x-ng-'],
    iidAttrNames: ['app-instanceid', 'data-instanceid', 'id'],
    modPathAttrName: 'data-modulepath',

    // All params optional except for 'element'
    bootstrap: function (element, ngModName, iid, dependencies, config) {
        // first, try to get moduleId from URL
        iid = iid || $nwsc.ng.findInstanceId(element) || $nwsc.ng.getParameterByName('mid'); // use fn-param, or get from DOM, or get url-param
        var sf = $.ServicesFramework(iid);

        angular.module('confDotNetNuclearApp' + iid, [])
            .constant('ModulePath', $nwsc.ng.findAttr(element, $nwsc.ng.modPathAttrName))
            .constant('AppInstanceId', iid)
            .constant('AppServiceFramework', sf)
            .constant('HttpHeaders', { "ModuleId": iid, "TabId": sf.getTabId(), "RequestVerificationToken": sf.getAntiForgeryValue() });
        var allDependencies = ['confDotNetNuclearApp' + iid, 'nwscDnn'].concat(dependencies || [ngModName]);

        angular.element(document).ready(function () {
            angular.bootstrap(element, allDependencies, config); // start the app
        });
    },

    // find instance Id in an attribute of the tag - typically with id="app-700" or something and use the number as IID
    findInstanceId: function findInstanceId(element) {
        var attrib = false, ngElement = angular.element(element);
        for (var i = 0; i < $nwsc.ng.iidAttrNames.length; i++)
            attrib = ngElement.attr($nwsc.ng.iidAttrNames[i]);
        if (attrib) {
            var iid = parseInt(attrib.toString().replace(/\D/g, '')); // filter all characters if necessary
            if (!iid) throw "iid or instanceId (the DNN moduleid) not supplied and automatic lookup failed. Please set app-tag attribute iid or give id in bootstrap call";
            return iid;
        }
    },

    // find template path in an attribute of the tag
    findAttr: function findAttr(element, attrName) {
        ngElement = angular.element(element);
        return ngElement.attr(attrName);
    },

    // Auto-bootstrap all sub-tags having an 'bravo2-app' attribute - for Multiple-Apps-per-Page
    bootstrapAll: function bootstrapAll(element) {
        element = element || document;
        var allAppTags = element.querySelectorAll('[' + $nwsc.ng.appAttribute + ']');
        angular.forEach(allAppTags, function (appTag) {
            var ngModName = appTag.getAttribute($nwsc.ng.appAttribute);
            var configDependencyInjection = { strictDi: $nwsc.ng.getNgAttribute(appTag, "strict-di") !== null };
            $nwsc.ng.bootstrap(appTag, ngModName, null, null, configDependencyInjection);
        });
    },

    // if the page contains angular, do auto-bootstrap of all bravo apps
    autoRunBootstrap: function autoRunBootstrap() {
        if (angular)
            angular.element(document).ready(function () {
                $nwsc.ng.bootstrapAll();
            });
    },

    // Helper function to try various attribute-prefixes
    getNgAttribute: function getNgAttribute(element, ngAttr) {
        var attr = null, i, ii = $nwsc.ng.ngAttrPrefixes.length;
        element = angular.element(element);
        for (i = 0; i < ii; ++i) {
            attr = $nwsc.ng.ngAttrPrefixes[i] + ngAttr;
            if (typeof (attr = element.attr(attr)) === 'string')
                return attr;
        }
        return null;
    },

    // get url param - mainly needed for mid=### in admin-dialogs
    getParameterByName: function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);

        // if nothing found, try normal URL because DNN places parameters in /key/value notation
        if (results === null) {
            // Otherwise try parts of the URL
            var matches = window.location.pathname.match("/" + name + "/([^/]+)", 'i');

            // Check if we found anything, if we do find it, we must reverse the results so we get the "last" one in case there are multiple hits
            if (matches !== null && matches.length > 1)
                results = matches.reverse()[0];
        } else
            results = results[1];

        return results === null ? "" : decodeURIComponent(results.replace(/\+/g, " "));
    }

};
$nwsc.ng.autoRunBootstrap();

angular.module('nwscDnn', ['ng'])
    // Configure $http for DNN web services (security tokens etc.)
    .config(function ($httpProvider, HttpHeaders) {
        angular.extend($httpProvider.defaults.headers.common, HttpHeaders);
    })
;
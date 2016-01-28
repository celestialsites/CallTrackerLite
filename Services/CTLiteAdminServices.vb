Imports DotNetNuke.Web.Api
Imports NWSC.Modules.CTLiteAdmin.Components.Common


Namespace Services

    Public Class CTLiteAdminServices
        Implements IServiceRouteMapper

        Public Sub RegisterRoutes(mapRouteManager As IMapRoute) Implements IServiceRouteMapper.RegisterRoutes
            mapRouteManager.MapHttpRoute(Constants.DESKTOPMODULE_NAME, "default", "{controller}/{action}", {"NWSC.Modules.CTLiteAdmin.Services.Controllers"})
        End Sub
    End Class

End Namespace


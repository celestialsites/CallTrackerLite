Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports DotNetNuke.Web.Api
Imports DotNetNuke.Security
Imports NWSC.Modules.CTLiteAdmin.Components
Imports NWSC.Modules.CTLiteAdmin.Components.Common
Imports NWSC.Modules.CTLiteAdmin.MyEntities



Namespace Services.Controllers
    <SupportedModulesAttribute(Constants.DESKTOPMODULE_NAME)>
    Public Class regionController
        Inherits DnnApiController

        Private _cityRepository As CityRepository

        Public Sub New()
            _cityRepository = New CityRepository()

        End Sub

#Region "Test"


        ''' <summary>
        ''' API that returns Hello world
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ActionName("Test")>
        <AllowAnonymous>
        Public Function HelloWorld() As HttpResponseMessage
            Return Request.CreateResponse(HttpStatusCode.OK, "Hello DNN Angular World!")
        End Function
#End Region

#Region "City/Region API"


        ''' <summary>
        ''' API that returns an City/Region List
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("cityList")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.View)>
        Public Function GetAllCitys() As HttpResponseMessage

            Try
                Dim cityList = _cityRepository.GetCitys(ActiveModule.ModuleID)
                Return Request.CreateResponse(HttpStatusCode.OK, cityList.ToList())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try

        End Function
        ''' <summary>
        ''' API that creates a new City/Region
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryToken>
        <ActionName("citynew")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function Addcity(t As RequestCity) As HttpResponseMessage
            Try
                Dim newcity As New City()
                newcity.ModuleId = ActiveModule.ModuleID
                newcity.CreatedByUserId = UserInfo.UserID
                newcity.CreatedOnDate = DateTime.Now
                newcity.LastModifiedByUserId = UserInfo.UserID
                newcity.LastModifiedOnDate = DateTime.Now
                newcity.CityName = t.CityName
                newcity.RegionName = t.RegionName
                newcity.UtilityType = t.UtilityType
                Dim cityid As Integer = _cityRepository.AddCity(newcity)
                Return Request.CreateResponse(HttpStatusCode.OK, cityid)
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that Updates a city/region
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("cityupdate")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function UpdateCityCode(t As City) As HttpResponseMessage
            Try
                t.LastModifiedByUserId = UserInfo.UserID
                t.LastModifiedOnDate = DateTime.Now
                _cityRepository.UpdateCity(t)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that Deletes a City/Region
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("citydelete")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function DeleteCityCode(delit As City) As HttpResponseMessage

            Try
                _cityRepository.DeleteCity(delit)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
            End Try

        End Function
#End Region


    End Class


    Public Class RequestCity

        Private _cityId As Integer
        Private _cityName As String
        Private _regionName As String
        Private _utilityType As String
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Property CityId() As Integer
            Get
                Return _cityId
            End Get
            Set(ByVal value As Integer)
                _cityId = value
            End Set
        End Property


        Public Property CityName() As String
            Get
                Return _cityName
            End Get
            Set(ByVal value As String)
                _cityName = value
            End Set
        End Property

        Public Property RegionName() As String
            Get
                Return _regionName
            End Get
            Set(ByVal value As String)
                _regionName = value
            End Set
        End Property

        Public Overloads Property UtilityType() As String
            Get
                Return _utilityType
            End Get
            Set(ByVal value As String)
                _utilityType = value
            End Set
        End Property

        Public Overloads Property CreatedByUserId() As Integer
            Get
                Return _createdByUserId
            End Get
            Set(ByVal value As Integer)
                _createdByUserId = value
            End Set
        End Property

        Public Overloads Property LastModifiedByUserId() As Integer
            Get
                Return _lastModifiedByUserId
            End Get
            Set(ByVal value As Integer)
                _lastModifiedByUserId = value
            End Set
        End Property

        Public Overloads Property CreatedOnDate() As DateTime

            Get
                Return _createdOnDate
            End Get
            Set(ByVal value As DateTime)
                _createdOnDate = value
            End Set
        End Property
        Public Overloads Property LastModifiedOnDate() As DateTime
            Get
                Return _lastModifiedOnDate
            End Get
            Set(ByVal value As DateTime)
                _lastModifiedOnDate = value
            End Set
        End Property

        Public Overloads Property ModuleId() As Integer
            Get
                Return _moduleId
            End Get
            Set(ByVal value As Integer)
                _moduleId = value
            End Set
        End Property



    End Class







End Namespace

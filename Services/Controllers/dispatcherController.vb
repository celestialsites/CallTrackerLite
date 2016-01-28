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
    <DnnModuleAuthorizeAttribute(AccessLevel:=SecurityAccessLevel.View)>
    Public Class dispatcherController
        Inherits DnnApiController

        Private _dispatcherRepository As DispatcherRepository

        Public Sub New()
            _dispatcherRepository = New DispatcherRepository()

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

#Region "Dispatcher API"

        ''' <summary>
        ''' API that returns an Dispatcher List
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("dpList")>
        Public Function GetAllDispatchers() As HttpResponseMessage

            Try
                Dim dispatcherList = _dispatcherRepository.GetDispatchers(ActiveModule.ModuleID)
                Return Request.CreateResponse(HttpStatusCode.OK, dispatcherList.ToList())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' API that creates a new Dispatchers
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryToken>
        <ActionName("dpnew")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function AddDispatcher(t As RequestDispatcher) As HttpResponseMessage
            Try
                Dim newDispatcher As New Dispatcher()
                newDispatcher.ModuleId = ActiveModule.ModuleID
                newDispatcher.CreatedByUserId = UserInfo.UserID
                newDispatcher.CreatedOnDate = DateTime.Now
                newDispatcher.LastModifiedByUserId = UserInfo.UserID
                newDispatcher.LastModifiedOnDate = DateTime.Now
                newDispatcher.CellPhone = t.CellPhone
                newDispatcher.HomePhone = t.HomePhone
                newDispatcher.AltPhone = t.AltPhone
                newDispatcher.DispatcherName = t.DispatcherName
                newDispatcher.DispatcherType = t.DispatcherType
                Dim dispatcherid As Integer = _dispatcherRepository.AddDispatcher(newDispatcher)
                Return Request.CreateResponse(HttpStatusCode.OK, dispatcherid)
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that deletes a Dispatcher 
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("dpdelete")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function DeleteDispatcher(delit As Dispatcher) As HttpResponseMessage

            Try
                _dispatcherRepository.DeleteDispatcher(delit)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' API that updates a Dispatcher
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("dpupdate")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function UpdateDispatcher(t As Dispatcher) As HttpResponseMessage
            Try
                t.LastModifiedByUserId = UserInfo.UserID
                t.LastModifiedOnDate = DateTime.Now
                _dispatcherRepository.UpdateDispatcher(t)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
#End Region

    End Class


    Public Class RequestDispatcher
        Private _dispatcherId As Integer
        Private _dispatcherName As String
        Private _dispatcherType As String
        Private _cellPhone As Int64
        Private _homePhone As Int64
        Private _altPhone As Int64
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Property DispatcherId() As Integer
            Get
                Return _dispatcherId
            End Get
            Set(ByVal value As Integer)
                _dispatcherId = value
            End Set
        End Property


        Public Property DispatcherName() As String
            Get
                Return _dispatcherName
            End Get
            Set(ByVal value As String)
                _dispatcherName = value
            End Set
        End Property
        Public Property DispatcherType() As String
            Get
                Return _dispatcherType
            End Get
            Set(ByVal value As String)
                _dispatcherType = value
            End Set
        End Property

        Public Property CellPhone() As Int64
            Get
                Return _cellPhone
            End Get
            Set(ByVal value As Int64)
                _cellPhone = value
            End Set
        End Property

        Public Property HomePhone() As Int64
            Get
                Return _homePhone
            End Get
            Set(ByVal value As Int64)
                _homePhone = value
            End Set
        End Property
        Public Property AltPhone() As Int64
            Get
                Return _altPhone
            End Get
            Set(ByVal value As Int64)
                _altPhone = value
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


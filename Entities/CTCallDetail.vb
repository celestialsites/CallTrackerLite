Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.ComponentModel.DataAnnotations
Imports System.Web.Caching
Imports System

Namespace MyEntities

    'setup the primary key for table
    'configure caching using PetaPoco
    'scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    '<Serializable>
    <TableName("CTLiteAdmin_CTCallDetails")>
    <PrimaryKey("CallDetailId", AutoIncrement:=True)>
    <Cacheable("CallDetails", CacheItemPriority.Default, 20)>
    <Scope("ModuleId")>
    Public Class CTCallDetail
        Implements ICTCallDetailModel

        Private _calldetailid As Integer
        Private _callid As Integer
        Private _dispatchcode As String
        Private _dispatchcodeId As Integer
        Private _dispatchtime As DateTime
        Private _comments As String
        Private _dispatcher As String
        Private _dispatcherid As Integer
        Private _dispatcherphone As Int64
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Sub New()
            CallDetailId = -1
        End Sub
        Public Property CallDetailId() As Integer Implements ICTCallDetailModel.CallDetailId
            Get
                Return _calldetailid
            End Get
            Set(ByVal value As Integer)
                _calldetailid = value
            End Set
        End Property
        Public Property CallId() As Integer Implements ICTCallDetailModel.CallId
            Get
                Return _callid
            End Get
            Set(ByVal value As Integer)
                _callid = value
            End Set
        End Property
        Public Property DispatchTime() As DateTime Implements ICTCallDetailModel.DispatchTime
            Get
                Return _dispatchtime
            End Get
            Set(ByVal value As DateTime)
                _dispatchtime = value
            End Set
        End Property
        Public Property DispatchCode() As String Implements ICTCallDetailModel.DispatchCode
            Get
                Return _dispatchcode
            End Get
            Set(ByVal value As String)
                _dispatchcode = value
            End Set
        End Property
        Public Property DispatchCodeId() As Integer Implements ICTCallDetailModel.DispatchCodeId
            Get
                Return _dispatchcodeId
            End Get
            Set(ByVal value As Integer)
                _dispatchcodeId = value
            End Set
        End Property
        Public Property Dispatcher() As String Implements ICTCallDetailModel.Dispatcher
            Get
                Return _dispatcher
            End Get
            Set(ByVal value As String)
                _dispatcher = value
            End Set
        End Property
        Public Property DispatcherId() As Integer Implements ICTCallDetailModel.DispatcherId
            Get
                Return _dispatcherid
            End Get
            Set(ByVal value As Integer)
                _dispatcherid = value
            End Set
        End Property
        Public Property DispatcherPhone() As Int64 Implements ICTCallDetailModel.DispatcherPhone
            Get
                Return _dispatcherphone
            End Get
            Set(ByVal value As Int64)
                _dispatcherphone = value
            End Set
        End Property
        Public Property Comments() As String Implements ICTCallDetailModel.Comments
            Get
                Return _comments
            End Get
            Set(ByVal value As String)
                _comments = value
            End Set
        End Property
        Public Overloads Property CreatedByUserId() As Integer Implements ICTCallDetailModel.createdByUserId
            Get
                Return _createdByUserId
            End Get
            Set(ByVal value As Integer)
                _createdByUserId = value
            End Set
        End Property

        Public Overloads Property LastModifiedByUserId() As Integer Implements ICTCallDetailModel.lastModifiedByUserId
            Get
                Return _lastModifiedByUserId
            End Get
            Set(ByVal value As Integer)
                _lastModifiedByUserId = value
            End Set
        End Property

        Public Overloads Property CreatedOnDate() As DateTime Implements ICTCallDetailModel.createdOnDate
            Get
                Return _createdOnDate
            End Get
            Set(ByVal value As DateTime)
                _createdOnDate = value
            End Set
        End Property
        Public Overloads Property LastModifiedOnDate() As DateTime Implements ICTCallDetailModel.lastModifiedOnDate
            Get
                Return _lastModifiedOnDate
            End Get
            Set(ByVal value As DateTime)
                _lastModifiedOnDate = value
            End Set
        End Property

        Public Overloads Property ModuleId() As Integer Implements ICTCallDetailModel.moduleId
            Get
                Return _moduleId
            End Get
            Set(ByVal value As Integer)
                _moduleId = value
            End Set
        End Property
    End Class


End Namespace


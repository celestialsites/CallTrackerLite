Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.ComponentModel.DataAnnotations
Imports System.Web.Caching
Imports System

Namespace MyEntities

    'setup the primary key for table
    'configure caching using PetaPoco
    'scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    '<Serializable>
    <TableName("CTLiteAdmin_CTCalls")>
    <PrimaryKey("CallId", AutoIncrement:=True)>
    <Cacheable("Calls", CacheItemPriority.Default, 20)>
    <Scope("ModuleId")>
    Public Class CTCall
        Implements ICTCallModel

        Private _callid As Integer
        Private _calldate As DateTime
        Private _callername As String
        Private _calleraddress As String
        Private _cityid As Integer
        Private _callercity As String
        Private _region As String
        Private _utilitytype As String
        Private _callbacknumber As Integer
        Private _crossstreet As String
        Private _comments As String
        Private _calltype As String
        Private _dispatchflag As Integer
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _csr As String
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Sub New()
            CallId = -1
        End Sub
        Public Property CallId() As Integer Implements ICTCallModel.CallId

            Get
                Return _callid
            End Get
            Set(ByVal value As Integer)
                _callid = value
            End Set
        End Property
        Public Property CallDate() As DateTime Implements ICTCallModel.CallDate
            Get
                Return _calldate
            End Get
            Set(ByVal value As DateTime)
                _calldate = value
            End Set
        End Property
        Public Property CallerName() As String Implements ICTCallModel.CallerName
            Get
                Return _callername
            End Get
            Set(ByVal value As String)
                _callername = value
            End Set
        End Property
        Public Property CallerAddress() As String Implements ICTCallModel.CallerAddress
            Get
                Return _calleraddress
            End Get
            Set(ByVal value As String)
                _calleraddress = value
            End Set
        End Property
        Public Property CallerCity() As String Implements ICTCallModel.CallerCity
            Get
                Return _callercity
            End Get
            Set(ByVal value As String)
                _callercity = value
            End Set
        End Property
        Public Property CityId() As Integer Implements ICTCallModel.CityId

            Get
                Return _cityid
            End Get
            Set(ByVal value As Integer)
                _cityid = value
            End Set
        End Property
        Public Property Region() As String Implements ICTCallModel.Region
            Get
                Return _region
            End Get
            Set(ByVal value As String)
                _region = value
            End Set
        End Property
        Public Property UtilityType() As String Implements ICTCallModel.UtilityType
            Get
                Return _utilitytype
            End Get
            Set(ByVal value As String)
                _utilitytype = value
            End Set
        End Property
        Public Property CallBackNumber() As Integer Implements ICTCallModel.CallBackNumber
            Get
                Return _callbacknumber
            End Get
            Set(ByVal value As Integer)
                _callbacknumber = value
            End Set
        End Property
        Public Property CrossStreet() As String Implements ICTCallModel.CrossStreet
            Get
                Return _crossstreet
            End Get
            Set(ByVal value As String)
                _crossstreet = value
            End Set
        End Property
        Public Property Comments() As String Implements ICTCallModel.Comments
            Get
                Return _comments
            End Get
            Set(ByVal value As String)
                _comments = value
            End Set
        End Property
        Public Property CallType() As String Implements ICTCallModel.CallType
            Get
                Return _calltype
            End Get
            Set(ByVal value As String)
                _calltype = value
            End Set
        End Property

        Public Property DispatchFlag() As Integer Implements ICTCallModel.DispatchFlag
            Get
                Return _dispatchflag
            End Get
            Set(ByVal value As Integer)
                _dispatchflag = value
            End Set
        End Property
        Public Overloads Property CreatedByUserId() As Integer Implements ICTCallModel.createdByUserId
            Get
                Return _createdByUserId
            End Get
            Set(ByVal value As Integer)
                _createdByUserId = value
            End Set
        End Property

        Public Overloads Property LastModifiedByUserId() As Integer Implements ICTCallModel.lastModifiedByUserId
            Get
                Return _lastModifiedByUserId
            End Get
            Set(ByVal value As Integer)
                _lastModifiedByUserId = value
            End Set
        End Property
        Public Property CSR() As String Implements ICTCallModel.CSR
            Get
                Return _csr
            End Get
            Set(ByVal value As String)
                _csr = value
            End Set
        End Property

        Public Overloads Property CreatedOnDate() As DateTime Implements ICTCallModel.createdOnDate
            Get
                Return _createdOnDate
            End Get
            Set(ByVal value As DateTime)
                _createdOnDate = value
            End Set
        End Property
        Public Overloads Property LastModifiedOnDate() As DateTime Implements ICTCallModel.lastModifiedOnDate
            Get
                Return _lastModifiedOnDate
            End Get
            Set(ByVal value As DateTime)
                _lastModifiedOnDate = value
            End Set
        End Property

        Public Overloads Property ModuleId() As Integer Implements ICTCallModel.moduleId
            Get
                Return _moduleId
            End Get
            Set(ByVal value As Integer)
                _moduleId = value
            End Set
        End Property

    End Class

End Namespace



Namespace MyEntities
    Public Interface ICTCallModel

        Property CallId() As Integer
        Property CallDate() As DateTime
        Property CallerName() As String
        Property CallerAddress() As String
        Property CallerCity() As String
        Property CityId() As Integer
        Property Region() As String
        Property UtilityType() As String
        Property CallBackNumber() As Integer
        Property CrossStreet() As String
        Property Comments() As String
        Property CallType() As String
        Property DispatchFlag() As Integer
        Property createdByUserId() As Integer
        Property lastModifiedByUserId() As Integer
        Property CSR() As String
        Property createdOnDate() As DateTime
        Property lastModifiedOnDate() As DateTime
        Property moduleId() As Integer


    End Interface

End Namespace


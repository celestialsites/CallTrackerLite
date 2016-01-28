
Namespace MyEntities
    Public Interface ICTCallDetailModel

        Property CallDetailId As Integer
        Property CallId() As Integer
        Property DispatchTime() As DateTime
        Property DispatchCode As String
        Property DispatchCodeId As Integer
        Property Comments As String
        Property Dispatcher As String
        Property DispatcherId As Integer
        Property DispatcherPhone As Int64
        Property createdByUserId() As Integer
        Property lastModifiedByUserId() As Integer
        Property createdOnDate() As DateTime
        Property lastModifiedOnDate() As DateTime
        Property moduleId() As Integer


    End Interface

End Namespace




Namespace MyEntities
    Public Interface ICityModel

        Property CityId() As Integer
        Property CityName() As String
        Property RegionName() As String
        Property UtilityType() As String
        Property CreatedByUserId() As Integer
        Property LastModifiedByUserId() As Integer
        Property CreatedOnDate() As DateTime
        Property LastModifiedOnDate() As DateTime
        Property ModuleId As Integer

    End Interface


End Namespace

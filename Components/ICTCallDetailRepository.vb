Imports DotNetNuke.Collections
Imports NWSC.Modules.CTLiteAdmin.MyEntities


Namespace Components

    Public Interface ICTCallDetailRepository

        ''' <summary>
        ''' AddCTCallDetail adds a CTCallDetail to the repository
        ''' </summary>
        ''' <param name="t">The contact to add</param>
        ''' <returns>The Id of the contact</returns>
        Function AddCTCallDetail(t As CTCallDetail) As Integer

        ''' <summary>
        ''' DeleteContact deletes a contact from the repository
        ''' </summary>
        ''' <param name="t">The CTCallDetail to delete</param>
        Sub DeleteCTCallDetail(t As CTCallDetail)

        ''' <summary>
        ''' This GetContact  method retrieves a specific Contact in a portal
        ''' </summary>
        ''' <remarks>Contacts are cached by ModlueID, so this call will check the cache before going to the Database</remarks>
        ''' <param name="CallDetailId">The Id of the contact</param>
        ''' <param name="moduleId">The Id of the portal</param>
        ''' <returns>A single of contact</returns>
        Function GetCTCallDetail(CallDetailId As Integer, moduleId As Integer) As ICTCallDetailModel

        ''' <summary>
        ''' This GetCTCallDetails overload retrieves all the Calls for a portal
        ''' </summary>
        ''' <remarks>Contacts are cached by Module, so this call will check the cache before going to the Database</remarks>
        ''' <param name="callid">The Id of the Module</param>
        ''' <param name="moduleId">The Id of the Module</param>
        ''' <returns>A collection of Calls</returns>
        Function GetCTCallidDetails(callid As Integer, moduleId As Integer) As IEnumerable(Of CTCallDetail)

        ''' <summary>
        ''' This GetCTCallDetails overload retrieves all the Calls for a portal
        ''' </summary>
        ''' <remarks>Contacts are cached by Module, so this call will check the cache before going to the Database</remarks>
        ''' <param name="moduleId">The Id of the Module</param>
        ''' <returns>A collection of Calls</returns>
        Function GetCTCallDetails(moduleId As Integer) As IEnumerable(Of CTCallDetail)

        ''' <summary>
        ''' This GetContacts overload retrieves a page of Contacts for a portal
        ''' </summary>
        ''' <remarks>Contacts are cached by portal, so this call will check the cache before going to the Database</remarks>
        ''' <param name="searchTerm">The term to search for</param>
        ''' <param name="moduleId">The Id of the portal</param>
        ''' <param name="pageIndex">The page Index to fetch - this is 0 based so the first page is when pageIndex = 0</param>
        ''' <param name="pageSize">The size of the page to fetch from the database</param>
        ''' <returns>A paged collection of contacts</returns>
        Function GetCTCallDetails(searchTerm As String, moduleId As Integer, pageIndex As Integer, pageSize As Integer) As IPagedList(Of CTCallDetail)


        ''' <summary>
        ''' UpdateContact updates a contact in the repository
        ''' </summary>
        ''' <param name="t">The contact to update</param>
        Sub UpdateCTCallDetail(t As ICTCallDetailModel)




    End Interface

End Namespace


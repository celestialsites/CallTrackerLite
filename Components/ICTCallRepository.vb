Imports DotNetNuke.Collections
Imports NWSC.Modules.CTLiteAdmin.MyEntities


Namespace Components

    Public Interface ICTCallRepository

        ''' <summary>
        ''' AddCTCall adds a CTCall to the repository
        ''' </summary>
        ''' <param name="t">The contact to add</param>
        ''' <returns>The Id of the contact</returns>
        Function AddCTCall(t As CTCall) As Integer

        ''' <summary>
        ''' DeleteContact deletes a contact from the repository
        ''' </summary>
        ''' <param name="t">The CTCall to delete</param>
        Sub DeleteCTCall(t As CTCall)

        ''' <summary>
        ''' This GetContact  method retrieves a specific Contact in a portal
        ''' </summary>
        ''' <remarks>Contacts are cached by ModlueID, so this call will check the cache before going to the Database</remarks>
        ''' <param name="CallId">The Id of the contact</param>
        ''' <param name="moduleId">The Id of the portal</param>
        ''' <returns>A single of contact</returns>
        Function GetCTCall(CallId As Integer, moduleId As Integer) As ICTCallModel

        ''' <summary>
        ''' This GetCTCalls overload retrieves all the Calls for a portal
        ''' </summary>
        ''' <remarks>Contacts are cached by Module, so this call will check the cache before going to the Database</remarks>
        ''' <param name="moduleId">The Id of the Module</param>
        ''' <returns>A collection of Calls</returns>
        Function GetCTCalls(moduleId As Integer) As IEnumerable(Of CTCall)

        ''' <summary>
        ''' This GetCTCalls overload retrieves all the Calls for a portal
        ''' </summary>
        ''' <remarks>Contacts are cached by Module, so this call will check the cache before going to the Database</remarks>
        ''' <param name="moduleId">The Id of the Module</param>
        ''' <param name="userid">The Id of the current </param>
        ''' <returns>A collection of Calls</returns>
        Function GetOpenCTCalls(moduleId As Integer, userid As Integer) As IEnumerable(Of CTCall)

        ''' <summary>
        ''' This GetContacts overload retrieves a page of Contacts for a portal
        ''' </summary>
        ''' <remarks>Contacts are cached by portal, so this call will check the cache before going to the Database</remarks>
        ''' <param name="searchTerm">The term to search for</param>
        ''' <param name="moduleId">The Id of the portal</param>
        ''' <param name="pageIndex">The page Index to fetch - this is 0 based so the first page is when pageIndex = 0</param>
        ''' <param name="pageSize">The size of the page to fetch from the database</param>
        ''' <returns>A paged collection of contacts</returns>
        Function GetCTCalls(searchTerm As String, moduleId As Integer, pageIndex As Integer, pageSize As Integer) As IPagedList(Of CTCall)


        ''' <summary>
        ''' UpdateContact updates a contact in the repository
        ''' </summary>
        ''' <param name="t">The contact to update</param>
        Sub UpdateCTCall(t As ICTCallModel)




    End Interface

End Namespace



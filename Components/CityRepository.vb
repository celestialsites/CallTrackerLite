' Copyright (c) 2015  NWSC.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 

Imports System.Collections.Generic
Imports DotNetNuke.Collections
Imports DotNetNuke.Data
Imports NWSC.Modules.CTLiteAdmin.MyEntities


Namespace Components

    Public Class CityRepository
        Implements ICityRepository

        Public Sub ClearCache(moduleid As Integer)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of City)()
                Try
                    ' Setup fictitious Call to delete (just to clear the scope cache)
                    Dim t = New City() With {
                        .CityId = -1,
                        .ModuleId = moduleid
                    }
                    DeleteCity(t)
                Catch
                    ' ignore
                End Try
            End Using
        End Sub

        Public Sub DeleteCity(t As City) Implements ICityRepository.DeleteCity
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of City)()
                rep.Delete(DirectCast(t, City))
            End Using


        End Sub

        Public Sub UpdateCity(t As ICityModel) Implements ICityRepository.UpdateCity
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of City)()
                rep.Update(DirectCast(t, City))
            End Using
        End Sub

        Public Function AddCity(t As City) As Integer Implements ICityRepository.AddCity
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of City)()
                rep.Insert(DirectCast(t, City))
                Return t.CityId
            End Using
        End Function


        Public Function GetCity(cityid As Integer, moduleId As Integer) As ICityModel Implements ICityRepository.GetCity
            Dim t As City

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of City)()
                t = rep.GetById(cityid, moduleId)
            End Using
            Return t
        End Function


        Public Function GetCitys(moduleId As Integer) As IEnumerable(Of City) Implements ICityRepository.GetCitys
            Dim t As IEnumerable(Of City)

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of City) = ctx.GetRepository(Of City)()
                t = rep.Get(moduleId)
            End Using
            Return t
        End Function

        Public Function GetCitys(searchTerm As String,
                                   moduleId As Integer,
                                   pageIndex As Integer,
                                   pageSize As Integer) As IPagedList(Of City) Implements ICityRepository.GetCitys

            Dim calls = GetCitys(moduleId).Where(Function(c) c.CityName.Contains(searchTerm) OrElse c.RegionName.Contains(searchTerm))
            Return New PagedList(Of City)(calls, pageIndex, pageSize)
        End Function

    End Class

End Namespace
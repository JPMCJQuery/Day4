Imports System.Web.Mvc
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Threading.Tasks

Namespace Controllers
    Public Class CalendarController
        Inherits Controller

        ' GET: Calendar
        Function Index() As ActionResult
            'Return View()
            Return RedirectToAction("GetEvents")
        End Function

        Private Sub ConfigureHttpClient(client As HttpClient)
            client.BaseAddress = New Uri("http://localhost:35007/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(
                New MediaTypeWithQualityHeaderValue("application/json"))
        End Sub

        Async Function GetEventsAsJson() As Task(Of ActionResult)
            Using client As New HttpClient
                ConfigureHttpClient(client)

                Dim getResponse As HttpResponseMessage = Await client.GetAsync("api/Events")
                If (getResponse.IsSuccessStatusCode) Then
                    Return Content(Await getResponse.Content.ReadAsStringAsync())
                Else
                    Return HttpNotFound()
                End If
            End Using
        End Function

        Async Function GetEvents() As Task(Of ActionResult)
            Using client As New HttpClient
                ConfigureHttpClient(client)

                Dim getResponse As HttpResponseMessage = Await client.GetAsync("api/Events")
                If (getResponse.IsSuccessStatusCode) Then
                    Dim data As List(Of CalendarEvent) = Await getResponse.Content.ReadAsAsync(Of List(Of CalendarEvent))()
                    Return View(data)
                Else
                    Return HttpNotFound()
                End If
            End Using
        End Function

        <Route("Calendar/GetEventsByDateRange/{startDate:datetime}/{EndDate:datetime}")>
        Public Async Function GetEventsByDateRange(startDate As Date, EndDate As Date) As Task(Of ActionResult)
            Using client As New HttpClient
                ConfigureHttpClient(client)

                Dim getResponse As HttpResponseMessage = Await client.GetAsync("api/Events/" &
                                startDate.ToString("MM-dd-yy") & "/" & EndDate.ToString("MM-dd-yy"))
                If (getResponse.IsSuccessStatusCode) Then
                    Dim data As List(Of CalendarEvent) = Await getResponse.Content.ReadAsAsync(Of List(Of CalendarEvent))()
                    Return View("GetEvents", data)
                Else
                    Return HttpNotFound()
                End If
            End Using
        End Function

        <Route("Calendar/GetEventsBySearch/{criteria}")>
        Public Async Function GetEventsBySearch(criteria As String) As Task(Of ActionResult)
            Using client As New HttpClient
                ConfigureHttpClient(client)

                Dim getResponse As HttpResponseMessage = Await client.GetAsync("api/Events/" & criteria)
                If (getResponse.IsSuccessStatusCode) Then
                    Dim data As List(Of CalendarEvent) = Await getResponse.Content.ReadAsAsync(Of List(Of CalendarEvent))()
                    Return View("GetEvents", data)
                Else
                    Return HttpNotFound()
                End If
            End Using
        End Function

        Async Function PostEvent() As Task(Of ActionResult)
            Dim Data As New CalendarEvent With {.Title = "Event to Post"}

            Using client As New HttpClient
                ConfigureHttpClient(client)

                Dim postResponse As HttpResponseMessage = client.PostAsJsonAsync(Of CalendarEvent)("api/Events", Data).Result
                If (postResponse.IsSuccessStatusCode) Then
                    Return Content(Await postResponse.Content.ReadAsStringAsync())
                Else
                    Return HttpNotFound()
                End If
            End Using
        End Function

        Async Function PutEvent(Id As Integer) As Task(Of ActionResult)
            Dim Data As New CalendarEvent With {.Title = "Event to Put"}

            Using client As New HttpClient
                ConfigureHttpClient(client)

                Dim putResponse As HttpResponseMessage = Await client.PutAsJsonAsync("api/Events/" & Id, Data)
                If (putResponse.IsSuccessStatusCode) Then
                    Return Content(Await putResponse.Content.ReadAsStringAsync())
                Else
                    Return HttpNotFound()
                End If
            End Using
        End Function

        Async Function DeleteEvent(Id As Integer) As Task(Of ActionResult)
            Using client As New HttpClient
                ConfigureHttpClient(client)

                Dim deleteResponse As HttpResponseMessage = Await client.DeleteAsync("api/Events/" & Id)
                If (deleteResponse.IsSuccessStatusCode) Then
                    Return Content(Await deleteResponse.Content.ReadAsStringAsync())
                Else
                    Return HttpNotFound()
                End If
            End Using
        End Function
    End Class
End Namespace
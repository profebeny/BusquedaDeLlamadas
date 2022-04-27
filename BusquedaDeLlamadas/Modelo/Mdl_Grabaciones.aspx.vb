Imports System.Data.SqlClient
Imports Newtonsoft.Json
Public Class Mdl_Grabaciones
    Inherits System.Web.UI.Page
    Public json As Object
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Obtener_Datos()
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String = Nothing

        Try
            conn = New SqlConnection("Data Source=10.18.75.26; Initial Catalog=BD_089_2022; User ID=SistemasPachuca; Password=SistemasPachuc@")
            conn.Open()

            sql = " SELECT [IdCall], CONVERT(DATE, StartDateTime) AS Fecha, RIGHT( CONVERT(DATETIME, StartDateTime, 108),8) AS Hora, [Extension], [Duration], [Audio] "
            sql = sql + " FROM [Grabaciones].[dbo].[Grabaciones] order by StartDateTime desc "

            cmd = New SqlCommand(sql, conn)
            'CREAR UN DATATABLE
            Dim dt As New DataTable()
            dt.Load(cmd.ExecuteReader())
            conn.Close()
            SqlConnection.ClearPool(conn)

            json = JsonConvert.SerializeObject(dt, Formatting.Indented)
            dt.Dispose()


            Dim resultado As String
            resultado = "{" + """data"":" + json + "}"
            Response.Write(resultado)

        Catch ex As Exception
            Console.Write(ex)
            ex.ToString()
            conn.Close()
            SqlConnection.ClearPool(conn)
            'Alert de Error
            Response.Redirect("Frm_ErrorInfo.aspx")

        End Try
    End Sub


End Class
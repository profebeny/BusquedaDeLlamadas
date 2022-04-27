Imports System.Data.SqlClient
Imports Newtonsoft.Json
Public Class Dt_Grabaciones
    Inherits System.Web.UI.Page
    Public json As Object
    Public fi As String = ""
    Public ff As String = ""
    Public ext As String = ""
    Public party As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fi = Request.QueryString("fi")
        ff = Request.QueryString("ff")
        ext = Request.QueryString("ext")
        party = Request.QueryString("par")

        Obtener()
    End Sub

    'Public cadena As String = "Data Source=10.18.75.26; Initial Catalog=BD_089_2022; User ID=SistemasPachuca; Password=SistemasPachuc@; Connection Timeout=50"

    Private Sub Obtener()
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String = Nothing

        Try
            conn = New SqlConnection("Data Source=10.18.75.26; Initial Catalog=BD_089_2022; User ID=SistemasPachuca; Password=SistemasPachuc@")
            conn.Open()

            sql = " SELECT [IdCall] "
            sql = sql + " ,concat(SUBSTRING([StartDateTime],1,10),' ',SUBSTRING([StartDateTime],12,8)) as [StartDateTime] "
            sql = sql + " ,concat(SUBSTRING([EndDateTime],1,10),' ',SUBSTRING([EndDateTime],12,8)) as [EndDateTime]  "
            sql = sql + " ,SUBSTRING([Duration],1,8) as [Duration],[Extension],[OtherParty]  FROM [Grabaciones].[dbo].[Grabaciones] "
            sql = sql + " where CONVERT(date,StartDateTime,103)>='" & fi & "'  "
            sql = sql + " and CONVERT(date,StartDateTime,103)<='" & ff & "' "
            If ext <> "" Then
                sql = sql + " and [Extension] = '" & ext & "' "
            End If
            If party <> "" Then
                sql = sql + "   and [OtherParty] = '" & party & "' "
            End If
            sql = sql + ""


            'u.Estatus <> 'ACTIVO' and
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
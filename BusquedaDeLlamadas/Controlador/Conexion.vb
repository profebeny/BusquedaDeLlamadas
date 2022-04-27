Imports System.Data.SqlClient

Module Conexion
    Public conn As New SqlConnection("Data Source=10.18.8.104; Initial Catalog=Grabaciones; User ID=sa; Password=admin2022*")
    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public dt As New DataTable
    Public da As SqlDataAdapter
    Public sql As String

    Public Sub conectarse()
        conn.Close()
        SqlConnection.ClearPool(conn)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

        Catch ex As Exception
            If ex.ToString.Contains("No se pudo encontrar") Then
                'MsgBox("La base de datos a la que intentas conectar no se encuentra en el directorio, por favor, verifica e intenta nuevamente", MsgBoxStyle.Critical, "Error")
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                    SqlConnection.ClearPool(conn)
                End If
                conn.Close()
                SqlConnection.ClearPool(conn)
            End If
        End Try
    End Sub
    Public Sub desconectarse()
        If Not conn.State = ConnectionState.Closed Then
            conn.Close()
        End If
    End Sub
End Module
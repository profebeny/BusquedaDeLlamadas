Imports System.Data.SqlClient
Public Module ConexionSistemaUsuario

    Public conn_U As New SqlConnection("Data Source=10.18.8.195; Initial Catalog=GESTION_USUARIOS; User ID=Agenda; Password=Ag3nd4egm")
    Public cmd_U As New SqlCommand
    Public dr_U As SqlDataReader
    Public dt_U As New DataTable
    Public da_U As SqlDataAdapter
    Public sql_U As String

    Public Sub conectarse()
        conn_U.Close()
        SqlConnection.ClearPool(conn)
        Try
            If conn_U.State = ConnectionState.Closed Then
                conn_U.Open()
            End If

        Catch ex As Exception
            If ex.ToString.Contains("No se pudo encontrar") Then
                'MsgBox("La base de datos a la que intentas conectar no se encuentra en el directorio, por favor, verifica e intenta nuevamente", MsgBoxStyle.Critical, "Error")
                If conn_U.State = ConnectionState.Open Then
                    conn_U.Close()
                    SqlConnection.ClearPool(conn)
                End If
                conn_U.Close()
                SqlConnection.ClearPool(conn)
            End If
        End Try
    End Sub

    Public Sub desconectarse()
        If Not conn_U.State = ConnectionState.Closed Then
            conn.Close()
        End If
    End Sub
End Module

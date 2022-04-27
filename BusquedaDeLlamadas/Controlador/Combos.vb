
Imports System.Data.SqlClient
Imports System.Web

Namespace Controlador
    Public Class Combos

        Public Function LlenarComboMunicipioseleccionado()


            Conexion.conectarse()
            Conexion.sql = " "
            Conexion.sql = "SELECT  [IdMunicipio],[Municipio]  FROM [SEGURIDADPRIVADA].[dbo].[CatMunicipios] where idEstado = '13' "

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function

        Public Function LlenarComboEstado()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdEstado],[Estado]  FROM [SEGURIDADPRIVADA].[dbo].[CatEstados]where idEstado = '13' "

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function

        Public Function LlenarComboGiro()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdGiro],[Giro]  FROM [SEGURIDADPRIVADA].[dbo].[CatGiro]"

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function

        Public Function LlenarComboMunicipiosUsuarios()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdMunicipio],[Municipio]  FROM [SEGURIDADPRIVADA].[dbo].[CatMunicipios] where IdEstado = 13"

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function

        Public Function LlenarComboNivelEstudios()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdCatNivelEstudios],[DescNivelEstudios]  FROM [SEGURIDADPRIVADA].[dbo].[CatNivelEstudios]"

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function

        Public Function LlenarComboCargo()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdCargo],[Cargo]  FROM [SEGURIDADPRIVADA].[dbo].[CatCargos]"

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function

        Public Function LlenarComboServicio(ByRef Idempresa As String)


            If Idempresa = 1 Then
                Conexion.conectarse()
                Conexion.sql = ""
                Conexion.sql = "SELECT  [IdServicio],[Servicio]  FROM [SEGURIDADPRIVADA].[dbo].[Servicios]"

                Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
                Dim dt As New DataTable

                Try
                    da.Fill(dt)
                Catch ex As Exception
                    ex.ToString()
                    Conexion.conn.Close()
                    SqlConnection.ClearPool(Conexion.conn)
                End Try
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
                Return dt

            Else
                Conexion.conectarse()
                Conexion.sql = ""
                Conexion.sql = "SELECT  [IdServicio],[Servicio]  FROM [SEGURIDADPRIVADA].[dbo].[Servicios] where IdEmpresa = " & Idempresa

                Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
                Dim dt As New DataTable

                Try
                    da.Fill(dt)
                Catch ex As Exception
                    ex.ToString()
                    Conexion.conn.Close()
                    SqlConnection.ClearPool(Conexion.conn)
                End Try
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
                Return dt

            End If
        End Function

        Public Function LlenarComboEstatus()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdCatEstatus],[DescEstatus]  FROM [SEGURIDADPRIVADA].[dbo].[CatEstatus]"

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function



        Public Function LlenarComboTipoServicios()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdTipoServicios],[Servicios]  FROM [SEGURIDADPRIVADA].[dbo].[CatTipoServicios]"

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function

        Public Function LlenarComboEmpresas()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdEmpresa],[RazonSocial]  FROM [SEGURIDADPRIVADA].[dbo].[Empresas]"

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function
        Public Function LlenarComboEstatusVerificacion()
            Conexion.conectarse()
            Conexion.sql = ""
            Conexion.sql = "SELECT  [IdStatusVerificacion],[StatusVerificacion]  FROM [SEGURIDADPRIVADA].[dbo].[CatStatusVerificacion]"

            Dim da As New SqlDataAdapter(Conexion.sql, Conexion.conn)
            Dim dt As New DataTable

            Try
                da.Fill(dt)
            Catch ex As Exception
                ex.ToString()
                Conexion.conn.Close()
                SqlConnection.ClearPool(Conexion.conn)
            End Try
            Conexion.conn.Close()
            SqlConnection.ClearPool(Conexion.conn)
            Return dt
        End Function

    End Class
End Namespace

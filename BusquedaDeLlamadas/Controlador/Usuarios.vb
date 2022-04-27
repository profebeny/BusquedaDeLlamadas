Public Class Usuarios
    Public Function LogearUsuario(ByRef usuario As String, ByRef contrasena As String)
        ConexionSistemaUsuario.conectarse()
        Dim Existe As Integer = 0

        ConexionSistemaUsuario.cmd_U.CommandType = CommandType.Text
        ConexionSistemaUsuario.cmd_U.Connection = ConexionSistemaUsuario.conn_U

        ConexionSistemaUsuario.sql_U = ""
        ConexionSistemaUsuario.sql_U = "select count(*) from Usuarios where Numero_cuenta = '" & usuario & "' and Contraseña = '" & contrasena & "' and Id_activo=2"
        ConexionSistemaUsuario.cmd_U.CommandText = ConexionSistemaUsuario.sql_U
        Try

            ConexionSistemaUsuario.dr_U = ConexionSistemaUsuario.cmd_U.ExecuteReader()
            'Existe algun campo
            If ConexionSistemaUsuario.dr_U.HasRows Then
                While ConexionSistemaUsuario.dr_U.Read()
                    Existe = Convert.ToInt32(ConexionSistemaUsuario.dr_U(0))

                End While
                ConexionSistemaUsuario.conn_U.Close()
            Else
                Existe = 0
                ConexionSistemaUsuario.conn_U.Close()
            End If
        Catch ex As Exception
            ConexionSistemaUsuario.conn_U.Close()
        End Try
        Return Existe

    End Function


    Public Function TraerDatosUsuario_Principal(ByRef usuario As String)
        ConexionSistemaUsuario.conectarse()
        Dim Datos(4) As String

        ConexionSistemaUsuario.cmd_U.CommandType = CommandType.Text
        ConexionSistemaUsuario.cmd_U.Connection = ConexionSistemaUsuario.conn_U
        ConexionSistemaUsuario.sql_U = ""
        ConexionSistemaUsuario.sql_U = "SELECT CONCAT([Nombre],' ',[Apaterno],' ',[Amaterno]) as Nombre,[IdCelular], IdEmpresa, IdCargo   FROM Usuarios where IdCelular like '" & usuario & "'"
        ConexionSistemaUsuario.cmd_U.CommandText = ConexionSistemaUsuario.sql_U
        Try
            ConexionSistemaUsuario.dr_U = ConexionSistemaUsuario.cmd_U.ExecuteReader()
            'Existe algun campo
            If ConexionSistemaUsuario.dr_U.HasRows Then
                While ConexionSistemaUsuario.dr_U.Read()
                    Datos(0) = ConexionSistemaUsuario.dr_U(0).ToString
                    Datos(1) = ConexionSistemaUsuario.dr_U(1).ToString
                    Datos(2) = ConexionSistemaUsuario.dr_U(2).ToString
                    Datos(3) = ConexionSistemaUsuario.dr_U(3).ToString

                End While

                ConexionSistemaUsuario.conn_U.Close()
            Else
                Datos(0) = ""
                Datos(1) = ""
                Datos(2) = ""
                Datos(3) = ""


                ConexionSistemaUsuario.conn_U.Close()
            End If
        Catch ex As Exception
            ex.ToString()
            ConexionSistemaUsuario.conn_U.Close()
        End Try
        ConexionSistemaUsuario.conn_U.Close()
        Return Datos
    End Function

    Public Function PermisoSistema(ByRef usuario As String)
        ConexionSistemaUsuario.conectarse()
        Dim Existe As Integer = 0

        ConexionSistemaUsuario.cmd_U.CommandType = CommandType.Text
        ConexionSistemaUsuario.cmd_U.Connection = ConexionSistemaUsuario.conn_U

        ConexionSistemaUsuario.sql_U = ""
        ConexionSistemaUsuario.sql_U = "select count(*) as Permiso from Control_Sistema where Sigla_sistema='CLLA' and Numero_Cuenta='" & usuario & "'"
        ConexionSistemaUsuario.cmd_U.CommandText = ConexionSistemaUsuario.sql_U
        Try

            ConexionSistemaUsuario.dr_U = ConexionSistemaUsuario.cmd_U.ExecuteReader()
            'Existe algun campo
            If ConexionSistemaUsuario.dr_U.HasRows Then
                While ConexionSistemaUsuario.dr_U.Read()
                    Existe = Convert.ToInt32(ConexionSistemaUsuario.dr_U(0))

                End While
                ConexionSistemaUsuario.conn_U.Close()
            Else
                Existe = 0
                ConexionSistemaUsuario.conn_U.Close()
            End If
        Catch ex As Exception
            ConexionSistemaUsuario.conn_U.Close()
        End Try
        Return Existe


    End Function

    Public Function Privilegio(ByRef usuario As String)
        ConexionSistemaUsuario.conectarse()
        Dim Existe As Integer = 0

        ConexionSistemaUsuario.cmd_U.CommandType = CommandType.Text
        ConexionSistemaUsuario.cmd_U.Connection = ConexionSistemaUsuario.conn_U

        ConexionSistemaUsuario.sql_U = ""
        ConexionSistemaUsuario.sql_U = "select Id_privilegio from Control_Sistema where Sigla_sistema='CLLA' and Numero_cuenta='" & usuario & "'"
        ConexionSistemaUsuario.cmd_U.CommandText = ConexionSistemaUsuario.sql_U
        Try

            ConexionSistemaUsuario.dr_U = ConexionSistemaUsuario.cmd_U.ExecuteReader()
            'Existe algun campo
            If ConexionSistemaUsuario.dr_U.HasRows Then
                While ConexionSistemaUsuario.dr_U.Read()
                    Existe = Convert.ToInt32(ConexionSistemaUsuario.dr_U(0))

                End While
                ConexionSistemaUsuario.conn_U.Close()
            Else
                Existe = 0
                ConexionSistemaUsuario.conn_U.Close()
            End If
        Catch ex As Exception
            ConexionSistemaUsuario.conn_U.Close()
        End Try
        Return Existe
    End Function

    Public Function NombreUsuario(ByRef usuario As String)

        ConexionSistemaUsuario.conectarse()
        Dim Existe As String = ""

        ConexionSistemaUsuario.cmd_U.CommandType = CommandType.Text
        ConexionSistemaUsuario.cmd_U.Connection = ConexionSistemaUsuario.conn_U

        ConexionSistemaUsuario.sql_U = ""
        ConexionSistemaUsuario.sql_U = "select CONCAT(Nombre,' ',Ape_paterno,' ',Ape_materno) AS NOMBRE from Usuarios where Numero_cuenta='" & usuario & "'"
        ConexionSistemaUsuario.cmd_U.CommandText = ConexionSistemaUsuario.sql_U
        Try

            ConexionSistemaUsuario.dr_U = ConexionSistemaUsuario.cmd_U.ExecuteReader()
            'Existe algun campo
            If ConexionSistemaUsuario.dr_U.HasRows Then
                While ConexionSistemaUsuario.dr_U.Read()
                    Existe = ConexionSistemaUsuario.dr_U(0)

                End While
                ConexionSistemaUsuario.conn_U.Close()
            Else
                Existe = 0
                ConexionSistemaUsuario.conn_U.Close()
            End If
        Catch ex As Exception
            ConexionSistemaUsuario.conn_U.Close()
        End Try
        Return Existe
    End Function


    Public Function Subcentro(ByRef usuario As String)
        ConexionSistemaUsuario.conectarse()
        Dim Existe As String = ""

        ConexionSistemaUsuario.cmd_U.CommandType = CommandType.Text
        ConexionSistemaUsuario.cmd_U.Connection = ConexionSistemaUsuario.conn_U

        ConexionSistemaUsuario.sql_U = ""
        ConexionSistemaUsuario.sql_U = "select Id_subcentro from Control_Sistema where Sigla_sistema='CLLA' and Numero_cuenta='" & usuario & "'"
        ConexionSistemaUsuario.cmd_U.CommandText = ConexionSistemaUsuario.sql_U
        Try

            ConexionSistemaUsuario.dr_U = ConexionSistemaUsuario.cmd_U.ExecuteReader()
            'Existe algun campo
            If ConexionSistemaUsuario.dr_U.HasRows Then
                While ConexionSistemaUsuario.dr_U.Read()
                    Existe = Convert.ToInt32(ConexionSistemaUsuario.dr_U(0))

                End While
                ConexionSistemaUsuario.conn_U.Close()
            Else
                Existe = 0
                ConexionSistemaUsuario.conn_U.Close()
            End If
        Catch ex As Exception
            ConexionSistemaUsuario.conn_U.Close()
        End Try
        Return Existe


    End Function



End Class

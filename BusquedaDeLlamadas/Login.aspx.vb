Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Response.Cache.SetAllowResponseInBrowserHistory(False)
        Response.Cache.SetNoStore()

        If Not IsPostBack Then
            Session("Usuario") = ""
            Session("Nombre") = ""
            Session("Privilegio") = ""
            Session("Subarea") = ""

            Response.AppendHeader("Cache-Control", "no-store")
        End If
    End Sub

    Private Sub Btn_Ingresar_Click(sender As Object, e As EventArgs) Handles Btn_Ingresar.Click
        Dim Usuarios As New Usuarios
        Dim usuario As String
        Dim pass As String

        usuario = Txt_usuario.Text.ToUpper()
        Session("Usuario") = usuario
        pass = txt_Password.Text

        If Validar() = True Then
            If Usuarios.LogearUsuario(usuario, pass) > 0 Then
                If Usuarios.PermisoSistema(usuario) > 0 Then
                    Session("Nombre") = Usuarios.NombreUsuario(usuario)
                    Session("Privilegio") = Usuarios.Privilegio(usuario)

                    Response.Redirect("Frm_Menu.aspx")
                Else
                    lbl_validar.Visible = True
                    lbl_validar.Text = "El usuario ingresado no tiene permiso para ingresar"
                End If

            Else
                lbl_validar.Visible = True
                lbl_validar.Text = "El usuario ingresado no existe"
            End If
        End If
    End Sub

    Private Sub Borrar()
        Txt_usuario.Text = ""
        txt_Password.Text = ""
    End Sub

    Private Function Validar()
        Dim Resultado As Boolean = False
        If Txt_usuario.Text = "" And txt_Password.Text = "" Then
            lbl_validar.Visible = True
            lbl_validar.Text = "Escriba su Usuario y Contraseña"
            Resultado = False

        Else
            If Txt_usuario.Text = "" Then
                lbl_validar.Visible = True
                lbl_validar.Text = "Escriba su Usuario"
                Resultado = False
            Else
                If txt_Password.Text = "" Then
                    lbl_validar.Visible = True
                    lbl_validar.Text = "Escriba su Contraseña"
                    Resultado = False
                Else
                    Resultado = True

                End If
            End If
        End If
        Return Resultado
    End Function


End Class
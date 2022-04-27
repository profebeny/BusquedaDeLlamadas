Public Class Frm_Menu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Response.Cache.SetAllowResponseInBrowserHistory(False)
        Response.Cache.SetNoStore()
    End Sub

    Private Sub Btn_Procesar_Click(sender As Object, e As ImageClickEventArgs) Handles Btn_Procesar.Click

        Response.Redirect("Frm_Subida.aspx")
    End Sub
    Private Sub Btn_Consultar_Click(sender As Object, e As ImageClickEventArgs) Handles Btn_Consultar.Click
        Response.Redirect("Frm_Consulta.aspx")
    End Sub


End Class
Public Class Frm_Menu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Response.Cache.SetAllowResponseInBrowserHistory(False)
        Response.Cache.SetNoStore()
    End Sub


    Private Sub Btn_Consultar_Click(sender As Object, e As ImageClickEventArgs) Handles Btn_Consultar.Click
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "modaltipo", "modaltipo();", True)
    End Sub

    Protected Sub Btn089_Click(sender As Object, e As ImageClickEventArgs) Handles Btn089.Click
        Response.Redirect("Frm_Consulta.aspx")
    End Sub

    Protected Sub Btn911_Click(sender As Object, e As ImageClickEventArgs) Handles Btn911.Click
        Response.Redirect("Frm-911.aspx")
    End Sub
End Class
Public Class Principal
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "Nombre", "Nombre('" & Session("Nombre") & "')", True)
    End Sub

End Class
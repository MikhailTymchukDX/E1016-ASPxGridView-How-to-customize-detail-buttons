Imports System
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub ASPxImage1_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim img As ASPxImage = DirectCast(sender, ASPxImage)
        Dim templateContainer As GridViewDataItemTemplateContainer = CType(img.NamingContainer, GridViewDataItemTemplateContainer)
        Dim keyValue As Integer = CInt((templateContainer.KeyValue))
        If templateContainer.VisibleIndex Mod 2 = 0 Then
            img.Visible = False
        End If
        If templateContainer.Grid.DetailRows.IsVisible(templateContainer.VisibleIndex) Then
            img.ImageUrl = "~/Images/Ex.gif"
            img.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.CollapseDetailRow('{1}'); }}", templateContainer.Grid.ClientID, templateContainer.VisibleIndex)
        Else
            img.ImageUrl = "~/Images/Co.gif"
            img.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.ExpandDetailRow('{1}'); }}", templateContainer.Grid.ClientID, templateContainer.VisibleIndex)
        End If
    End Sub
    Protected Sub ASPxGridView2_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
        Session("CategoryID") = DirectCast(sender, ASPxGridView).GetMasterRowKeyValue()
    End Sub
End Class

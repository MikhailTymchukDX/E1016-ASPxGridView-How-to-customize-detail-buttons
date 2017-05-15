using System;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class _Default: System.Web.UI.Page {
    protected void ASPxImage1_Init(object sender, EventArgs e) {
        ASPxImage img = (ASPxImage)sender;
        GridViewDataItemTemplateContainer templateContainer = (GridViewDataItemTemplateContainer)img.NamingContainer;
        int keyValue = (int)templateContainer.KeyValue;
        if (templateContainer.VisibleIndex % 2 == 0)
            img.Visible = false;
        if (templateContainer.Grid.DetailRows.IsVisible(templateContainer.VisibleIndex)) {
            img.ImageUrl = "~/Images/Ex.gif";
            img.ClientSideEvents.Click = string.Format("function(s, e) {{ {0}.CollapseDetailRow('{1}'); }}", templateContainer.Grid.ClientID, templateContainer.VisibleIndex);
        } else {
            img.ImageUrl = "~/Images/Co.gif";
            img.ClientSideEvents.Click = string.Format("function(s, e) {{ {0}.ExpandDetailRow('{1}'); }}", templateContainer.Grid.ClientID, templateContainer.VisibleIndex);
        }
    }
    protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e) {
        Session["CategoryID"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
    }
}

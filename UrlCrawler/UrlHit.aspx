<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrlHit.aspx.cs" Inherits="SoftwareDeveloperSolution.UrlCrawler.UrlHit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    Web Site Path :
                </td>
                <td>
                    <asp:TextBox ID="txtWebSitePath" runat="server">http://softwaredevelopersolution.com/</asp:TextBox>
                </td>
                <td>
                    Site Map Path :
                </td>
                <td>
                    <asp:TextBox ID="txtSiteMapPath" runat="server">http://softwaredevelopersolution.com/sitemap1.xml</asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Label ID="lblWebPage" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

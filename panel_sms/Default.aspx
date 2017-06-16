<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>
        </h3>
    </div>
    <div class="style1">
        <br />
        <div class="style2">
            <br />
            <table>
                <tr>
                    <td>
                        شماره مشتری :
                        <asp:TextBox ID="Textbox1" runat="server" Text=""></asp:TextBox>
                        <asp:Label ID="label1" runat="server" Text=""></asp:Label>
                        <asp:Label ID="label2" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button2" runat="server" Text="جستجوی مشتری" OnClick="clk1" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <textarea id="txt" runat="server" cols="60" rows="10"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="ارسال" OnClick="clck" />
                    </td>
                    <td>
                        <asp:Label ID="res" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>

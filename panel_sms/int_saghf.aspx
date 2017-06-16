<%@ Page Language="C#" AutoEventWireup="true" CodeFile="int_saghf.aspx.cs" Inherits="int_saghf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
       <form id="form1" runat="server" style="font-size: 10pt; font-family: tahoma; text-align: center"
    dir="rtl" align="center">
    <div align="center">
        <br />
        <br />
        <br />
        
        <br />
        <table style="text-align: right" cellpadding="7" align="center">
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="سرویس" Width="300"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="سقف" Width="100"></asp:Label>
                </td>
               
            </tr>
        </table>
        <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="text-align: right" cellpadding="7" align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("des") %>' Width="300" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("saghf") %>' Width="100"></asp:Label>
                                </td>
                             
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="بازگشت" OnClick="clk1" />
    </div>
    </form>
</body>
</html>

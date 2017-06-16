<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bankstatement.aspx.cs" Inherits="bankstatement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="font-size: 10pt; font-family: tahoma; text-align: center"
    dir="rtl">
    <div>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <table align="center">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="text-align: right" cellpadding="7" align="center">
                        <tr>
                            
                            <td>
                                <asp:Label ID="Label77" runat="server" Width="100" Text="بدهکار"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label78" runat="server" Width="100" Text="بستانکار"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label79" runat="server" Width="300" Text="شرح"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Width="120" Text="مانده حساب"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label76" runat="server" Width="200" Text="تاریخ و زمان"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="false" GridLines="Both">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table style="text-align: right" cellpadding="7" align="center">
                                        <tr>
                                           
                                            <td>
                                                <asp:Label ID="Label77" runat="server" Width="100" Text='<%#Eval("bed") %>'> '></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label78" runat="server"  Width="100" Text='<%#Eval("bes") %>'>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label79" runat="server"  Width="300"  Text='<%#Eval("dsc") %>'>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server"  Width="120" Text='<%#Eval("bal") %>'>'></asp:Label>
                                            </td>
                                             <td>
                                                <asp:Label ID="Label76" runat="server"  Width="200"  Text='<%#Eval("dat") %>'>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="بازگشت" OnClick="btn1" />
    </div>
    </form>
</body>
</html>

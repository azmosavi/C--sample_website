<%@ Page Language="C#" AutoEventWireup="true" CodeFile="acntdetail.aspx.cs" Inherits="acntdetail" %>

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
        <asp:GridView ID="gridview4" runat="server" AutoGenerateColumns="false" Style="background-color: white"
            BorderColor="White">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="text-align: right" cellpadding="7" align="center">
                            <tr>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text="شماره حساب" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Text='<%#Eval("hesab") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="شماره مشتری" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("cif") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label27" runat="server" Text="رابطه مشتری با حساب" Width="120"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label29" runat="server" Text='<%#Eval("rabet") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="شرایط برداشت" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("cond") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="مانده" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("mandeh") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="روز واریز سود" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Text='<%#Eval("day") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="شماره حساب واریز سود" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Text='<%#Eval("hesab_sood") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="مسدودی مشمول سود" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("masdoodi_ba") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="مسدودی بدون سود" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("masdoodi_bi") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text=" پیام مشتری" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("msg") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="تاریخ افتتاح" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text='<%#Eval("opn") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="تاریخ بستن" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text='<%#Eval("cls") %>' Width="200"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Text="توضیحات حساب" Width="200"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text='<%#Eval("cmnt") %>' Width="200"></asp:Label>
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

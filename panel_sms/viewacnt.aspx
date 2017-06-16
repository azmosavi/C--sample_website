<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewacnt.aspx.cs" Inherits="viewacnt" %>

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
        <table style="text-align: right" >
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="شماره حسابها" Width="150"></asp:Label>
                </td>
                <td>
                 <asp:Label ID="Label17" runat="server" Text="وضعیت" Width="100"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label18" runat="server" Text="روزانه با فرمت html" Width="100"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="روزانه با فرمت excel" Width="100"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="روزانه با فرمت csv" Width="100"></asp:Label>
                </td>
                
                <td>
                    <asp:Label ID="Label14" runat="server" Text="هفتگی با فرمت csv" Width="100"></asp:Label>
                </td>
                 <td>
                    <asp:Label ID="Label13" runat="server" Text="ماهانه با فرمت html" Width="100"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="ماهانه با فرمت excel" Width="100"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="ماهانه با فرمت csv" Width="100"></asp:Label>
                </td>
               
            </tr>
        </table>
        <asp:GridView ID="gridview2" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                   
                        <table style="text-align: right"  >
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("account_no") %>' Width="150" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("active") %>' Width="100"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text='<%#Eval("daily_html") %>' Width="100" ></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("daily_excel") %>' Width="105" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("daily_csv") %>' Width="105"></asp:Label>
                                </td>
                                 
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("weekly_csv") %>' Width="100"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("monthly_html") %>' Width="100" ></asp:Label>
                                </td>
                                
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("monthly_excel") %>' Width="100" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval(" monthly_csv") %>' Width="100"></asp:Label>
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

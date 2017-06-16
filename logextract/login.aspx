<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .style3
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 10pt; font-family: tahoma; text-align: center" dir="rtl" align="center">
        <br />
        <br />
        <br />
        <table class="style5" align="center" style="font-family:tahoma">
            <tr>
                <td bgcolor="#990033" class="style3">
                    <asp:Label ID="Label60" runat="server" Text="سامانه پیگیری خدمات اینترنتی" Font-Bold="True"
                        Font-Size="Small" font-family="tahoma" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset class="style5">
                        <legend align="right">ورود به سامانه</legend>
                        <table align="center" class="style5">
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table class="style5" align="center" style="font-family:tahoma">
                            <tr align="center">
                                <td align="center">
                                    <asp:Label ID="Label1" runat="server" Text="نام کاربری"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="TextBox1" runat="server" Width="81px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr align="center">
                                <td align="center">
                                    <asp:Label ID="Label2" runat="server" Text="رمز عبور"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="81px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="style5" align="center" style="font-family:tahoma">
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="ورود" OnClick="clk1" Width="96px" Height="30px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

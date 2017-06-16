<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<script type="text/javascript" language="javascript">
        $(function() {
        .blur(function() {
                    var r = new RegExp(' ', 'g');
                    var a = $(this).css('background-color').replace(r, '');
                    if (a == '#fdcfc6' || a == 'rgb(253,207,198)') {
                        $(this).val('');
                        $(this).css('background-color', 'white');
                    }
                });
                })

    </script>--%>
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style3
        {
            height: 41px;
        }
        .style4
        {
            width: 808px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" onload="form1_load">
    <div style="font-size: 10pt; font-family: tahoma; text-align: center" dir="rtl" align="center">
        <br />
        <table width="90%" align="center" font-family="tahoma">
            <tr>
                <td bgcolor="#990033" class="style3">
                    <asp:Label ID="Label60" runat="server" Text="سامانه جستجوی مشتریان مرکز تماس" Font-Bold="True"
                        Font-Size="Medium" font-family="tahoma" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <fieldset>
                        <legend align="right">پارامترهای جستجو</legend>
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" TextAlign="Right" Height="115px"
                                        OnSelectedIndexChanged="rch1">
                                        <asp:ListItem Text="شماره مشتری" Selected="True">
                                        </asp:ListItem>
                                        <asp:ListItem Text="شماره ملی">
                                        </asp:ListItem>
                                        <asp:ListItem Text="شماره کارت">
                                        </asp:ListItem>
                                        <asp:ListItem Text="شماره حساب">
                                        </asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right">
                                    <table cellspacing="6" style="margin-top: 20px">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TextBox1" runat="server" Text="" Height="12px" TabIndex="1" MaxLength="8"
                                                    Font-Size="Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:TextBox ID="TextBox2" runat="server" Text="" Height="12px" TabIndex="2" MaxLength="10"
                                                    Font-Size="Small" onblur="return checkMelliCode(this,this);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:TextBox ID="TextBox3" runat="server" Text="" Height="12px" TabIndex="3" MaxLength="16"
                                                    Font-Size="Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <table align="left">
                                                    <tr align="left">
                                                        <td align="left">
                                                            <asp:TextBox ID="TextBox6" runat="server" Text="" Style="text-align: left" Width="33px"
                                                                Height="12px" TabIndex="6" MaxLength="3" Font-Size="Small" ></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox5" runat="server" Text="" Height="12px" TabIndex="5" MaxLength="8"
                                                                Font-Size="Small"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox4" runat="server" Text="" Width="41px" Height="12px" TabIndex="4"
                                                                MaxLength="3" Font-Size="Small"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button8" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA"
                                                                BorderColor="#D1C6BC" Text="جستجو" OnClick="clk6" Font-Names="Tahoma" Height="28px"
                                                                TabIndex="7" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
        <table style="height: 43px; margin-right: 50px; font-family: Tahoma;">
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA"
                        BorderColor="#D1C6BC" Text="مشخصات شناسنامه ای" OnClick="clk1" Height="28px"
                        Visible="false" TabIndex="8" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA"
                        BorderColor="#D1C6BC" Text="اطلاعات حساب" OnClick="clk2" Height="28px" Visible="false"
                        TabIndex="9" />
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA"
                        BorderColor="#D1C6BC" Text="اطلاعات کارت" OnClick="clk3" Height="28px" Visible="false"
                        TabIndex="10" />
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA"
                        BorderColor="#D1C6BC" Text="موبایل بانک- ایمیل و sms" Height="28px" Visible="false"
                        TabIndex="11" OnClick="clk9" Font-Names="tahoma" />
                </td>
                <td>
                    <asp:Button ID="Button12" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA"
                        BorderColor="#D1C6BC" Text="اینترنت بانک و تلفن بانک" Height="28px" Visible="false" Font-Names="tahoma"
                        TabIndex="12" OnClick="clk10" />
                </td>
                <td>
                    <asp:Button ID="Button7" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA"
                        BorderColor="#D1C6BC" Text="خروج" OnClick="clk5" Font-Names="Tahoma" Height="28px"
                        TabIndex="13" />
                </td>
            </tr>
        </table>
        <asp:Label ID="Label50" runat="server" Text="" ForeColor="Maroon"></asp:Label>
        <table style="margin-right: 50px" width="950">
            <tr>
                <td class="style4">
                    <asp:MultiView ID="multuview1" runat="server">
                        <asp:View ID="view1" runat="server">
                            <div>
                                <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="false" GridLines="Both">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table border="1" style="text-align: right" cellpadding="7" width="920">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label36" runat="server" Text="شماره مشتری" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("no") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text="نام" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label41" runat="server" Text='<%#Eval("bc_nam") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label13" runat="server" Text="نام خانوادگی" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("bc_family") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label15" runat="server" Text="نام پدر" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("bc_pedar") %>'>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label16" runat="server" Text="جنسیت" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("bc_sex") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label17" runat="server" Text="تاریخ تولد" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("bc_dat") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label14" runat="server" Text="شماره شناسنامه" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("bc_id") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label18" runat="server" Text="کدملی" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("bc_codmelli") %>'>'></asp:Label>
                                                        </td>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label19" runat="server" Text="شماره سریال شناسنامه" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("bc_srl") %>'>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label21" runat="server" Text="محل تولد" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("bc_plc") %>'>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label22" runat="server" Text="کدشعبه تعریف مشتری" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("bc_cod") %>'>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label47" runat="server" Text="شغل" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label48" runat="server" Text='<%#Eval("job") %>'>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label24" runat="server" Text="تلفن" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label25" runat="server" Text='<%#Eval("phone") %>'>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label45" runat="server" Text="موبایل" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label46" runat="server" Text='<%#Eval("mobil") %>'>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label26" runat="server" Text="ایمیل" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label27" runat="server" Text='<%#Eval("email") %>'>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label28" runat="server" Text="فکس" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label29" runat="server" Text='<%#Eval("fax") %>'>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" Text="آدرس" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td colspan="5">
                                                                <asp:Label ID="Label23" runat="server" Text='<%#Eval("adrs") %>'>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label30" runat="server" Text="کدپستی" ForeColor="Maroon"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label31" runat="server" Text='<%#Eval("zip") %>'>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:View>
                        <asp:View ID="view2" runat="server">
                            <div>
                                <table style="text-align: right" cellpadding="7">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label32" runat="server" Text="کد شعبه" Width="70"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label33" runat="server" Text="شماره حساب" Width="120"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label34" runat="server" Text="عنوان حساب" Width="470"></asp:Label>
                                        </td>
                                        <%--<td>
                                            <asp:Label ID="Label35" runat="server" Text="شرایط برداشت از حساب" Width="200"></asp:Label>
                                        </td>--%>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="gridview2" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table style="text-align: right" cellpadding="7">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label37" runat="server" Text='<%#Eval("cod") %>' Width="70">' ></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label38" runat="server" Text='<%#Eval("hesab") %>' Width="120">'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label39" runat="server" Text='<%#Eval("titl") %>' Width="470">'></asp:Label>
                                                        </td>
                                                        <%-- <td>
                                                            <asp:Label ID="Label40" runat="server" Text='<%#Eval("cond") %>' Width="200">'></asp:Label>
                                                        </td>--%>
                                                        <td>
                                                            <asp:Button ID="Button4" runat="server" Text="جزییات حساب" OnClick="clk7" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:View>
                        <asp:View ID="view3" runat="server">
                            <div>
                                <table style="text-align: right" cellpadding="7">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label53" runat="server" Text="شماره کارت" Width="170"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label54" runat="server" Text="حساب اصلی متصل به کارت" Width="170"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label56" runat="server" Text="حساب فرعی متصل به کارت" Width="170"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label42" runat="server" Text="وضعیت کارت" Width="80"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label43" runat="server" Text="وضعیت رمز اینترنتی کارت" Width="170"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label55" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="gridview3" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table style="text-align: right" cellpadding="7">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label51" runat="server" Text='<%#Eval("card") %>' Width="170">'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label52" runat="server" Text='<%#Eval("hesab") %>' Width="170"> '></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label44" runat="server" Text='<%#Eval("hesabha") %>' Width="170">'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("STAT") %>' Width="80">'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label49" runat="server" Text='<%#Eval("stat_ramz2") %>' Width="170">'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button6" runat="server" Text="جزییات کارت" OnClick="clk8" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:View>
                        <asp:View ID="view4" runat="server">
                            <div>
                                <br />
                                <fieldset>
                                    <legend align="right">موبایل بانک</legend>
                                    <table style="text-align: right" cellpadding="7">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label57" runat="server" Text="" Width="10"></asp:Label>
                                            </td>
                                            <td>
                                                <table style="text-align: right" cellpadding="7">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label58" runat="server" Text="وضعیت انتقال وجه" Width="240"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label59" runat="server" Text="وضعیت پرداخت قبوض" Width="125"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label61" runat="server" Text="وضعیت شارژ" Width="125"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label62" runat="server" Text="آخرین زمان ورود به سیستم" Width="150"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Label ID="Label73" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="gridview6" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table style="text-align: right" cellpadding="7">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label63" runat="server" Text="" Width="70"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <table style="text-align: right" cellpadding="7">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label64" runat="server" Text='<%#Eval("vz") %>' Width="250"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label65" runat="server" Text='<%#Eval("bill") %>' Width="125"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label66" runat="server" Text='<%#Eval("sharj") %>' Width="125"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label67" runat="server" Text='<%#Eval("dat") %>' Width="150"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </fieldset>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div>
                                <fieldset>
                                    <legend align="right">sms </legend>
                                    <table style="text-align: right" cellpadding="7">
                                        <tr>
                                            <td >
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label78" runat="server" Text="وضعیت در سرویسهای مدرن sms و email"
                                                                Width="250"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label79" runat="server" Text="حالتهای ارسال sms" Width="250"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label80" runat="server" Text="وضعیت ارسال sms" Width="200"></asp:Label>
                                                        </td>
                                                         <td>
                                                            <asp:Label ID="Label85" runat="server" Text="شماره موبایل" Width="200"></asp:Label>
                                                        </td>
                                                       
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <asp:Label ID="Label82" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                         <td>
                                        <asp:Label ID="label94" runat="server" Text="" Width="20"></asp:Label>
                                        </td>
                                            <td >
                                                <asp:GridView ID="gridview8" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table style="text-align: right" cellpadding="7">
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="Label69" runat="server" Text='<%#Eval("general_stat") %>' Width="260"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label71" runat="server" Text='<%#Eval("event") %>' Width="250"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label83" runat="server" Text='<%#Eval("sms_stat") %>' Width="200"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label86" runat="server" Text='<%#Eval("mobile_no") %>' Width="200"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label69" runat="server" Text="" Width="100"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <br />
                            <br />
                            <div>
                              <fieldset>
                                     <legend align="right">email</legend>
                                    <table style="text-align: right" cellpadding="7">
                                        <tr>
                                        <td>
                                        <asp:Label ID="labelo" runat="server" Text=""></asp:Label>
                                        </td>
                                            <td >
                                                <table>
                                                    <tr>
                                                        
                                                        <td>
                                                            <asp:Label ID="Label89" runat="server" Text="وضعیت email" Width="180"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label92" runat="server" Text="email" Width="260"></asp:Label>
                                                        </td>
                                                         <td>
                                                            <asp:Label ID="Label93" runat="server" Text="حسابها" Width="100"></asp:Label>
                                                        </td>
                                                       
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center" colspan="2">
                                                <asp:Label ID="Label88" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                            </td>
                                           
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                         <td>
                                        <asp:Label ID="label87" runat="server" Text="" Width="50"></asp:Label>
                                        </td>
                                            <td >
                                             
                                                                <table style="text-align: right" cellpadding="7">
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    
                                                                                   <td>
                                                                                        <asp:Label ID="Label71" runat="server" Text="" Width="130"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label83" runat="server" Text="" Width="190"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label86" runat="server" Text="" Width="100"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                          
                                            </td>
                                          
                                            <td>
                                                <asp:Button ID="Button13" runat="server" Text="مشاهده حسابها" Width="120" OnClick="hesabha" />
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            
                            </div>
                        </asp:View>
                        <asp:View ID="view5" runat="server">
                            <div>
                                <br />
                                <fieldset>
                                    <legend align="right">اینترنت بانک</legend>
                                    <table>
                                        <tr>
                                            <td>
                                                <table style="text-align: right" cellpadding="7">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label35" runat="server" Text="" Width="120"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label40" runat="server" Text="سرویس" Width="250"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label72" runat="server" Text="وضعیت" Width="125"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">
                                                            <asp:Label ID="Label75" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label74" runat="server" Text="آخرین زمان ورود به سیستم" Width="175"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label76" runat="server" Text="مشاهده سقفها" Width="100"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                             <asp:Label ID="Label77" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label70" runat="server" Text="" Width="175"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button9" runat="server" Text="مشاهده سقفها" Width="100" OnClick="clksaghf" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gridview7" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table style="text-align: right" cellpadding="7">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label68" runat="server" Text="" Width="120"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="Label69" runat="server" Text='<%#Eval("srv") %>' Width="250"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="Label71" runat="server" Text='<%#Eval("act") %>' Width="125"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
                                </fieldset>
                                <br />
                                <br />
                                <br />
                                <div>
                                    <fieldset>
                                        <legend align="right">تلفن بانک</legend>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                       
                                                        <td>
                                                            <asp:Label ID="Label100" runat="server" Text="" Width="30"></asp:Label>
                                                        </td>
                                                            <td>
                                                                <asp:Label ID="Label81" runat="server" Text="سرویس" Width="260"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label84" runat="server" Text="وضعیت" Width="250"></asp:Label>
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label96" runat="server" Text="آخرین زمان ورود به سیستم" Width="220"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label97" runat="server" Text="مشاهده سقفها" Width="100"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                <asp:Label ID="Label90" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label91" runat="server" Text="" Width="230"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button11" runat="server" Text="مشاهده سقفها" Width="100" OnClick="saghf_tel" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gridview9" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <table style="text-align: right" cellpadding="7">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label68" runat="server" Text="" Width="120"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label69" runat="server" Text='<%#Eval("srv") %>' Width="250"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label71" runat="server" Text='<%#Eval("act") %>' Width="125"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
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
                                          
                                    </fieldset>
                                </div>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
        function checkMelliCode(objcode, varmellicode) {


            var meli_code;
            meli_code = varmellicode.value;
            if (meli_code.length == 10) {
                if (meli_code == '1111111111' ||
            meli_code == '0000000000' ||
            meli_code == '2222222222' ||
            meli_code == '3333333333' ||
            meli_code == '4444444444' ||
            meli_code == '5555555555' ||
            meli_code == '6666666666' ||
            meli_code == '7777777777' ||
            meli_code == '8888888888' ||
            meli_code == '9999999999') {
                    document.getElementById("TextBox2").focus();
                    varmellicode.focus();
                    alert('کد ملي صحيح نمي باشد');
                    //varmellicode.style.borderColor = '#7f9db9';
                    varmellicode.value = "";
                    document.getElementById("TextBox2").focus();
                    return false;
                }
                c = parseInt(meli_code.charAt(9));
                n = parseInt(meli_code.charAt(0)) * 10 +
            parseInt(meli_code.charAt(1)) * 9 +
            parseInt(meli_code.charAt(2)) * 8 +
            parseInt(meli_code.charAt(3)) * 7 +
            parseInt(meli_code.charAt(4)) * 6 +
            parseInt(meli_code.charAt(5)) * 5 +
            parseInt(meli_code.charAt(6)) * 4 +
            parseInt(meli_code.charAt(7)) * 3 +
            parseInt(meli_code.charAt(8)) * 2;
                r = n - parseInt(n / 11) * 11;
                if ((r == 0 && r == c) || (r == 1 && c == 1) || (r > 1 && c == 11 - r)) {
                    // varmellicode.style.borderColor = '#7f9db9';
                    return true;
                }
                else {
                    alert('کد ملي صحيح نمي باشد');
                    varmellicode.value = "";
                    // varmellicode.style.borderColor = '#7f9db9';
                    varmellicode.focus();
                    return false;
                }
            }
            else {
                if (varmellicode.value != "") {
                    alert('کد ملي صحيح نمي باشد');
                    varmellicode.focus();
                }
                //varmellicode.style.borderColor = '#7f9db9';
                varmellicode.value = "";
                return false;

            }
        }


        function KeyDownNumber(str, e) {
            var key;
            var pE = e;
            if (e && e.which) {
                key = e.which;
            }
            else {
                e = event;
                key = e.keyCode;
            }
            //----
            if (!((key >= 48 && key <= 57) || key == 8 || key == 9 || key == 37 || key == 39 || key == 35 || key == 36 || key == 46 || (key >= 96 && key <= 105))) {
                if (window.event) pE = window.event;
                if (pE.cancelBubble != null) pE.cancelBubble = true;
                if (pE.stopPropagation) pE.stopPropagation();
                if (pE.preventDefault) pE.preventDefault();
                if (window.event) pE.returnValue = false;
                if (pE.cancel != null) pE.cancel = true;
            }
        }


    </script>
</body>
</html>

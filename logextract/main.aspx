<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="themes/parsian-theme/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.4.4.min.js" type="text/javascript" language="javascript"></script>
    <script src="js/jquery-ui-1.8.5.custom.min.js" type="text/javascript"></script>
    <script src="js/jquery.maskedinput-1.2.2.min.js" type="text/javascript" language="javascript"></script>
    <script src="js/calendar.min.js" type="text/javascript"></script>
    <script src="js/jquery.ui.datepicker-cc.min.js" type="text/javascript"></script>
    <script src="js/jquery.ui.datepicker-cc-fa.min.js" type="text/javascript"></script>
    <script src="js/myscripts.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            function err(input) {
                $(input).css('background-color', '#fdcfc6');
            }
            var a = $(".DtPckr")
            .attr("size", 10)
            .css("direction", "ltr")
            .css("text-align", "center")
            .mask("9999/99/99")
            .keydown(function (e) {
                var KeyVal = GetKeyVal(e);
                var val = $(this).val();
                var empty = '____/__/__';
                if (KeyVal == 32) {
                    if (val == empty || val == '')
                        val = TodayS();
                    else
                        val = empty;
                    $(this).val(val); //.focus();
                    //return false; 
                };
                if (KeyVal == 13 && val == empty) {
                    $(this).val('');
                    return false;
                }
                return true;
            })
             .keyup(function (e) {
                 var cval = $(this).val();
                 var rg1 = new RegExp('/', 'g');
                 var rg2 = new RegExp('_', 'g');
                 var nval = cval.replace(rg1, '').replace(rg2, '');
                 if (nval.length == 6) {
                     if (ValidateDate(cval, '/')) {
                         $(this).css('background-color', 'white');
                         var jd = StrToJD(cval, '/');
                         var kv = GetKeyVal(e);
                         if (kv == 38)
                             jd.setDate(jd.getDate() + 1);
                         else if (kv == 40)
                             jd.setDate(jd.getDate() - 1);
                         var d = jd.getGregorianDate();
                         var maxDate = null, minDate = null;
                         if ((maxDate != null && d > maxDate) || (minDate != null && d < minDate)) {
                             err(this);
                             return false;
                         }
                         else {
                             if (kv == 38 || kv == 40)
                                 $(this).val(JDToStr(jd, '/')).focus();
                         }
                     }
                     else {
                         err(this);
                         return false;
                     }
                 }
                 return true;
             })
                .blur(function () {
                    var r = new RegExp(' ', 'g');
                    var a = $(this).css('background-color').replace(r, '');
                    if (a == '#fdcfc6' || a == 'rgb(253,207,198)') {
                        $(this).val('');
                        $(this).css('background-color', 'white');
                    }
                });
            var opts = {
                isRTL: true,
                dateFormat: 'yy/mm/dd',
                showOn: 'button',
                buttonImage: 'images/calendar.gif',
                buttonImageOnly: true,
                showAnim: 'slideDown'
            };
            $(a).datepicker(opts);
        })
    </script>
</head>
<body style="font-family:Tahoma; font-size:small;">
    <form id="form1" runat="server" style="font-size: 10pt; font-family: tahoma; text-align: center"
    dir="rtl" align="center">
    <br />
    <br />
    <br />
    <div>
        <table width="90%" align="center" style="font-family:tahoma">
            <tr>
                <td bgcolor="#990033" class="style3">
                    <asp:Label ID="Label60" runat="server" Text="سامانه پیگیری خدمات اینترنتی" Font-Bold="True"
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
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" font-family="tahoma" TextAlign="Right" Height="90px" OnSelectedIndexChanged="radioch" AutoPostBack="true">
                                        <asp:ListItem Text="شماره مشتری" Selected="True">
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
                                                <asp:TextBox ID="TextBox1" runat="server" Text="" TabIndex="1" MaxLength="8"
                                                    Font-Size="Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:TextBox ID="TextBox3" runat="server" Text="" TabIndex="3" MaxLength="16"
                                                    Font-Size="Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <table align="left">
                                                    <tr align="left">
                                                        <td align="left">
                                                            <asp:TextBox ID="TextBox6" runat="server" Text="" Style="text-align: left" Width="33px"
                                                                 TabIndex="6" MaxLength="3" Font-Size="Small"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox5" runat="server" Text="" TabIndex="5" MaxLength="8"
                                                                Font-Size="Small"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBox4" runat="server" Text="" Width="41px"  TabIndex="4"
                                                                MaxLength="3" Font-Size="Small"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button8" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA"
                                                                BorderColor="#D1C6BC" Text="جستجو" Font-Names="Tahoma" Height="28px" TabIndex="7"
                                                                OnClick="clk1" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button1" runat="server" BorderStyle="Solid" BorderWidth="2px" BackColor="#E5DDDA" font-family="tahoma"
                                                                BorderColor="#D1C6BC" Text="خروج" Font-Names="Tahoma" Height="28px" TabIndex="7"
                                                                OnClick="clk2" />
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
        <br />
        <br />
        <table align="right" style="margin-right: 50px">
            <tr>
                <td>
                    <asp:Label ID="Label42" runat="server" Text="نوع خدمات" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Visible="false" font-family="tahoma">
                        <asp:ListItem Value="0">لطفا انتخاب کنید</asp:ListItem>
                        <asp:ListItem Value="1">خدمات ویژه</asp:ListItem>
                        <asp:ListItem Value="2">اینترنت بانک</asp:ListItem>
                        <asp:ListItem Value="3">انتقال کارت به کارت</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label44" runat="server" Text="از تاریخ" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Visible="false" CssClass="DtPckr"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label45" runat="server" Text="تا تاریخ" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Visible="false" CssClass="DtPckr"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="clksch" runat="server" Text="نمایش" Visible="false" OnClick="dpch1" font-family="tahoma"/>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <table style="margin-right: 50px" align="center">
            <tr>
                <td>
                    <asp:MultiView ID="multuview1" runat="server">
                        <asp:View ID="view1" runat="server">
                            <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                Style="margin-right: 26px">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table border="1" align="center" cellpadding="7" width="1000">
                                                <tr align="center" style="text-align: right">
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="شماره مشتری" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("no") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text="نام" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("bc_nam") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text="نام خانوادگی" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("bc_family") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text="نام پدر" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("bc_pedar") %>'>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr align="center" style="text-align: right">
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" Text="جنسیت" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("bc_sex") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label11" runat="server" Text="تاریخ تولد" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("bc_dat") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" Text="شماره شناسنامه" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("bc_id") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label15" runat="server" Text="کدملی" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" Text='<%#Eval("bc_codmelli") %>'>'></asp:Label>
                                                    </td>
                                                    <tr align="center" style="text-align: right">
                                                        <td>
                                                            <asp:Label ID="Label17" runat="server" Text="شماره سریال شناسنامه" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label18" runat="server" Text='<%#Eval("bc_srl") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label19" runat="server" Text="محل تولد" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label20" runat="server" Text='<%#Eval("bc_plc") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label21" runat="server" Text="کدشعبه تعریف مشتری" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label22" runat="server" Text='<%#Eval("bc_cod") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label23" runat="server" Text="شغل" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label24" runat="server" Text='<%#Eval("job") %>'>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="center" style="text-align: right">
                                                        <td>
                                                            <asp:Label ID="Label25" runat="server" Text="تلفن" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label26" runat="server" Text='<%#Eval("phone") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label27" runat="server" Text="موبایل" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label28" runat="server" Text='<%#Eval("mobil") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label29" runat="server" Text="ایمیل" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label30" runat="server" Text='<%#Eval("email") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label31" runat="server" Text="فکس" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label32" runat="server" Text='<%#Eval("fax") %>'>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="center" style="text-align: right">
                                                        <td>
                                                            <asp:Label ID="Label33" runat="server" Text="آدرس" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td colspan="5">
                                                            <asp:Label ID="Label34" runat="server" Text='<%#Eval("adrs") %>'>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label35" runat="server" Text="کدپستی" ForeColor="Maroon"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label36" runat="server" Text='<%#Eval("zip") %>'>'></asp:Label>
                                                        </td>
                                                    </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="Label106" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                        </asp:View>
                        <asp:View ID="view2" runat="server">
                            <table style="text-align: right" cellpadding="7" align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text=" ip" Width="100"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label43" runat="server" Text="تاریخ ورود" Width="90"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label46" runat="server" Text="زمان ورود" Width="90"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label47" runat="server" Text=" زمان خروج" Width="90"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label95" runat="server" Text=" حساب مبدا" Width="110"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label96" runat="server" Text=" حساب مقصد" Width="170"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label97" runat="server" Text=" عملیات" Width="100"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="مشاهده جزییات" Width="100"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="Label56" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="gridview_khadamat" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                AllowPaging="true" PageSize="10" OnPageIndexChanging="grid_khadamat">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="text-align: right" cellpadding="7" align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label38" runat="server" Text='<%#Eval("ip_address") %>' Width="100"> '></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label39" runat="server" Text='<%#Eval("logind") %>' Width="90">'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label48" runat="server" Text='<%#Eval("logint") %>' Width="90"> '></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label49" runat="server" Text='<%#Eval("logoutt") %>' Width="90">'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label98" runat="server" Text='<%#Eval("source_dps") %>' Width="110">'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label99" runat="server" Text='<%#Eval("dest_account") %>' Width="170">'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label40" runat="server" Text='<%#Eval("service_type") %>' Width="100">'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btkhadamat" runat="server" Text="مشاهده صورتحساب" OnClick="clkkhesabhad" font-family="tahoma"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="gridview_int1" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                AllowPaging="true" PageSize="20" OnPageIndexChanging="gridview_int1_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="text-align: right" cellpadding="7" align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label37" runat="server" Width="120" Text='<%#Eval("ip") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label38" runat="server" Width="100" Text='<%#Eval("logind") %>'> '></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label39" runat="server" Width="100" Text='<%#Eval("logint") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label40" runat="server" Width="100" Text='<%#Eval("logoutt") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label157" runat="server" Width="120" Text='<%#Eval("mabda") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label158" runat="server" Width="120" Text='<%#Eval("maghsad") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label50" runat="server" Width="120" Text='<%#Eval("service") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button4" runat="server" Text="مشاده صورتحساب" OnClick="clkhesab1" font-family="tahoma" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="Button2" runat="server" Text="صفحه بعد" Visible="false" OnClick="pagesec"  font-family="tahoma"/>
                            <asp:Button ID="Button10" runat="server" Text="صفحه قبل" Visible="false" OnClick="pagefirs" font-family="tahoma" />
                        </asp:View>
                        <asp:View ID="view3" runat="server">
                            <table style="text-align: right" cellpadding="7" align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label57" runat="server" Text=" ip" Width="120"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label58" runat="server" Text="تاریخ ورود" Width="100"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label59" runat="server" Text="زمان ورود" Width="100"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label62" runat="server" Text=" زمان خروج" Width="100"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label92" runat="server" Text="حساب مبدا" Width="120"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label93" runat="server" Text=" حساب مقصد" Width="120"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label94" runat="server" Text="عملیات" Width="120"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label61" runat="server" Text="مشاهده جزییات"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="Label63" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="gridview_int2" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                AllowPaging="true" PageSize="20" OnPageIndexChanging="gridview_int2_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="text-align: right" cellpadding="7" align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label70" runat="server" Width="120" Text='<%#Eval("ip") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label71" runat="server" Width="100" Text='<%#Eval("logind") %>'> '></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label72" runat="server" Width="100" Text='<%#Eval("logint") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label73" runat="server" Width="100" Text='<%#Eval("logoutt") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label159" runat="server" Width="120" Text='<%#Eval("mabda") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label160" runat="server" Width="120" Text='<%#Eval("maghsad") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label75" runat="server" Width="120" Text='<%#Eval("service") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button5" runat="server" Text="مشاهده صورتحساب" OnClick="clkhesab2" font-family="tahoma"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="Button3" runat="server" Text="صفحه بعد" Visible="false" OnClick="pagethi" />
                            <asp:Button ID="Button11" runat="server" Text="صفحه قبل" Visible="false" OnClick="pagesec" />
                        </asp:View>
                        <asp:View ID="view4" runat="server">
                            <table style="text-align: right" cellpadding="7" align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label64" runat="server" Text=" ip" Width="120"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label65" runat="server" Text="تاریخ ورود" Width="100"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label66" runat="server" Text="زمان ورود" Width="100"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label68" runat="server" Text=" زمان خروج" Width="100"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label41" runat="server" Text=" حساب مبدا" Width="120"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label74" runat="server" Text=" حساب مقصد" Width="120"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label80" runat="server" Text=" عملیات" Width="120"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label67" runat="server" Text="مشاهده جزییات" Width="100"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="Label69" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="gridview_int3" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                AllowPaging="true" PageSize="20" OnPageIndexChanging="gridview_int3_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="text-align: right" cellpadding="7" align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label76" runat="server" Width="120" Text='<%#Eval("ip") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label77" runat="server" Width="100" Text='<%#Eval("logind") %>'> '></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label78" runat="server" Width="100" Text='<%#Eval("logint") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label79" runat="server" Width="100" Text='<%#Eval("logoutt") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Labellee" runat="server" Width="120" Text='<%#Eval("mabda")%>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Labelloo" runat="server" Width="120" Text='<%#Eval("maghsad") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label81" runat="server" Width="120" Text='<%#Eval("service") %>'>'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button6" runat="server" Text="مشاهده صورتحساب" OnClick="clkhesab3" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="Button12" runat="server" Text="صفحه قبل" Visible="false" OnClick="pagesec" />
                        </asp:View>
                        <asp:View ID="view5" runat="server">
                            <table style="text-align: right" cellpadding="7" align="center">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label89" runat="server" Width="150" Text="شماره کارت"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label91" runat="server" Text="انتخاب"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="text-align: right" cellpadding="7" align="center">
                                <tr>
                                    <td>
                                        <asp:GridView ID="gridview_card" runat="server" AutoGenerateColumns="false" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <table style="text-align: right" cellpadding="7" align="center">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label90" runat="server" Width="150" Text='<%#Eval("cdcardno") %>'>'></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="Button7" runat="server" Text="مشاهده" OnClick="clkcard" font-family="tahoma"/>
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
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Label ID="Label82" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:Panel ID="panel1" runat="server" Visible="false">
                                <table style="text-align: right" cellpadding="7" align="center">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label83" runat="server" Text=" ip" Width="170"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label84" runat="server" Text="تاریخ ورود" Width="170"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label85" runat="server" Text="زمان ورود" Width="170"></asp:Label>
                                        </td>
                                        <%--  <td>
                                            <asp:Label ID="Label86" runat="server" Text="تاریخ خروج" Width="170"></asp:Label>
                                        </td>--%>
                                        <td>
                                            <asp:Label ID="Label87" runat="server" Text=" زمان خروج" Width="170"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label54" runat="server" Text=" مشاهده جزییات" Width="170"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:GridView ID="gridview_pardakhtcard" runat="server" AutoGenerateColumns="false"
                                    GridLines="Both" AllowPaging="true" PageSize="10" OnPageIndexChanging="grid_card">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table style="text-align: right" cellpadding="7" align="center">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label51" runat="server" Text='<%#Eval("ip") %>' Width="170">'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label52" runat="server" Text='<%#Eval("strdat") %>' Width="170"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label53" runat="server" Text='<%#Eval("strtim") %>' Width="170">'></asp:Label>
                                                        </td>
                                                        <%-- <td>
                                                            <asp:Label ID="Label54" runat="server" Text='<%#Eval("enddat") %>' Width="170"></asp:Label>
                                                        </td>--%>
                                                        <td>
                                                            <asp:Label ID="Label55" runat="server" Text='<%#Eval("endtim") %>' Width="170">'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Button9" runat="server" Text="مشاهده صورتحساب" OnClick="soratcard" font-family="tahoma"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:Label ID="Label88" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>

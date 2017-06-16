<%@ Page Language="C#" AutoEventWireup="true"    EnableEventValidation = "false"   CodeFile="main.aspx.cs" Inherits="main" %>



<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
<body>
    <form id="form1" runat="server">
    <div id="d" runat="server">

    <br />
    <br />
    <br />

    <table  width="300" align="center" style="font-family:tahoma; font-size:small" >
    
    <tr>
    <td colspan="2"
     bgcolor="#990033" class="style3" align="center">
                    <asp:Label ID="Label60" runat="server" Text="مانده حسابها" Font-Bold="True" 
                        Font-Size="Medium" font-family="tahoma" ForeColor="White"></asp:Label>
               
    </td>
    </tr>

    <tr>
    
    <td colspan="2">
    <br />
    <br />
    </td>
    </tr>
    <tr>
    <td>
    

         <asp:TextBox ID="TextBox2" runat="server"  CssClass="DtPckr"></asp:TextBox>
    

    </td>
    <td>
        <asp:Label ID="Label4" runat="server" Text="مانده حسابها در تاریخ"></asp:Label>
    
    </td>
    
    </tr>


    <tr>
    <td colspan="2" align="center">
    <br />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
   
    </td>
    
    </tr>

    
    <tr>
    
    <td>

    
 <asp:ImageButton ID="imbtn" runat="server"  ImageUrl="~/exl.jpg"   OnClick="clk1"  Height="30px" Width="30px" BorderWidth="2px"/>

     
    </td>
    <td>
     <asp:Label ID="Label1" runat="server" Text="مشاهده بفرمت اکسل"></asp:Label>
    
    </td>
    </tr>


    <tr>
    <td>
    
    </td>
    <td>
    
    
    </td>
    
    </tr>
    </table>



 <asp:GridView ID="gridview1"  runat="server"  AutoGenerateColumns="false" GridLines="Both" BorderWidth="1"
 AllowPaging="true" PageSize="100" OnPageIndexChanging="gridindex">
  

                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table style="text-align: right" cellpadding="7" align="center">
                                                <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Width="50" Text='<%#Eval("dt") %>'></asp:Label>
                                                </td>
                                                    <td>
                                                        <asp:Label ID="Label38" runat="server" Text='<%#Eval("ac") %>' Width="80"> '></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label39" runat="server" Text='<%#Eval("shop") %>' Width="150">'></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label48" runat="server" Text='<%#Eval("tedad") %>' Width="50"> '></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label49" runat="server" Text='<%#Eval("mandeh") %>' Width="90">'></asp:Label>
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>


        <asp:Label ID="lbl1" runat="server" Text="Label"></asp:Label>


    </div>
    </form>
</body>
</html>

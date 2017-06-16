<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>سامانه ثبت برگ سپرده</title>
    <style type="text/css">
        .style5
        {
            width: 139px;
        }
        .style6
        {
            width: 114px;
        }
        .style7
        {
            width: 130px;
        }
    </style>
</head>
<body bgcolor="Silver">
    <form id="form1" runat="server" onload="frm_load" style="font-family: Tahoma; font-size: small">
    <div>
        <br />
        <br />
        <asp:Panel ID="panel_head" runat="server" Style="font-family: Tahoma; font-size: small">
            <table border="2" align="center" style="border: medium solid #970000;">
                <tr>
                    <td>
                        سامانه ثبت برگ سپرده
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <fieldset dir="rtl">
            <legend>مشخصات کاربر</legend>
            <table>
                <tr>
                    <td>
                        <div class="inner">
                            کد شعبه
                            <br />
                            <asp:Label ID="lbl_brcod" runat="server" Text="2"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div class="inner">
                            نام شعبه
                            <br />
                            <asp:Label ID="lbl_brname" runat="server" Text=""></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div class="inner">
                            کد کاربر
                            <br />
                            <asp:Label ID="lbl_usercod" runat="server" Text="3847"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div class="inner">
                            <br />
                            <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <asp:Panel ID="panel_reg_cheq" runat="server" Style="font-family: Tahoma; font-size: small">
            <fieldset dir="rtl">
                <legend>ثبت مشخصات چک</legend>
                <table align="center">
                    <tr>
                    
                        <td class="style7">
                            <div class="inner">
                                نوع برگ سپرده
                                <br />
                                <asp:DropDownList ID="drp_typ" runat="server" TabIndex="2">
                                    <asp:ListItem>
               برگ سپرده ریالی
                                    </asp:ListItem>
                                    <asp:ListItem>
                 برگ سپرده ارزی
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td class="style5">
                        </td>
                    </tr>
                    <tr>
                        
                        <td class="style7">
                            <div class="inner">
                                از سریال
                                <br />
                                <asp:TextBox ID="txt_from_seri" runat="server" MaxLength="10" Width="120px" TabIndex="4"></asp:TextBox>
                            </div>
                        </td>
                        <td class="style5">
                            <div class="inner">
                                تا سریال
                                <br />
                                <asp:TextBox ID="txt_ta_seri" runat="server" MaxLength="10" Width="120px" TabIndex="5"></asp:TextBox>
                            </div>
                        </td>
                    </tr>



                    <tr>
                        
                        <td class="style7">
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="RangeValidator"
                                ControlToValidate="txt_from_seri" MaximumValue="9999999999" MinimumValue="100000"
                                Display="Dynamic" ValidationGroup="reg" SetFocusOnError="True" Type="Double">شماره سریال حداقل 6 رقم و حداکثر 10 رقم می باشد</asp:RangeValidator>
                        </td>
                        <td class="style5" >
                            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="RangeValidator"
                                ControlToValidate="txt_ta_seri" MaximumValue="9999999999" MinimumValue="100000" Display="Dynamic"
                                ValidationGroup="reg" Type="Double">شماره سریال حداقل 6 رقم و حداکثر 10 رقم می باشد</asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                  <td class="style7">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
                                Display="Dynamic" ValidationGroup="reg" SetFocusOnError="True" ControlToValidate="txt_from_seri">شماره سریال نمی تواند خالی باشد</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
                                Display="Dynamic" ValidationGroup="reg" SetFocusOnError="True" ControlToValidate="txt_ta_seri">شماره سریال نمی تواند خالی باشد</asp:RequiredFieldValidator>
                        </td>
                    
                    </tr>
                    <tr>
                        <td class="style7">
                            <div class="inner">
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="ثبت گواهی سپرده" OnClick="reg_cheq"
                                    ValidationGroup="reg" />
                            </div>
                        </td>
                       
                        <td class="style5">
                            <div class="inner">
                                <br />
                                <asp:Button ID="Button2" runat="server" Text="مشاهده برگ سپرده های ثبت شده و تخصیص برگ سپرده"
                                    OnClick="allocate_cheque" Width="255px" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div class="inner">
                                <br />
                                <asp:Label ID="lbl_result" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            <div class="inner">
                                <br />
                                <asp:Button ID="btn_bale" runat="server" Text="بله"  OnClick="clk_bale" Visible="false"/>
                            </div>
                        </td>
                        <td class="style5">
                            <div class="inner">
                                <br />
                                <asp:Button ID="btn_kheir" runat="server" Text="خیر" OnClick="clk_kheir" Visible="false" />
                            </div>
                        </td>
                           </tr>
                        <tr>
                        
                     
                        <td colspan="2">
                        <div class="inner">
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <br />
        <table dir="rtl" align="center" style="font-family: Tahoma; font-size: small">
            <tr>
                <td align="center">
                    <asp:Panel ID="panel_view_cheques" runat="server" Visible="false" Style="font-family: Tahoma;
                        font-size: small">
                        <fieldset dir="rtl">
                            <legend>مشاهده برگ سپرده های ثبت شده</legend>
                            <table>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <div class="inner">
                                            نوع برگ سپرده
                                            <br />
                                            <asp:DropDownList ID="drp_kind" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drp_kind_ch">
                                                <asp:ListItem>
               برگ سپرده ریالی
                                                </asp:ListItem>
                                                <asp:ListItem>
                 برگ سپرده ارزی
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="inner">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div class="inner">
                                            <br />
                                            <asp:Button ID="Button3" runat="server" Text="مشاهده" OnClick="view_chs" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <asp:GridView ID="gridviewcheques" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                    GridLines="Vertical" OnRowDeleting="gridviewcheques_delrow" OnSelectedIndexChanged="gridviewcheques_edt"
                                    OnClientClick="return BtnDeleteBaseInfo_Clicked()">
                                    <RowStyle BackColor="#F7F7DE" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="شناسه">
                                            <ItemStyle Font-Bold="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="typ" HeaderText="نوع برگ سپرده">
                                            <HeaderStyle Font-Bold="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="from_seri" HeaderText="از سریال">
                                            <HeaderStyle Font-Bold="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="to_seri" HeaderText="تا سریال">
                                            <HeaderStyle Font-Bold="False" />
                                        </asp:BoundField>
                                        <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/Delete.JPG"
                                            HeaderText="حذف">
                                            <HeaderStyle Font-Bold="False" />
                                            <ItemStyle BackColor="#EADFDB" />
                                        </asp:CommandField>
                                        <asp:CommandField SelectText="مشاهده" ShowSelectButton="True" ButtonType="Image"
                                            SelectImageUrl="~/images/edit.JPG" HeaderText="مشاهده ">
                                            <HeaderStyle Font-Bold="False" />
                                            <ItemStyle BackColor="#EADFDB" />
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#F7F7DE" Font-Bold="True" ForeColor="Black" />
                                    <HeaderStyle BackColor="#990033" Font-Bold="False" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </div>
                            <div class="inner">
                                <br />
                                <asp:Label ID="lbl_show_res" runat="server" Text=""></asp:Label>
                            </div>
                            <div>
                                <br />
                                <asp:GridView ID="grid_extract_cheq" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                    GridLines="Vertical" OnSelectedIndexChanged="grid_extract_cheq_edt" AllowPaging="true"
                                    PageSize="20" OnPageIndexChanging="grid_extract_cheq_paging">
                                    <RowStyle BackColor="#F7F7DE" />
                                    <Columns>
                                        <asp:BoundField DataField="id_per_chequ" HeaderText="شناسه">
                                            <ItemStyle Font-Bold="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="from_seri" HeaderText="از سریال">
                                            <HeaderStyle Font-Bold="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="allocate" HeaderText="واگذارشده">
                                            <HeaderStyle Font-Bold="False" />
                                        </asp:BoundField>
                                        <asp:CommandField SelectText="تخصیص دسته چک" ShowSelectButton="True" ButtonType="Image"
                                            SelectImageUrl="~/images/edit.JPG" HeaderText="تخصیص برگ سپرده">
                                            <HeaderStyle Font-Bold="False" />
                                            <ItemStyle BackColor="#EADFDB" />
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#F7F7DE" Font-Bold="True" ForeColor="Black" />
                                    <HeaderStyle BackColor="#990033" Font-Bold="False" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </div>
                        </fieldset>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="panel_allocate" runat="server" Visible="false" Style="font-family: Tahoma;
                        font-size: small">
                        <fieldset dir="rtl">
                            <legend>تخصیص چک</legend>
                            <table align="center">
                                <tr>
                                    <td>
                                        <div class="inner">
                                            شماره حساب
                                            <br />
                                            <table align="left">
                                                <tr align="left">
                                                    <td align="left">
                                                        <asp:TextBox ID="txtfirst" runat="server" Text="" Style="text-align: left" Width="33px"
                                                            Height="18px" TabIndex="8" MaxLength="3" Font-Size="Small"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtmid" runat="server" Text="" Height="18px" TabIndex="7" MaxLength="8"
                                                            Font-Size="Small"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtlast" runat="server" Text="" Width="41px" Height="18px" TabIndex="6"
                                                            MaxLength="3" Font-Size="Small"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="inner">
                                            <br />
                                            <asp:LinkButton ID="linkbtn" runat="server" Text="" OnClick="linkclk">کنترل صاحب حساب</asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="inner">
                                            <br />
                                            <asp:Label ID="lbl_showname" runat="server" Text=""></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div class="inner">
                                            <br />
                                            <asp:Button ID="Button4" runat="server" Text="ثبت" OnClick="clkreg_acnt" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="inner">
                                            <br />
                                            <asp:Label ID="lbl_reg_acnt" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <asp:GridView ID="gr_allocatd" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                                                GridLines="Vertical" OnRowDeleting="gr_allocatd_delrow" AllowPaging="true" PageSize="5"
                                                OnPageIndexChanging="gr_allocatd_paging">
                                                <RowStyle BackColor="#F7F7DE" />
                                                <Columns>
                                                    <asp:BoundField DataField="id_per_chequ" HeaderText="شناسه">
                                                        <ItemStyle Font-Bold="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="typ" HeaderText="نوع برگ سپرده">
                                                        <HeaderStyle Font-Bold="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="from_seri" HeaderText="سریال">
                                                        <HeaderStyle Font-Bold="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="nam" HeaderText="نام صاحب حساب">
                                                        <HeaderStyle Font-Bold="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="acnt_number" HeaderText="شماره حساب">
                                                        <HeaderStyle Font-Bold="False" />
                                                    </asp:BoundField>
                                                    <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/images/Delete.JPG"
                                                        HeaderText="حذف">
                                                        <HeaderStyle Font-Bold="False" />
                                                        <ItemStyle BackColor="#EADFDB" />
                                                    </asp:CommandField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#F7F7DE" Font-Bold="True" ForeColor="Black" />
                                                <HeaderStyle BackColor="#990033" Font-Bold="False" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
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

        function BtnDeleteBaseInfo_Clicked() {
            var result = confirm('آیا مطمئن هستید؟');
            return result;
        }
       

    </script>
</body>
</html>

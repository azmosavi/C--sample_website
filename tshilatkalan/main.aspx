<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
<body>
    <form id="form1" runat="server" class="style1" width="90%">
    <div>
        <br />
        <br />
        <table class="style1" align="right" style="font-family: tahoma; font-size: small;
            border-color: Maroon;" border="1" cellpadding="5" cellspacing="5">
            <tr>
                <td bgcolor="#990033" colspan="2" height="50" align="center">
                    <asp:Label ID="Label107" runat="server" Font-Bold="False" Font-Names="Tahoma" Font-Size="Medium"
                        Font-Underline="False" ForeColor="White" Text="سامانه الکترونیکی تسهیلات و تعهدات کلان "></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" style="color: Maroon;">
                    <asp:Panel ID="Panel1" runat="server" BackColor="#F7EAF3">
                        <asp:TreeView ID="TreeView1" runat="server" class="style1" Font-Names="tahoma" Font-Size="Small"
                            ForeColor="Maroon" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" BackColor="#F7EAF3">
                            <Nodes>
                                <asp:TreeNode Text="گروه">
                                    <asp:TreeNode Text=" تعریف گروه جدید"></asp:TreeNode>
                                    <asp:TreeNode>
                                        <asp:TreeNode Text="تعریف گروه حقیقی" Target="_self" Value="hagh"></asp:TreeNode>
                                        <asp:TreeNode Text="تعریف گروه حقوقی" Target="_self" Value="hogh"></asp:TreeNode>
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="زیرگروه">
                                    <asp:TreeNode Text="تعریف زیرگروه جدید" Target="_self" Value="subgr"></asp:TreeNode>
                                    <asp:TreeNode Text="تعریف اشخاص مرتبط" Target="_self" Value="ashkhasmortabet"></asp:TreeNode>
                                    <asp:TreeNode Text="تعریف شماره مشتریهای تکراری" Target="_self" Value="sabtid"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="مشاهده، ویرایش و حذف">
                                    <asp:TreeNode Text="  مشاهده، ویرایش و حذف مشخصات گروه و زیرگروه" Target="_self" Value="viraiesh">
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="گزارش گیری">
                                    <asp:TreeNode Text="گزارش گیری تسهیلاتی جدول شماره یک" Target="_self" Value="jad1">
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                 <asp:TreeNode Text="خروج" Target="_self" Value="khorooj">
                                    
                                </asp:TreeNode>

                            </Nodes>
                        </asp:TreeView>
                    </asp:Panel>
                </td>
                <td width="600">
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="view1" runat="server">
                            <fieldset>
                                <legend align="right">تعریف گروه حقیقی</legend>
                                <table cellpadding="5">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="نام گروه"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Textgrnam" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="Dropiscust" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chdrop1">
                                                <asp:ListItem>
                                       شماره مشتری وجود دارد
                                                </asp:ListItem>
                                                <asp:ListItem>
                                        شماره مشتری وجود ندارد
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Textcustidhagh" runat="server" Visible="false"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button5" runat="server" Text="بازیابی" OnClick="clk1_baziabi" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="grinthagh" Visible="false" runat="server">
                                    <table cellpadding="5">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="نام مشتری"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Texthaghname" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="نام خانوادگی"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Texthaghfamilyname" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="شماره شناسنامه"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Texthaghid" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="نام پدر"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Texthaghpedar" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="محل تولد"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Texthaghbc" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="کد ملی"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Texthaghcodmeli" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label20" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="ذخیره" OnClick="clk1save" />
                                            </td>
                                            <td colspan="4">
                                                <asp:Button ID="Button16" runat="server" Text="تعریف گروه جدید" OnClick="newgrhagh" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="color: #FF0000">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label36" runat="server" Visible="false" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label10" Visible="false" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label87" runat="server" Visible="false" Text="است"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="color: #FF0000">
                                                <asp:Label ID="Label108" runat="server" Visible="false" Text="اسم گروه را وارد نمایید"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="grcomplete" runat="server" Visible="false">
                                    <table cellpadding="5" align="center" style="color: #FF0000">
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Label ID="Label52" runat="server" Text="گروه با مشخصات زیر تشکیل شد:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label1" runat="server" Text="کد گروه" Width="50"></asp:Label>
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="Label51" runat="server" Text="نام گروه" Width="100"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label53" runat="server" Width="50" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label54" runat="server" Width="100" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <br />
                                <br />
                                <asp:Panel ID="sabtcustidhagh" runat="server" Visible="false">
                                    <fieldset>
                                        <table>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="Label96" runat="server" Text="ثبت سایر شماره مشتریها"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label88" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBox38" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label95" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button18" runat="server" Text="ثبت" OnClick="sabtcustidhaghigh" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </asp:Panel>
                            </fieldset>
                        </asp:View>
                        <asp:View ID="view2" runat="server">
                            <fieldset>
                                <legend align="right">تعریف گروه حقوقی</legend>
                                <table cellpadding="5" width="600">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="نام گروه"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chdrop2">
                                                <asp:ListItem>
                                       شماره مشتری وجود دارد
                                                </asp:ListItem>
                                                <asp:ListItem>
                                        شماره مشتری وجود ندارد
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label72" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button6" runat="server" Text="بازیابی" OnClick="clk2_baziabi" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="grinthogh" Visible="false" runat="server">
                                    <table cellpadding="5">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text="نام شرکت"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text="شماره ثبت"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label15" runat="server" Text="تاریخ ثبت"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text="محل ثبت"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text="نوع شرکت"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="دفتر مرکزی"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" Text="کد اقتصادی"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label21" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button2" runat="server" Text="ذخیره" OnClick="clk2save" />
                                            </td>
                                            <td>
                                                <asp:Button ID="Button20" runat="server" Text="تعریف گروه جدید" OnClick="newgrhogh" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="color: #FF0000">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label111" runat="server" Visible="false" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label112" Visible="false" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label113" runat="server" Visible="false" Text="است"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="color: #FF0000">
                                                <asp:Label ID="Label114" runat="server" Visible="false" Text="اسم گروه را وارد نمایید"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:Panel ID="grcompletehogh" runat="server" Visible="false" align="center" style="color: #FF0000">
                                    <table cellpadding="5" align="center" style="color: #FF0000">
                                        <tr>
                                            <td colspan="2" align="center" style="color: #FF0000">
                                                <asp:Label ID="Label55" runat="server" Text="گروه با مشخصات زیر تشکیل شد:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="color: #FF0000">
                                                <asp:Label ID="Label56" runat="server" Text="کد گروه" Width="50"></asp:Label>
                                            </td>
                                            <td align="center" style="color: #FF0000">
                                                <asp:Label ID="Label57" runat="server" Text="نام گروه" Width="100"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                   
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label58" runat="server" Width="50" Text="" ></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label59" runat="server" Width="100" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                
                                </asp:Panel>
                            </fieldset>
                        </asp:View>
                        <asp:View ID="view3" runat="server">
                            <br />
                            <table width="600" align="center"  >
                                <tr>
                                    <td>
                                        <fieldset>
                                            <legend align="right"></legend>
                                            <br />
                                            <br />
                                            <table align="center" >
                                            <tr>
                                            <td colspan="4">
                                            
                                            
                                            </td>
                                                <asp:Label ID="labelcaption_total" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                            
                                            </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label35" runat="server" Text="نام گروه"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="drop3ch"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label23" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="viewgr" runat="server" Text="دیدن مشخصات گروه" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TreeView ID="TreeViewsubgr" runat="server" PopulateNodesFromClient="true" ShowLines="true"
                                                            ShowExpandCollapse="true" MaxDataBindDepth="2" OnTreeNodePopulate="treeView1_TreeNodePopulate"
                                                            OnSelectedNodeChanged="trch" OnTreeNodeExpanded="trexpand">
                                                        </asp:TreeView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <br />
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Panel ID="relationpanel" Visible="false" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label32" runat="server" Text="نوع رابطه"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="drop4ch"
                                                                            AutoPostBack="true">
                                                                            <asp:ListItem>
                                    
                                    
                                                                            </asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label73" runat="server" Text="نوع زیررابطه"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="drop5ch"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Panel ID="mortabetrelation" runat="server" Visible="false">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="DropDownList8" runat="server" OnSelectedIndexChanged="drop8ch"
                                                                            AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <br />
                                                      
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                           
                                            <table align="center" >
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="confsabtid" runat="server" Visible="false" align="center" 
                                                            dir="rtl"  BorderColor="Maroon" BorderStyle="Solid" 
                                                            BorderWidth="1px" Direction="RightToLeft">

                                                            <table dir="rtl" align="center"  BorderColor="Maroon" BorderStyle="Solid" 
                                                            BorderWidth="1px" >
                                                    
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label103" runat="server" Text="شما در حال تعریف شماره مشتری برای "></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label104" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label121" runat="server" Text="می باشید. "></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label110" runat="server" Text="آیا مطمئن هستید؟"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="Button22" runat="server" Text="بلی" OnClick="sabtcustomerid" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="Button23" runat="server" Text="خیر" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td align="center" dir="rtl">
                                                        <asp:Panel ID="confsub_gr" runat="server" Visible="false" align="center" 
                                                            dir="rtl"  BorderColor="Maroon" BorderStyle="Solid" 
                                                            BorderWidth="1px" Direction="RightToLeft">

                                                            <table dir="rtl" align="center"  BorderColor="Maroon" BorderStyle="Solid" 
                                                            BorderWidth="1px" >
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="Label74" runat="server" Text="شما در حال تعریف زیرگروه برای "></asp:Label>
                                                                        <asp:Label ID="Label75" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                  
                                       </tr>

                                                                      <tr dir="rtl" align="right" >
                                                                    <td  dir="rtl" align="right" colspan="2">
                                                                        <asp:Label ID="Label76" runat="server" Text="بارابطه"></asp:Label>
                                                                        <asp:Label ID="Label77" runat="server" Text=""></asp:Label>
                                                                        <asp:Label ID="Label78" runat="server" Text="و زیر رابطه"></asp:Label>
                                                                        <asp:Label ID="Label79" runat="server" Text=""></asp:Label>
                                                                         <asp:Label ID="Label97" runat="server" Text="می باشید. "></asp:Label>
                                                                        <asp:Label ID="Label98" runat="server" Text="آیا مطمئن هستید؟"></asp:Label>
                                                                    </td>
                                                                   
                                                                   
                                                                    </tr>
                
                                                                     <tr>
                                                                    <td >
                                                                        <asp:Button ID="Button9" runat="server" Text="بلی" OnClick="sub_baleh" />
                                                                    </td>
                                                                    <td >
                                                                        <asp:Button ID="Button10" runat="server" Text="خیر" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td>
                                                        <asp:Panel ID="sabtid" runat="server" Visible="false">
                                                            <table align="center" >
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label105" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="TextBox39" runat="server" Text=""></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label106" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="Button24" runat="server" Text="ثبت" OnClick="dosabt" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                <td colspan="4">
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="clklinkbtn" Font-Underline="False">کنترل شماره مشتری</asp:LinkButton>
                                                                </td>
                                                                </tr>
                                                                  <tr>
                                                                <td colspan="4">
                                                                    <asp:Label ID="Label116" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                </tr>
                                                                <tr>
                                                                <td colspan="4">
                                                                    <asp:Label ID="Label80" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="Panelmortabetcof" runat="server" Visible="false" align="center" 
                                                            dir="rtl"  BorderColor="Maroon" BorderStyle="Solid" 
                                                            BorderWidth="1px" Direction="RightToLeft">

                                                            <table dir="rtl" align="center"  BorderColor="Maroon" BorderStyle="Solid" 
                                                            BorderWidth="1px" >
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label971" runat="server" Text="شما در حال تعریف اشخاص مرتبط برای "></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label981" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label99" runat="server" Text="بارابطه"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label100" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label1031" runat="server" Text="می باشید. "></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label1041" runat="server" Text="آیا مطمئن هستید؟"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="Button19" runat="server" Text="بلی" OnClick="sub_baleh" />
                                                                    </td>
                                                                    <td colspan="3">
                                                                        <asp:Button ID="Button21" runat="server" Text="خیر" />
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                                    </td>
                                                </tr>
                                              
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="panelsubgr" runat="server" Visible="false">
                                                            <fieldset ID="f1" runat="server" Width="600">
                                                                <legend align="right" ></legend>
                                                                <table align="center">
                                                              <tr>
                                                              <td>
                                                              
                                                                  <asp:Label ID="labelcaption_hagh" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                              </td>
                                                              </tr>

                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="subgriscusthagh" runat="server" Visible="false" Width="600">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td colspan="4">
                                                                                            <asp:Label ID="Label44" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="true" 
                                                                                                OnSelectedIndexChanged="drp6ch">
                                                                                                <asp:ListItem>
                                       شماره مشتری وجود دارد
                                                                                                </asp:ListItem>
                                                                                                <asp:ListItem>
                                        شماره مشتری وجود ندارد
                                                                                                </asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="Textcustidsub" runat="server" Enabled="true" Visible="false"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label25" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="Button3" runat="server" OnClick="clk3_baziabi" Text="بازیابی" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="subgrinthagh" runat="server" Visible="false" Width="600">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label26" runat="server" Text="نام مشتری" Width="70"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox20" runat="server" Width="110px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label27" runat="server" Text="نام خانوادگی" Width="100"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox21" runat="server" Width="110px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label28" runat="server" Text="شماره شناسنامه" Width="100"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox22" runat="server" Width="70px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label29" runat="server" Text="نام پدر" Width="70"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox23" runat="server" Width="110px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label30" runat="server" Text="محل تولد" Width="70"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox24" runat="server" Width="110px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label31" runat="server" Text="کد ملی" Width="80"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox25" runat="server" Width="70px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                    <td >
                                                                                        <asp:Label ID="sahmtext" runat="server" Text="درصد سهم" Visible="false"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="sahmprc" runat="server" Visible="false"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="3">
                                                                                    
                                                                                    </td>
                                                                                    
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label33" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="Button8" runat="server" OnClick="clk3save" Text="ذخیره" />
                                                                                        </td>
                                                                                        <td colspan="3">
                                                                                            <asp:Label ID="Labelerr" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </asp:Panel>
                                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="subgrcomplete" runat="server" align="center" 
                                            style="color: #FF0000" Visible="false">
                                            <table align="center" cellpadding="5" style="color: #FF0000">
                                                <tr align="center">
                                                    <td colspan="3">
                                                        <asp:Label ID="Label64" runat="server" Text="زیر گروه با مشخصات زیر تشکیل شد:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td align="center">
                                                        <asp:Label ID="Label65" runat="server" Text="نام زیر گروه"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="labelnamgr" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="Label63" runat="server" Text="کد زیرگروه"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td colspan="3">
                                                        <table align="center">
                                                            <tr align="center">
                                                                <td>
                                                                    <asp:Label ID="Label84" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label85" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label86" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Button27" runat="server" OnClick="clknewsubgr" 
                                                            Text="تعریف زیرگروه جدید" Visible="false" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button7" runat="server" OnClick="clklinkrel" 
                                                            Text="تعریف اشخاص مرتبط" />
                                                    </td>
                                                    <td>
                                                     <asp:Button ID="Button28" runat="server" OnClick="clklinkcustid" 
                                                            Text="تعریف شماره مشتری متعدد" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: #FF0000">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label101" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label102" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label109" runat="server" Text="است" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panelsubgr1" runat="server" Visible="false">
                                            <fieldset>
                                                <legend align="right"></legend>
                                                <br />
                                                <table>
                                          <tr>
                                                              <td>
                                                              
                                                                  <asp:Label ID="labelcaption_hogh" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                              </td>
                                                              </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="subgriscusthogh" runat="server" Visible="false">
                                                                <table>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Label ID="Label45" runat="server" Text=" "></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="true" 
                                                                                OnSelectedIndexChanged="drp7ch">
                                                                                <asp:ListItem>
                                       شماره مشتری وجود دارد
                                                                                                </asp:ListItem>
                                                                                <asp:ListItem>
                                        شماره مشتری وجود ندارد
                                                                                                </asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Textcustidhogh" runat="server" Enabled="true" Visible="false"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label46" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="Button11" runat="server" OnClick="clk4_baziabi" 
                                                                                Text="بازیابی" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="subgrinthogh" runat="server" Visible="false">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label22" runat="server" Text="نام شرکت"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label24" runat="server" Text="شماره ثبت"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label37" runat="server" Text="تاریخ ثبت"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label38" runat="server" Text="محل ثبت"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label39" runat="server" Text="نوع شرکت"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox29" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label40" runat="server" Text="دفتر مرکزی"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox30" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label41" runat="server" Text="کد اقتصادی"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="TextBox31" runat="server"></asp:TextBox>
                                                                        </td>

                                                                         <td >
                                                                                        <asp:Label ID="sahmprc_hogh" runat="server" Text="درصد سهم" Visible="false"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="sahmtext_hogh" runat="server" Visible="false"></asp:TextBox>
                                                                                    </td>


                                                                       
                                                                        <td colspan="2">
                                                                        
                                                                        </td>
                                                                        
                                                                        </tr>
                                                                        <tr>
                                                                         <td>
                                                                            <asp:Label ID="Label42" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="Button4" runat="server" OnClick="clk4save" Text="ذخیره" />
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:Label ID="Labelerrhogh" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                        </td>
                                                                        <%-- <td>
                                                                                            <asp:Button ID="Button17" runat="server"  Visible="false" Text="تعریف زیر گروه حقوقی جدید" />
                                                                                        </td>--%>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="panelreport" runat="server" align="center" BorderColor="Maroon" 
                                            BorderStyle="Solid" BorderWidth="1px" dir="rtl" Direction="RightToLeft" 
                                            Visible="false">
                                            <table align="center" BorderColor="Maroon" BorderStyle="Solid" 
                                                BorderWidth="1px" dir="rtl">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label81" runat="server" Text=" گزارش گیری تسهیلاتی"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label115" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button ID="Button17" runat="server" OnClick="rep_jad1" Text="دیدن گزارش" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                                </table>
                                                
                                                
                                            <br />
                                            <br />
                                            <br />
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="view4" runat="server">
                            <table width="600" align="center" >
                                <tr>
                                    <td>
                                        <fieldset>
                                            <legend align="right">مشاهده، ویرایش و حذف مشخصات گروه و زیرگروه</legend>
                                            <br />
                                            <br />
                                            <table align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label34" runat="server" Text="نام گروه"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="drop1ch"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TreeView ID="TreeViewedit" runat="server" PopulateNodesFromClient="true" ShowLines="true"
                                                            ShowExpandCollapse="true" MaxDataBindDepth="2" OnTreeNodePopulate="treeView2_TreeNodePopulate"
                                                            OnSelectedNodeChanged="trch2">
                                                        </asp:TreeView>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                            <br />
                                            <table align="center">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="Panel2" runat="server"  align="center" 
                                                            dir="rtl"  BorderColor="Maroon" BorderStyle="Solid" 
                                                            BorderWidth="1px" Direction="RightToLeft" >
                                                           
                                                            <table dir="rtl" align="center"  BorderColor="Maroon" BorderStyle="Solid" 
                                                            BorderWidth="1px" >
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label48" runat="server" Text="شما در حال مشاهده و ویرایش "></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label49" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label66" runat="server" Text="می باشید. "></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label67" runat="server" Text="آیا مطمئن هستید؟"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="Button14" runat="server" Text="بلی" OnClick="clkviewgr" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="Button15" runat="server" Text="خیر" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="panel5" runat="server" Visible="false">
                                                            <fieldset>
                                                  
                                                                  <legend align="right">مشاهده و ویرایش شخص حقیقی</legend>
                                                                <table align="center">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="Paneledithagh" runat="server"  Visible="false">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label89" runat="server" Text="نام مشتری"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label90" runat="server" Text="نام خانوادگی"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label50" runat="server" Text="شماره مشتری"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label91" runat="server" Text="شماره شناسنامه"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label92" runat="server" Text="نام پدر"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label93" runat="server" Text="محل تولد"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label94" runat="server" Text="کد ملی"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label43" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="Button13" runat="server" Text="ذخیره" OnClick="clk5save" />
                                                                                        </td>
                                                                                        <td>
                                                                                        <asp:Button ID="Button25" runat="server" Text="حذف" OnClick="clkdel" />
                                                                                        </td>
                                                                                        <td >
                                                                                            <asp:Label ID="Label47" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="panel8" runat="server" Visible="false">
                                                            <fieldset>
                                                                <legend align="right">مشاهده و ویرایش شخص حقوقی</legend>
                                                                <table align="center">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="Paneledithogh" runat="server" Visible="false">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label60" runat="server" Text="نام شرکت"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label83" runat="server" Text="شماره مشتری"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox37" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label61" runat="server" Text="شماره ثبت"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label62" runat="server" Text="تاریخ ثبت"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox32" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label68" runat="server" Text="محل ثبت"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox33" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label69" runat="server" Text="نوع شرکت"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox34" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="Label70" runat="server" Text="دفتر مرکزی"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox35" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label71" runat="server" Text="کد اقتصادی"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TextBox36" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td colspan="2">
                                                                                            <asp:Label ID="Label82" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                       
                                                                                        </tr>
                                                                                         <tr>
                                                                                        
                                                                                        <td>
                                                                                            <asp:Button ID="Button12" runat="server" Text="ذخیره" OnClick="clk6save" />
                                                                                        </td>
                                                                                        <td>
                                                                                           <asp:Button ID="Button26" runat="server" Text="حذف" OnClick="clkdel2" />
                                                                                        </td>
                                                                                        <td colspan="4">
                                                                                        
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </fieldset>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="panel9" runat="server" Visible="false" align="center">
                                                            <table align="center" >
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Label ID="labeleditcom" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

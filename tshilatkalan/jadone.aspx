<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jadone.aspx.cs" Inherits="jadone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" dir="rtl" align="center" class="style1" style="font-family: tahoma;
    font-size: small">
    <div>
        <br />
        <br />
        <br />
        <table width="700">
            <tr>
                <td>
                    <table width="700">
                        <tr>
                            <td>
                                <asp:Label ID="Label49" runat="server" Text="نام مشتری"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label50" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label51" runat="server" Text="" Width="350"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label52" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label53" runat="server" Text="نام شعبه"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label54" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label55" runat="server" Text="شماره مشتری"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label56" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label57" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label58" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label59" runat="server" Text="کد شعبه"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label60" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label61" runat="server" Text="جدول شماره یک"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label62" runat="server" Text="" Width="20"></asp:Label>
                            </td>
                            <td>
                                <table align="center" width="150">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label63" runat="server" Text=" خالص تسهیلات در تاریخ "></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:Label ID="Label64" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label65" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label66" runat="server" Text="ارقام به میلیون ریال"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1" dir="rtl" align="right" style="font-family: tahoma; font-size: small"
                        border="1" cellpadding="5" cellspacing="5" width="700">
                        <tr>
                            <td>
                                <asp:Label ID="Label41" runat="server" Text="ردیف"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label42" runat="server" Text="نوع تسهیلات"></asp:Label>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label43" runat="server" Text="(1)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label44" runat="server" Text="مانده بدهی تسهیلات"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label45" runat="server" Text="(2)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label46" runat="server" Text="کسر می شود"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label47" runat="server" Text="(3)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label48" runat="server" Text="مانده خالص تسهیلات"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="فروش اقساطی مواد اولیه، لوازم یدکی و ابزار کار"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="2"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="فروش اقساطی ماشین آلات، تاسیسات و وسایل تولید"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="3"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="سلف"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="4"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="مشارکت مدنی"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label19" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="5"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="مضاربه"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label23" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label25" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" Text="6"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label27" runat="server" Text="اجاره به شرط تملیک"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label28" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label29" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label30" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label31" runat="server" Text="7"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label32" runat="server" Text="جعاله"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label33" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label34" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label35" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label36" runat="server" Text="8"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label37" runat="server" Text="خرید دین"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label38" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label39" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label40" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label77" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label78" runat="server" Text="جمع تسهیلات جاری"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label79" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label80" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label81" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label82" runat="server" Text="9"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label83" runat="server" Text="بدهکاران بابت ضمانتنامه های پرداخت شده"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label84" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label85" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label86" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label87" runat="server" Text="10"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label88" runat="server" Text="بدهکاران بابت اعتبارات اسنادی پرداخت شده"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label89" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label90" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label91" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label92" runat="server" Text="11"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label93" runat="server" Text="مطالبات سررسید گذشته"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label94" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label95" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label96" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label97" runat="server" Text="12"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label98" runat="server" Text="مطالبات معوق"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label99" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label100" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label101" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label102" runat="server" Text="13"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label103" runat="server" Text="مطالبات مشکوک الوصول"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label104" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label105" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label106" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label67" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label68" runat="server" Text="جمع تسهیلات غیرجاری"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label69" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label70" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label71" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label72" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label73" runat="server" Text="جمع کل تسهیلات جاری و غیر جاری"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label74" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label75" runat="server" Text="0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label76" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table width="700">
            <tr>
                <td>
                    <table width="700">
                        <tr>
                            <td>
                                <asp:Label ID="Label107" runat="server" Text="جدول شماره دو"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label109" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label108" runat="server" Text="خالص تعهدات تبدیل شده در تاریخ"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label110" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label111" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label112" runat="server" Text="ارقام به میلیون ریال"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="style1" dir="rtl" align="right" style="font-family: tahoma; font-size: small"
                        border="1" cellpadding="5" cellspacing="5" width="700">
                        <tr>
                            <td>
                                <asp:Label ID="Label113" runat="server" Text="ردیف"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label114" runat="server" Text="نوع تعهدات"></asp:Label>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label115" runat="server" Text="(1)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label116" runat="server" Text="مانده ناخالص تعهدات"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label117" runat="server" Text="(2)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label118" runat="server" Text="کسر می شود"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                         <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label119" runat="server" Text="(3)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label120" runat="server" Text="مانده خالص تعهدات"></asp:Label>
                                    </td>
                                </tr>
                            </table>


                         </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label121" runat="server" Text="(4)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label122" runat="server" Text="ضرایب تبدیل"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>

                                 <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label123" runat="server" Text="(5)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label124" runat="server" Text="تعهدات تبدیل شده"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                            
                        </tr>
                        <tr>
                        <td>
                            <asp:Label ID="Label125" runat="server" Text="1"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label126" runat="server" Text="اعتبارات اسنادی دیداری"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label127" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label128" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label129" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label130" runat="server" Text="20%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label131" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>
                         <tr>
                        <td>
                            <asp:Label ID="Label132" runat="server" Text="2"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label133" runat="server" Text="اعتبارات اسنادی مدتدار و ریفاینانس اسناد تحویل شده"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label134" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label135" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label136" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label137" runat="server" Text="50%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label138" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>
                          <tr>
                        <td>
                            <asp:Label ID="Label139" runat="server" Text="2"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label140" runat="server" Text="اعتبارات اسنادی مدتدار و ریفاینانس اسناد تحویل نشده"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label141" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label142" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label143" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label144" runat="server" Text="20%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label145" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>
                          <tr>
                        <td>
                            <asp:Label ID="Label146" runat="server" Text="4"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label147" runat="server" Text="اعتبارات اسنادی با وثیقه غیر کالا از قبیل خدمات مهندسی، انتقال تکنولوژی و کرایه حمل"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label148" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label149" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label150" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label151" runat="server" Text="50%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label152" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>
                          <tr>
                        <td>
                            <asp:Label ID="Label153" runat="server" Text="2"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label154" runat="server" Text="ضمانتنامه های ریالی و ارزی با سررسید کمتر از یکسال"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label155" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label156" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label157" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label158" runat="server" Text="20%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label159" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>

                          <tr>
                        <td>
                            <asp:Label ID="Label160" runat="server" Text="6"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label161" runat="server" Text="ضمانتنامه های ریالی و ارزی با سررسید بیش از یکسال"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label162" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label163" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label164" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label165" runat="server" Text="50%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label166" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>

                          <tr>
                        <td>
                            <asp:Label ID="Label167" runat="server" Text="7"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label168" runat="server" Text="ظهرنویسی اسناد و بروات"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label169" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label170" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label171" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label172" runat="server" Text="100%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label173" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>

                          <tr>
                        <td>
                            <asp:Label ID="Label174" runat="server" Text="8"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label175" runat="server" Text="سایر تعهدات"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label176" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label177" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label178" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label179" runat="server" Text="100%"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label180" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>

                          <tr>
                        <td>
                            <asp:Label ID="Label181" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label182" runat="server" Text="جمع"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label183" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label184" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label185" runat="server" Text="0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label186" runat="server" Text="---"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label187" runat="server" Text="0"></asp:Label>
                        </td>
                        </tr>

                          <tr>
                          <td colspan="6">
                          
                          </td>
                       
                        <td>
                            <asp:Label ID="Label188" runat="server" Text=""></asp:Label>
                        </td>
                        </tr>
                          <tr>
                          <td colspan="6">
                          
                          </td>
                       
                        <td>
                            <asp:Label ID="Label189" runat="server" Text=""></asp:Label>
                        </td>
                        </tr>

                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

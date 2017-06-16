function CallWebMethod(mname, DTO, ReqCd, success, error, XmlJson, ShowProgress, Timeout) {
    if (Timeout == null)
        Timeout = 1500;
    if (ShowProgress !== false)
        ShowProgress = true;

    // compatibility fix
    if (mname.indexOf('/', 0) == -1)
        mname = "webServices.asmx/" + mname;

    mname = "WS/" + mname;

    if (!XmlJson)
        XmlJson = 'json';


    var Cntnr = $("#NotifyDiv div table tbody");

    function SetVisibility() {
        if ($(">tr", Cntnr).size() == 0)
            $("#NotifyDiv").hide();
        else
            $("#NotifyDiv").show();
    }

    if (ShowProgress) {
        var tr = $("<tr>")
        .append('<td class="jc">' + ReqCd + '</td>')
        .append('<td class="jn">' + SrvrReqCdsTxt(ReqCd) + '</td>')
        .appendTo(Cntnr);

        var img = $("<img>")
        .attr("src", 'images/ajax-loader.gif')
        .attr("title", "در حال بارگذاری...")
        .click(function() {
            $(tr).remove().hide();
            SetVisibility();
        })
        .css("cursor", "pointer")
        .width(20).height(20);


        $(tr)
        .append($("<td>").append(img))
        .append('<td class="jr"></td>');

        SetVisibility();
    }
    //for asp.net
    if (DTO == null)
        DTO = {};
    $.ajax({
        type: "POST",
        contentType: "application/" + XmlJson + "; charset=utf-8",
        url: mname,
        data: JSON.stringify(DTO),
        dataType: XmlJson,
        cache: false,
        processData: false,


        success: function(xml) {
            if (ShowProgress) {
                $(img).attr("src", "images/ok.gif");
                $(">td.jr", tr).text("عملیات با موفقیت انجام شد");
                setTimeout(function() {
                    $(tr).remove().hide();
                    SetVisibility();
                }, Timeout);
            }
            if (success != null) {
                success(xml);
                
            }
        },




        error: function(e, xhr, settings, exception) {
            var errCode, errMsg;
            if (e.status == 0) {
                errCode = 0;
                errMsg = "شما به شبکه متصل نمی باشید.";
            }
            else if (e.status == 404) {
                errCode = 404;
                errMsg = "آدرس درخواستی اشتباه است.";
            }
            else {
                if (e.status == 500) {
                    try {
                        var obj = $.parseJSON(e.responseText);
                        var xml = { d: obj.Message };
                        var dom = GetDom(xml);

                        errCode = $(dom).find("Code").text();
                        errMsg = $(dom).find("Message").text();
                    }
                    catch (ex) {
                        errCode = 500;
                        errMsg = "خطای داخلی سرویس دهنده." + e.responseText;
                    }
                };


                if (errCode == 1012 || errCode == 1013) {
                    LogOutUser();
                }

            }
            if (ShowProgress) {
                $(img).attr("src", "images/error.gif");

                $("td.jr", tr).css("text-align", "justify").html(
        '<span class="bold">کد خطا:</span>' +
        "<span>" + errCode + "</span>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        '<span class="bold">متن خطا:</span>' +
        "<span>" + errMsg + "</span>"
         );

                setTimeout(function() {
                    $(tr).remove().hide();
                    SetVisibility();
                }, Timeout);
            }
            var CustomErrDlg;
            if (error != null)
                CustomErrDlg = error(errMsg, errCode);
            if (CustomErrDlg !== false)
                Globals.Dialogs.Failure("<p>کد خطا: " + errCode + "</p>" + "<p>متن خطا: " + errMsg + "</p>");

        }
    });


}


String.prototype.trim = function() {
    return this.replace(/^\s+|\s+$/g, "");
}
String.prototype.ltrim = function() {
    return this.replace(/^\s+/, "");
}
String.prototype.rtrim = function() {
    return this.replace(/\s+$/, "");
}


$(function() {
    var NumStrDiv = $(document.createElement("div"))
        .hide()
        .addClass("StrNum")
        .append('<span></span>')
        .appendTo($('body'));

    $('td.Number input:text, .Number:text').live('keyup', function(e) {




        var top = $(this).offset().top;
        var left = $(this).offset().left - $(window).scrollLeft();

        var width = $(window).width();

        var dtop, dleft, dwidth = 600;

        dtop = top + 23;
        dleft = (width - dwidth) * 1.0 / 2 - 40;

        $(NumStrDiv)
            .css("left", dleft)
            .css("top", dtop)
            .css("width", dwidth)
            .css("z-index", 500000)
            .slideDown(400)
            .bgiframe()
            .find("span")
            .text(NumToStr($(this).val()));








        var $this = $(this);
        var keyVal = GetKeyVal(e);
        if (keyVal == 27)
            $(NumStrDiv).hide();
        if (keyVal == 106)
            if ($this.val().length + 3 <= $this.attr('maxlength'))
            $this.val($this.val() + '000');

        var num = $this.val().replace(/[^0-9]/g, '');
        $this.val(CommaSep(num));
        $("span", NumStrDiv).text(NumToStr(num));
        e.preventDefault();
        return false;
    })
    .live('blur', function() {
        $(NumStrDiv).hide();
    })
    .live('focus', function() {




    });

    $('.EngAlphaNum input:text, .EngAlphaNum input[type=password]').live('keypress', function(e) {
        var keyVal = GetKeyVal(e);
        var res =
            (keyVal > 64 && keyVal < 91) ||
            (keyVal > 96 && keyVal < 123) ||
            (keyVal > 47 && keyVal < 58) ||
            (keyVal == 8) ||
            (keyVal == 9) ||
            (keyVal == 46) ||
            (keyVal == 13)
            ;
        if (!res)
            alert("لطفا فقط از حروف انگلیسی و اعداد استفاده نمائید");
        return res;
    });

    $('.Numeric input:text, input:text.Numeric').live('keypress', function(e) {
        var keyVal = GetKeyVal(e);
        var res =
            (keyVal > 47 && keyVal < 58) ||
            (keyVal == 8) ||
            (keyVal == 9) ||
            (keyVal == 46) ||
            (keyVal == 13) ||
            (keyVal == 118)
            ;
        if (!res) e.preventDefault();
        return res;

    });
});

function CommaSep(num) {
    if (NotEmpty(num)) {
        var n = String(num).replace(/[^0-9]/g, '');
        return n.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
    } else
        return '';
}


function GetDom(xml) {
    var xmlString = xml.d;
    var dom = $.xmlDOM(xmlString, function(error) {
        throw ('A parse error occurred! ' + error);
    });
    return dom;
}



function CompObj(obj1, obj2) {
    try {
        for (var field in obj1)
            if (obj1[field] != obj2[field])
            return false;
        return true;
    } catch (e) {
        return false;
    }
}



function IsArray(a) {
    return Object.prototype.toString.apply(a) === '[object Array]';
}

function IsDate(a) {
    return Object.prototype.toString.apply(a) === '[object Date]';
}

function IsNumber(a) {
    return Object.prototype.toString.apply(a) === '[object Number]';
}

function IsString(a) {
    return Object.prototype.toString.apply(a) === '[object String]';
}


function DomToObj(dom, AryFlds) {

    function Get(Parent, dom) {
        if ($(dom).children().size() == 0)
            return $(dom).text();

        var name = Parent == null ? dom.nodeName : Parent.nodeName + '.' + dom.nodeName;

        if (ArrayContains(AryFlds, name)) {
            var ary = new Array();
            $(dom).children().each(function() {
                ary.push(Get(dom, this));
            });
            return ary;
        }
        else {
            var obj = {};
            $(dom).children().each(function() {
                obj[this.nodeName] = Get(dom, this);
            });
            return obj;
        }
    }

    return Get(null, dom);
}


function AddToTree(item, array, ChildrenField, PKField, ParentField) {
    var res = false;
    for (var i in array) {
        var elem = array[i];
        if (elem[PKField] == item[ParentField]) {
            if (elem[ChildrenField] == null)
                elem[ChildrenField] = new Array();
            elem[ChildrenField].push(item);
            return true;
        }
        else
            if (elem[ChildrenField] != null) {
            res = AddToTree(item, elem[ChildrenField], ChildrenField, PKField, ParentField);
            if (res)
                return true;
        }

    }
    return false;
}


function Search(arr, Prop, Val) {
    for (var i in arr) {
        if (arr[i][Prop] == Val)
            return arr[i];
    }
}

function SearchHrch(arr, ChildrenField, Prop, Val) {
    for (var i in arr) {
        if (arr[i][Prop] == Val)
            return arr[i];
        if (arr[i][ChildrenField] != null) {
            var res = SearchHrch(arr[i][ChildrenField], ChildrenField, Prop, Val);
            if (res != null)
                return res;
        }
    }
}

function DeleteFromTreeObj(arr, ChildrenField, Prop, Val) {
    for (var i in arr) {
        if (arr[i][Prop] == Val) {
            arr.splice(i, 1);
            return true;
        }
        if (arr[i][ChildrenField] != null) {
            var res = DeleteFromTreeObj(arr[i][ChildrenField], ChildrenField, Prop, Val);
            if (res != null)
                return res;
        }
    }
    return false;

}

function Filter(array, fn) {
    var result = [];

    for (var i in array) {
        if (fn(i, array[i])) {
            result[i] = array[i];
        }
    }

    return result;
}


function NotEmpty(val) {
    if (val == null)
        return false;
    else
        return true;
}


function MergeToNew(obj1, obj2) {
    var obj = {};
    for (var i in obj1)
        obj[i] = obj1[i];
    for (var i in obj2)
        obj[i] = obj2[i];
    return obj;
}



function MergeToFirst(obj1, obj2) {
    var a = new Array();
    for (var i in obj2)
        obj1[i] = obj2[i];
    return obj1;
}




function MsgBox(text, type, buttons, CallBack) {

    var div = $(document.createElement("div"))
    .attr("title", "توجه")
    .text(text);

    function fnc(res) {
        if (CallBack) {

            var eng;
            var t = $(res.target).text();

            if (t == 'بله') eng = "Yes";
            if (t == 'خیر') eng = "No";
            if (t == 'موافقم') eng = "OK";
            if (t == 'قبول') eng = "OK";
            if (t == 'انصراف') eng = "Cancel";
            CallBack(eng);
        }
        $(div).dialog('close');
    }



    switch (buttons) {
        case "YesNo":
            $(div).dialog({
                modal: true,
                buttons: {
                    'بله': fnc,
                    'خیر': fnc
                }
            });
            break;
        case "OK":
            $(div).dialog({
                modal: true,
                buttons: {
                    'موافقم': fnc
                }
            });
            break;
        case "OKCancel":
            $(div).dialog({
                modal: true,
                buttons: {
                    'قبول': fnc,
                    'انصراف': fnc
                }
            });
            break;

    }

}


function GetRandomName() {
    return "C" + String(Math.random()).replace('.', '');
}


function CloneObj(obj) {
    if (obj == null) return null;
    var res = {};
    for (var fld in obj)
        res[fld] = obj[fld];
    return res;
}



function CommaCat(array, Field) {
    var names = '';
    for (var i in array) {
        names += array[i][Field] + ',';
    }
    if (names.length > 0)
        names = names.substr(0, names.length - 1);
    return names;
}



function UpdateNTT(firstNtt, scndNtt, ValFields) {
    ValFields = ValFields.split(',');
    for (var j in ValFields) {
        var fn = ValFields[j];
        firstNtt[fn] = scndNtt[fn];
    }
}

function ScrollTo(dom, TopOrBottom, Container) {
    var c = Container == null ? window : Container;

    if (!TopOrBottom) TopOrBottom = "Bottom";
    var x;
    if (TopOrBottom == "Bottom")
        x = $(dom).offset().top - $(c).height() + $(dom).height(); // 100 provides buffer in viewport
    else
        x = $(dom).offset().top;

    $(Container == null ? 'html,body' : Container).animate({ scrollTop: x }, Globals.Anim);
}

function BlinkDom(dom, count) {
    for (var i = 0; i < count; i++) {
        $(dom).animate({ opacity: 'toggle' },
        200,
        null,
        null,
        null,
        true);
    }
}

function SortSelect(select) {
    var my_options = $("option", select);

    my_options.sort(function(a, b) {
        if (a.text > b.text) return 1;
        else if (a.text < b.text) return -1;
        else return 0
    })

    $(select).empty().append(my_options);
}

function SetNumberOnly(textbox) {
    $(textbox).keypress(function(e) {
        var keyVal = GetKeyVal(e);
        return (keyVal > 47 && keyVal < 58) || (keyVal == 8) || (keyVal == 46);
    });
}


function RemoveObj(ar, Field1, Value1, Field2, Value2) {
    if (Field2)
        for (var i in ar) {
        if (ar[i][Field1] == Value1 &&
               ar[i][Field2] == Value2) {
            ar.splice(i, 1);
            break;
        }
    }
    else
        for (var i in ar) {
        if (ar[i][Field1] == Value1) {
            ar.splice(i, 1);
            break;
        }
    }
}

function GetNumSortFunc(FieldName) {

    return function(x, y) {
        a = x[FieldName];
        b = y[FieldName];
        if (isNaN(a) && isNaN(b))
            return 0;
        if (isNaN(a) && !isNaN(b))
            return -1;
        if (!isNaN(a) && isNaN(b))
            return 1;
        return a - b;
    }
}

function GetAlpSortFunc(FieldName) {

    return function(x, y) {
        a = x[FieldName];
        b = y[FieldName];
        if (a == null && b == null)
            return 0;
        if (a == null && b != null)
            return -1;
        if (a != null && b == null)
            return 1;

        if (a > b) return 1;
        if (a < b) return -1;
        return 0;
    }
}

function ArrayContains(array, val) {
    for (var i in array) {
        if (array[i] == val) return true;
    }
    return false;
}


function GetKeyVal(e) {
    return (e.charCode ? e.charCode : ((e.keyCode) ? e.keyCode : e.which));
}

function NumToStr(Num) {
    var texts = {
        1: 'یک',
        2: 'دو',
        3: 'سه',
        4: 'چهار',
        5: 'پنج',
        6: 'شش',
        7: 'هفت',
        8: 'هشت',
        9: 'نه',
        10: 'ده',
        11: 'یازده',
        12: 'دوازده',
        13: 'سیزده',
        14: 'چهارده',
        15: 'پانزده',
        16: 'شانزده',
        17: 'هفده',
        18: 'هجده',
        19: 'نوزده',
        20: 'بیست',
        30: 'سی',
        40: 'چهل',
        50: 'پنجاه',
        60: 'شصت',
        70: 'هفتاد',
        80: 'هشتاد',
        90: 'نود',
        100: 'یکصد',
        200: 'دویست',
        300: 'سیصد',
        400: 'چهارصد',
        500: 'پانصد',
        600: 'ششصد',
        700: 'هفتصد',
        800: 'هشتصد',
        900: 'نهصد'
    }

    function ToStr(Num) {

        var SNum = String(Num);

        var hzmyrd;
        var myrd;
        var mlin;
        var hzr;
        var sad;

        if (SNum.length > 15)
            return 'بزرگتر از حد مجاز';

        SNum = SNum.pad(15, '0', 0);

        hzmyrd = SNum.substr(0, 3);
        myrd = SNum.substr(3, 3);
        mlin = SNum.substr(6, 3);
        hzr = SNum.substr(9, 3);
        sad = SNum.substr(12, 3);

        function func(Num) {
            if (Num.length != 3)
                throw null;

            var sad = Num.charAt(0) + '00';
            var dah = Num.charAt(1) + '0';
            var yek = Num.charAt(2);
            var res = '';
            if (sad != 0)
                res = texts[sad];
            if (dah != 0) {
                if (dah == 10) {
                    var t = String(Num.charAt(1)) + String(Num.charAt(2));
                    if (res != '') {
                        return res + ' و ' + texts[t];

                    }
                    else
                        return texts[t];
                }
                else {
                    if (res != '')
                        res += ' و ' + texts[dah];
                    else
                        res = texts[dah];
                }
            }
            if (yek != 0)
                if (res != '')
                res += ' و ' + texts[yek];
            else
                res = texts[yek];

            return res;
        }


        var res = '';

        if (hzmyrd != 0) hzmyrd = func(hzmyrd);
        if (myrd != 0) myrd = func(myrd);
        if (mlin != 0) mlin = func(mlin);
        if (hzr != 0) hzr = func(hzr);
        if (sad != 0) sad = func(sad);

        if (hzmyrd != 0) {
            res += hzmyrd + ' هزار ';
        }

        if (myrd != 0) {
            if (res != '')
                res += 'و ' + myrd;
            else
                res = myrd;
            res += ' میلیارد ';
        }
        else
            if (res != '')
            res += ' میلیارد ';

        if (mlin != 0) {
            if (res != '') {
                res += 'و ' + mlin;
            } else
                res = mlin;

            res += ' میلیون ';
        }

        if (hzr != 0) {
            if (res != '') {
                res += 'و ' + hzr;
            }
            else
                res = hzr;

            res += ' هزار ';
        }

        if (sad != 0) {
            if (res != '') {
                res += 'و ' + sad;
            }
            else
                res = sad;
        }

        if (res == '') return 'صفر';
        return res;
    }


    Num = String(Num).replace(/,/g, '');
    return ToStr(Num);
}



function nvl(val, rep) {
    if (rep == null) rep = '';
    if ($.trim(val) == "") return rep;
    return val;
}


function Divide(a, b) {
    return (a - a % b) / b;
}

function SalVaMahTXT(mah) {
    if (mah != null) {
        mah = Number(mah);
        var S = Divide(mah, 12);
        var M = mah % 12;
        var txt = '';
        if (S != 0)
            txt = S + ' سال';
        if (M != 0)
            if (txt != '')
            txt += ' و ' + M + ' ماه';
        else
            txt = M + ' ماه';
        return txt;
    }
    else
        return '';
}



function Utf8Encode(string) {
    string = String(string).replace(/\r\n/g, "\n");
    var utftext = "";

    for (var n = 0; n < string.length; n++) {

        var c = string.charCodeAt(n);

        if (c < 128) {
            utftext += String.fromCharCode(c);
        }
        else if ((c > 127) && (c < 2048)) {
            utftext += String.fromCharCode((c >> 6) | 192);
            utftext += String.fromCharCode((c & 63) | 128);
        }
        else {
            utftext += String.fromCharCode((c >> 12) | 224);
            utftext += String.fromCharCode(((c >> 6) & 63) | 128);
            utftext += String.fromCharCode((c & 63) | 128);
        }

    }

    return utftext;
};


function ccrc32(str) {

    str = Utf8Encode(str);
    var crc = 0;
    var table = "00000000 77073096 EE0E612C 990951BA 076DC419 706AF48F E963A535 9E6495A3 0EDB8832 79DCB8A4 E0D5E91E 97D2D988 09B64C2B 7EB17CBD E7B82D07 90BF1D91 1DB71064 6AB020F2 F3B97148 84BE41DE 1ADAD47D 6DDDE4EB F4D4B551 83D385C7 136C9856 646BA8C0 FD62F97A 8A65C9EC 14015C4F 63066CD9 FA0F3D63 8D080DF5 3B6E20C8 4C69105E D56041E4 A2677172 3C03E4D1 4B04D447 D20D85FD A50AB56B 35B5A8FA 42B2986C DBBBC9D6 ACBCF940 32D86CE3 45DF5C75 DCD60DCF ABD13D59 26D930AC 51DE003A C8D75180 BFD06116 21B4F4B5 56B3C423 CFBA9599 B8BDA50F 2802B89E 5F058808 C60CD9B2 B10BE924 2F6F7C87 58684C11 C1611DAB B6662D3D 76DC4190 01DB7106 98D220BC EFD5102A 71B18589 06B6B51F 9FBFE4A5 E8B8D433 7807C9A2 0F00F934 9609A88E E10E9818 7F6A0DBB 086D3D2D 91646C97 E6635C01 6B6B51F4 1C6C6162 856530D8 F262004E 6C0695ED 1B01A57B 8208F4C1 F50FC457 65B0D9C6 12B7E950 8BBEB8EA FCB9887C 62DD1DDF 15DA2D49 8CD37CF3 FBD44C65 4DB26158 3AB551CE A3BC0074 D4BB30E2 4ADFA541 3DD895D7 A4D1C46D D3D6F4FB 4369E96A 346ED9FC AD678846 DA60B8D0 44042D73 33031DE5 AA0A4C5F DD0D7CC9 5005713C 270241AA BE0B1010 C90C2086 5768B525 206F85B3 B966D409 CE61E49F 5EDEF90E 29D9C998 B0D09822 C7D7A8B4 59B33D17 2EB40D81 B7BD5C3B C0BA6CAD EDB88320 9ABFB3B6 03B6E20C 74B1D29A EAD54739 9DD277AF 04DB2615 73DC1683 E3630B12 94643B84 0D6D6A3E 7A6A5AA8 E40ECF0B 9309FF9D 0A00AE27 7D079EB1 F00F9344 8708A3D2 1E01F268 6906C2FE F762575D 806567CB 196C3671 6E6B06E7 FED41B76 89D32BE0 10DA7A5A 67DD4ACC F9B9DF6F 8EBEEFF9 17B7BE43 60B08ED5 D6D6A3E8 A1D1937E 38D8C2C4 4FDFF252 D1BB67F1 A6BC5767 3FB506DD 48B2364B D80D2BDA AF0A1B4C 36034AF6 41047A60 DF60EFC3 A867DF55 316E8EEF 4669BE79 CB61B38C BC66831A 256FD2A0 5268E236 CC0C7795 BB0B4703 220216B9 5505262F C5BA3BBE B2BD0B28 2BB45A92 5CB36A04 C2D7FFA7 B5D0CF31 2CD99E8B 5BDEAE1D 9B64C2B0 EC63F226 756AA39C 026D930A 9C0906A9 EB0E363F 72076785 05005713 95BF4A82 E2B87A14 7BB12BAE 0CB61B38 92D28E9B E5D5BE0D 7CDCEFB7 0BDBDF21 86D3D2D4 F1D4E242 68DDB3F8 1FDA836E 81BE16CD F6B9265B 6FB077E1 18B74777 88085AE6 FF0F6A70 66063BCA 11010B5C 8F659EFF F862AE69 616BFFD3 166CCF45 A00AE278 D70DD2EE 4E048354 3903B3C2 A7672661 D06016F7 4969474D 3E6E77DB AED16A4A D9D65ADC 40DF0B66 37D83BF0 A9BCAE53 DEBB9EC5 47B2CF7F 30B5FFE9 BDBDF21C CABAC28A 53B39330 24B4A3A6 BAD03605 CDD70693 54DE5729 23D967BF B3667A2E C4614AB8 5D681B02 2A6F2B94 B40BBE37 C30C8EA1 5A05DF1B 2D02EF8D";

    var x = 0;
    var y = 0;

    crc = crc ^ (-1);
    for (var i = 0, iTop = str.length; i < iTop; i++) {
        y = (crc ^ str.charCodeAt(i)) & 0xFF;
        x = "0x" + table.substr(y * 9, 8);
        crc = (crc >>> 8) ^ x;
    }

    crc = String(Math.abs(crc ^ (-1)));
    return crc.charAt(0) + crc.charAt(3);

}

function IsEmpty(str) {
    return str == null || str == '';
}


function CheckState(cb) {
    return $(cb).filter("input[type=checkbox]:checked").size();
}


(function($) {
    $.fn.myVals = function() {
        var a = [];
        this.filter(":checked").each(function() {
            a.push($(this).val());
        });
        return a;
    }
    $.fn.myVal = function() {
        return this.filter(":checked").val();
    }
})(jQuery);

function JDToStr(jd, sep) {
    var parts = String(jd).split(',');
    var y = parts[0] - 1300;
    var m = Number(parts[1]) + 1;
    if (m < 10) m = '0' + m;
    var d = parts[2];
    if (d < 10) d = '0' + d;
    return y + sep + m + sep + d;
}

function StrToJD(str, sep) {
    var p = str.split(sep);
    return jd = new JalaliDate(Number(p[0]) + 1300, p[1] - 1, p[2]);
}

function TodayS() {
    return JDToStr(new JalaliDate(), '/');
}
function TodayA() {
    var jd = new JalaliDate();
    var p = String(jd).split(',');
    p[0] = p[0] - 1300;
    p[1] = Number(p[1]) + 1;
    return p;
}

function OneMonthBefore() {
    var p = TodayA();
    if (p[1] == 1) {
        p[0]--;
        p[1] = 12;
    }
    else
        p[1]--;
    p[2] = 1;
    if (p[1] < 10) p[1] = '0' + p[1];
    if (p[2] < 10) p[2] = '0' + p[2];
    return p[0] + '/' + p[1] + '/' + p[2];
}
$(function() {
    String.prototype.pad = function(l, s, t) {
        return s || (s = " "), (l -= this.length) > 0 ? (s = new Array(Math.ceil(l / s.length)
            + 1).join(s)).substr(0, t = !t ? l : t == 1 ? 0 : Math.ceil(l / 2))
            + this + s.substr(0, l - t) : this;
    };
});

function ValidateReqFlwNum(FlwNum) {
    
    if (FlwNum.length > 2) {
        var CheckSum = FlwNum.substr(FlwNum.length - 2, 2);
        var RawVal = FlwNum.substr(0, FlwNum.length - 2);
        return ccrc32(RawVal) == CheckSum;
    }
    else {
        return false;
    }
}


function ValidateDate(d, sep) {
    var p = d.split(sep);
    var rm = p[0] % 33;
    switch (rm) {
        case 1:
        case 5:
        case 9:
        case 13:
        case 17:
        case 22:
        case 26:
        case 30:
            if (p[2] > 29)
                return false;
    }
    if (p[1] > 12 || p[1] < 1) return false;
    if (p[1] < 7) {
        if (p[2] > 31)
            return false;
    }
    else
        if (p[2] > 30)
        return false;

    if (p[2] < 1) return false;
    return true;
}


function IfEnter(cb) {
    return function temp(e) {
        var key = GetKeyVal(e);
        if (key == 13) {
            if (cb)
                cb();
            e.preventDefault();
            return false;
        }
    };
}

function WrapInObj(func) {
    return function() {
        func();
    };
}

function UnknwnErr() {
    Globals.Dialogs.Failure("خطای ناشناخته");
}

function PrvntAutoSbmt(event) {
    if (event.keyCode == 13) {
        event.preventDefault();
        return false;
    }
}

function ReFunc(func, p) {
    return function() {
        func(p);
    }
}

function JsonDtToP1(dt) {
    dt = eval("new " + dt.split('/')[1]);
    var jd = gregorian_to_jd(dt.getFullYear(), dt.getMonth() + 1, dt.getDate());
    jd = jd_to_persian(jd);
    var a = String(jd[0]).substr(2, 2) + '/' + String(jd[1]).pad(2, '0', 0) + '/' + String(jd[2]).pad(2, '0', 0);
    return a;

}
function P1StrToJson(str) {
    var a = StrToJD(str, '/');
    gd = a.getGregorianDate().valueOf();
    return "/Date(" + gd + ")/";
}
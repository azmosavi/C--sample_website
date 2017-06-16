var UI = {

    FocusLater: function(obj) {
        setTimeout(function() { obj.focus() }, 100);
    },
    NwCrdtTypsSlct: function(withNull, cb) {

        var Slct = $("<select>");
        function FillCrdtsSlct(CrdtTyps) {
            if (withNull === 1)
                $("<option>").appendTo(Slct);

            for (var i in CrdtTyps) {
                var Rows = CrdtTyps[i].Rows;
                var Grp = $("<optgroup>")
            .attr("label", CrdtTyps[i].MjrTypNm)
            .appendTo(Slct);

                for (var j in Rows) {
                    $("<option>").text(Rows[j].CRDTTYPNM)
                .val(Rows[j].CRDTTYPID)
                .appendTo(Grp)
                .data("ROW", Rows[j]);
                }
            }
            if (cb) cb();
        }

        Load.AllCrdtTypsWGrp(FillCrdtsSlct);
        return Slct;
    },
    NwPg: function(Ttr, func, Params) {
        var page = {
            Ttr: Ttr,
            OpenFunc: func,
            Params: Params
        };
        return page;
    },
    NwTxtBx: function() {
        return $("<input>").attr("type", "text");
    },

    NwNmrcTxtBx: function() {
        return $("<input>").attr("type", "text").addClass("Numeric");
    },
    NwNmbrTxtBx: function() {
        return $("<input>").attr("type", "text").addClass("Number").attr('maxlength', 19).attr("size", 19);
    },
    NwTbl: function(Cols, Rows, Thead, Tfoot) {
        var Table = $(document.createElement("table"));

        if (Thead === true) Rows++;
        if (Tfoot === true) Rows++;

        for (var i = 0; i < Rows; i++) {
            var row = "<tr>";
            for (var j = 0; j < Cols; j++) {
                row += "<td></td>";
            }
            row += "</tr>";
            $(Table).append(row);
        }

        if (Thead === true)
            $("tr:first", Table).wrap("<thead></thead>");
        if (Tfoot === true)
            $("tr:last", Table).wrap("<tfoot></tfoot>");

        return Table;

    },
    NwFormTbl: function(Cols, Rows) {
        var Table = this.NwTbl(Cols, Rows).addClass("FormTable");
        return Table;
    },
    NwExpndngTbl: function() {
        //use this function with GetTdFunc2
        var Table = $("<table>").addClass("FormTable");
        $(Table).append("<tbody>").data("_NUMROWS", 0).data("_NUMCOLS", 0);
        return Table;
    },
    AplyTdFunc: function(context, table) {
        alert('AplyTdFunc Depricated');
    },
    GetTdFunc: function(table) {
        return function(row, col) {
            return $("tbody>tr:nth(" + row + ")>td:nth(" + col + ")", table);
        }
    },
    GetTdFunc2: function(table) {
        if (table == null) alert("null table");
        return function(row, col) {
            row = Number(row);
            col = Number(col);
            if (row > $(table).data("_NUMROWS") - 1) {
                for (var i = $(table).data("_NUMROWS"); i < row + 1; i++) {
                    var tr = $("<tr>").appendTo($("tbody", table));
                    for (var j = 0; j < $(table).data("_NUMCOLS"); j++)
                        tr.append("<td>");
                }
                $(table).data("_NUMROWS", row + 1);
            }
            if (col > $(table).data("_NUMCOLS") - 1) {
                for (var i = $(table).data("_NUMCOLS"); i < col + 1; i++) {
                    $("tr", table).append("<td>");
                }
                $(table).data("_NUMCOLS", col + 1);
            }

            return $("tbody>tr:nth(" + row + ")>td:nth(" + col + ")", table);
        }
    },

    NwA: function() {
        return $("<a>")
        .attr("href", "javascript:void(0)");
        
    },

    NwSlct: function(obj) {
        var sct = $("<select>");
        if (obj)
            for (var i in obj)
            $("<option>").val(i).text(obj[i]).appendTo(sct);
        return sct;
    },
    RedStar: function(a) {
        return a + '<span class="RedStar">*</span>';
    },
    RedSpan: function(a) {
        return '<span class="error">' + a + '</span>';
    },

    NwSlctWNull: function(obj, NA) {
        var sct = $("<select>");

        $("<option>").val('').text(NA == null ? '' : NA).appendTo(sct);

        if (obj)
            for (var i in obj)
            $("<option>").val(i).text(obj[i]).appendTo(sct);

        return sct;
    },
    NwGrpSlct: function(dom, sct) {
        if (!sct)
            sct = this.NwSlct();
        function AddToList(item) {
            var og = $("<optgroup>")
                    .attr("label", item.Value)
                    .appendTo(sct);

            for (var i in item.Children) {
                var t = item.Children[i];
                $("<option>")
                        .text(t.Value)
                        .val(t.ID)
                        .appendTo(og);
            }
        }
        $("ArrayOfTreeNode > TreeNode", dom).each(function() {
            var item = DomToObj(this, ['TreeNode.Children']);
            AddToList(item);
        });
        return sct;
    },
    SetSlct: function(slct, Values) {
        var ReturnResult = 0;
        if (!IsArray(Values))
            Values = [Values];

        var SlctdCnt = 0;
        $("option", slct).each(function() {

            for (var i in Values) {
                if (Values[i] == null)
                    Values[i] = '';

                if ($(this).val() == Values[i]) {
                    if ($(this).attr("disabled"))
                        ReturnResult = 1;
                    else
                        $(this).attr("selected", true);
                    SlctdCnt++;
                    break;

                }
            }

        });

        if (SlctdCnt != Values.length)
            ReturnResult = 2;


        return ReturnResult;

    },

    NwDGrpSlctWNull: function(dom, NA, sct) {
        if (!sct)
            sct = this.NwSlct();
        $("<option>").val('').text(NA == null ? '' : NA).appendTo(sct);

        function AddToList(item) {
            var og = $("<optgroup>")
                    .attr("label", item.Value)
                    .appendTo(sct);

            for (var i in item.Children) {
                var t = item.Children[i];
                $("<option>")
                        .text(t.Value)
                        .val(t.ID)
                        .appendTo(og);
            }
        }
        $("ArrayOfTreeNode > TreeNode", dom).each(function() {
            var item = DomToObj(this, ['TreeNode.Children']);
            AddToList(item);
        });
        return sct;
    },

    NwDSlctWNull: function(dom, ElmntName, DispField, ValField, NA, sct) {
        if (!sct)
            sct = this.NwSlct();
        $("<option>").val('').text(NA == null ? '' : NA).appendTo(sct);
        $(ElmntName, dom).each(function() {
            var obj = DomToObj(this);
            $("<option>").val(obj[ValField]).text(obj[DispField]).appendTo(sct);
        });
        return sct;

    },
    BindSalVaMah: function(tb, container) {
        $(container).append('<span class="SalVaMah"></span>');
        $(".SalVaMah", container).text(SalVaMahTXT(tb.val()));
        tb.keyup(function() {
            var num = $(this).val();
            $(".SalVaMah", container).text(SalVaMahTXT(num));
        });
    },

    NwPrdTxtBx: function() {
    },
    AttchPrdTxtBxTDesc: function() {
    },
    AttchTxtAreaCntr: function(elmnt, count) {
        var p = $("<p>").insertBefore(elmnt);
        var res;
        $(elmnt).keydown(function(e) {
            var vkey = 1;
            var v = GetKeyVal(e);
            var keys = [8, 46, 37, 38, 39, 40, 16, 33, 34, 45, 17, 36, 35, 18];
            for (var i in keys)
                if (keys[i] == v) {
                vkey = 0;
                break;
            }

            var c = count - $(this).val().length - vkey;
            var d = c;
            if (d < 0) d = 0;
            $(p).text("طول متن حداکثر " + count + " حرف. باقیمانده: " + d);

            return (c >= 0 || !vkey);

        });
    },
    NwTxtArea: function(width, height) {
        return $("<textarea>")
                .css("width", width)
                .css("height", height);
    },
    NwBTN: function(text) {
        return $("<button>").text(text);
    }
    ,
    MergeTD: function(td, cnt) {
        $(td).attr("colspan", cnt);
        for (var i = 0; i < cnt - 1; i++)
            $(td).next().remove();
    }
    ,
    StyleFrmTbl: function(tb) {
        $("tbody>tr", tb)
        .find("td:even")
        .addClass("FieldTitle").end()
        .find("td:odd")
        .addClass("FieldValue");
    },
    NwDateTxtBx: function(parent, max, min, def) {
        var minDate, maxDate;
        if (IsNumber(max)) {
            maxDate = new Date();
            maxDate.setDate(maxDate.getDate() + max);
            maxDate.setHours(0, 0, 0, 0);
        }
        if (IsNumber(min)) {
            minDate = new Date();
            minDate.setDate(minDate.getDate() + min);
            minDate.setHours(0, 0, 0, 0);
        }

        function err(input) {
            $(input).css('background-color', '#fdcfc6');
        }

        var a = $(document.createElement("input"))
    .attr("type", "text")
    .attr("size", 10)
    .css("direction", "ltr")
    .css("text-align", "center")
    .mask("99/99/99")
    .keydown(function(e) {
        var KeyVal = GetKeyVal(e);

        var val = $(this).val();
        var empty = '__/__/__';

        if (KeyVal == 32) {
            if (val == empty || val == '')
                val = TodayS();
            else
                val = empty;

            $(this).val(val).focus();

            return false;
        };
        if (KeyVal == 13 && val == empty) {
            $(this).val('');
            return false;
        }


        return true;
    })

     .keyup(function(e) {
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
    .blur(function() {
        var r = new RegExp(' ', 'g');
        var a = $(this).css('background-color').replace(r, '');
        if (a == '#fdcfc6' || a == 'rgb(253,207,198)') {
            $(this).val('');
            $(this).css('background-color', 'white');
        }
    })

    .appendTo(parent);

        var opts = {
            isRTL: true,
            dateFormat: 'y/mm/dd',
            showOn: 'button',
            buttonImage: 'images/calendar.gif',
            buttonImageOnly: true,
            showAnim: 'slideDown'
        };

        if (IsNumber(min))
            opts.minDate = min + "d";
        if (IsNumber(max))
            opts.maxDate = max + "d";
        if (IsNumber(def))
            opts.DefaultDate = def + "d";

        $(a).datepicker(opts);

        return a;
    },



    Validate: function(div) {
        var res = true;
        $(".vldt", div).each(function() {
            $(this).data("VldtnTrgt").find(".error").empty();
        });
        $(".vldt", div).each(function() {
            var funcs = $(this).data("Vldtrs");
            for (var i in funcs)
                res = funcs[i]() && res;

        });
        return res;
    },

    __EnblVldtn: function(elmnt, container, html, params, func) {
        $(elmnt).addClass("vldt");
        if ($(elmnt).data("Vldtrs") == null)
            $(elmnt).data("Vldtrs", new Array());

        $(container).append('&nbsp;<span class="error"></span>');
        $(elmnt).data("VldtnTrgt", container);
        $(elmnt).data("Vldtrs").push(function() {
            return func(elmnt, container, html, params);
        });
    },

    ////////////////////////////////////////////
    VTxtBxNNull: function(elmnt, container, html) {
        if (html == null)
            html = "مقدار این فیلد الزامیست.";
        var val = $.trim($(elmnt).val());
        if (val == null || val == '') {
            $(".error:empty:first", container).html(html);
            return false;
        }
        else
            return true;
    },

    VTxtAreaNNull: function(elmnt, container, html) {
        return UI.VTxtBxNNull(elmnt, container, html);
    },

    VSlctNNull: function(elmnt, container, html) {
        return UI.VTxtBxNNull(elmnt, container, html);
    },

    VRadioNNull: function(elmnt, container, html) {
        if (html == null)
            html = "لطفا یک مورد را انتخاب فرمائید.";
        var name = $(elmnt).attr("name");
        var parent = $(elmnt).parent().parent();
        if ($(parent).size() == 0)
            parent = $("body");
        var val = $("input[type=radio][name=" + name + "]:checked", parent).val();
        if (val == undefined) {
            $(".error:empty:first", container).html(html);
            return false;
        }
        else
            return true;
    },


    VTxtBxMaxLen: function(elmnt, container, html, len) {
        if (html == null)
            html = "حداکثر طول این فیلد " + len + " می باشد.";
        var val = $.trim($(elmnt).val());
        if (val != null && val.length > len) {
            $(".error:empty:first", container).html(html);
            return false;
        }
        return true;
    },

    VTxtAreaMaxLen: function(elmnt, container, html, len) {
        return UI.VTxtBxMaxLen(elmnt, container, html, len);
    },
    VValLTE: function(left, container, html, right) {
        if (html == null)
            html = "خطا";
        var val1 = $(left).val();
        var val2 = $(right).val();

        if (NotEmpty(val1)) {
            if (NotEmpty(val2)) {
                if (Number(val1) < Number(val2)) {
                    return true;
                }
                else {
                    $(".error:empty:first", container).html(html);
                    return false;
                }
            }
            else {
                $(".error:empty:first", container).html(html);
                return false;
            }
        }
        else
            return true;
    },
    VValLTEE: function(left, container, html, right) {
        if (html == null)
            html = "خطا";
        var val1 = $(left).val();
        var val2 = $(right).val();

        if (NotEmpty(val1)) {
            if (NotEmpty(val2)) {
                val1 = Number(val1);
                val2 = Number(val2);
                if (val1 <= val2) {
                    return true;
                }
                else {
                    $(".error:empty:first", container).html(html);
                    return false;
                }
            }

            else {
                $(".error:empty:first", container).html(html);
                return false;
            }
        }
        else
            return true;
    },
    VValGTEA: function(elmnt, container, html, amnt) {
        if (html == null)
            html = "حداقل مقدار قابل قبول " + amnt + " می باشد.";

        var val = $(elmnt).val().replace(/,/g, '');
        if (NotEmpty(val)) {
            val = Number(val);
            amnt = Number(amnt);
            if (val >= amnt) {
                return true;
            }
            else {
                $(".error:empty:first", container).html(html);
                return false;
            }
        }
        else {
            $(".error:empty:first", container).html(html);
            return false;
        }
    },
    /////////////////////////////////////////////////////////
    BVTxtBxNNull: function(elmnt, container, html) {
        UI.__EnblVldtn(elmnt, container, html, null, this.VTxtBxNNull);
    },
    BVTxtAreaNNull: function(elmnt, container, html) {
        UI.__EnblVldtn(elmnt, container, html, null, this.VTxtAreaNNull);
    },
    BVSlctNNull: function(elmnt, container, html) {
        UI.__EnblVldtn(elmnt, container, html, null, this.VSlctNNull);
    },
    BVRadioNNull: function(elmnt, container, html) {
        UI.__EnblVldtn(elmnt, container, html, null, this.VRadioNNull);
    },
    BVTxtBxMaxLen: function(elmnt, container, html, len) {
        UI.__EnblVldtn(elmnt, container, html, len, this.VTxtBxMaxLen);
    },
    BVTxtAreaMaxLen: function(elmnt, container, html, len) {
        UI.__EnblVldtn(elmnt, container, html, len, this.VTxtAreaMaxLen);
    },
    BVValLTE: function(elmnt, container, html, rightElm) {
        UI.__EnblVldtn(elmnt, container, html, rightElm, this.VValLTE);
    },
    BVValLTEE: function(elmnt, container, html, rightElm) {
        UI.__EnblVldtn(elmnt, container, html, rightElm, this.VValLTEE);
    },
    BVValGTEA: function(elmnt, container, html, amnt) {
        UI.__EnblVldtn(elmnt, container, html, amnt, this.VValGTEA);
    }
};

//js的日期格式转换
Date.prototype.format = function (format) {
    var args = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds()
    };
    if (/(y+)/.test(format))
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var i in args) {
        var n = args[i];
        if (new RegExp("(" + i + ")").test(format))
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? n : ("00" + n).substr(("" + n).length));
    }
    return format;
}

//将C#通过Json传过来的DateTime格式化
function DateFormatter(value) {
    if (value == undefined) {
        return "";
    }
    //json格式的时间转换成js格式的时间
    var dateValue = eval('new ' + eval(value).source);
    return dateValue.format("yyyy/MM/dd");
}

//将C#通过Json传过来的DateTime格式化(含时分秒)
function DateTimeFormatter(value) {
    if (value == undefined) {
        return "";
    }
    //json格式的时间转换成js格式的时间
    var dateValue = eval('new ' + eval(value).source);
    return dateValue.format("yyyy/MM/dd hh:mm:ss");
}
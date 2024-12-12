$(document).ready(function () {
    // логин
    $("#btnLogin").click(function () {
        var nickName = $("#txtUserName").val();
        if (nickName) {
            // формируем ссылку с параметрами, по которой идет обращение
            // Метод encodeURIComponent заменяет все символы, кроме:
            // символов латинского алфавита, десятичных цифр и - _ . ! ~ * ' ( ).
            var href = "http://10.2.220.27/AjaxChat/Home/Index?user=" + encodeURIComponent(nickName);
            href = href + "&logOn=true";
            $("#LoginButton").attr("href", href).click();

            //установка поля с ником пользователя
            $("#Username").text(nickName);
        }
    });
});

//при успешном входе загружаем сообщения
function LoginOnSuccess(result) {

    Scroll();
    ShowLastRefresh();

    //каждые пять секунд обновляем чат
    setTimeout("Refresh();", 5000);

    //отправка сообщений по нажатию Enter
    $('#txtMessage').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnMessage").click();
        }
    });

    //установка обработчика нажатия кнопки для отправки сообщений
    $("#btnMessage").click(function () {
        var text = $("#txtMessage").val();
        if (text) {

            //обращаемся к методу Index и передаем параметр "chatMessage"
            var href = "http://10.2.220.27/AjaxChat/Home/Index?user=" + encodeURIComponent($("#Username").text());
            href = href + "&chatMessage=" + encodeURIComponent(text);
            $("#ActionLink").attr("href", href).click();
            $("#txtMessage").empty();
        }
    });

    //обработчик кнопки выхода из чата
    $("#btnLogOff").click(function () {

        //обращаемся к методу Index и передаем параметр "logOff"
        var href = "http://10.2.220.27/AjaxChat/Home/Index?user=" + encodeURIComponent($("#Username").text());
        href = href + "&logOff=true";
        $("#ActionLink").attr("href", href).click();

        document.location.href = "http://10.2.220.27/AjaxChat/Home/Index";
    });

}

//при ошибке отображаем сообщение об ошибке при логине
function LoginOnFailure(result) {
    $("#Username").val("");
    $("#Error").text(result.responseText);
    setTimeout("$('#Error').empty();", 2000);
}

// каждые пять секунд обновляем поле чата
function Refresh() {
    var href = "http://10.2.220.27/AjaxChat/Home/Index?user=" + encodeURIComponent($("#Username").text());

    $("#ActionLink").attr("href", href).click();
    setTimeout("Refresh();", 5000);
}

//Отображаем сообщение об ошибке
function ChatOnFailure(result) {
    $("#Error").text(result.responseText);
    setTimeout("$('#Error').empty();", 2000);
}

// при успешном получении ответа с сервера
function ChatOnSuccess(result) {
    Scroll();
    ShowLastRefresh();
}

//скролл вниз к самым последним сообщениям
function Scroll() {
    var win = $('#Messages');
    // Получим полную высоту контейнера DIV
    var height = win[0].scrollHeight;
    // устанавливаем отступ сверху
    win.scrollTop(height);
}

//отображение времени последнего обновления чата
function ShowLastRefresh() {
    var dt = new Date();
    var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
    $("#LastRefresh").text("Последнее обновление было в " + time);
}

$(function () {
    $("a[id^='LinkId_']").click(function () {
        $("#Id_" + $(this).attr("data-val-prodid")).submit();
    });
});
$("#btnGenerate").click(function () {
    var html = $("#divMainBody").html();
    html = html.replace(/</g, "start").replace(/>/g, "end");

    window.open("../../PDFGenerator/Generator?html=" + html, "_blank");
});
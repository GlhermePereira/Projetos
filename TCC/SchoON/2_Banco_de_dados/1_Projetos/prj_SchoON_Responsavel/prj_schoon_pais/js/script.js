function buscarNotificacao() {

    $.post("lib/buscarNotificacao.aspx", "", function (retorno) {
        if (parseInt(retorno) == null) {
            $("#lblQuantidade").html("");
        }
        else {
            $("#lblQuantidade").html("<div class='notificacao'>" + retorno + "</div>");
           
        }
    });
}


function buscarLinksNotificacao() {
    $.post("buscarLinksNotificacao.aspx", "", function (retorno) {
        if ( retorno != "") {
            $("#conteudoNotificacao").html(retorno);
        }
        else {
            $("#conteudoNotificacao").html("");
        }
    });
}

function AtivaNotificacao() {
    setInterval(buscarNotificacao, 5000);
}

$(document).ready(function () {

    buscarNotificacao();
    AtivaNotificacao();

    $(".iconeChat").hover(
        function () {
            if ($(".notificacao").length > 0) {
                buscarLinksNotificacao();
                $(".janelaNotificacao").show();
            }
        },
        function () {
            $("#conteudoNotificacao").html("");
            $(".janelaNotificacao").hide();
        }
    );


});
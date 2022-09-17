

$.post("lib/buscarNotificacao.aspx", "", function (retorno) {
    if (parseInt(retorno) > 0) {
        $("#lblQuantidade").html("Recados : " + retorno);
    }
    else {
        $("#lblQuantidade").html("Recados");
    }
});





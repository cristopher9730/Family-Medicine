function myFunction() {

    $.ajax({
        method: "POST",
        url: '/DashboardUsuario/Prueba',
    }).done(function (response) {
        console.log(response)
        if (response.result === "OK") {
            alert(response.data);
        }
        else {
            var mens = "Hubo un error" + response.Message;
            alert(mens);
        }
    }
    ).fail(function (error) {
        console.log(error)
        alert('Hubo un problema al crear la Oferta');
    });

    if ($('#correoForgotPassword').val().length == 0) {
        return false;
    } else {
        Swal.fire(
            'Recuperar contraseña',
            'Se envió un correo electrónico de restablecimiento de contraseña si la dirección de correo electrónico proporcionada estaba registrada.',
            'success'
        ).then(function () {
            window.location = "/ ";
        });
    }
}

this.ComprarPedido = function () {

    var pedido = {}
    pedido.IdentificadorOferta = $("#txtIdentificador").val();
    pedido.IdentificadorComprador = '202209';

    var urlAPI = "https://agrocorde.azurewebsites.net/api/Pedidos/ProcesarPedido";
}
function myFunction() {
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
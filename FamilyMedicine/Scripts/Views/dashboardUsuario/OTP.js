function OTP() {
    this.InitView = function () {
        $("#btnRegistrarse").click(function () {
            var vista = new OTP();
            vista.ValidarOTP();
        });
    }

    this.ValidarOTP = function () {
        var otp = {}
        usuario.Nombre = $("#txtNombre").val();
       

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://localhost:44391/api/Usuario/RegistrarUsuario",
            contentType: "application/json",
            data: JSON.stringify(usuario),
            hasContent: true
        }).done(function (info) {
            alert('Usuario Creado correctamente');
            window.location.href = "/IniciarSesion/OTP";
        }
        ).fail(function (info) {
            alert('hubo un problema al crear usuario');
        });
    }
}

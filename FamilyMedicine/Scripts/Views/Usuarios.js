function Usuarios() {
    var otp;
    this.InitView = function () {
        $("#btnRegistrarse").click(function () {
            var vista = new Usuarios();
           // vista.RegistrarUsuario();
            vista.enviarOTPCorreo();
        });
    }

    this.generarOTP = function () {
        var a = 6;
        var b = (Math.random()) * (10 ** a);
         otp = Math.floor(b);
    }

    this.enviarOTPCorreo = function () {
        var usuario = {}
        usuario.Nombre = $("#txtNombre").val();
        usuario.Correo = $("#txtCorreo").val();
        usuario.Telefono = $("#txtTelefono").val();
        usuario.Clave = $("#txtClave").val();
        usuario.Foto = "foto";
        usuario.Estado = "Pendiente";
        usuario.Codigo = otp;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://localhost:44391/api/Comunicacion/EnviarEmailBienvenida",
            contentType: "application/json",
            data: JSON.stringify(usuario),
            hasContent: true
        }).done(function (response) {
            if (response.Result === "OK") {
                alert(response.Message);
            }
            else {
                var mens = "Hubo un error " + response.Message;
                alert(mens);
            }
        }
        ).fail(function () {
            alert('Hubo un problema al enviar otp');
        });
        
    }

    this.RegistrarUsuario = function () {
        var usuario = {}
        usuario.Nombre = $("#txtNombre").val();
        usuario.Correo = $("#txtCorreo").val();
        usuario.Telefono = $("#txtTelefono").val();
        usuario.Clave = $("#txtClave").val();
        usuario.Foto = "Foto";
        usuario.Estado = "Pendiente";
        usuario.Codigo = otp

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
        }
        ).fail(function (info) {
            alert('hubo un problema al crear usuario');
        });
    }


}

$(document).ready(function () {
    $.noConflict();
    var view = new Usuarios();
    view.InitView();
});
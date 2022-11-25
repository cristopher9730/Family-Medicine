function Usuarios() {
    this.InitView = function () {
        $("#btnRegistrarse").click(function () {
            var vista = new Usuarios();
            vista.RegistrarUsuario();
        });
    }

    this.RegistrarUsuario = function () {
        var usuario = {}
        usuario.Nombre = $("#txtNombre").val();
        usuario.PrimerApellido = $("#txtPrimerApellido").val();
        usuario.SegundoApellido = $("#txtSegundoApellido").val();
        usuario.Correo = $("#txtCorreo").val();
        usuario.Telefono = $("#txtTelefono").val();
        usuario.Clave = $("#txtClave").val();
        usuario.Foto = "Foto";
        usuario.Estado = "Pendiente";
        usuario.RolId = 1;
        usuario.MembresiaId = 0;
        usuario.LaboratorioId = 0;

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

$(document).ready(function () {
    $.noConflict();
    var view = new Usuarios();
    view.InitView();
});
function Personal() {

    this.InitView = function () {
        $("#btnRegistrarPersonal").click(function () {
            var vista = new Personal();
            vista.registrarPersonal();
        });
    }

    this.cargarLaboratorio = function () {

    }

    this.registrarPersonal = function () {
        var usuario = {}
        usuario.Nombre = $("#txtNombre").val();
        usuario.PrimerApellido = $("#txtPrimerApellido").val();
        usuario.SegundoApellido = $("#txtSegundoApellido").val();
        usuario.Correo = $("#txtCorreo").val();
        usuario.Telefono = $("#txtTelefono").val();
        usuario.Clave = $("#txtClave").val();
        usuario.Foto = "Foto";
        usuario.Estado = "Pendiente";
        usuario.RolId = $("#slt_rol").val();
        usuario.MembresiaId = 0;
        usuario.LaboratorioId = 0;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://familymedicine-api.azurewebsites.net/api/Usuario/RegistrarUsuario",
            contentType: "application/json",
            data: JSON.stringify(usuario),
            hasContent: true
        }).done(function (info) {
            alert('Usuario registrado correctamente');
        }
        ).fail(function (info) {
            alert('hubo un problema al registrar usuario');
        });
    }
}

$(document).ready(function () {
    $.noConflict();
    var view = new Personal();
    view.InitView();
});
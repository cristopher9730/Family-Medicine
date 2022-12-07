function DashboardCliente() {

    this.InitView = function () {
        $("#btnActualizarCliente").click(function () {
            var vista = new DashboardCliente();
            vista.ActualizarUsuario();
        });
        this.CargarTabla();
    }

    this.ActualizarUsuario = function() {
        var usuario = {}
        usuario.UsuarioId = Session["UsuarioId"];
        usuario.Nombre = $("#txtNombre").val();
        usuario.PrimerApellido = $("#txtPrimerApellido").val();
        usuario.SegundoApellido = $("#txtSegundoApellido").val();
        usuario.Correo = $("#txtCorreo").val();
        usuario.Telefono = $("#txtTelefono").val();
        usuario.Clave = $("#txtClave").val();
        usuario.Foto = "Foto";
        usuario.MembresiaId = 0;
        usuario.LaboratorioId = 0;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "PUT",
            url: "https://localhost:44391/api/Usuario/ActualizarDatos",
            contentType: "application/json",
            data: JSON.stringify(usuario),
            hasContent: true
        }).done(function (info) {S
            alert('Datos actualizados correctamente');
        }
        ).fail(function (info) {
            alert('hubo un problema al actualizar datos');
        });
    }
}

$(document).ready(function () {
    var view = new DashboardCliente();
    view.InitView();
});
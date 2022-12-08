function ActualizarLaboratorio() {

    this.InitView = function () {
        $("#btnActualizarCliente").click(function () {
            var vista = new ActualizarLaboratorio();
            vista.ActualizarLaboratorio();
        });
        this.CargarTabla();
    }

    this.ActualizarLaboratorio = function() {
        var laboratorio = {}
        laboratorio.UsuarioPropietarioId = Session["UsuarioPropietarioId"];
        laboratorio.NombreLaboratorio = $("#txtNombreLaboratorio").val();
        laboratorio.CorreoLaboratorio = $("#txtCorreoLaboratorio").val();
        laboratorio.Telefono = $("#txtTelefono").val();
        laboratorio.CedulaJuridica = $("#txtCedulaJuridica").val();
        laboratorio.RazonSocial = $("#txtRazonSocial").val();
        laboratorio.PaginaWeb = $("#txtPaginaWeb").val();
        laboratorio.RedSocial = $("#txtRedSocial").val();

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "PUT",
            url: "https://localhost:44391/api/Usuario/ActualizarDatos",
            contentType: "application/json",
            data: JSON.stringify(laboratorio),
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
    var view = new ActualizarLaboratorio();
    view.InitView();
});
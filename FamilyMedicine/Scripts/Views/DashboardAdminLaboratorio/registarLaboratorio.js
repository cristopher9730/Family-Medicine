function Laboratorio() {

    this.InitView = function () {
        $("#btnRegistrar").click(function () {
            var vista = new Laboratorio();
            vista.RegistrarLaboratorio();
        });
    }

    this.RegistrarLaboratorio = function () {
        var laboratorio = {}
        laboratorio.UsuarioPropietarioId = 1;
        laboratorio.NombreLaboratorio = $("#txtNombre").val();
        laboratorio.SedeLaboratorio = "Heredia";
        laboratorio.Telefono = $("#txtTelefono").val();
        laboratorio.CorreoLaboratorio = $("#txtCorreo").val();
        laboratorio.Direccion = $("#txtDireccion").val();
        laboratorio.CedulaJuridica = $("#txtCedula").val();
        laboratorio.RazonSocial = $("#txtRazon").val();
        laboratorio.Estado = "Activo";
        laboratorio.PaginaWeb = $("#txtPaginaWeb").val();
        laboratorio.RedSocial = $("#txtRedSocial").val();
        
        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://localhost:44391/api/Laboratorio/RegistrarLaboratorio",
            contentType: "application/json",
            data: JSON.stringify(laboratorio),
            hasContent: true
        }).done(function (info) {
            alert('Laboratorio Creado correctamente');
        }
        ).fail(function (info) {
            alert('hubo un problema al crear el laboratorio');
        });
    }

    
}

$(document).ready(function () {
    $.noConflict();
    var view = new Laboratorio();
    view.InitView();
});
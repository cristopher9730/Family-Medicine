function Laboratorio() {

    this.InitView = function () {
        $("#btnRegistrar").click(function () {
            var vista = new Laboratorio();
            vista.RegistrarLaboratorio();
        });
        this.CargarTabla();
    }

    this.RegistrarLaboratorio = function () {
        var laboratorio = {}
        laboratorio.NombreLaboratorio = $("#txtNombre").val();
        laboratorio.Dirrecion = $("#txtDirreccion").val();
        laboratorio.Telefono = $("#txtTelefono").val();
        laboratorio.CorreoLaboratorio = $("#txtCorreo").val();
        laboratorio.CedulaJuridica = $("#txtCedula").val();
        laboratorio.RazonSocial = $("#txtRazon").val();
        laboratorio.RazonSocial = $("#txtPaginaWeb").val();
        laboratorio.RazonSocial = $("#txtRedSocial").val();
        
        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://localhost:44391/api/Laboratorio/RegistrarLaboratorio",
            contentType: "application/json",
            data: JSON.stringify(usuario),
            hasContent: true
        }).done(function (info) {
            alert('Laboratorio Creado correctamente');
        }
        ).fail(function (info) {
            alert('hubo un problema al crear el laboratorio');
        });
    }

    $(document).ready(function () {
        $.noConflict();
        var view = new Laboratorio();
        view.InitView();
    });
}
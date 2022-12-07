function Cita() {

    this.InitView = function () {
        $("#btnRegistrar").click(function () {
            var vista = new Cita();
            vista.RegistrarCitas();
        });
        this.CargarTabla();
    }

    this.RegistrarCitas = function () {
        var Cita = {}
        Cita.ExamenId = $("#examenesId").val();
        Cita.FechaExpiracion = $("#exampleSelect2").val();
        Cita.HoraCita = $("#hora").val();
        Cita.Cupon = $("#nputDefault").val();

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://familymedicine-api.azurewebsites.net/api/Cita/RegistrarCita",
            contentType: "application/json",
            data: JSON.stringify(Cita),
            hasContent: true
        }).done(function (info) {
            alert('Usuario Creado correctamente');
        }
        ).fail(function (info) {
            alert('hubo un problema al crear usuario');
        });
    }

    this.CargarTabla = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'Dia' };
        arrayColumnsData[1] = { 'data': 'HoraInicio' };
        arrayColumnsData[2] = { 'data': 'HoraFin' };
        arrayColumnsData[3] = { 'data': 'Cupos' };

        $('#datos').DataTable({
            ajax: {
                method: "GET",
                url: "https://familymedicine-api.azurewebsites.net/api/Laboratorio/ObtenerListaLaboratorios",
                contentType: "application/json;charset=utf-8",
                dataSrc: function (json) {
                    var json = { 'data': json }
                    return json.data;
                }
            },
            columns: arrayColumnsData
        });
        //table.buttons().container()
        //    .appendTo($('.col-sm-6:eq(0)', table.table().container()));
    }
}

$(document).ready(function () {
    $.noConflict();
    var view = new Cita();
    view.InitView();
});
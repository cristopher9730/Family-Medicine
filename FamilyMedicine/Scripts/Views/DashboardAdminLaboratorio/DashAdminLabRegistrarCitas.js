function horario() {

    this.InitView = function () {
        $("#btnRegistrarHorario").click(function () {
            var vista = new horario();
            vista.RegistrarHorario();
        });
        this.CargarTabla();
    }

    this.RegistrarHorario = function () {
        var horario = {}
        horario.Dia = $("#txtDia").val();
        horario.HoraInicio = $("#txtHoraInicio").val();
        horario.HoraFin = $("#txtHoraFinal").val();
        horario.Cupos = $("#txtCuposDisponibles").val();
        horario.ExamenId = $("#examenesId").val();

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://familymedicine-api.azurewebsites.net/api/Horario/RegistrarHorario",
            contentType: "application/json",
            data: JSON.stringify(horario),
            hasContent: true
        }).done(function (info) {
            alert('Horario Creado correctamente');
            var table = $('#datosHorarios').DataTable();
            table.ajax.reload();
        }
        ).fail(function (info) {
            alert('hubo un problema al crear el horario');
        });
    }

    this.CargarTabla = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'Dia' };
        arrayColumnsData[1] = { 'data': 'HoraInicio' };
        arrayColumnsData[2] = { 'data': 'HoraFin' };
        arrayColumnsData[3] = { 'data': 'Cupos' };
        arrayColumnsData[4] = { 'data': 'ExamenId' };

        var id = $("#session").val();

        $('#datosHorarios').DataTable({
            "language": {
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                },
                "lengthMenu": "Mostrar _MENU_ resultados por pagina",
                "zeroRecords": "Sin resultados",
                "info": "Pagina _PAGE_ de _PAGES_",
                "infoEmpty": "Tabla vacia",
                "infoFiltered": "(Filtrando de _MAX_ total de resultados)"
            ajax: {
                method: "GET",
                url: "https://localhost:44391/api/Horario/ObtenerListaHorariosPorId?id=" + id,
                contentType: "application/json;charset=utf-8",
                dataSrc: function (json) {
                    var json = { 'data': json }
                    return json.data;
                }
            },
            columns: arrayColumnsData
        });
    }
}

$(document).ready(function () {
    $.noConflict();
    var view = new horario();
    view.InitView();
});
function Examen() {
    this.InitView = function () {
        $("#btnRegistrar").click(function () {
            var vista = new Examen();
            vista.RegistrarExamen();
        });
        this.CargarTablaExamen();
    }

    this.CargarTablaExamen = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'Nombre' };
        arrayColumnsData[1] = { 'data': 'NombreInterno' };
        arrayColumnsData[2] = { 'data': 'Precio' };
        arrayColumnsData[3] = { 'data': 'Descripcion' };
        arrayColumnsData[4] = { 'data': 'Ventas' };
        arrayColumnsData[5] = { defaultContent: '<button class="btn btn-primary">Eliminar</button>' };
        var id = $("#session").val();

        $('#datos').DataTable({
            "language": {
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                },
                "lengthMenu": "Mostrar _MENU_ resultados por pagina",
                "zeroRecords": "Sin resultados",
                "info": "Pagina _PAGE_ de _PAGES_",
                "infoEmpty": "Tabla vacia",
                "search": "Buscar:",
                "infoFiltered": "(Filtrando de _MAX_ total de resultados)"

            },
            ajax: {
                method: "GET",
                url: "https://localhost:44391/api/Examen/ObtenerListaExamenesPorId?id=" + id,
                contentType: "application/json;charset=utf-8",
                dataSrc: function (json) {
                    var json = { 'data': json }
                    return json.data;
                }
            },
            columns: arrayColumnsData
        });

    }

    this.RegistrarExamen = function () {
        var examen = {}
        examen.Nombre = $("#txtNombre").val();
        examen.NombreInterno = $("#txtNombreInterno").val();
        examen.Precio = $("#txtPrecio").val();
        examen.LaboratorioId = $("#session").val();
        examen.Descripcion = $("#txtDescripcion").val();
        examen.Ventas = 0;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://localhost:44391/api/Examen/RegistrarExamen",
            contentType: "application/json",
            data: JSON.stringify(examen),
            hasContent: true
        }).done(function () {
            alert('Exámen Creado correctamente');
            var table = $('#datos').DataTable();
            table.ajax.reload();
        }
        ).fail(function (info) {
            alert('Hubo un problema al crear el exámen');
        });
    }


}

$(document).ready(function () {
    $.noConflict();
    var view = new Examen();
    view.InitView();
});
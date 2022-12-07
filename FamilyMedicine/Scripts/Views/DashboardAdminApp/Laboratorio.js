function Laboratorios() {

    this.InitView = function () {
        this.CargarTabla();
    }

    this.CargarTabla = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'NombreLaboratorio' };
        arrayColumnsData[1] = { 'data': 'CedulaJuridica' };
        arrayColumnsData[2] = { 'data': 'PaginaWeb' };
        arrayColumnsData[3] = { 'data': 'Telefono' };
        arrayColumnsData[4] = { 'data': 'CorreoLaboratorio' };
        arrayColumnsData[5] = { defaultContent: '<button class="btn btn-primary">Inactivar</button>' };

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
    var view = new Laboratorios();
    view.InitView();
});
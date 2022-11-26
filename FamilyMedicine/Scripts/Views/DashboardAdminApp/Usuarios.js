function Usuarios() {

    this.InitView = function () {
        this.CargarTabla();
    }

    this.CargarTabla = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'Nombre' };
        arrayColumnsData[1] = { 'data': 'PrimerApellido' };
        arrayColumnsData[2] = { 'data': 'SegundoApellido' };
        arrayColumnsData[3] = { 'data': 'Telefono' };
        arrayColumnsData[4] = { 'data': 'Correo' };
        arrayColumnsData[5] = { 'data': 'Estado' };

        $('#datos').DataTable({
            ajax: {
                method: "GET",
                url: "https://localhost:44391/api/Usuario/ObtenerListaUsuarios",
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
    var view = new Usuarios();
    view.InitView();
});
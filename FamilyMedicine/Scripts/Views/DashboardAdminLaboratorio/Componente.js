function Componente() {

    this.InitView = function () {
        
        this.listarComponentes();
    }

    this.listarComponentes = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'NombreComponente' };
        arrayColumnsData[1] = { 'data': 'SimboloMedida' };
        arrayColumnsData[2] = { 'data': 'MedidaReferencia' };
        arrayColumnsData[3] = { 'data': 'Estado' };

        var lab = $("#session").val();

        api = "https://localhost:44391/api/Componente/ObtenerListaComponentesPorId/?id=" + lab; //Recordar cambiar por el que hay en la nube
        $('#datosComponente').DataTable({
            ajax: {
                method: "GET",
                url: api,
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
    var view = new Componente();
    view.InitView();
});
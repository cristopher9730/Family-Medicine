function Cupones() {
    this.InitView = function () {
        $("#btnRegistrar").click(function () {
            var vista = new Cupones();
            vista.RegistrarCupon();
        });
        this.CargarTabla();
    }

    this.CargarTabla = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'PromocionDescripcion' };
        arrayColumnsData[1] = { 'data': 'Codigo' };
        arrayColumnsData[2] = { 'data': 'Descuento' };
        arrayColumnsData[3] = { 'data': 'Usos' };
        arrayColumnsData[4] = { 'data': 'FechaDeVencimiento' };
        arrayColumnsData[5] = { defaultContent: '<button class="btn btn-primary">Eliminar</button>' };


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
            ajax:{
                method: "GET",
                url: "https://familymedicine-api.azurewebsites.net/api/Promocion/ObtenerListaPromociones",
                contentType: "application/json;charset=utf-8",
                dataSrc: function (json) {
                    var json = { 'data': json }
                    return json.data;
                }
            },            
            columns: arrayColumnsData
        });
    }

    this.RegistrarCupon = function () {
        var user = $("#session").val();
        var cupon = {}
        cupon.PromocionDescripcion = $("#txtNombre").val();
        cupon.Descuento = $("#txtPorcentaje").val();
        cupon.LaboratorioId = 1;
        cupon.EstadoPromocion = "Activo";
        cupon.UsuarioId = user;
        cupon.FechaDeVencimiento = $("#txtFecha").val();
        cupon.Usos = 0;
        cupon.Codigo = Math.round(Math.random() * 999999);

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://familymedicine-api.azurewebsites.net/api/Promocion/RegistrarPromocion",
            contentType: "application/json",
            data: JSON.stringify(cupon),
            hasContent: true
        }).done(function (info) {
            alert('Cupón Creado correctamente');
            var table = $('#datos').DataTable();
            table.ajax.reload();
        }
        ).fail(function (info) {
            alert('Hubo un problema al crear el cupón');
        });
    }


}

$(document).ready(function () {
    $.noConflict();
    var view = new Cupones();
    view.InitView();
});



//$('#datos').DataTable({
//    "language": {
//        "lengthMenu": "Mostrar _MENU_ resultados por pagina",
//        "zeroRecords": "Nothing found - sorry",
//        "info": "Showing page _PAGE_ of _PAGES_",
//        "infoEmpty": "No records available",
//        "infoFiltered": "(filtered from _MAX_ total records)"
//    }
//})
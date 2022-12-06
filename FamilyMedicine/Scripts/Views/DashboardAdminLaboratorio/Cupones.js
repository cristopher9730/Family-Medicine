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


        $('#datos').DataTable({
            ajax: {
                method: "GET",
                url: "https://localhost:44391/api/Promocion/ObtenerListaPromociones",
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
        var cupon = {}
        cupon.PromocionDescripcion = $("#txtNombre").val();
        cupon.Descuento = $("#txtPorcentaje").val();
        cupon.LaboratorioId = 1;
        cupon.EstadoPromocion = "Activo";
        cupon.UsuarioId = 1;
        cupon.FechaDeVencimiento = $("#txtFecha").val();
        cupon.Usos = 0;
        cupon.Codigo = Math.round(Math.random() * 999999);

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://localhost:44391/api/Promocion/RegistrarPromocion",
            contentType: "application/json",
            data: JSON.stringify(cupon),
            hasContent: true
        }).done(function (info) {
            alert('Cupón Creado correctamente');
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
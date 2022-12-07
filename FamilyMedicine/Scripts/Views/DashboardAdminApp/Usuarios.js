function Usuarios() {

    this.InitView = function () {
        $("#btnRegistrar").click(function () {
            var vista = new Usuarios();
            vista.RegistrarUsuario();
        });
        this.CargarTabla();
    }

    this.CargarTabla = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'Nombre' };
        arrayColumnsData[1] = { 'data': 'PrimerApellido' };
        arrayColumnsData[2] = { 'data': 'SegundoApellido' };
        arrayColumnsData[3] = { 'data': 'Correo' };
        arrayColumnsData[4] = { 'data': 'Telefono' };
        arrayColumnsData[5] = { 'data': 'Estado' };


        $('#datosUsuarios').DataTable({
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
                url: "https://familymedicine-api.azurewebsites.net/api/Usuario/ObtenerListaUsuarios",
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

    this.RegistrarUsuario = function () {
        var usuario = {}
        usuario.Nombre = $("#txtNombre").val();
        usuario.PrimerApellido = $("#txtPrimerApellido").val();
        usuario.SegundoApellido = $("#txtSegundoApellido").val();
        usuario.Correo = $("#txtCorreo").val();
        usuario.Telefono = $("#txtTelefono").val();
        usuario.Clave = $("#txtClave").val();
        usuario.Foto = "Foto";
        usuario.Estado = "Pendiente";
        usuario.RolId = 1;
        usuario.MembresiaId = 0;
        usuario.LaboratorioId = 0;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://familymedicine-api.azurewebsites.net/api/Usuario/RegistrarUsuario",
            contentType: "application/json",
            data: JSON.stringify(usuario),
            hasContent: true
        }).done(function (info) {
            alert('Usuario Creado correctamente');
        }
        ).fail(function (info) {
            alert('hubo un problema al crear usuario');
        });
    }  
}
$(document).ready(function () {
    $.noConflict();
    var view = new Usuarios();
    view.InitView();
});
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
        arrayColumnsData[3] = { 'data': 'Telefono' };
        arrayColumnsData[4] = { 'data': 'Correo' };
        arrayColumnsData[5] = { 'data': 'Estado' };

        $('#datos').DataTable({
            ajax: {
                method: "GET",
                url: "https://localhost:44391/api/Usuario/ObtenerListaUsuarios",
                contentType: "application/json;charset=utf-8",
                dataSrc: function (json) {
                    var json = { 'data': json.Data }
                    return json.data;
                }
            },
            columns: arrayColumnsData
        });

        //Agregar datos del api a la tabla en html
        $('#datos tbody').on('click', 'tr', function () {
            var tr = $(this).closest('tr');
            var data = $('#datos').DataTable().row(tr).data();

            //se necesita para mostrar detalle de la tabla en formulario
            var controlAcciones = new ControlAcciones();
            controlAcciones.BindFields("frmUsuario", data);
        })
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
        usuario.RolId = $("#txtRol").val();
        usuario.MembresiaId = 0;
        usuario.LaboratorioId = 0;

        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: "https://localhost:44391/api/Usuario/RegistrarUsuario",
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

    $(document).ready(function () {
        $.noConflict();
        var view = new Usuarios();
        view.InitView();
    });
}
﻿function Personal() {

    this.InitView = function () {
        $("#btnRegistrarPersonal").click(function () {
            var vista = new Personal();
            vista.registrarPersonal();
        });
        this.listarPersonal();
    }

    this.cargarLaboratorio = function () {

    }

    this.registrarPersonal = function () {
        var lab = $("#session").val();
        var usuario = {}
        usuario.Nombre = $("#txtNombre").val();
        usuario.PrimerApellido = $("#txtPrimerApellido").val();
        usuario.SegundoApellido = $("#txtSegundoApellido").val();
        usuario.Correo = $("#txtCorreo").val();
        usuario.Telefono = $("#txtTelefono").val();
        usuario.Clave = $("#txtClave").val();
        usuario.Foto = "Foto";
        usuario.Estado = "Pendiente";
        usuario.RolId = $("#slt_rol").val();
        usuario.MembresiaId = 0;
        usuario.LaboratorioId = lab;
   
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
            alert('Usuario registrado correctamente');
            var table = $('#datosPersonal').DataTable();
            table.ajax.reload();
        }
        ).fail(function (info) {
            alert('hubo un problema al registrar usuario');
        });
    }

    this.listarPersonal = function () { 
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'Nombre' };
        arrayColumnsData[1] = { 'data': 'PrimerApellido' };
        arrayColumnsData[2] = { 'data': 'SegundoApellido' };
        arrayColumnsData[3] = { 'data': 'RolId' };
        arrayColumnsData[4] = { 'data': 'Correo' };
        arrayColumnsData[5] = { 'data': 'Estado' };
        arrayColumnsData[6] = { defaultContent: '<button class="btn btn-primary">Editar</button>' };


        var lab = $("#session").val();
        
        api = "https://familymedicine-api.azurewebsites.net/api/Usuario/ObtenerListaPersonal?id=" + lab;
        $('#datosPersonal').DataTable({
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
    var view = new Personal();
    view.InitView();
});
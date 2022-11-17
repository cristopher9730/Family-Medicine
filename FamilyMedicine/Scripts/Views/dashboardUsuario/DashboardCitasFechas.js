const str = " Fecha: 2022/11/27 a las 16:00\n" +
    " Costo pagado de cita: ₡12000\n";

/*
function myFunctionDateAgendada() {
    Swal.fire({
        title: 'Fecha de cita',
        html: '<pre>' + str + '</pre>',
        confirmButtonColor: "#325D88",
        confirmButtonText: 'Hecho',
        customClass: {
            popup: 'format-pre'
        }
    });
}*/


function myFunctionDateAgendada() {
    Swal.fire({
        title: 'Quieres Agendar fecha de cita"',
        showDenyButton: true,
        showCancelButton: true,
        cancelButtonText: "Cerrar",
        confirmButtonText: 'Ver cita',
        denyButtonText: `Cancelar cita`,
        confirmButtonColor: "#325D88",
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: 'Fecha de cita',
                html: '<pre>' + str + '</pre>',
                confirmButtonColor: "#325D88",
                confirmButtonText: 'Hecho',
                customClass: {
                    popup: 'format-pre'
                }
            });
        } else if (result.isDenied) {
            Swal.fire({
                icon: 'warning',
                title: 'Quieres cancelar cita?',
                showDenyButton: true,
                showCancelButton: true,
                cancelButtonText: "Cerrar ya no quiero",
                confirmButtonText: 'Si cancelar',
                confirmButtonColor: "#325D88",
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire({
                        icon: 'info',
                        title: 'Si se cancelo la cita',
                        confirmButtonText: 'Hecho',
                        confirmButtonColor: "#325D88",
                    });
                } else if (result.isDenied) {
                    Swal.fire({
                        icon: 'info',
                        title: 'No se cancelo la cita',
                        confirmButtonText: 'Hecho',
                        confirmButtonColor: "#325D88",
                    });
                }
            });
        }
    });
}




function myFunctionDate() {
    Swal.fire({
        title: "Agendar fecha de cita",
        html: '<input id="datetimepicker"  type="datetime-local" class="form-control" autofocus>',
        type: "warning",
        confirmButtonColor: "#325D88",
        confirmButtonText: 'Hecho',
        onOpen: function () {
            $('#datetimepicker').datetimepicker({
                format: 'DD/MM/YYYY hh:mm A',
                defaultDate: new Date()
            });
        }
    });
}

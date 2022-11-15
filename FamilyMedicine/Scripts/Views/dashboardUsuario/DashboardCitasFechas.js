const str = " Fecha: 2022/11/27 a las 16:00\n" +
    " Costo pagado de cita: ₡12000\n";

function myFunctionDate() {
    Swal.fire({
        title: 'Fecha de cita',
        html: '<pre>' + str + '</pre>',
        confirmButtonColor: "#325D88",
        confirmButtonText: 'Hecho',
        customClass: {
            popup: 'format-pre'
        }
    });
}
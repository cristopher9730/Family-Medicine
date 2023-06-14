/* POR SI SIRVE ALGUN DIA :(

function validarRequired() {
    let x = document.getElementById('ContenedorSelect').value;
    if (x == "") {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            text: 'Por favor seleccione el dia del examen',
            confirmButtonColor: "#325D88",
            confirmButtonText: 'Hecho',
        });
        return false; 
    } else {
        Swal.fire({
            icon: 'success',
            title: 'Agendado correctamente',
            text: 'Se envió un correo electrónico con el codigo QR que debe presentar a la hora de presentarse en la cita. Por favor presentarse dentro de la hora estipulada',
            confirmButtonColor: "#325D88",
            confirmButtonText: 'Aceptar',
        }
        ).then(function () {
            window.location = "/DashboardUsuario/DashBoardCitas ";
        });
    }
}

*/


function validarRequired() {
    Swal.fire({
        icon: 'success',
        title: 'Agendado correctamente',
        text: 'Se envió un correo electrónico con el codigo QR que debe presentar a la hora de presentarse en la cita. Por favor presentarse dentro de la hora estipulada',
        confirmButtonColor: "#325D88",
        confirmButtonText: 'Aceptar',
    }
    ).then(function () {
        window.location = "/DashboardUsuario/DashBoardCitas ";
    });
}
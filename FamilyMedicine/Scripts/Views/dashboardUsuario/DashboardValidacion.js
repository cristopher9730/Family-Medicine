function myfuncionGeneral() {
    Swal.fire({
        title: 'Quieres guardar los cambios',
        showDenyButton: true,
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonText: 'Guardar',
        denyButtonText: `No guardar`,
        confirmButtonColor: "#325D88",
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            Swal.fire({
                title: 'Guardado!',
                icon: 'success',
                confirmButtonColor: "#325D88",
                confirmButtonText: 'Hecho',
            });
        } else if (result.isDenied) {
            Swal.fire({
                title: 'Los cambios no se guardaron',
                icon: 'info',
                confirmButtonColor: "#325D88",
                confirmButtonText: 'Hecho',
            });  
        }
    })
}


function myfuncionGeneralCrear(ReporteCreado) {
    Swal.fire({
        title: ReporteCreado,
        showDenyButton: true,
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonText: 'Guardar',
        denyButtonText: `No guardar`,
        confirmButtonColor: "#325D88",
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            Swal.fire({
                title: 'Creado!',
                icon: 'success',
                confirmButtonColor: "#325D88",
                confirmButtonText: 'Hecho',
            });
        } else if (result.isDenied) {
            Swal.fire({
                title: 'No se creo',
                icon: 'info',
                confirmButtonColor: "#325D88",
                confirmButtonText: 'Hecho',
            });
        }
    })
}
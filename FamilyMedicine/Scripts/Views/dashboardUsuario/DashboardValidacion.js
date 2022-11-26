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


function myfuncionGeneralCrear() {
    Swal.fire({
        title: "Crear",
        showDenyButton: true,
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonText: 'Crear',
        denyButtonText: `No crear`,
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

function myfuncionGeneralRegistrar() {
    Swal.fire({
        title: "Registrar",
        showDenyButton: true,
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonText: 'Registrar',
        denyButtonText: `No registrar`,
        confirmButtonColor: "#325D88",
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            Swal.fire({
                title: 'Registrado!',
                icon: 'success',
                confirmButtonColor: "#325D88",
                confirmButtonText: 'Hecho',
            });
        } else if (result.isDenied) {
            Swal.fire({
                title: 'No se registrado',
                icon: 'info',
                confirmButtonColor: "#325D88",
                confirmButtonText: 'Hecho',
            });
        }
    })
}

function myfuncionGeneralCarrito() {
    Swal.fire({
        title: 'Agregado al carrito',
        icon: 'success',
        confirmButtonColor: "#325D88",
        confirmButtonText: 'Hecho',
    });
}

function myFunctionFile() {
    Swal.fire({
        title: 'Agregado al carrito',
        input: 'file',
        icon: 'success',
        confirmButtonColor: "#325D88",
        confirmButtonText: 'Hecho',
    });
}

function verPassword() {
    var x = document.getElementById("contrasenaUsuario");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}


/* CAMBIOS DE IMAGENES GENERALES PARA PERFIL, LOGOS E IMAGENES DE LABORATORIO*/

function showPreview(event) {
    if (event.target.files.length > 0) {
        var src = URL.createObjectURL(event.target.files[0]);
        var preview = document.getElementById("file-ip-1-preview");
        preview.src = src;
        preview.style.display = "block";
    }
}

/*----------------------------------DE LABORATORIO*/

function showPreviewLab1(event) {
    if (event.target.files.length > 0) {
        var src = URL.createObjectURL(event.target.files[0]);
        var preview = document.getElementById("labImg1");
        preview.src = src;
        preview.style.display = "block";
    }
}

function showPreviewLab2(event) {
    if (event.target.files.length > 0) {
        var src = URL.createObjectURL(event.target.files[0]);
        var preview = document.getElementById("labImg2");
        preview.src = src;
        preview.style.display = "block";
    }
}

function showPreviewLab3(event) {
    if (event.target.files.length > 0) {
        var src = URL.createObjectURL(event.target.files[0]);
        var preview = document.getElementById("labImg3");
        preview.src = src;
        preview.style.display = "block";
    }
}


function showPreviewLab4(event) {
    if (event.target.files.length > 0) {
        var src = URL.createObjectURL(event.target.files[0]);
        var preview = document.getElementById("labImg4");
        preview.src = src;
        preview.style.display = "block";
    }
}


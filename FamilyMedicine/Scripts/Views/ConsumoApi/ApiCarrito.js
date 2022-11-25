const d = document
/*
$table = d.querySelector(".crud-table"),
$form = d.querySelector(".crud-form"),
$title = d.querySelector(".crud-title"),
$template = d.getElementById("crud-template").content,
$fragment = d.createDocumentFragment(); */



const ajax = (options) => {
    let { url, method, success, error, data } = options;
    const xhr = new XMLHttpRequest();

    xhr.addEventListener("readystatechange", e => {
        if (xhr.readyState !== 4) return;

        if (xhr.status >= 200 && xhr.status < 300) {
            let json = JSON.parse(xhr.responseText);
            success(json);
        } else {
            let message = xhr.statusText || "Ocurrió un error";
            error(`Error ${xhr.status}: ${message}`);
        }
    });

    xhr.open(method || "GET", url);
    xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
    xhr.send(JSON.stringify(data));
}

const getAll = () => {
    ajax({
        url: "https://localhost:44391/api/Examen/devolverExamen",
        success: (res) => {
            console.log("FUCK NO SIRVE SHITTT")
/*
            for (let i = 0; i < 4; i++) {
                //CREAR DIV CONTENEDOR
                let containGeneral = document.querySelector(".contendorGeneral")
                let contenedor = document.createElement("div")
                contenedor.setAttribute("class", `newExam${i}`)
                containGeneral.append(contenedor)

                // ELEMENTOS DEL CONTENEDOR NUEVO EXAMEN 
                let tituloExamen = document.createElement("h1")
                let descripcionExamen = document.createElement("p")
                let clinicaExamen = document.createElement("p")
                let precioExamen = document.createElement("p")
                let btnEliminar = document.createElement("button")

                tituloExamen.setAttribute("class", `name${i}`)

                descripcionExamen.setAttribute("class", `description${i}`)
                clinicaExamen.setAttribute("class", `clinic${i}`)
                precioExamen.setAttribute("class", `price${i}`)
                btnEliminar.setAttribute("class", `delete`)
                btnEliminar.setAttribute("data-id", i + 1)

                document.querySelector(`.newExam${i}`).append(tituloExamen)
                document.querySelector(`.newExam${i}`).append(descripcionExamen)
                document.querySelector(`.newExam${i}`).append(clinicaExamen)
                document.querySelector(`.newExam${i}`).append(precioExamen)
                document.querySelector(`.newExam${i}`).append(btnEliminar)




                document.querySelector(`.name${i}`).textContent = res[i].nombre
                document.querySelector(`.description${i}`).textContent = res[i].descripcion
                document.querySelector(`.clinic${i}`).textContent = res[i].clinica
                document.querySelector(`.price${i}`).textContent = res[i].precio
                document.querySelectorAll(`.delete`)[i].textContent = "Eliminar"
            }
            */
        },
        error: (err) => {
            console.log(err);
            $table.insertAdjacentHTML("afterend", `<p><b>${err}</b></p>`);
        }
    })
}

d.addEventListener("DOMContentLoaded", getAll);

d.addEventListener("submit", e => {
    if (e.target === $form) {
        e.preventDefault();

        if (!e.target.id.value) {
            //Create - POST
            ajax({
                url: "http://localhost:3000/data",
                method: "POST",
                success: (res) => location.reload(),
                error: (err) => $form.insertAdjacentHTML("afterend", `<p><b>${err}</b></p>`),
                data: {
                    nombre: e.target.nombre.value,
                    constelacion: e.target.constelacion.value
                }
            });
        } else {
            //Update - PUT
            ajax({
                url: `http://localhost:3000/data/${e.target.id.value}`,
                method: "PUT",
                success: (res) => location.reload(),
                error: (err) => $form.insertAdjacentHTML("afterend", `<p><b>${err}</b></p>`),
                data: {
                    nombre: e.target.nombre.value,
                    constelacion: e.target.constelacion.value
                }
            });
        }
    }
});

d.addEventListener("click", e => {
    if (e.target.matches(".edit")) {
        $title.textContent = "Editar Santo";
        $form.nombre.value = e.target.dataset.name;
        $form.constelacion.value = e.target.dataset.constellation;
        $form.id.value = e.target.dataset.id;
    }

    if (e.target.matches(".delete")) {
        console.log(e.target.dataset)
        let isDelete = confirm(`¿Estás seguro de eliminar el id ${e.target.dataset.id}?`);
        let idDelete = e.target.dataset.id

        if (isDelete) {
            //Delete - DELETE
            ajax({
                url: `http://localhost:3000/data/${idDelete}`,
                method: "DELETE",
                success: (res) => location.reload(),
                error: (err) => alert(err)
            });
        }
    }
})
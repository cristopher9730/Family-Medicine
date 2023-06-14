document.getElementById("remove").onclick = function () {
    document.getElementById("idCarritoContenedorDeExamenes").remove();
}

function ventanaSecundaria(URL) {
    window.open(URL, "ventana1", "width=475,height=585,scrollbars=NO,resizable=NO,center")
}


'use strict'
let reset = (() => {
    document.querySelector(".V1").textContent = ("₡0")
    document.querySelector(".V2").textContent = ("₡0")
    document.querySelector(".V3").textContent = ("₡0")
    document.querySelector(".V4").textContent = ("0")
    document.querySelector(".V5").textContent = ("0")
})

document.querySelector(".eliminarExamen").addEventListener("click", (e) => reset())



'use strict'
let resetPrecio = (() => {
    document.querySelector(".total").textContent = ("₡17000")
})

document.querySelector(".cupon").addEventListener("input", (e) => resetPrecio())



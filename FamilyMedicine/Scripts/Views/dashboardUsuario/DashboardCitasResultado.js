function myFunctionResultado() {

    const swal_html =
        '<table class="table table-hover" style=" border-radius: 10px;"><thead><tr><th scope="col">Determinaciones</th><th scope="col">Valores naturales</th></tr ></thead><tbody><tr><th scope="row">Glucosa</th><td>70-110 mg/dl</td><tr><th scope="row">Urea</th><td>0.6-1.5 mg/dl</td><tr><th scope="row">Ácido úrico</th><td>2-7 mg/dl</td><tr><th scope="row">Creatinina</th><td>70-110 ml/min</td><tr><th scope="row">Triglicéridos</th><td>30-280 mg/dl</td><tr><th scope="row">Hierro</th><td>50-150 mg/dl</td></tbody></table>';

    Swal.fire({
        title: "Resultados de examen",
        confirmButtonColor: "#325D88",
        confirmButtonText: 'Hecho',
        html: swal_html,
    });
}
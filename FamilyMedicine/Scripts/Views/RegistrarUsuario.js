function GeneradorNumerosOTP() {
    this.InitView = function () {
        $("#btnEnviarOTP").click(function () {
            var vista = new GeneradorNumerosOTP();
            vista.EnviarOTP();
        });
    }

    this.EnviarOTP = function () {
        var a = 6;
        var b = (Math.random()) * (10 ** a);
        var otp = Math.floor(b);

        //Sustituir por el metodo de enviar por correo y SMS
        alert('El numero es: ' + otp);

    }
}

$(document).ready(function () {
    $.noConflict();
    var view = new GeneradorNumerosOTP();
    view.InitView();
});
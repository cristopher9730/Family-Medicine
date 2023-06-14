function verPassword() {
    var x = document.getElementById("txtClave");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
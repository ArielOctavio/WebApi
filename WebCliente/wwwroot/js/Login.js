function Login() {
    var email = $("#InputEmail").val();
    var password = $("#InputPassword").val();


    ///VAlidaciones si email es null o password
    var user = {
        email: email,
        password: password
    }


    var settings = {
        "url": "https://localhost:44338/Account/login",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify(user),
    };

    $.ajax(settings).done(function (response) {
        console.log(response);
        window.location = '/Home/Bienvenida/?Nombre=' + response.value.nombre + ', ' + response.value.apellido;


    }).fail(function (error) {
        console.log(error);
        //alert("Datos incorrectos")
        //java script
        // var elemtError = document.getElementById("ErrorLabel");

        //jquery
        var elemtErrorJQ = $("#ErrorLabel");
        elemtErrorJQ.html("Datos incorrectos");
    });

}
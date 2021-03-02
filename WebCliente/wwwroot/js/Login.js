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
    }).fail(function (error) {
        console.log(response);
    });

}
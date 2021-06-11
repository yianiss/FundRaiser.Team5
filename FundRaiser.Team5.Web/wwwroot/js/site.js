// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.querySelector('#login_bg').addEventListener("click", function () {
    document.querySelector('#login_session').classList.add("d-none");

    document.querySelector('#Email').nodeValue = "";
    document.querySelector('#Password').nodeValue = "";

    console.log("Hide");


});

let login = document.querySelector('#nav-login');
if (login != null) {
    login.addEventListener("click", function () {
        document.querySelector('#login_session').classList.remove("d-none");

        document.querySelector('#Email').nodeValue = "";
        document.querySelector('#Password').nodeValue = "";
        console.log("show");
    });
}

document.querySelector('#loginbtn').addEventListener("click", function () {

    let form = document.querySelector('#loginform');
    $.ajax(
        {
            url: "/login",
            dataType: 'POST',
            data: form.serialize(),
            success: function (data) {
                alert("FormOK"); // show response from the php script.
            }
        }

    );
});

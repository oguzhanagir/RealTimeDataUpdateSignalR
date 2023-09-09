









 const connection = new signalR.HubConnectionBuilder()
    .withUrl("/userHub") 
    .build();

    connection.start().then(function () {
    console.log("Bağlantı başarıyla kuruldu.");
    }).catch(function (err) {
    console.error(err.toString());
    });
 

    $("#loginButton").click(function () {
        mail = $("#mail").val(); // Kullanıcının mail adresini alındığı kısım
        // Sunucuya giriş isteği
        connection.invoke("UserLoggedIn", mail).catch(function (err) {
            console.error(err.toString());
        });
    });



    

    connection.on("UserLoggedIn", function (username) {
    // Kullanıcı giriş bildirimi
        console.log(username + " kullanıcısı giriş yaptı.");
        showNotification(username + " kullanıcısı giriş yaptı.","success");


   
    });




function showNotification(message, type) {
    Swal.fire({
        title: message,
        position: 'top-end', 
        toast: true, 
        icon: type, 
        timer: 7000, 
        showConfirmButton: false, 
        width: '300px' 
    });
}


// Kullanıcı çıkışı işlemi
$("#logout").click(function () {
 
    userName = $("#username").text();
    connection.invoke("UserLoggedOut", userName).catch(function (err) {
        console.error(err.toString());
    });
    });

connection.on("UserLoggedOut", function (username) {
    // Kullanıcı çıkış bildirimi
    console.log(username + " kullanıcısı çıkış yaptı.");


    showNotification(username + " kullanıcısı çıkış yaptı.", "warning");
    
    window.location.href = "/Auth/LogOut";
});


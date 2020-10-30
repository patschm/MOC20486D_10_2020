$(document).ready(async () => {
    var conn = new signalR.HubConnectionBuilder().withUrl("/blater").build(); 
    var $nick = $("#txtNick");
    var $msg = $("#txtMsg");
    var $box = $("#msgBox");

    await conn.start();

    $("#btnRegister").click(() => {
        conn.invoke("IkDoeMee", $nick.val());
    });

    $("#btnSend").click(() => {
        conn.invoke("Blaat", $nick.val(), $msg.val());
    });

    conn.on("Joehoe", msg => {
        $("<h2>").text(msg).appendTo($box);
    });

   
});
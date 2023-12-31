﻿// view Hub
//WebSocket = undefined; // is like making browser see that websocket not supported

let viewConnection = new signalR.HubConnectionBuilder()
    /*.configureLogging(signalR.LogLevel.None)*/
    .configureLogging(signalR.LogLevel.Trace)
    .withUrl("/hubs/view")//, { transport: signalR.HttpTransportType.LongPolling }
    //transport: signalR.HttpTransportType.WebSockets | signalR.HttpTransportType.ServerSentEvents
    .withAutomaticReconnect()
    .build();

//on view update message from client
viewConnection.on("viewCountUpdate", function (value) {
    var counter = document.getElementById("viewCounter");
    counter.innerText = value.toString();
    if (value % 10 == 0) {
        viewConnection.off("viewCountUpdate");
    }
})
document.getElementById("incrementCount").addEventListener('click', function () {
    viewConnection.invoke("notifyWatching")
})
//notify server we are watching
function notify() {
    viewConnection.send("notifyWatching");
}

//startConnection
function startSuccess() {
    console.log("Connected.");
    //notify();
}
function startFail() {
    console.log("Connection Failed.");
}
viewConnection.start().then(startSuccess, startFail);

let body = document.getElementsByTagName("body")[0];

viewConnection.onreconnected((connectionId) => {
    body.style.backgroundColor = "green";

    setTimeout(() => {
        body.style.backgroundColor = "white";
    }, 500000);
});

viewConnection.onreconnecting((error) => {
    body.style.backgroundColor = "yellow";
});

viewConnection.onclose((error) => {
    body.style.backgroundColor = "red";
});
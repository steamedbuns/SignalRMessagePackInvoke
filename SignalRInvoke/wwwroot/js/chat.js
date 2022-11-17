"use strict";

var connection =
   new signalR.HubConnectionBuilder()
      .withUrl("/ChatHub")
      .withHubProtocol(new signalR.protocols.msgpack.MessagePackHubProtocol())
      .build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessageInvoke",
   async function(user, message) {
      console.log("Client.ReceiveMessageInvoke: method entry.");
      await new Promise(res => setTimeout(res, 5000));
      var li = document.createElement("li");
      document.getElementById("messagesList").appendChild(li);
      li.textContent = `${user} says ${message}`;
      console.log("Client.ReceiveMessageInvoke: method exit.");
      return message === 'true';
   });

connection.start().then(function () {
   document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
   return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", async function (event) {
   console.log("Client.sendButton: method entry.");
   var user = document.getElementById("userInput").value;
   var message = document.getElementById("messageInput").value;
   await connection.invoke("InvokeMessage", user, message).catch(function (err) {
      return console.error(err.toString());
   });
   console.log("Client.sendButton: method exit.");
   event.preventDefault();
});
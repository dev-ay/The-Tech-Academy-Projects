// here we are requireing the modules used
var express = require("express");
var bodyParser = require("body-parser");
var app = express();
var http = require("http").Server(app);
var io = require("socket.io")(http);
var mongoose = require("mongoose");

app.use(express.static(__dirname));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: false}));

var dbUrl = "mongodb://user:password@ds247678.mlab.com:47678/node-messenger"

// message model for database
var Message = mongoose.model("Message", {
    name: String,
    message: String
})


// here's another callback!
app.get("/messages", (request, response) =>{
    Message.find({}, (err, messages) => {
        response.send(messages)
    })
});

// here's another callback!
app.post("/messages", (request, response) =>{
    var message = new Message(request.body)

    message.save((err) => {
        if(err) {
            sendStatus(500)
        }
        else {
            io.emit("message", request.body)
            response.sendStatus(200)
        }
    })
});

io.on("connection", (socket) => {
    console.log("User connected")
});

mongoose.connect(dbUrl, (err) => {
    console.log("Mongo DB Connection -", err)
})

var server = http.listen(3000, () => {
    console.log("server is listening on port ", server.address().port)
});
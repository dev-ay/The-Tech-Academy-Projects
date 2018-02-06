console.log("The custom script is running");

// Start: Hilight active list item
var btnContainer = document.getElementById("steps");
var btns =  btnContainer.getElementsByClassName("list-group-item");

// this will through the buttons and add the active class to the clicked list item
for (var i = 0; i < btns.length;  i++) {
    btns[i].addEventListener("click", function() {
        var current = document.getElementsByClassName("list-group-item active");
        current[0].className = current[0].className.replace("list-group-item active", "list-group-item");
        this.className += " active";
    });
};

// Start: update progress bar
function progress_bar() {
    if (btns[0].className == "list-group-item active") {
        document.getElementById("bar").style.width = "12%";
        document.getElementById("bar").innerHTML = "12%";
    } else if (btns[1].className == "list-group-item active") {
        document.getElementById("bar").style.width = "25%";
        document.getElementById("bar").innerHTML = "25%";
    } else if (btns[2].className == "list-group-item active") {
        document.getElementById("bar").style.width = "37%";
        document.getElementById("bar").innerHTML = "37%";
    } else if (btns[3].className == "list-group-item active") {
        document.getElementById("bar").style.width = "50%";
        document.getElementById("bar").innerHTML = "50%";
    } else if (btns[4].className == "list-group-item active") {
        document.getElementById("bar").style.width = "62%";
        document.getElementById("bar").innerHTML = "62%";
    } else if (btns[5].className == "list-group-item active") {
        document.getElementById("bar").style.width = "75%";
        document.getElementById("bar").innerHTML = "75%";
    } else if (btns[6].className == "list-group-item active") {
        document.getElementById("bar").style.width = "87%";
        document.getElementById("bar").innerHTML = "87%";
    } else if (btns[7].className == "list-group-item active") {
        document.getElementById("bar").style.width = "100%";
        document.getElementById("bar").innerHTML = "100%";
    };
};

btnContainer.addEventListener("click", progress_bar);

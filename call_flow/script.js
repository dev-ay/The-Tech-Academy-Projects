console.log("The custom script is running")

// Start: Hilight active list item
var btnContainer = document.getElementById("steps");
var btns =  btnContainer.getElementsByClassName("list-group-item");

// this will through the buttons and add the active class to the clicked list item
for (var i = 0; i < btns.length;  i++) {
    btns[i].addEventListener("click", function() {
        var current = document.getElementsByClassName("active");
        current[0].className = current[0].className.replace(" active", "");
        this.className += " active";
    });
};
// End: Hilight Active List Item

// Start: update progress bar
function progress_bar() {
    if (btns[0].className == "list-group-item active") {
        // console.log("The first button is sellected")
        document.getElementById("bar").style.width = "14%";
        document.getElementById("bar").innerHTML = "14%";
    } else if (btns[1].className == "list-group-item active") {
        // console.log("The Second button is sellected")
        document.getElementById("bar").style.width = "28%";
        document.getElementById("bar").innerHTML = "28%";
    } else if (btns[2].className == "list-group-item active") {
        // console.log("The third button is sellected")
        document.getElementById("bar").style.width = "42%";
        document.getElementById("bar").innerHTML = "42%";
    } else if (btns[3].className == "list-group-item active") {
        // console.log("The fourth button is sellected")
        document.getElementById("bar").style.width = "56%";
        document.getElementById("bar").innerHTML = "56%";
    } else if (btns[4].className == "list-group-item active") {
        // console.log("The fifth button is sellected")
        document.getElementById("bar").style.width = "70%";
        document.getElementById("bar").innerHTML = "70%";
    } else if (btns[5].className == "list-group-item active") {
        // console.log("The sizth button is sellected")
        document.getElementById("bar").style.width = "84%";
        document.getElementById("bar").innerHTML = "84%";
    } else if (btns[6].className == "list-group-item active") {
        // console.log("The seventh button is sellected")
        document.getElementById("bar").style.width = "100%";
        document.getElementById("bar").innerHTML = "100%";
    }
};

btnContainer.addEventListener("click", progress_bar)

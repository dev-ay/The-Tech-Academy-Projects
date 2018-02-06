console.log("The second custom script is running");

// Update progress bar

var all_checks = document.getElementById("checks");
var count = 0;

function progress_bar(count) {
    if (count == 0) {
        document.getElementById("bar").style.width = "0%";
        document.getElementById("bar").innerHTML = "&nbsp;";
    } else if (count == 1) {
        document.getElementById("bar").style.width = "12%";
        document.getElementById("bar").innerHTML = "12%";
    } else if (count == 2) {
        document.getElementById("bar").style.width = "25%";
        document.getElementById("bar").innerHTML = "25%";
    } else if (count == 3) {
        document.getElementById("bar").style.width = "37%";
        document.getElementById("bar").innerHTML = "37%";
    } else if (count == 4) {
        document.getElementById("bar").style.width = "50%";
        document.getElementById("bar").innerHTML = "50%";
    } else if (count == 5) {
        document.getElementById("bar").style.width = "62%";
        document.getElementById("bar").innerHTML = "62%";
    } else if (count == 6) {
        document.getElementById("bar").style.width = "75%";
        document.getElementById("bar").innerHTML = "75%";
    } else if (count == 7) {
        document.getElementById("bar").style.width = "87%";
        document.getElementById("bar").innerHTML = "87%";
    } else if (count == 8) {
        document.getElementById("bar").style.width = "100%";
        document.getElementById("bar").innerHTML = "100%";
    };
};


all_checks.addEventListener("click", function() {
    count = document.querySelectorAll('input[type="checkbox"]:checked').length;
    progress_bar(count);
});


// Clears all check boxes when the "clear" button is clicked
function clearForm() { 
    document.getElementById("box1").checked=false;  
    document.getElementById("box2").checked=false; 
    document.getElementById("box3").checked=false; 
    document.getElementById("box4").checked=false;
    document.getElementById("box5").checked=false;
    document.getElementById("box6").checked=false;
    document.getElementById("box7").checked=false;
    document.getElementById("box8").checked=false;
    count = 0;
    progress_bar(count);
}; 
    
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



const btn = document.getElementById("scrollBtn");
function myScrollBtn() {

    const pageHeight = document.body.offsetHeight;
    const distanceToBottom = pageHeight - (window.scrollY + window.innerHeight)

    if (window.scrollY > 900 || distanceToBottom < 80) {
        btn.classList.remove("d-none");
    }
    else {
        btn.classList.add("d-none");
    }


}



window.addEventListener("scroll", myScrollBtn);


function updateStatus() {
    const statusBox = document.getElementById("statusCheckBox");
    const text = document.getElementById("statusText");

    text.innerText = statusBox.checked ? "Active" : "Inactive";
}
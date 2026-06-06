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


document.addEventListener("DOMContentLoaded", function () {
    var modalElement = document.getElementById('messageModal');

    if(modalElement){
        var modal = new bootstrap.Modal(modalElement);

        modal.show();
    }
});



document.addEventListener("DOMContentLoaded", function () {
    var modalElement = document.getElementById('responseModal');

    if (modalElement) {
        var modal = new bootstrap.Modal(modalElement);

        modal.show();

    }
});


async function validateCode() {

    const code = document.getElementById("promotionCode").value;
    const priceElement = document.getElementById("totalPrice");
    const orginalPrice = parseFloat(priceElement.dataset.orginalPrice);

    if (code === "") {
        document.getElementById("promotionMessage").innerText = "Ange en rabattkod"
        return;
    }

    const response = await fetch("https://localhost:44303/api/promotion/validate-code/" + code);

    const result = await response.json();

    document.getElementById("promotionMessage").innerText = result.message;

    if (result.isValid) {
        document.getElementById("promotionId").value = result.promotionId;

        const discountPrice = orginalPrice * result.discountPercent / 100;
        const newPrice = orginalPrice - (orginalPrice * result.discountPercent / 100);

        document.getElementById("discountAmount").innerText = "-" + discountPrice;
        priceElement.innerText = newPrice;
    }
}
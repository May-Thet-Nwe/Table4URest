// _wwwroot/custom.js
window.showMessage = function (message) {
    alert(message);
};

window.showExceedMessage = function () {
    var messageDiv = document.getElementById("reservationExceedMessage");
    if (messageDiv != null) {
        messageDiv.style.display = "block";
    }
};
window.hideExceedMessage = function () {
    var messageDiv = document.getElementById("reservationExceedMessage");
    if (messageDiv != null) {
        messageDiv.style.display = "none";
    }
};

$(document).ready(function () {
    toggleMerken();
    toggleStijlen();
    slider();
})

function toggleMerken() {
    $(".merken").toggle();
}

function toggleStijlen() {
    $(".stijlen").toggle();
}


function slider() {
    $("#ex2").slider({});
};
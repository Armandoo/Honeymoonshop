
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


document.filterprijsform.minprijs.oninput = function () {
    document.filterprijsform.priceOutputMinPrijs.value = document.filterprijsform.minprijs.value;
}

document.filterprijsform.maxprijs.oninput = function () {
    document.filterprijsform.priceOutputMaxPrijs.value = document.filterprijsform.maxprijs.value;
}
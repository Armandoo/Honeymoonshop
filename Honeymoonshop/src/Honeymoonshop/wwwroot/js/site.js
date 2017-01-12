
$(document).ready(function () {
    toggleMerken();
    toggleStijlen();
    slider();
    $("#datepicker").datepicker({
        minDate: +0,
        language: "nl",
        prevText: '<span class="glyphicon glyphicon-menu-left"></span>',
        nextText: '<span class="glyphicon glyphicon-menu-right"></span>',
        onSelect: function () {
            $("#dueDate").val($("#datepicker").datepicker({dateFormat : 'dd/mm/yyyy'}).val());
        }
    });
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
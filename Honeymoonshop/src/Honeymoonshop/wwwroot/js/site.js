
$(document).ready(function () {
    toggleMerken();
    toggleStijlen();
    toggleKleuren();
    toggleNeklijnen();
    toggleSilhouettes();
    //toggleImage();
    slider();

    

    $("#slider").slider().on('slideStop', function (ev) {


        var minPrijs = $("#slider").data("slider").getValue()[0];
        var maxPrijs = $("#slider").data("slider").getValue()[1];

        $(".minprijs").text(minPrijs);
        $(".maxprijs").text(maxPrijs);

        $('input:hidden[name=minPrijs]').val( minPrijs);
        $('input:hidden[name=maxPrijs]').val( maxPrijs);
    });;

    $('select[name=sorteer] option:selected').each(function () {
        
        console.log("a");
    });

})

/*function toggleImage() {
    $(".rbfilter").click(function () {

        
       
        $(".rb.outer", this).toggle();
        $(this).children("input").prop("checked", !$(this).children("input").is(':checked'));
 
        
        $(".rb.inner", this).toggle();
    
    });
};*/
        /*
        if ($(".rb.inner").show()) {
            $('.merk').prop('checked', true);
        }

        else {
            $(".rb.inner", this).toggle();
            $('.merk').prop('unchecked', false);
        }
*/        
 

function toggleMerken() {
    $(".merken").toggle();
}

function toggleKleuren() {
    $(".kleuren").toggle();
}

function toggleStijlen() {
    $(".stijlen").toggle();
}

function toggleNeklijnen() {
    $(".neklijnen").toggle();
}

function toggleSilhouettes() {
    $(".silhouettes").toggle();
}

function slider() {
    $("#slider").slider({});
};


/*document.filterprijsform.minprijs.oninput = function () {
    document.filterprijsform.priceOutputMinPrijs.value = document.filterprijsform.minprijs.value;
}

document.filterprijsform.maxprijs.oninput = function () {
    document.filterprijsform.priceOutputMaxPrijs.value = document.filterprijsform.maxprijs.value;
}*/
